using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSiteTemplete.Models
{
    public class MediaSubTypes
    {
        public int ID { get; set; }
        public string url { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser user { get; set; }
        public Nullable<int> MediaTypeID { get; set; }
        [ForeignKey("MediaTypeID")]
        public virtual MediaTypes MediaTypes  { get; set; }

    }
}