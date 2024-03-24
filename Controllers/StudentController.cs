using BasicASP.Data;
using BasicASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BasicASP.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDBContext _db;
        public StudentController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()//แสดงคะแนนสอบ
        {
           // Student s1 = new Student();
            var s1 = new Student(); //recommended มองหาเองว่า object เป็น  type  อะไร
                                    // Student s1 = new();
            /* s1.Id = 1;
             s1.Name = "ก้อง";
             s1.Score = 100;

             var s2 = new Student();
             s2.Id = 2;
             s2.Name = "แก้ง";
             s2.Score = 15;

             Student s3 = new();
             s3.Id = 3;
             s3.Name = "กุ้ง";
             s3.Score = 100;

             //return View(s1,s2,s3); CANT 
             List<Student> allStudent = new List<Student>();
             allStudent.Add(s1);
             allStudent.Add(s2);
             allStudent.Add(s3);
            */

            IEnumerable <Student> allStudent = _db.Students;//retrive data from database to display on view
            return View(allStudent);
           
           

        }
        //ถ้า return View();  จะเป็น GET METHOD
        //ถ้ามีพารามิเตอร์ค่อยจะเป็น Post Method
        public IActionResult Create()//บันทึกคะแนนสอบ
        {
            return View();

        }
        [HttpPost]//Name,Score
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)//บันทึกคะแนนสอบ
        {
            if (ModelState.IsValid)//Data Valisation 
            {
                _db.Students.Add(obj);
                _db.SaveChanges();//save data to Database
                return RedirectToAction("Index");//when save then goback to first page  of website
            }
            return View(obj); //If input incorrect then user can't save data

        }
        public IActionResult Edit(int? id)//? mean can be null
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]//Name,Score
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)//UpdateButton
        {
            if (ModelState.IsValid)//Data Valisation 
            {
                _db.Students.Update(obj);
                _db.SaveChanges();//save data to Database
                return RedirectToAction("Index");//when save then goback to first page  of website
            }
            return View(obj); //If input incorrect then user can't save data

        }
        public IActionResult Delete(int? id)//? mean can be null
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Students.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
