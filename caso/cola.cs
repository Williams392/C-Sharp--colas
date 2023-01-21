using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace caso
{
    internal class cola
    {
        public bodega inicio, fin;
        public cola()
        {
            inicio = fin = null;
        }
        int MAX=0, MIN=0,X=1;
        double ganancia = 0;
        public void menu()
        {
            Console.WriteLine("**************************");
            Console.WriteLine("\tTIENDA LA BODEGUITA");
            Console.WriteLine("**************************");
            Console.WriteLine("[1]Registrar Venta");
            Console.WriteLine("[2]Listar venta");
            Console.WriteLine("[3]Reporte General");
            Console.WriteLine("[4]Salir");
            Console.WriteLine("===========================");
            Console.Write("INGRESAR LA OPCION: ");
        }
        public void registrar()
        {
            bodega nuevo = new bodega();
            Console.WriteLine("----------------");
            Console.WriteLine("Registro de venta");
            Console.WriteLine("-----------------");
            nuevo.codigo = 1000 + X;
            Console.WriteLine("Codigo: " + nuevo.codigo);
            nuevo.correlativo = X;
            Console.WriteLine("Numero Orden: " + nuevo.correlativo);
            X++;
            Console.Write("Producto: ");
            nuevo.producto = Console.ReadLine();
            Console.Write("Precio: ");
            nuevo.precio = double.Parse(Console.ReadLine());
            Console.Write("Cantidad: ");
            nuevo.cant = int.Parse(Console.ReadLine());
            nuevo.sgte = null;
            //maximo
            if (MAX == 0)
                MAX = nuevo.cant;
            else if (nuevo.cant > MAX)
                MAX = nuevo.cant;
            //minimo
            if (MIN == 0)
                MIN = nuevo.cant;
            else if (nuevo.cant < MIN)
                MIN = nuevo.cant;
            //importe
            Console.WriteLine("Importe total: " + nuevo.precio * nuevo.cant);

            ganancia = ganancia + nuevo.precio * nuevo.cant;
            if (inicio == null)
            {
                inicio = nuevo;
                fin = nuevo;
            }
            else
            {
                fin.sgte = nuevo;
                fin = nuevo;
            }
            Console.WriteLine("venta registrada con exito..!!");
        }

        public void mostrar()
        {
            bodega aux;
            int i=1;
            aux = inicio;
            if (inicio == null)
            {
                Console.WriteLine("REPORTE VACIO..!!");
            }
            else
            {
                Console.WriteLine("Registro de ventas");
                while (aux != null)
                {
                    Console.WriteLine("\nVenta[" + i + "]");
                    Console.WriteLine("------------");
                    Console.WriteLine("Codigo: " + aux.codigo);
                    Console.WriteLine("Num. Orden: " + aux.correlativo);
                    Console.WriteLine("Producto: " + aux.producto);
                    Console.WriteLine("Precio: " + aux.precio);
                    Console.WriteLine("Cantidad: " + aux.cant);
                    Console.WriteLine("Importe total: " + aux.precio * aux.cant);
                    aux = aux.sgte;
                    i=i + 1;

                }
            }
        }
        public void reporte()
        {
            if (inicio != null)
            {
                Console.Clear();
                Console.WriteLine("==========================");
                Console.WriteLine("Reporte general de ventas");
                Console.WriteLine("==========================");
                bodega aux=inicio;
                Console.WriteLine("==========================");
                Console.WriteLine("Reporte de max y min de demanda");
                Console.WriteLine("==========================");
                Console.WriteLine("Articulo más vendido: ");
                while (aux != null)
                {
                    if (aux.cant == MAX)
                    {
                        Console.WriteLine("Nombre del producto: " + aux.producto);
                        Console.WriteLine("Cantidad: " + aux.cant);
                    }
                    aux= aux.sgte;
                }
                Console.WriteLine("Articulo menos vendido: ");
                aux = inicio;
                while (aux != null)
                {
                    if (aux.cant == MIN)
                    {
                        Console.WriteLine("Nombre del producto: " + aux.producto);
                        Console.WriteLine("Cantidad: " + aux.cant);
                    }
                    aux=aux.sgte;
                }
                Console.WriteLine("==========================");
                Console.WriteLine("Ganancia total");
                Console.WriteLine("==========================");
                Console.WriteLine("La utilidad acumulada es: S/" + ganancia);
            }
            else
            {
                Console.WriteLine("No existe registros de venta");
            }
        }
    }
}
