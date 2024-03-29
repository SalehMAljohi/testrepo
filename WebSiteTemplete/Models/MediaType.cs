﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteTemplete.Models
{
    public class MediaTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MediaTypes()
        {
            this.PageDetails = new HashSet<PageDetails>();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PageDetails> PageDetails { get; set; }
        public int ID { get; set; }
        public string MediaTypeName { get; set; }
        public string MediaTypeAName { get; set; }
        public string MediaTypeEName { get; set; }

    }
}