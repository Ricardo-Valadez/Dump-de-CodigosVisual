using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilas_estáticas_de_estudiantes
{
    class Program
    {
        public static void Imprimir(string[] Nombres, int Top)
        {
            for (int i = Top - 1; i >= 0; i--)
            {
                Console.WriteLine(Nombres[i]+"|");
            }

        }

        public static bool Llena(int Top,int Tamaño)
        {
            if (Top == Tamaño)
            {
                return true;
            }
            else
                return false;
        }
        public static int Insertar(string[] Nombres,int Tamaño,int Top, string Elemento)
        {
            if (Llena(Top,Tamaño) == true)
            {
                Console.WriteLine("Pila llena");
                Console.WriteLine("Overflow");

            }
            else
            {
                Nombres[Top] = Elemento;
                Top = Top + 1;
            }

            return Top;
        }

        public static bool Vacia(int Top)
        {
            if (Top == -1)
            {
                return true;
            }
            else
                return false;
        }
        public static int Eliminar(string[] Nombres, int Top, string Temporal)
        {
            if (Vacia(Top) == true)
            {
                Console.WriteLine("Pila Vacia");

            }
            else
            {
                Temporal = Nombres[Top - 1];
                Console.WriteLine($"Valor eliminado {Temporal}");
                Nombres[Top - 1] = null;
                Top = Top - 1;
            }
            return Top;
        }
        static void Main(string[] args)
        {
            //Valadez Leal Ricardo 19211744


            Console.Title=("Pila estatica de nombres");

            //Crea un programa donde insertes en una pila nombres de alumnos, en otra su promedio, 
            //se dejara de hacer las inserciones mientras el usuario así lo decida, luego realiza 
            //las eliminaciones mientras el usuario así lo decida, y para finalizar muestra los valores de la pila. 
            //Recuerda usar los Pseudocodigo que se vieron en clase. cabe aclarar que para el despliegue de los valores 
            //debes de tomar en cuenta el concepto de pila para mostrarlos. 
            //Las pilas tienen un máximo de 100 espacios disponibles cada una.

            int Tamaño=100;
            string Elemento;
            int Top = 0;
            string Otro = " ";
            string Temporal=" ";
            string[] Nombres=new string[Tamaño];

            //Variable para usar el menu
            string Seleccion;
            //Creacion de un ciclo do while
            do
            {
                Console.WriteLine("MENU División Números Tipo Doble " +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Pila de nombres" +
                "\n2) Pila de promedios" +
                "\n3) Salir del programa" );
                Console.Write("Opcion : ");


                Seleccion = Console.ReadLine();
                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (Seleccion)
                {
                    case "1":
                        string Seleccion2;
                        Console.WriteLine("Elige una opcion\n" + "\n1) Insertar" +"\n2) Eliminar" +"\n3) Despliegue" + "\n4)Salir");
                        Console.Write("Opcion : ");
                        Seleccion2=Console.ReadLine();

                        do
                        {
                            switch (Seleccion2)
                            {
                                case "1":
                                    Console.WriteLine("Ingreso");
                                    do
                                    {
                                        Console.WriteLine("Ingrese el elemento que entrara a a la pila");
                                        Elemento = Console.ReadLine();

                                        Top = Insertar(Nombres, Tamaño,Top, Elemento);

                                        Console.WriteLine("Va ingresar otro dato [1]Si , [2]No");
                                        Otro = Console.ReadLine();

                                    } while (Otro.Equals("1"));
                                    Console.Clear();

                                    break;

                                case "2":

                                    do
                                    {
                                        Console.WriteLine("Pila tamaño " + Top);
                                        Console.WriteLine("Quiere eliminar un dato de la pila [1]Si , [2]No");
                                        Elemento = Console.ReadLine();

                                        Top = Eliminar(Nombres,Top, Elemento);

                                        Console.WriteLine("Va ingresar otro dato [1]Si , [2]No");
                                        Otro = Console.ReadLine();

                                    } while (Otro.Equals("1"));

                                    break;

                                case "3":
                                    Imprimir(Nombres, Top);

                                    break;

                                case "4":

                                    break;
                            }

                        } while (Seleccion != "4");

                        break;
                    case "2":

                        break;

                    case "3":
                        Console.WriteLine("");
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

                // Si el valor no es "b" se seguira repitiendo el ciclo
            } while (Seleccion != "3");

            Console.Read();
        }
    }
}
