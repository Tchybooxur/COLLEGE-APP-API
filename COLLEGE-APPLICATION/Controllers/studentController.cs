using COLLEGE_APPLICATION.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace COLLEGE_APPLICATION.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class studentController : ControllerBase
    {
        [HttpGet]
        [Route("All", Name = "GetStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            var students = CollegeRepository.students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Address = s.Address,
            });

            //OK - 200 - success
            return Ok(students);
        }

        [HttpGet]
        [Route("{Id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> GetStudentById(int Id)
        {
            // BadRequest - 400 - Bad request - Client error
            if (Id <= 0)
                return BadRequest($"Your input should be between 1 and {CollegeRepository.students.Count}!");

            Predicate<Student> predicate = student => student.Id == Id;
            Student? student = CollegeRepository.students.Find(x => predicate(x));

            // Not Found - 400 - Bad request - Client error
            if (student == null)
                return BadRequest($"Could not find any student with Id of {Id}.");

            var studentDTO = new StudentDTO() 
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Address = student.Address,
            };

            //OK - 200 - success
            return Ok(studentDTO);
        }

        [HttpGet]
        [Route("{name:alpha}", Name = "GetStudentByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> GetStudentByName(string name)
        {
            // BadRequest - 400 - Bad request - Client error
            if (string.IsNullOrEmpty(name))
                return BadRequest($"Your input cannot be empty buddy!");

            Predicate<Student> predicate = s => s.Name == name;
            Student? student = CollegeRepository.students.Find(x => predicate(x));

            // Not Found - 400 - Bad request - Client error
            if (student == null)
                return BadRequest($"Could not find any student with the name of {name}.");

            var studentDTO = new StudentDTO()
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Address = student.Address,
            };

            //OK - 200 - success
            return Ok(studentDTO);
        }

        [HttpPost]
        [Route("Create", Name = "CreateStudent")]
        //api/student/Create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> CreateStudent([FromBody]StudentDTO model)
        {
            //if(!ModelState.IsValid)
                //return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            int newId = CollegeRepository.students.LastOrDefault().Id + 1;
            var student = new Student()
            {
                Id = newId,
                Name = model.Name,
                Email = model.Email,
                Address = model.Address,
            };
            CollegeRepository.students.Add(student);
            model.Id = newId;
            return CreatedAtRoute("GetStudentById", new {Id = model.Id}, model);
        }  

        [HttpDelete]
        [Route("{Id:int}", Name = "DeleteStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> DeleteStudentById(int Id)
        {
            // BadRequest - 400 - Bad request - Client error
            if (Id <= 0)
                return BadRequest($"Your input should be between 0 and {CollegeRepository.students.Count}!");
            
            // get the student to delete
            Predicate<Student> predicate = student => student.Id == Id;
            Student? student = CollegeRepository.students.Find(x => predicate(x));

            // Not Found - 400 - Bad request - Client error
            if (student == null)
                return BadRequest($"Could not find any student with Id of {Id}.");

            CollegeRepository.students.Remove(student);

            //OK - 200 - success
            return Ok(true);
        }
    }
}
