
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
    using Speakeasy.Bar.Utils;
    
    public class GetDrinkRequest
    {

        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=name")]
        public string Name { get; set; } = default!;
    }
}