
//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasyapi.dev). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Speakeasy.Bar.Models.Requests
{
    using Newtonsoft.Json;
    
    public class AuthenticateRequestBody
    {

        [JsonProperty("password")]
        public string? Password { get; set; }

        [JsonProperty("username")]
        public string? Username { get; set; }
    }
}