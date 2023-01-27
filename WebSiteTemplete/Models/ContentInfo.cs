using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSiteTemplete.Models
{
    public class ContentInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContentInfo()
        {
            this.PageDetails = new HashSet<PageDetails>();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PageDetails> PageDetails { get; set; }
        public int ID { get; set; }
        public string ContentName { get; set; }
        public string ContentAName { get; set; }
        public string ContentEName { get; set; }
      
        public Nullable<int> PageID { get; set; }
        [ForeignKey("PageID")]
        public virtual PageInfo PageInfo { get; set; }

    }
}