using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;


namespace WebSiteTemplete.Models
{
    public class RoleViewModels
    {
        public string Id { get; set; }

        [DisplayName("اسم القاعدة")]
        public string Name { get; set; }
    }
}