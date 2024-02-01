using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class StudentBook
    {
        public int Id { get; set; }

        public DateTime GetDate { get; set; }


        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student student { get; set; }


        [ForeignKey("Book")]
        public int bookId { get; set; }
        public Book Book { get; set; }




    }
}
