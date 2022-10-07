using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usando_Pilas_con_Stack
{
    class Program
    {
        //Metodos que verifican si estan llenas o vacias las pilas
        public static bool Vacia(int top)
        {
            if (top == -1)
            {
                return true;
            }
            else
                return false;
        }
        public static bool Llena(int top, int tamaño)
        {
            if (top == tamaño)
            {
                return true;
            }
            else
                return false;
        }
        //Metodo para ingresar
        public static int Ingresar(Stack<string>nombres,Stack<int>promedios,int tamaño,int top,string val,int val2)
        {
            if (Llena(top, tamaño) == true)
            {
                Console.WriteLine("Pila llena");
                Console.WriteLine("Overflow");
                Console.WriteLine("");
            }
            else
            {
                nombres.Push(val);
                promedios.Push(val2);
                top = top + 1;
            }

            return top;
        }
        //Metodo para eliminar 
        public static int Eliminar(Stack<string> nombres, Stack<int> promedios, int top)
        {
            if (Vacia(top) == true)
            {
                Console.WriteLine("Pila Vacia");
                Console.WriteLine("");

            }
            else
            {
                Console.WriteLine($"Valores eliminados {nombres.Peek()},{promedios.Peek()}");
                nombres.Pop();
                promedios.Pop();
                top = top - 1;

            }
            return top;
        }
        //Metodo para buscar un dato dentro de la pila
        public static void Busca(Stack<string> nombres, Stack<int> promedios, int top, string busca, int busca2)
        {
            int badera = 0;

            if (nombres.Contains(busca) == true)
            {
                Console.WriteLine("SE ENCUNTRA {0}", busca);
                badera = 1;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("NO SE ENCUNTRA {0}", busca);

            }


            if (promedios.Contains(busca2) == true)
            {
                Console.WriteLine("SE ENCUNTRA {0}", busca2);
                badera = 1;
                Console.ReadKey();
            }
            else
            Console.WriteLine("NO SE ENCUNTRA {0}", busca2);

        }
        //Metodo que despliega los datos
        public static void Despliegue(Stack<string> nombres, Stack<int> promedios, int top)
        {
            foreach(string valor in nombres)
            {
                Console.WriteLine(valor + "|");

            }

            foreach (int valor2 in promedios)
            {
                Console.WriteLine(valor2 + "|");
            }
        }



        static void Main(string[] args)
        {
            //Valadez Leal Ricardo 19211744


            Console.Title = ("Pila dinamica de nombres y promedios");
            
            //Variables auxiliriaes
            Stack<string> nombres = new Stack<string>();
            Stack<int> promedios = new Stack<int>();
            int tamaño;
            int top = 0;
            string val;
            int val2;
            string respuesta = " ";
            int temporal = 0;
            string opcion;
            //Se ingresa el tamaño de la pila
            Console.Write("Tamaño de la pila: ");
            tamaño = Int32.Parse(Console.ReadLine());
            Console.Clear();

            do
            {
                //Menu
                Console.WriteLine("MENU Pila de nombres y de Promedios " +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Ingresar Nombre y Promedio" +
                "\n2) Elimimar un Nombre y Promedio" +
                "\n3) Borrar todas las pilas"+
                "\n4) Buscar un dato" +
                "\n5) Salir del programa");
                Console.Write("Opcion : ");


                opcion = Console.ReadLine();
                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (opcion)
                {
                    case "1":
                        //Caso para ingresar datos a la pila
                        do
                        {
                            Console.WriteLine("Ingresa un valor [" + (top + 1) + "]:");
                            Console.WriteLine("Ingrese el nombre del alumno que entrara a a la pila");

                            val = Console.ReadLine();

                            Console.WriteLine("Ingrese el promedio que entrara a a la pila");

                            val2 = Int32.Parse(Console.ReadLine());

                            top = Ingresar(nombres,promedios,tamaño,top,val,val2);


                            Console.WriteLine("Va ingresar otro dato [1]Si , [2]No");
                            respuesta = Console.ReadLine();
                            Console.Clear();
                        } while (respuesta != "2");

                        Console.Clear();

                        break;
                    
                     
                        
                    //Caso para elimnar datos a la pila

                    case "2":
                        do
                        {
                            Console.WriteLine("Pila tamaño: " + top);
                            Console.WriteLine("Quiere eliminar un dato de la pila [1]Si , [2]No");
                            respuesta = Console.ReadLine();

                            if (respuesta.Equals("1"))
                            {
                                top = Eliminar(nombres, promedios, top);
                            }

                            Console.WriteLine("Va eliminar otro dato [1]Si , [2]No");
                            respuesta = Console.ReadLine();

                        } while (respuesta != "2");

                        Console.Clear();


                        break;

                    //Caso para elimiar todos datos a la pila

                    case "3":
                        Console.WriteLine("Pila tamaño: " + top);
                        Console.WriteLine("Quiere eliminar todos los datos de la pila [1]Si , [2]No");
                        respuesta = Console.ReadLine();
                        if (respuesta.Equals("1"))
                        {
                            nombres.Clear();
                            promedios.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("SE ELIMINARON LOS DATOS DE AMBAS PILAS");
                            top = 0;
                            Console.Clear();
                        }

                        break;
                    //Caso para buscar datos en la pila
                    case "4":
                        string busca;
                        int busca2;
                        do
                        {
                            Console.WriteLine("Pila tamaño: " + top);
                            Console.WriteLine("Quiere buscar un dato de la pila [1]Si , [2]No");
                            respuesta = Console.ReadLine();

                            if (respuesta.Equals("1"))
                            {
                                Console.WriteLine("Ingresa el valor a buscar en pila de nombres");
                                busca = Console.ReadLine();
                                Console.WriteLine("Ingresa el valor a buscar en pila de promedios");
                                busca2 = Int32.Parse(Console.ReadLine());

                                Busca(nombres, promedios, top, busca, busca2);
                            }


                        } while (respuesta.Equals("1"));

                        Console.Clear();
                        break;

                    //Caso que te saca del programa
                    case "5":
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
            } while (opcion != "5");

            Console.Read();
        }
    }
}

        