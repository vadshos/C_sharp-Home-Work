using System;

namespace Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Shostak Vadym Vyacheslavovych");
            
            Grade gr = new Grade(9, new DateTime(2021,3,11));
            student.AddGrade(gr);
            student.AddGrade(new Grade(10, new DateTime(2021, 4, 1)));
            student.AddGrade(new Grade(12, new DateTime(2021, 5, 4)));
            student.RemoveGrade(0);
            Console.WriteLine(student);
            Console.WriteLine(student.AvaregeGrade());
        }
    }
}
