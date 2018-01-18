using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAll
{
    public class Employeess
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public string FirstName { get; set; }



        public static List<Employeess> employees = new List<Employeess>()
        {
            new Employeess {Id=1,FirstName="Vinu",Age=23,Salary=24000 },
             new Employeess {Id=2,FirstName="Man",Age=24,Salary=27000 },
              new Employeess {Id=3,FirstName="bbb",Age=25,Salary=28000 },
               new Employeess {Id=1,FirstName="Vinu",Age=23,Salary=24000 },
                new Employeess {Id=2,FirstName="Man",Age=24,Salary=27000 }
        };
          
    }
    }
