using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebSiteTemplete.Models
{
    public class Titles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Titles()
        {
            this.PageDetails = new HashSet<PageDetails>();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PageDetails> PageDetails { get; set; }
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