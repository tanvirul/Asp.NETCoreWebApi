using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class StudentCourse:Entity
    {
        public int StudentId { get; set; }
        public virtual Student Student{ get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
