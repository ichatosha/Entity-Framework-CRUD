using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Department 
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="Please insert your name!")]
        public string Name { get; set; }

        [MaxLength(10,ErrorMessage ="Maximum chars ONLY 10!")]
        public string? description {  get; set; }


        public ICollection<Student> Students { get; set; }



    }
}
