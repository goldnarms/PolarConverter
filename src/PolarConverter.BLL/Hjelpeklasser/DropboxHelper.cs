using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PolarConverter.BLL.Entiteter;
using Spring.IO;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.Social.OAuth1;

namespace PolarConverter.BLL.Hjelpeklasser
{
    public static class DropboxHelper
    {
        private const string AuthorizationCallbackUri = "http://polarconverter.azurewebsites.net/Home/Dropboxlogin";
        //private const string AuthorizationCallbackUri = "http://localhost:41687/Home/Dropboxlogin";
        private const string ConsumerKey = "bh8p1imxveuzkcb";
        private const string ConsumerSecret = "t8dqymf78c0j2wg";
        private static OAuthToken _requestResult;
        private static IDropbox _dropboxApi;
        private static DropboxServiceProvider _serviceProvider;
        private static IOAuth1Operations _oauthOperations;

        public static bool LoginDropbox(string value, string secret)
        {
            try
            {
                _serviceProvider = new DropboxServiceProvider(ConsumerKey, ConsumerSecret, AccessLevel.AppFolder);
                _dropboxApi = _serviceProvider.GetApi(value, secret);
                KobleOppDropbox();
                return _dropboxApi != null;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> SokOppFilerFraDropboxMappe(FilTyper filTyper)
        {
            var resultat = new List<Entry>();
            var sokestreng = string.Format(".{0}", Enum.GetName(typeof(FilTyper), filTyper).ToLower());
            Task.WaitAll(_dropboxApi.SearchAsync("", sokestreng).ContinueWith(t => resultat.AddRange(t.Result)));
            return resultat.Select(res => res.Path.Substring(1)).ToList();
        }

        public static string VideresendBrukerTilDropBox()
        {
            KobleOppDropbox();
            var url = "";
            var parameters = new OAuth1Parameters { CallbackUrl = AuthorizationCallbackUri };
            Task.WaitAll(_oauthOperations.FetchRequestTokenAsync(AuthorizationCallbackUri, null).ContinueWith(t => _requestResult = t.Result).ContinueWith(t => url = _oauthOperations.BuildAuthorizeUrl(t.Result.Value, parameters)));
            return url;
        }

        public static OAuthToken GenererAccessToken(string uid, string oauthToken)
        {
            KobleOppDropbox();
            OAuthToken res = null;
            Task.WaitAll(_oauthOperations.ExchangeForAccessTokenAsync(new AuthorizedRequestToken(_requestResult, oauthToken), null).ContinueWith(t => res = t.Result));
            return res;
        }

        public static void LastInnFilerFraDropbox(List<DropboxItem> filesToBeConverted, string serversti, string brukerGuid)
        {
            Task.WaitAll(filesToBeConverted.
                Select(filer => _dropboxApi.DownloadFileAsync(filer.Filnavn).
                    ContinueWith(task => task.Result.Content.SkrivByteArrayTilFil(string.Format("{0}{1}{2}{3}", 
                        serversti, 
                        task.Result.Metadata.Path.Substring(0, task.Result.Metadata.Path.Length - 4),
                        brukerGuid,
                        task.Result.Metadata.Path.Substring(task.Result.Metadata.Path.Length - 4))))).ToArray());
        }

        public static void LagreResultatTilDropbox(Stream stream, string serversti)
        {
            var filnavn = string.Format("{0}\\{1}{2}{3}", serversti, "tcxFiles", Guid.NewGuid(), ".zip");
            using (var fileStream = File.Create(filnavn))
            {
                stream.CopyTo(fileStream);
            }
            Task.WaitAll(_dropboxApi.UploadFileAsync(new FileResource(filnavn), string.Format("tcxFiles{0}.zip", DateTime.Now.ToShortDateString())));
            FilHandler.SlettFil(filnavn);
        }

        private static void KobleOppDropbox()
        {
            if(_serviceProvider == null)
                _serviceProvider = new DropboxServiceProvider(ConsumerKey, ConsumerSecret, AccessLevel.AppFolder);
            _oauthOperations = _serviceProvider.OAuthOperations;
        }
    }
}
