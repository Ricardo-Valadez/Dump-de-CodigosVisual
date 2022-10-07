using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usando_Aritmetica_modular
{
    class Program
    {
        //Todas las variables auxiliares globales
        static Random aleatorio = new Random();

        //Metodo para ingresar datos a los arreglos
        static void Ingresar(int[] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = aleatorio.Next(100, 2000);              
            }
            Console.WriteLine("Se lleno el Arreglo!!");


            Console.ReadKey();
        }

        //Metodo que despliega el contenido del arreglo
        static void Despliegue(int[] arreglo)
        {
            for (int i = 0; i < arreglo.Length; i++)
                Console.WriteLine("[{1}]:{0}|", arreglo[i],i+1);
        }

        //Metodo que cambia la dirreccion a un nuevo arreglo
        static void Direction (int[] arreglo1,int[] arreglo2)
        {
            int indicador = 0, encuentro, tamaño = arreglo1.Length-1;

            for(int i = 0; i <= tamaño; i++)
            {
                indicador = (arreglo1[i] % tamaño) + 1;

                while (arreglo2[indicador] != 0) 
                {
                    encuentro = indicador + 1;

                    if (encuentro > tamaño)
                    {
                        indicador = 0;
                    }
                    else
                    {
                        indicador = encuentro;
                    }
                }
                arreglo2[indicador] = arreglo1[i];
            }
            Console.WriteLine("Los nuevos valores han sido asignados");
            Console.WriteLine("");
            for (int f = 0; f < arreglo2.Length; f++)
            {
                Console.Write("[{0}].- {1}\t\t\t\t[{2}].-{3}\n", f + 1, arreglo1[f], f + 1, arreglo2[f]);
            }
        }

        //Metodo que muestra el nuevo arreglo y busca un dato dentro de el
        static void Search(int[] arreglo2)
        {
            int indicador, dirreccionT, tamaño = arreglo2.Length - 1,busca;

            Console.WriteLine("//Matriculas del arreglo Indice//");
            Console.WriteLine("");
            Despliegue(arreglo2);
            Console.WriteLine("");

            Console.WriteLine("Ingresar la matricula a buscar");
            busca = Int32.Parse(Console.ReadLine());

            indicador = (busca % tamaño) + 1;

            Console.WriteLine("");

            if (arreglo2[indicador] == busca)
            {
                Console.Write("El elemento :{0}: esta en la posicion: [{1}]", busca, indicador + 1);
            }
            else
            {
                dirreccionT = indicador + 1;
                while (dirreccionT <= tamaño && arreglo2[dirreccionT] != busca && arreglo2[dirreccionT] != 0 && dirreccionT != indicador)
                {
                    dirreccionT++;
                    if (dirreccionT > tamaño)
                    {
                        dirreccionT = 0;
                    }

                    if (arreglo2[indicador] == busca)
                    {
                        Console.WriteLine("El elemento :{0}: esta en la posicion: [{1}]", busca, dirreccionT + 1);
                    }
                    else
                    {
                        Console.WriteLine("El elemento :{0}: no esta dentro del arreglo!!", busca);

                    }
                }

            }
        }

        static void Main(string[] args)
        {

            //Valadez Leal Ricardo 19211744

            Console.Title = ("Usando Aritmetica Modular");
           
            //Todas las variables auxiliares que usaremos
            int[] matriculas = new int[100];
            int[] dato = new int[100];
            string respuesta;

            //Creacion de un ciclo do while
            do
            {
                Console.Clear();
                //Menu
                Console.WriteLine("MENU Aritmetica Modular " +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Creacion de matriculas" +
                "\n2) Despliegue de matriculas" +
                "\n3) Asignacion de nueva direccion" +
                "\n4) Despliegue de nuevos indice y busqueda" +
                "\n5) Salir del Programa");
                Console.Write("Opcion : ");


                respuesta = Console.ReadLine();
                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (respuesta)
                {
                    //Case para ingresar los datos del arreglo
                    case "1":
                        Console.Title = ("Generacion de matriculas");
                        Ingresar(matriculas);
                        //Console.ReadKey();
                        break;

                    //Case de busqueda secuencial metodo 1
                    case "2":
                        Console.Title = ("Despliegue del arreglo");
                        Despliegue(matriculas);
                        Console.ReadKey();
                        break;
                    //Case de busqueda secuencial metodo 2
                    case "3":
                        Console.Title = ("Dirreccion de indice");
                        Direction(matriculas,dato);
                        Console.ReadKey();
                        break;
                    //Case de busqueda secuencial metodo 3
                    case "4":
                        Console.Title = ("Busqueda");
                        Search(dato);
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
