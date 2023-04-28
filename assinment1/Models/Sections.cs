using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace assinment1.Models
{
    public class Sections
    {
        [Key]
        public int Section_Id { get; set; }
        [ForeignKey("professor")]
        public int Professor_Id { get; set; }
        [ForeignKey("course")]
        public string Course_Code { get; set; }
        public string FirstDay { get; set; }
        public string LastDays { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("Room")]
        public int Hall_Num { get; set; }
        public virtual ClassRoom Room { get; set; }
        public virtual Courses course { get; set; }
        public virtual Professors professor { get; set; }


    }
}
