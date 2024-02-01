using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    // changing table name :
    //[Table("StudentAttendance")]
    // One To Many ==> Student
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        // change prop name and type :
        //[Column("TheName",TypeName = "varchar(20)")]
        public string DayName { get; set; }

        public string StudentName { get; set; }

        public DateTime AttenDate { get; set; }

        [ForeignKey("Student")]
        public int studentId { get; set; }

        public Student student { get; set; }







    }
}
