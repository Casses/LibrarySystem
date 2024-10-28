using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [Table("ActivityLog")]
    public class ActivityLog
    {
        [Key]
        public int Id { get; set; }
        public DateTime Checkout { get; set; }
        public DateTime? Return { get; set; }

        public virtual Member Member { get; set; }
        public virtual Book Book { get; set; }
    }
}
