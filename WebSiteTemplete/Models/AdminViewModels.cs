using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteTemplete.Models
{
    public class AdminViewModels
    {
        public int ID { get; set; }
        public string MediaTypeName { get; set; }
        public string MediaTypeAName { get; set; }
        public string MediaTypeEName { get; set; }
        public string url { get; set; }
        public string UserId { get; set; }
        public Nullable<int> MediaTypeID { get; set; }
        public string ParaGrapheName { get; set; }
        public string ParaGrapheAName { get; set; }
        public string ParaGrapheEName { get; set; }
        public Nullable<int> TextTypeID { get; set; }
        public string TextTypeName { get; set; }
        public string TextTypeAName { get; set; }
        public string TextTypeEName { get; set; }
        public string TitleName { get; set; }
        public string TitleAName { get; set; }
        public string TitleEName { get; set; }
    }
}