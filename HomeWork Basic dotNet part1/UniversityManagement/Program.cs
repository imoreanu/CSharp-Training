using UniversityManagement.DataModels;
using UniversityManagement.Enums;

namespace UniversityManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            using Context myContext = new Context();
            myContext.Students.Add(new Student()
            {
                StudentName = "Maggie Peters",
                Age = 21,
                StudentClasses = new List<Class>()
                {
                    new Class()
                    {
                        ClassLanguage = Language.English,
                        ClassName = "English History",
                        MaxClassSize = 13
                    },
                    new Class()
                    {
                        ClassLanguage = Language.French,
                        ClassName = "French Revolution",
                        MaxClassSize = 20
                    }
                }
            }
            );
            myContext.SaveChanges();
        }   
    }
}