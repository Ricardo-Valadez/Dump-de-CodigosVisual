using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_de_ordenamiento_por_Mezcla
{
    class Program
    {
        //Primer Metodo Mezcla
        static void Mezcla1(double[] sueldos)
        {
            SortMezcla(sueldos, 0, sueldos.Length - 1);
        }

        //Segundo Metodo Mezcla
        static void SortMezcla(double[] sueldos, int inicio,int final )
        {
            if (inicio == final)
                return;

            int mitad = (inicio + final) / 2;

            SortMezcla(sueldos, inicio, mitad);
            SortMezcla(sueldos, mitad + 1, final);

            double[] vectorH = Merge(sueldos, inicio, mitad, mitad + 1, final);
            Array.Copy(vectorH, 0, sueldos, inicio, vectorH.Length);

        }

        //Tercer Metodo Mezcla que hace el mayo procedimiento
        static double[] Merge(double[] sueldos, int inicio1, int final1, int inicio2, int final2)
        {
            int a = inicio1;
            int b = inicio2;

            double[] Mezcla = new double[final1 - inicio1 + final2 - inicio2 + 2];

            for(int i = 0; i < Mezcla.Length; i++)
            {
                if (b != Mezcla.Length)
                {
                    if (a > final1 && b <= final2)
                    {
                        Mezcla[i] = sueldos[b];
                        b++;
                    }
                    if (b > final2 && a <= final1)
                    {
                        Mezcla[i] = sueldos[a];
                        a++;
                    }
                    if (a <= final1 && b <= final2)
                    {
                        if (sueldos[b] <= sueldos[a])
                        {
                            Mezcla[i] = sueldos[b];
                            b++;
                        }
                        else
                        {
                            Mezcla[i] = sueldos[a];
                            a++;
                        }
                    }
                }
                else
                {
                    if (a <= final1)
                    {
                        Mezcla[i] = sueldos[a];
                        a++;
                    }
                }
            }
            return Mezcla;
        }

        static void Main(string[] args)
        {
            //Valadez Leal Ricardo 19211744

            Console.Title = ("Ordenamiento Metodo Mezcla");

            //Variables auxiliares que usaremos
            double[] sueldos = new double[20];

            string respuesta;

            //Creacion de un ciclo do while
            do
            {
                //Menu
                Console.WriteLine("MENU Sueldos por Ordenamiento Mescla" +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Ingresar Sueldos" +
                "\n2) Despliegue de Sueldos desordenados y ordenados" +
                "\n3) Salir del programa");
                Console.Write("Opcion : ");


                respuesta = Console.ReadLine();
                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (respuesta)
                {
                    //Case para ingresar los sueldos
                    case "1":
                        Console.WriteLine("20 Sueldos de empleados");

                        Console.WriteLine("Despliegue del Arreglo sin Ordenar");
                        Console.WriteLine();

                        for (int i = 0; i < sueldos.Length; i++)
                        {
                            Console.Write("{0}.-Sueldo ingresado : ", i + 1);
                            sueldos[i] = double.Parse(Console.ReadLine());

                        }

                        Console.Clear();
                        break;

                    //Case para el despliegue de los arreglos
                    case "2":
                        Console.WriteLine("Despliegue en ordenaminto externo Mezcla");
                        Console.WriteLine("Arreglo Sin Ordenar");
                        Console.WriteLine();

                        for (int i = 0; i < sueldos.Length; i++)
                            Console.Write("{0}|", sueldos[i]);

                        Console.WriteLine();
                        Console.WriteLine();
                        Mezcla1(sueldos);

                        Console.WriteLine("Arreglo Ordenado por Merge");
                        Console.WriteLine();
                        for (int i = 0; i < sueldos.Length; i++)
                            Console.Write("{0}|", sueldos[i]);

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
