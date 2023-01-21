using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            cola obj_cola=new cola();
            int opc;
            do
            {
                Console.Clear();
                obj_cola.menu();
                opc=int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        obj_cola.registrar();
                        break;
                    case 2:
                        obj_cola.mostrar();
                        break;
                    case 3:
                        obj_cola.reporte();
                        break;
                }
                Console.ReadKey();
            } while (opc!=4);
        }
    }
}
