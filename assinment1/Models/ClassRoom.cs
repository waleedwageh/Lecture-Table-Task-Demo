using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace assinment1.Models
{
    public class ClassRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Hall_Code { get; set; }

        public virtual ICollection<Sections> Sections { get; set; }
    }
}
