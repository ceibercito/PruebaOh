using Microsoft.AspNetCore.Mvc;
using PruebaOh.Db;
using PruebaOh.Models;

namespace PruebaOh.Controllers
{

    [ApiController]
    [Route("api/empleado")]

    public class EmpleadoController : Controller
    {

        private readonly DbEmpleadoDbContext _dbEmpleadoDbContext;

        public EmpleadoController(DbEmpleadoDbContext dbEmpleadoDbContext)
            => _dbEmpleadoDbContext = dbEmpleadoDbContext;

        [HttpPost()]       
        public IActionResult Add(Empleado empleado)
        {
            _dbEmpleadoDbContext.Empleados.Add(empleado);
            _dbEmpleadoDbContext.SaveChanges();
            return Ok("Created");
        }

        [HttpPut()]
        public IActionResult Update(Empleado empleado)
        {
            var existing = _dbEmpleadoDbContext.Empleados.FirstOrDefault(x=>x.Id == empleado.Id);
            if (existing == null)
                return NotFound();

            existing.Name = empleado.Name;
            existing.Document_number = empleado.Document_number;
            existing.Salary = empleado.Salary;
            existing.Profile = empleado.Profile;
            existing.Admission_date = empleado.Admission_date;
            _dbEmpleadoDbContext.Update(existing);
            _dbEmpleadoDbContext.SaveChanges();
            return Ok("Updated");
        }

        [HttpDelete()]
        public IActionResult Delete(int id)
        {
            var existing = _dbEmpleadoDbContext.Empleados.FirstOrDefault(x => x.Id == id);
            if (existing == null)
                return NotFound();

            _dbEmpleadoDbContext.Empleados.Remove(existing);
            _dbEmpleadoDbContext.SaveChanges();
                        
            return Ok("Updated");
        }
        
        [HttpGet("{id}")]
        public ActionResult<Empleado> Get(string id)
        {
            var parametro = Int64.Parse(id);
            var existing = _dbEmpleadoDbContext.Empleados.FirstOrDefault(x => x.Id == parametro);
            if (existing == null)
            {
                if (id.Length > 8)
                    return NotFound("El numero de documento debe ser de 8 digitos");
                existing = _dbEmpleadoDbContext.Empleados.FirstOrDefault(x => x.Document_number == id);
                if (existing == null)
                    return NotFound();
               
            }

                

            return Ok(existing);
        }

        [HttpGet("{document_number:alpha}")]
        public ActionResult<Empleado> GetByDocumentNumber(string document_number)
        {
            var existing = _dbEmpleadoDbContext.Empleados.FirstOrDefault(x => x.Document_number == document_number);
            if (existing == null)
                return NotFound();

            if (existing.Document_number.Length > 8)
                return NotFound("El numero de documento debe ser de 8 digitos");

            return Ok(existing);
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Empleado>> List()
        {
            return Ok(_dbEmpleadoDbContext.Empleados.ToList());
        }

    }
}
