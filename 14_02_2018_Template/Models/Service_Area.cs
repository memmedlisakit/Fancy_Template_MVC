//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _14_02_2018_Template.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Service_Area
    {
        public int service_id { get; set; }
        [DisplayName("Image")]
        public string service_img { get; set; }
        [DisplayName("Title")]
        public string service_title { get; set; }
        [DisplayName("Content")]
        public string service_content { get; set; }
        [DisplayName("Url")]
        public string service_content_url { get; set; }
    }
}
