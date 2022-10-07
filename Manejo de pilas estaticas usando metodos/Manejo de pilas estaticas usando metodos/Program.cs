using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_de_pilas_estaticas_usando_metodos
{
    class Program
    {
        public static bool Vacia(int Top)
        {
            if (Top == -1)
            {
                return true;
            }
            else
                return false;
        }

        public static bool Capacidad(int Top, int Tamaño)
        {
            if (Top == Tamaño)
            {
                return true;
            }
            else
                return false;
        }

        public static void Ingresar(int[] Edades,int Espacio,int Top,int var,string Pregunta)
        {
            Console.Write("Ingrese una edad mayor a 18: ({0}): ", Top+1);
            var = Int32.Parse(Console.ReadLine());

            if (Capacidad(Top,Espacio) == true)
            {
                Console.WriteLine("Pila llena");
                Console.WriteLine("Overflow");

            }
            else
            {
                if (var < 18)
                {
                    Console.WriteLine("Por favor ingrese un numero MAYOR A 18");
                    Console.ReadKey();
                }
                else
                {

                    Edades[Top] = var;
                    Top = Top + 1;

                    Console.WriteLine();
                    Console.WriteLine("Va ingresar otro dato [1]Si , [2]No");
                    Pregunta = Console.ReadLine();

                    if(Pregunta != "2")
                    {
                        Ingresar(Edades, Espacio, Top, var, Pregunta);
                        Console.Clear();
                    }
                }

            }



        }

        public static void  Eliminar(int[] Edades, int Top, int Aux)
        {
            string Pregunta;
            Console.WriteLine("Quiere eliminar un dato de la pila [1]Si , [2]No");
            Pregunta = Console.ReadLine();

            if (Pregunta == "1")
            {
                if (Vacia(Top) == true)
                {
                    Console.WriteLine("Pila Vacia");

                }
                else
                {
                    Aux = Edades[Top - 1];
                    Console.WriteLine($"Valor eliminado {Aux}");
                    Top = Top - 1;
                    Edades[Top - 1] = 0;
                    Eliminar(Edades,Top, Aux);
                }
            }

        }

        //Metodo para ingresar nombres Nombres
        public static void Imprimir(int[] Edades, int Top)
        {
            for (int i = Top - 1; i >= 0; i--)
            {
                Console.WriteLine(Edades[i] + "|");
            }



        }

        static void Main(string[] args)
        {
            int Espacio = 50;
            int[] Edades = new int[Espacio];
            int Top = 0;
            int var=0;
            string Pregunta="";
            int Aux = 0;

            string Opcion;

            do
            {
                //Menu
                Console.WriteLine("MENU Pila de Edades " +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Ingresar Edades" +
                "\n2) Elimimar Edades" +
                "\n3) Despliegue de datos" +
                "\n4) Salir del programa");
                Console.Write("Opcion : ");


                Opcion = Console.ReadLine();

                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (Opcion)
                {
                    case "1":
                        //Caso para ingresar datos a la pila
                            Ingresar(Edades,Espacio,Top,var,Pregunta);
                        break;

                    case "2":
                        //Caso para eliminar datos
                        Eliminar(Edades, Top, Aux);
                        break;

                    case "3":
                        //Caso que despliega la info
                        Console.WriteLine("Pila de edades");
                        Console.WriteLine("");

                        Imprimir(Edades, Top);

                        Console.WriteLine("Presione cualquier tecla para regresar al menu");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    //Caso que te saca del programa
                    case "4":
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
            } while (Opcion != "4");

            Console.Read();
        }
    }
}

