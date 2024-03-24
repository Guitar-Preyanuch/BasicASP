using Microsoft.EntityFrameworkCore;
using BasicASP.Models;

namespace BasicASP.Data
{
    public class ApplicationDBContext : DbContext
    {
        //Create Constructor, option เป็นตัวกำหนดว่าโปรเจคของเราจจะเชื่อมต่อกับฐานข้อมูลแบบใด เพราะฐานข้อมูลมีท้งแบบ MySQL,MSSQL ในที่นี้ก็คือเชื่อมต่อกับ pplicationDBContext
        //แล้วก็โย options เข้าไปทำงานใน class แม่
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        //เอา model Student ไปสร้างเป็นตารางในดาต้าเบสชื่อว่า Students, การจะเข้าถึงฐานข้อมูลต้องมีการเข้าถึงผ่าน DeSet Entity ที่ชื่อว่า Students
        public DbSet<Student> Students {get;set;}

        //เอา DBContext มาตั้งค่าเป็น Service ที่จะถูกใช้งานใน ASP
    }
}
