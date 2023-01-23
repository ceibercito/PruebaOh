namespace PruebaOh.Models
{
    public class Empleado
    {
        public int Id { get; set; }

         public string Name { get; set; }

        public string ?Document_number { get; set; }

        public double Salary { get; set; }

        public string Profile { get; set; }

        public DateTime Admission_date { get; set; } 
    }
}
