using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usando_buqueda_binaria
{
    class Program
    {
        //Metodo para ingresar los datos al arreglo, seran valores entre 10 y 30
        static public void Ingresar(int[] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                do
                {
                    Console.Write("{0}.-Numero de empleado ingresado : ", i + 1);
                    arreglo[i] = Int32.Parse(Console.ReadLine());

                }while(arreglo[i] < 10 || arreglo[i]>30);

            }
            Console.WriteLine("Se lleno el Arreglo!!");
        }

        //Metodo de busqueda binaria de manera descendente
        static void BusquedaB(int[] arreglo)
        {
            Array.Sort(arreglo);
            Array.Reverse(arreglo);

            int T = arreglo.Length;
            int mitad,pos=0,busca;
            int Li = 0, Ls = T - 1;
            bool badera = false;

            Console.Write("Ingrese el valor a buscar: ");
            busca = Int16.Parse(Console.ReadLine());

            while(Li<=Ls && badera != true)
            {
                mitad = (Li + Ls) / 2;
                if (arreglo[mitad] == busca)
                {
                    pos = mitad;
                    badera = true;
                }
                else
                {
                    if (arreglo[mitad] > busca)
                    {
                        Li = mitad + 1;
                    }
                    else
                    {
                        Ls = mitad - 1;
                    }
                }
            }
            if (badera == true)
            {
                Console.WriteLine("Se encuentra {0} en la posicion {1}",busca,pos+1);
            }
            else
            {
                Console.WriteLine("No se encuentra {0} dentro del arreglo", busca);
            }
        }

        //Metodo de despliegue 
        static void Despliegue(int[] arreglo)
        {
            Console.WriteLine("Contenido del arreglo:");
            for (int f = 0; f < arreglo.Length; f++)
            {
                Console.WriteLine("[{1}: {0}]", arreglo[f], f + 1);
            }
        }

        static void Main(string[] args)
        {
            //Valadez Leal Ricardo 19211744

            Console.Title=("Busqueda Binaria");
            //Todas las variables auxiliares 
            int[] empleados = new int[5];
            int[] desordern = new int[5];

            string respuesta;

            //Creacion de un ciclo do while
            do
            {
                Console.Clear();
                //Menu
                Console.WriteLine("MENU Numeros de empleados" +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Ingresar numeros de empleados" +
                "\n2) Busqueda de numeros de empleados" +
                "\n3) Salir del Programa");
                Console.Write("Opcion : ");


                respuesta = Console.ReadLine();
                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (respuesta)
                {
                    //Case para ingresar los datos del arreglo
                    case "1":
                        Console.Title = ("Busqueda Secuencial Binaria");
                        Ingresar(desordern);
                        Array.Copy(desordern, empleados, 5);
                        break;

                    //Case de busqueda binaria
                    case "2":
                        Console.Title = ("Busqueda Secuencial Binaria");
                        BusquedaB(desordern);
                        Console.WriteLine("");
                        Console.WriteLine("Arreglo ordenado de manera descendente");
                        Despliegue(desordern);
                        Console.WriteLine("");
                        Console.WriteLine("Arreglo Original");
                        Despliegue(empleados);
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Presione cualquier tecla para salir del programa");
                        break;

                    //Case default por si no ingresan ningun valor deseado
                    default:
                        Console.WriteLine("\nNo selecciono ninguna opcion");
                        Console.WriteLine("\nPresione <enter> para regresar al menu");
                        Console.WriteLine();
                        Console.Read();
                        Console.Clear();
                        Console.Read();
                        break;
                }

                // Si el valor no es 3 se seguira repitiendo el ciclo
            } while (respuesta != "3");

            Console.Read();
        }
    }
}

