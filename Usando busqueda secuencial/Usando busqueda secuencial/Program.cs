using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usando_busqueda_secuencial
{
    class Program
    {
        //Varibles auxiliares universales
        static string busca;
        static int pos = 0;

        //Metodo para ingresar datos a los arreglos
        static void Ingresar(string[] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                Console.Write("{0}.-Nombre Ingresado : ", i + 1);
                arreglo[i] = Console.ReadLine();
            }
            Console.WriteLine("Se lleno el Arreglo!!");


            Console.ReadKey();         
        }

        //Metodo de busqueda del primer metodo
        static void BSM1(string[] arreglo)
        {
            Console.Write("Nombre que quiere buscar: ");
            busca = Console.ReadLine();

            bool bandera = false;
            int T = arreglo.Length;

            for(int i = 0; i < T; i++)
            {
                if (arreglo[i] == busca)
                {
                    Console.WriteLine("Valor Encontrado");
                    Console.WriteLine("Posicion: [{0}]",i+1);
                    Console.WriteLine("Numero de comparaciones: {0}",i);
                    bandera = true;
                }
            }
            if (bandera == false)
            {
                Console.WriteLine("No se encuentra ese nombre!!");
            }
            Console.WriteLine("Contenido del arreglo:");
            for(int f = 0; f < T; f++)
            {
                Console.WriteLine("[{1}: {0}]",arreglo[f],f+1);
            }
        }

        //Metodo de busqueda del segundo metodo
        static void BSM2(string[] arreglo)
        {
            //Orden ascendente
            Array.Sort(arreglo);

            int T = arreglo.Length;

            Console.Write("Nombre que quiere buscar: ");
            busca = Console.ReadLine();

            bool bandera = false;

            while(pos<T && bandera != true)
            {
                if (arreglo[pos] == busca)
                {
                    Console.WriteLine("Valor Encontrado");
                    Console.WriteLine("Posicion: [{0}]", pos+1);
                    Console.WriteLine("Numero de comparaciones: {0}", pos);
                    bandera = true;
                }
                pos=pos+1;
            }
            if (bandera == false)
            {
                Console.WriteLine("No se encuentra ese nombre!!");
                Console.WriteLine("Numero de comparaciones: {0}", pos);
            }
            Console.WriteLine("Contenido del arreglo:");
            for (int f = 0; f < T; f++)
            {
                Console.WriteLine("[{1}: {0}]", arreglo[f], f + 1);
            }
        }

        //Metodo de busqueda del tercero metodo
        static void BSM3(string[] arreglo)
        {
            //Orden descendente
            Array.Sort(arreglo);
            Array.Reverse(arreglo);

            bool detener = false;

            Console.Write("Nombre que quiere buscar: ");
            busca = Console.ReadLine();

            bool bandera = false;
            int T = arreglo.Length;

            while (pos < T && bandera != true || detener==true)
            {
                if (arreglo[pos] == busca)
                {
                    Console.WriteLine("Valor Encontrado");
                    Console.WriteLine("Posicion: [{0}]", pos+1);
                    Console.WriteLine("Numero de comparaciones: {0}", pos);
                    bandera = true;
                }
                else
                {
                    if (String.Compare(arreglo[pos], busca) > 0)
                        pos++;
                    else
                        detener = false;                
                }
            }
            if (bandera == false)
            {
                Console.WriteLine("No se encuentra ese nombre!!");
                Console.WriteLine("Numero de comparaciones: {0}", pos);
            }
            Console.WriteLine("Contenido del arreglo:");
            for (int f = 0; f < T; f++)
            {
                Console.WriteLine("[{1}: {0}]", arreglo[f], f + 1);
            }
        }

        static void Despliegue(string[] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
                Console.Write("{0}|", arreglo[i]);
        }

        static void Main(string[] args)
        {
            //Valadez Leal Ricardo 19211744

            Console.Title = ("Busqueda Secuencial");

            //Todas las variables auxiliares que usaremos
            string[] nombres = new string[3];
            string[] nombresA = new string[3];
            string[] nombresD = new string[3];
            string respuesta;

            //Creacion de un ciclo do while
            do
            {
                Console.Clear();
                //Menu
                Console.WriteLine("MENU Nombres con apellidos " +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Ingresar los nombres completos" +
                "\n2) Busqueda secuencial M1" +
                "\n3) Busqueda secuencial M2" +
                "\n4) Busqueda secuencial M3" +
                "\n5) Salir del Programa");
                Console.Write("Opcion : ");


                respuesta = Console.ReadLine();
                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (respuesta)
                {
                    //Case para ingresar los datos del arreglo
                    case "1":
                        Ingresar(nombres);
                        Console.WriteLine();
                        Despliegue(nombres);
                        Console.ReadKey();
                        nombresA = nombres;
                        nombresD = nombres;
                        break;

                    //Case de busqueda secuencial metodo 1
                    case "2":
                        Console.Title = ("Busqueda Secuencial Metodo 1");
                        BSM1(nombres);
                        Console.ReadKey();
                        break;
                    //Case de busqueda secuencial metodo 2
                    case "3":
                        Console.Title = ("Busqueda Secuencial Metodo 2");
                        BSM2(nombresA);
                        Console.ReadKey();
                        break;
                    //Case de busqueda secuencial metodo 3
                    case "4":
                        Console.Title = ("Busqueda Secuencial Metodo 3");
                        BSM3(nombresD);
                        Console.ReadKey();
                        break;

                    //Case para salir de programa
                    case "5":
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

                // Si el valor no es 5 se seguira repitiendo el ciclo
            } while (respuesta != "5");

            Console.Read();
        }
    }
}
        