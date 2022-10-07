using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas_Dinámicas
{
    class Program
    {
        //Variables auxiliares globales
        public static int IndiceF=0;
        public static int IndiceI=0;
        //Metodo para ingresar 
        public static void Ingresar(Queue<string> nombres, int tamaño, string val)
        {
            if (IndiceF == tamaño)
            {
                Console.WriteLine("La Cola Esta Llena!!");
            }
            else
            {
                IndiceF = IndiceF + 1;
                nombres.Enqueue(val);
            }

            if (IndiceI == -1)
            {
                IndiceI = 0;
            }
        
        }
        //Borrar un solo dato dentro de la cola
        public static void Borrar1(Queue<string> nombres)
        {
            if (IndiceI == -1)
            {
                Console.WriteLine("La Cola Esta Vacia!!");
            }
            else
            {
                if (IndiceI == IndiceF)
                {
                    Console.WriteLine("El elemento que se elimino fue: " + nombres.Dequeue());
                    IndiceF = -1;
                    IndiceI = -1;
                }
                else
                {
                    Console.WriteLine("El elemento que se elimino fue: " + nombres.Dequeue());
                    IndiceI = -1;
                }
            }
        }
        //Metodo que limpia toda la cola
        public static void BorrarTodo(Queue<string> nombres)
        {
            if (IndiceI == -1)
            {
                Console.WriteLine("La Cola Esta Vacia!!");
            }
            else
            {
                nombres.Clear();
            }
        }
        //Metodo que busca un string dentro de la cola
        public static void Buscar(Queue<string> nombres,string busca)
        {
            if (nombres.Contains(busca) == true)
            {
                Console.WriteLine("Si se encuentra dentro de la cola : " + busca);
            }
            else
            {
                Console.WriteLine("No se encuentra dentro de la cola: " + busca);
            }
        }
        //Metodo que despliega los datos
        public static void Despliegue(Queue<string> nombres)
        {
            foreach(string x in nombres)
            {
                Console.WriteLine(x);
            }
        }

        static void Main(string[] args)
        {
            //Variables auxiliares locales
            int tamaño = 100;
            Queue<string> nombres = new Queue<string>(tamaño);
            string val;
            string respuesta;

            do
            {
                //Menu
                Console.WriteLine("MENU Pila de nombres y de Promedios " +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Ingresar Nombre " +
                "\n2) Elimimar un Nombre " +
                "\n3) Borrar todos los datos dentro de la cola" +
                "\n4) Buscar un dato" +
                "\n5) Despliegue de la cola" +
                "\n6) Salir del programa");
                Console.Write("Opcion : ");


                respuesta = Console.ReadLine();
                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (respuesta)
                {
                    //Caso para ingresar datos a la cola
                    case "1":
                        do
                        {
                            Console.WriteLine("Posicion de la cola: " + IndiceF);
                            Console.WriteLine("Ingrese el nombre que entrara a la cola");

                            val = Console.ReadLine();


                            Ingresar(nombres,tamaño,val);

                            Console.WriteLine("Va ingresar otro dato [1]Si , [2]No");
                            respuesta = Console.ReadLine();
                            Console.Clear();
                        } while (respuesta != "2");

                        Console.Clear();

                        break;



                    //Caso para elimnar un dato a la cola
                    case "2":
                        do
                        {
                            Console.WriteLine("Posicion de la cola: " + IndiceF);
                            Console.WriteLine("Quiere eliminar un dato de la pila [1]Si , [2]No");
                            respuesta = Console.ReadLine();

                            if (respuesta.Equals("1"))
                            {
                                Borrar1(nombres);
                            }

                            Console.WriteLine("Va eliminar otro dato [1]Si , [2]No");
                            respuesta = Console.ReadLine();

                        } while (respuesta != "2");

                        Console.Clear();


                        break;

                    //Caso para elimiar todos datos a la cola
                    case "3":
                        Console.WriteLine("Posicion de la cola: " + IndiceF);
                        Console.WriteLine("Quiere eliminar todos los datos de la pila [1]Si , [2]No");
                        respuesta = Console.ReadLine();
                        if (respuesta.Equals("1"))
                        {
                            BorrarTodo(nombres);
                            Console.WriteLine("");
                            Console.WriteLine("SE ELIMINARON LOS DATOS!!");
                            Console.ReadKey();
                            Console.Clear();
                        }

                        break;

                    //Caso para buscar datos en la cola
                    case "4":
                        string busca;

                        do
                        {
                            Console.WriteLine("Quiere buscar un dato de la pila [1]Si , [2]No");
                            respuesta = Console.ReadLine();

                            if (respuesta.Equals("1"))
                            {
                                Console.WriteLine("Ingresa el valor a buscar en pila de nombres");
                                busca = Console.ReadLine();

                                Buscar(nombres,busca);

                            }


                        } while (respuesta.Equals("1"));

                        Console.Clear();
                        break;

                    //Caso que te despliega los datos dentro de la cola
                    case "5":
                        Console.WriteLine("Cola de nombres");
                        Console.WriteLine("");

                        Despliegue(nombres);
                        Console.WriteLine("");
                        Console.WriteLine("Presione cualquier tecla para regresar al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;

                    //Caso que te saca del programa
                    case "6":
                        Console.WriteLine("Presione cualquier tecla para salir del programa");
                        break;


                    //Case default si el valor no es ninguno de los que queremos
                    default:
                        Console.WriteLine("\nNo selecciono ninguna opcion");
                        Console.WriteLine("\nPresione <enter> para regresar al menu");
                        Console.WriteLine();
                        Console.Read();
                        Console.Clear();
                        Console.Read();
                        break;
                }

                // Si el valor no es 4 se seguira repitiendo el ciclo
            } while (respuesta != "6");

            Console.Read();
        }
    }
}

