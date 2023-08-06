using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskmanager
{
     class task
    {
      public void  Task()
        {
            
            Console.WriteLine("----------------Task Manager ------------");
           int num =Int32.Parse(Console.ReadLine());
            switch(num)
            {
                case 1:
                    Console.WriteLine("Add a Task");
                    break;
                case 2:
                    Console.WriteLine("View Task");
                    break;
                case 3:
                    Console.WriteLine("Mark Completed");
                    break;
                case 4:
                    Console.WriteLine("Delete Task");
                    break;
                case 5:
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("your choice is invalid");
                    break;
            }
        }
        
    }

}
