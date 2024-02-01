using EntityFramework;
using EntityFramework.Models;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

Console.WriteLine("Hello!");


using var db = new inherDbContext();

//  ***CRUD Operations:
// ****Insert Data // (C)
var department = new Department()
{
    //    Name = "HESHAM"
    description = "hehshshshshshshshs"
};
//db.Add(department);
//db.SaveChanges();

// check validation before save changes in database:
var context = new ValidationContext(department);
var errors = new List<ValidationResult>();
    if (!Validator.TryValidateObject(department, context,errors,true))
    {
        foreach(var ValidationResult in errors)
        {
            Console.WriteLine(ValidationResult);
        }
    }
    else
    {
        db.Add(department);
        db.SaveChanges();
    }

// *******Find + Update Data  // (R + U)
//var department = db.Departments.Find(3);
//if (department != null)
//{
//    Console.WriteLine(department.Name);
//    // Update
//    //department.Name = "HESHAM FATHY";
//    //db.SaveChanges();
//}
//else
//{
//    Console.WriteLine("Nothing!");
//}

// *******Delete // (D)
//db.Departments.Remove(department);


var dbs = new inherDbContext();

//var students = dbs.Students.ToList();

//foreach(var item in  students)
//{
//    Console.WriteLine(item.Name);
//}


//// print studentId = 7
//var student = dbs.Students.Find(7);
//Console.WriteLine(student.Name);



// conditions (id == , name == , age==)
var student = dbs.Students.SingleOrDefault(s => s.Id == 1 && s.Name == "hesham" && s.Age == 26);
Console.WriteLine(student.Name);