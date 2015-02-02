using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using com.strava.api.Authentication;
using HealthGraphNet;
using HealthGraphNet.Models;
using PolarConverter.BLL.Entiteter;
using PolarConverter.BLL.Interfaces;
using PolarConverter.JSWeb.Models;
using DataFormat = com.strava.api.Upload.DataFormat;
using PolarConverter.BLL.Services;
using PolarConverter.DAL.Models;

namespace PolarConverter.JSWeb.Controllers.Api
{
    public class ServiceController : ApiController
    {
        private readonly IStorageHelper _storageHelper;
        private AccessTokenManager _tokenManager;
        private DropboxService _dropboxService;

        private const string StravaUrl = "https://www.strava.com";
        private const string RunkeeperUrl = "https://api.runkeeper.com";
        private const string RunkeeperAuthUrl = "https://runkeeper.com";
        private const string RunkeeperClientId = "aa628d46ca704d69964f19c993a25207";


        public ServiceController()
        {
            _storageHelper = DependencyResolver.Current.GetService<IStorageHelper>();
            _dropboxService = new DropboxService();
        }

        public ServiceController(IStorageHelper storageHelper)
        {
            _storageHelper = storageHelper;
            _dropboxService = new DropboxService();
        }

        [System.Web.Http.Route("api/service/getFilesFromDropbox")]
        public IEnumerable<DropboxResult> GetFilesFromDropbox(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                var dropboxToken = db.OauthTokens.FirstOrDefault(oa => oa.UserId == id && oa.ProviderType == ProviderType.Dropbox);
                var userLogin = new DropNet.Models.UserLogin();
                userLogin.Token = dropboxToken.Token;
                userLogin.Secret = dropboxToken.Secret;
                _dropboxService.Init(userLogin);
                return _dropboxService.GetFilesForUser();
            }
        }

        [System.Web.Http.Route("api/service/export")]
        public async Task<IHttpActionResult> Export(ExportFileData exportFileData)
        {
            if (string.IsNullOrEmpty(exportFileData.Reference))
                return NotFound();
            using (var db = new ApplicationDbContext())
            {
                var provider = (ProviderType)Enum.Parse(typeof(ProviderType), exportFileData.Provider);
                var userToken =
                    await
                        db.OauthTokens.FirstOrDefaultAsync(
                            oa => oa.UserId == exportFileData.UserId && oa.ProviderType == provider);
                if (userToken != null)
                {
                    var token = userToken.Token;
                    switch (provider)
                    {
                        case ProviderType.Strava:
                            ExportToStrava(token, exportFileData);
                            break;
                        case ProviderType.Runkeeper:
                            ExportToRunkeeper(token, exportFileData);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    return Ok();
                }
                return NotFound();
            }
        }

        public void ExportToRunkeeper(string token, ExportFileData exportFileData)
        {
            var activities = ConvertFileToRunkeeperActivity(exportFileData);
            var clientSecret = ConfigurationManager.AppSettings["RunkeeperClientSecret"];
            _tokenManager = new AccessTokenManager(RunkeeperClientId, clientSecret, RunkeeperAuthUrl)
            {
                Token = new AccessTokenModel { AccessToken = token, TokenType = "Bearer" }
            };
            var userRequest = new UsersEndpoint(_tokenManager);
            var user = userRequest.GetUser();
            var activitiesRequest = new FitnessActivitiesEndpoint(_tokenManager, user);
            foreach (var activity in activities)
            {
                var uri = activitiesRequest.CreateActivity(activity);
            }
        }

        private IEnumerable<FitnessActivitiesNewModel> ConvertFileToRunkeeperActivity(ExportFileData exportFileData)
        {
            TrainingCenterDatabase_t trainingCenterDatabase;
            if (exportFileData.FromDropbox)
            {
                trainingCenterDatabase = (TrainingCenterDatabase_t)_dropboxService.ReadXmlDocument(exportFileData.Reference, typeof(TrainingCenterDatabase_t));
            }
            else
            {
                trainingCenterDatabase = (TrainingCenterDatabase_t)_storageHelper.ReadXmlDocument(exportFileData.Reference, typeof(TrainingCenterDatabase_t));
            }
            var runkeeperList = new List<FitnessActivitiesNewModel>();
            foreach (var activity in trainingCenterDatabase.Activities.Activity)
            {
                var type = GetActivityType(activity.Sport);
                if(activity.Lap == null || !activity.Lap.Any())
                    continue;
                var startTime = activity.Lap.First().StartTime;
                var runkeeperActivity = new FitnessActivitiesNewModel
                {
                    AverageHeartRate = 
                        Convert.ToInt32(Math.Round(activity.Lap.Average(l => l.AverageHeartRateBpm.Value))),
                    Duration = activity.Lap.Sum(l => l.TotalTimeSeconds),
                    HeartRate = activity.Lap.SelectMany(l => l.Track.Select(t => new HeartRateModel
                    {
                        HeartRate = t.HeartRateBpm.Value,
                        Timestamp = (startTime - t.Time).TotalSeconds
                    })).ToList(),
                    Notes = activity.Notes,
                    Type = type,
                    StartTime = startTime,
                    TotalCalories= activity.Lap.Sum(l => l.Calories),
                    TotalDistance= activity.Lap.Sum(l => l.DistanceMeters)
                };

                if (activity.Lap.Any(l => l.Track != null && l.Track.Any(t => t.Position != null)))
                {
                    runkeeperActivity.Path = activity.Lap.SelectMany(l => l.Track.Select(t => new PathModel
                    {
                        Altitude = t.AltitudeMeters,
                        Latitude = t.Position.LatitudeDegrees,
                        Longitude = t.Position.LongitudeDegrees,
                        Type = "gps",
                        Timestamp = (startTime - t.Time).TotalSeconds
                    })).ToList();
                }
                runkeeperList.Add(runkeeperActivity);
            }
            return runkeeperList;
        }

        private string GetActivityType(Sport_t sport)
        {
            switch (sport)
            {
                case Sport_t.Running:
                    return "Running";
                case Sport_t.Biking:
                    return "Cycling";
                case Sport_t.Other:
                    return "Other";
                default:
                    return "Other";
            }
        }

        public async void ExportToStrava(string token, ExportFileData exportFileData)
        {
            var auth = new StaticAuthentication(token);
            var client = new com.strava.api.Client.StravaClient(auth);
            string filePath;
            if (exportFileData.FromDropbox)
            {
                filePath = _dropboxService.DownloadFile(exportFileData.Reference, exportFileData.Name);
            }
            else
            {
                filePath = _storageHelper.DownloadFile(exportFileData.Reference, exportFileData.Name);
            }
            var status = await client.Uploads.UploadActivityAsync(filePath, DataFormat.Tcx);
            //var s = await client.Uploads.CheckUploadStatusAsync(status.Id.ToString());
            //var check = new UploadStatusCheck(token, status.Id.ToString());
            //check.UploadChecked += (o, args) => Console.WriteLine(args.Status);
            //check.Start();
        }

        public class ExportFileData
        {
            public string Provider { get; set; }
            public string Reference { get; set; }
            public string Name { get; set; }
            public string UserId { get; set; }
            public bool FromDropbox{ get; set; }
        }
    }
}
