using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Grade
    {
        // One to One ==> Student Table
        [Key]
        public int Id { get; set; }

        public decimal Mathmatics { get; set; }

        public decimal Physics { get; set; }

        public decimal Programming { get; set; }

        // foreignkey ==> student table
        [ForeignKey("student")]
        public int? StudentId { get; set; }

        // Navigation properity
        public Student student { get; set; }

    }
}
