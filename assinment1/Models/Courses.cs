using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace assinment1.Models
{
    public class Courses
    {
        [Key]
  
    [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string Course_code { get; set; }
        public string Course_Name { get; set; }
        public int Hours_Per_week { get; set; }

        public virtual ICollection<Sections> Sections { get; set; }
        public virtual ICollection<Professor_course> professor_Courses { get; set; }
    }
}
