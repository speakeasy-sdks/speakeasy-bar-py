
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Speakeasy.Bar
{
    using Speakeasy.Bar.Models.Components;
    using Speakeasy.Bar.Utils;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System;



    /// <summary>
    /// The environment name. Defaults to the production environment.
    /// </summary>
    public enum ServerEnvironment
    {
        [JsonProperty("prod")]
        Prod,
        [JsonProperty("staging")]
        Staging,
        [JsonProperty("dev")]
        Dev,
    }

    public static class ServerEnvironmentExtension
    {
        public static string Value(this ServerEnvironment value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static ServerEnvironment ToEnum(this string value)
        {
            foreach(var field in typeof(ServerEnvironment).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    var enumVal = field.GetValue(null);

                    if (enumVal is ServerEnvironment)
                    {
                        return (ServerEnvironment)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum ServerEnvironment");
        }
    }
    /// <summary>
    /// The Speakeasy Bar: A bar that serves drinks.
    /// 
    /// <remarks>
    /// A secret underground bar that serves drinks to those in the know.
    /// </remarks>
    /// 
    /// <see>https://docs.speakeasy.bar} - The Speakeasy Bar Documentation.</see>
    /// </summary>
    public interface ISpeakeasy
    {

        /// <summary>
        /// The authentication endpoints.
        /// </summary>
        public IAuthentication Authentication { get; }

        /// <summary>
        /// The drinks endpoints.
        /// </summary>
        public IDrinks Drinks { get; }

        /// <summary>
        /// The ingredients endpoints.
        /// </summary>
        public IIngredients Ingredients { get; }

        /// <summary>
        /// The orders endpoints.
        /// </summary>
        public IOrders Orders { get; }
        public IConfig Config { get; }
    }
    
    public class SDKConfig
    {
        public static Dictionary<string, string> ServerList = new Dictionary<string, string>()
        {
            {"Serverprod", "https://speakeasy.bar" },
            {"Serverstaging", "https://staging.speakeasy.bar" },
            {"Servercustomer", "https://{organization}.{environment}.speakeasy.bar" },
        };
        /// Contains the list of servers available to the SDK
        public string serverUrl = "";
        public string server = "";
        public Dictionary<string, Dictionary<string, string>> ServerDefaults = new Dictionary<string, Dictionary<string, string>>();

        public string GetTemplatedServerDetails()
        {
            if (!String.IsNullOrEmpty(this.serverUrl))
            {
                return Utilities.TemplateUrl(Utilities.RemoveSuffix(this.serverUrl, "/"), new Dictionary<string, string>());
            }
            if (!String.IsNullOrEmpty(this.server))
            {
                this.server = "Serverprod";
            }

            return Utilities.TemplateUrl(SDKConfig.ServerList[this.server], this.ServerDefaults.get(this.server, new Dictionary<string, string>()));
        }
    }

    /// <summary>
    /// The Speakeasy Bar: A bar that serves drinks.
    /// 
    /// <remarks>
    /// A secret underground bar that serves drinks to those in the know.
    /// </remarks>
    /// 
    /// <see>https://docs.speakeasy.bar} - The Speakeasy Bar Documentation.</see>
    /// </summary>
    public class Speakeasy: ISpeakeasy
    {
        public SDKConfig Config { get; private set; }

        private const string _language = "csharp";
        private const string _sdkVersion = "0.1.0";
        private const string _sdkGenVersion = "2.202.2";
        private const string _openapiDocVersion = "1.0.0";
        private const string _userAgent = "speakeasy-sdk/csharp 0.1.0 2.202.2 1.0.0 Speakeasy.Bar";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _defaultClient;
        private ISpeakeasyHttpClient _securityClient;
        public IAuthentication Authentication { get; private set; }
        public IDrinks Drinks { get; private set; }
        public IIngredients Ingredients { get; private set; }
        public IOrders Orders { get; private set; }
        public IConfig Config { get; private set; }

        public Speakeasy(Security? security = null, string? server = null, ServerEnvironment? environment = null, string?  organization = null, string? serverUrl = null, Dictionary<string, string>? urlParams = null, ISpeakeasyHttpClient? client = null)
        {
            if (serverUrl != null) {
                if (urlParams != null) {
                    serverUrl = Utilities.TemplateUrl(serverUrl, urlParams);
                }
                _serverUrl = serverUrl;
            }
            serverDefaults = new Dictionary<string, Dictionary<string, string>()
            {
                "prod": new Dictionary<string, string>()
                {
                    
                },
                "staging": new Dictionary<string, string>()
                {
                    
                },
                "customer": new Dictionary<string, string>()
                {
                    
                    
                    {"environment", environment == null ? "prod" : ServerEnvironmentExtension.Value(environment.Value)},
                    
                    
                    {"organization", organization == null ? "api" : organization},
                    
                },
            };

            _defaultClient = new SpeakeasyHttpClient(client);
            _securityClient = _defaultClient;
            
            if(security != null)
            {
                _securityClient = SecuritySerializer.Apply(_defaultClient, security);
            }
            
            Config = new SDKConfig()
            {
                ServerDefaults = serverDefaults,
                serverUrl = _serverUrl
            };

            Authentication = new Authentication(_defaultClient, _securityClient, _serverUrl, Config);
            Drinks = new Drinks(_defaultClient, _securityClient, _serverUrl, Config);
            Ingredients = new Ingredients(_defaultClient, _securityClient, _serverUrl, Config);
            Orders = new Orders(_defaultClient, _securityClient, _serverUrl, Config);
            Config = new Config(_defaultClient, _securityClient, _serverUrl, Config);
        }
    }
}