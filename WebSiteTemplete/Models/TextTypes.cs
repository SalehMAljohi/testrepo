using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteTemplete.Models
{
    public class TextTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TextTypes()
        {
            this.PageDetails = new HashSet<PageDetails>();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PageDetails> PageDetails { get; set; }
        public int ID { get; set; }
        public string TextTypeName { get; set; }
        public string TextTypeAName { get; set; }
        public string TextTypeEName { get; set; }
    }
}