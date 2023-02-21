using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.EF;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase {
        public readonly AppDBContext _context;

        public StudentsController(AppDBContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            List<Student> students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id) {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            var existingStudent = await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (existingStudent == null) return NotFound();
            return Ok(existingStudent);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student student) {
            if (student == null) throw new ArgumentNullException(nameof(student));

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return Ok(student.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(string id,Student student) {
            if(string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            if (student == null) throw new ArgumentNullException(nameof(student));

            var existingStudent = await _context.Students.Where(x => x.Id==id).FirstOrDefaultAsync();
            if (existingStudent == null) return NotFound();

            existingStudent.Name= student.Name;
            existingStudent.Address = student.Address;
            existingStudent.ParentName = student.ParentName; 
            existingStudent.PhoneNumber = student.PhoneNumber;
            existingStudent.Age = student.Age;
            existingStudent.Gender= student.Gender;

            await _context.SaveChangesAsync();

            return Ok(existingStudent);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id) {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            var existingStudent = await _context.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (existingStudent == null) return NotFound();


            _context.Students.Remove(existingStudent);
            await _context.SaveChangesAsync();

            return Ok(existingStudent.Id);
        }
    }
}
