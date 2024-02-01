using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Book
    {

        [Key]
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string AuthorGender { get; set; }
        
        public DateTime Created { get; set; }


        public ICollection<StudentBook> Students { get; set; }

    }
}
