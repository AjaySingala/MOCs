using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thinktecture.IdentityModel.Tokens.Http;

namespace BlueYonder.Companion.Host.Authentication
{
    public class AuthenticationConfig
    {
        public static AuthenticationConfiguration CreateConfiguration()
        {
            var config = new AuthenticationConfiguration();

            // Get the SWT configuration from the Web Role configuration
            string issuerName =  Microsoft.WindowsAzure.CloudConfigurationManager.GetSetting("ACS.IssuerName").Trim();
            string realm = Microsoft.WindowsAzure.CloudConfigurationManager.GetSetting("ACS.Realm").Trim();
            string signingKey = Microsoft.WindowsAzure.CloudConfigurationManager.GetSetting("ACS.SigningKey").Trim();

            // Add an SWT authentication support
            config.AddSimpleWebToken(
                issuer: issuerName,
                audience: realm,
                signingKey: signingKey,
                options: AuthenticationOptions.ForAuthorizationHeader("OAuth"));

            // Set defaults
            config.DefaultAuthenticationScheme = "OAuth";
            config.EnableSessionToken = true;

            return config;
        }
    }

}