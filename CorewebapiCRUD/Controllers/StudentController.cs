using CorewebapiCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorewebapiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly MyDbContext context;

        public StudentController(MyDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentsByID(int id)
        {
            var students = await context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return students;
        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> CreateStudents(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudents(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
            context.Entry(std).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok();


        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudents(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
