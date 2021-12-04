using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Contacts;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //private readonly AppDbContext _context;
        private readonly IStudentRepository StudentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            StudentRepository = studentRepository;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await StudentRepository.FindAll().Include(x=>x.StudentCourses).ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await StudentRepository.FindByCondition(s=>s.Id==id).Include(x=> x.StudentCourses).FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            Student oldStudent = await StudentRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
            oldStudent.Name = student.Name;

            StudentRepository.UpdateStudentName(oldStudent);
            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            StudentRepository.Create(student);
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await StudentRepository.FindByCondition(x=> x.Id==id).FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound();
            }
            StudentRepository.Delete(student);
            
            return NoContent();
        }

    }
}
