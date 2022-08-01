using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSiteTemplete.Models
{
    public class Titles
    {
        public int ID { get; set; }
        public string TitleName { get; set; }
        public string TitleAName { get; set; }
        public string TitleEName { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser user { get; set; }
        public Nullable<int> TextTypeID { get; set; }
        [ForeignKey("TextTypeID")]
        public virtual TextTypes TextTypes { get; set; }
    }
}