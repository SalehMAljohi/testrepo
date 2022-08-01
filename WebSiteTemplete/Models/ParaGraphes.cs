using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSiteTemplete.Models
{
    public class ParaGraphes
    {
        public int ID { get; set; }
        public string ParaGrapheName { get; set; }
        public string ParaGrapheAName { get; set; }
        public string ParaGrapheEName { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser user { get; set; }
        public Nullable<int> TextTypeID { get; set; }
        [ForeignKey("TextTypeID")]
        public virtual TextTypes TextTypes { get; set; }
    }
}