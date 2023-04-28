using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace assinment1.Models
{
    public class Professor_course
    {

        [ForeignKey("Course") ,Key]
        public string Course_code { get; set; }
        [ForeignKey("Professor") ,Key]

        public int Prof_Id { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Professors Professor { get; set; }
    }
}


