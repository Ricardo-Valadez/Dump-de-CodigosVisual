using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodo_dos_de_intercalación_simple
{
    class Program
    {
        static void IntercalacionM2(int[] vector, int[] vector2)
        {
            int N, M;

            N = vector.Length;
            M = vector2.Length;

            int[] vector3=new int[N + M];
            int i = 0,j = 0, k = 0;

            while (i < N & j < M)
            {
                if (vector[i] <= vector2[j])
                {
                    vector3[k] = vector[i];
                    i++;
                }
                else
                {
                    vector3[k] = vector2[j];
                    j++;
                }

                k++;

              }

            if (i == N)
            {
                for (int p=j;p==M;p++)
                {
                    vector3[k] = vector2[p];
                    k++;
                }
            }
            else
            {
                for (int p = j; p == N; p++)
                {
                    vector3[k] = vector[p];
                    k++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Arreglo [3]");
            Console.WriteLine();
            for (int F = 0; F < vector3.Length-1; F++)
            {
                Console.Write("{0}|", vector3[F]);
            }
        }
        static void BubbleSimp(int[] vector1, int[] vector2)
        {
            int x;

            for (int a = 0; a < vector1.Length; a++)
            {
                for (int b = 0; b < vector1.Length - 1; b++)
                {
                    if (vector1[b].CompareTo(vector1[b + 1]) > 0)
                    {
                        x = vector1[b];
                        vector1[b] = vector1[b + 1];
                        vector1[b + 1] = x;
                    }
                }
            }

            for (int a = 0; a < vector2.Length; a++)
            {
                for (int b = 0; b < vector2.Length - 1; b++)
                {
                    if (vector2[b].CompareTo(vector2[b + 1]) > 0)
                    {
                        x = vector2[b];
                        vector2[b] = vector2[b + 1];
                        vector2[b + 1] = x;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //Valadez Leal Ricardo 19211744

            Console.Title = ("Ordenamiento Metodo 2 Intercalacion Simple");


            //Todas las variables auxiliraes que usaremos
            int[] vector = new int[12];
            int[] vector2 = new int[15];

            int N = vector.Length;
            int M = vector2.Length;

            Random aletorio = new Random();

            string respuesta;

            //Creacion de un ciclo do while
            do
            {
                //Menu
                Console.WriteLine("MENU Arreglos por Ordenamiento Metodo 2" +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Generar dos Arreglos Aletorios" +
                "\n2) Tercer Arreglo con Metodo 2" +
                "\n3) Salir del programa");
                Console.Write("Opcion : ");


                respuesta = Console.ReadLine();
                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (respuesta)
                {
                    //Case donde se despliega los arreglos aletorios
                    case "1":



                        Console.WriteLine("Despliegue del Arreglo sin Ordenar");
                        Console.WriteLine();

                        for (int i = 0; i < vector.Length; i++)
                        {
                            vector[i] = aletorio.Next(0, 1000);
                        }

                        for (int i = 0; i < vector2.Length; i++)
                        {
                            vector2[i] = aletorio.Next(0, 1000);
                        }
                        Console.WriteLine("Primer Arreglo Desordenado [12]");
                        Console.WriteLine("Arreglo [1]");
                        Console.WriteLine();
                        for (int i = 0; i < vector.Length; i++)
                        {
                            Console.Write("{0}|", vector[i]);
                        }
                        Console.WriteLine();

                        Console.WriteLine();
                        Console.WriteLine("Segundo Arreglo Desordenado [15]");
                        Console.WriteLine("Arreglo [2]");
                        Console.WriteLine();
                        for (int i = 0; i < vector2.Length; i++)
                        {
                            Console.Write("{0}|", vector2[i]);
                        }

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Case ordenado por el segundo metodo
                    case "2":
                        BubbleSimp(vector, vector2);
                        Console.WriteLine("Despliegue en ordenaminto externo Metodo 2");
                        Console.WriteLine("Arreglos Ordenados");
                        Console.WriteLine();
                        Console.WriteLine("Arreglo [1]");
                        Console.WriteLine();
                        for (int i = 0; i < vector.Length; i++)
                        {
                            Console.Write("{0}|", vector[i]);
                        }

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Arreglo [2]");
                        Console.WriteLine();
                        for (int i = 0; i < vector2.Length; i++)
                        {
                            Console.Write("{0}|", vector2[i]);
                        }

                        Console.WriteLine();
                        Console.WriteLine();

                        IntercalacionM2(vector, vector2);

                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Case para salir de programa
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