using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSiteTemplete.Models
{
    public partial class PageDetails
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser user { get; set; }
        public Nullable<int> MediaTypeID { get; set; }
        [ForeignKey("MediaTypeID")]
        public virtual MediaTypes MediaTypes { get; set; }
        public Nullable<int> PageID { get; set; }
        [ForeignKey("PageID")]
        public virtual PageInfo PageInfo { get; set; }
        public Nullable<int> ContentID { get; set; }
        [ForeignKey("ContentID")]
        public virtual ContentInfo ContentInfo { get; set; }
        public Nullable<int> MediaSubTypeID { get; set; }
        [ForeignKey("MediaSubTypeID")]
        public virtual MediaSubTypes MediaSubTypes { get; set; }
        public Nullable<int> TextTypeID { get; set; }
        [ForeignKey("TextTypeID")]
        public virtual TextTypes TextTypes { get; set; }
        public Nullable<int> ParaGraphesID { get; set; }
        [ForeignKey("ParaGraphesID")]
        public virtual ParaGraphes ParaGraphes { get; set; }
        public Nullable<int> TitleID { get; set; }
        [ForeignKey("TitleID")]
        public virtual Titles Titles { get; set; }
    }
}