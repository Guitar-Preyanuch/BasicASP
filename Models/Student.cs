using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicASP.Models
{
    /*
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }*/
    
    //Connect with Database
    public class Student
    {
        [Key] //deffine Id to be Key
        public int Id { get; set; }
        
        [Required(ErrorMessage ="กรุณาป้อนชื่อนักเรียน")]//Not Null

        [DisplayName("ชื่อนักเรียน")]
        public string Name { get; set; }

        [DisplayName("คะแนนสอบ")]//For display in other languages
        [Range(0,100, ErrorMessage="กรุณาป้อนคะแแนนในช่วง 0-100")]
        public int Score { get; set; }
    }
}
