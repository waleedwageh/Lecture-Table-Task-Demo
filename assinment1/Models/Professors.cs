using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assinment1.Models
{
    public class Professors
    {
        [Key]
        public int Professor_Id { get; set; }
        public string Professor_Name { get; set; }
        public int Teaching_Load { get; set; }

        public virtual ICollection<Professor_course> professor_Courses { get; set; }



    }
}
