using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Contacts
{
    public interface IStudentRepository: IRepositoryBase<Student>
    {
        public bool UpdateStudentName(Student student);
    }
}
