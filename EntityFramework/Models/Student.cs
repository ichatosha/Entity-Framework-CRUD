using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public  class Student
    {
        [Key]                        
        // auto increment (Primary Key) in .net8 
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        //Navigation prop.
        public Grade Grade { get; set; }
        
        
        // foreignkey ==> department table
        [ForeignKey("department")]
        public int  departmentId { get; set; }
        // Navigation properity
        public Department department { get; set; }


        public ICollection<StudentBook> Books { get; set; }

        // Ignore it in database
        //[NotMapped]
        public ICollection<Attendance> Attendances { get; set; }
    }
}
