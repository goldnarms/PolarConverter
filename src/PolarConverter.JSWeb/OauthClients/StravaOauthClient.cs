using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Nemiro.OAuth;

namespace PolarConverter.JSWeb.OauthClients
{
    public class StravaOauthClient : OAuth2Client
    {
        public StravaOauthClient(string clientId, string clientSecret) : base("https://www.strava.com/oauth/authorize", "https://www.strava.com/oauth/token", clientId, clientSecret)
        {
            this.Scope = "write";
        }

        public override string ProviderName
        {
            get { return "Strava"; }
        }

        public override UserInfo GetUserInfo()
        {
            // query parameters
            var parameters = new NameValueCollection
            {
                { "access_token" , this.AccessToken["access_token"].ToString() }
            };
            // execute the request
            var result = Nemiro.OAuth.Helpers.ExecuteRequest("GET", this.AccessTokenUrl, parameters, null);
            // field mapping
            var map = new ApiDataMapping();
            map.Add("id", "UserId", typeof(string));
            map.Add("firstname", "FirstName");
            map.Add("lastname", "LastName");
            map.Add("email", "Email");
            //map.Add("birthday", "Birthday", typeof(DateTime), @"MM\/dd\/yyyy");
            map.Add
            (
            "sex", "Sex",
            delegate (object value)
            {
                if (value != null)
                {
                    if (value.ToString().Equals("M", StringComparison.OrdinalIgnoreCase))
                    {
                        return Sex.Male;
                    }
                    else if (value.ToString().Equals("F", StringComparison.OrdinalIgnoreCase))
                    {
                        return Sex.Female;
                    }
                }
                return Sex.None;
            }
            );
            // parse the server response and returns the UserInfo instance
            return new UserInfo(result.Result as Dictionary<string, object>, map);
        }
    }
}