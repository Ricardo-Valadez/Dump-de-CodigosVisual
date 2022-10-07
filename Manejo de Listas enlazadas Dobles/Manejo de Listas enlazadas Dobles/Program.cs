using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manejo_de_Listas_enlazadas_Dobles
{
    class Program
    {
        //Variables auxiliares goblales incluyendo los de las clases 
        static Nodo indiceI;
        static Nodo indiceF;
        static Nodo indiceT;
        static Nodo a;
        static Nodo s;

        static float num;
        static float valortemp;
        static int tamaño = 0;


           

        //Clase Nodo
        class Nodo
        {
            public float val;
            public Nodo direccionder;
            public Nodo direccionizq;
        }

        //Metodo para ingresar un dato en lista enlazada
        public static void Ingresar()
        {
            if (indiceI == null)
            {
                indiceI = new Nodo();
                indiceI.val = num;
                indiceF = indiceI;
                indiceF.direccionder = null;
                indiceI.direccionizq = null;

            }
            else
            {
                if (num < indiceI.val)
                {
                    indiceT = new Nodo();
                    indiceT.val = num;
                    indiceT.direccionder = indiceI;
                    indiceI.direccionizq = indiceT;
                    indiceI = indiceT;
                    indiceT.direccionizq = null;
                }
                else
                {
                    if (num > indiceF.val)
                    {
                        indiceT = new Nodo();
                        indiceT.val = num;
                        indiceT.direccionizq = indiceF;
                        indiceF.direccionder = indiceT;
                        indiceF = indiceT;
                        indiceF.direccionder = null;
                    }
                    else
                    {
                        a = indiceI;
                        s = indiceI.direccionder = null;

                        while (num > s.val)
                        {
                            a = s;
                            s = indiceI.direccionder;
                        }

                        indiceT = new Nodo();
                        indiceT.val = num;
                        indiceT.direccionizq = a;
                        a.direccionder = indiceT;
                        indiceT.direccionder = s;
                        s.direccionizq = indiceT;


                    }
                }
            }

            tamaño = tamaño + 1;
        }
        //Metodo que te borra los datos
        public static void Borrar()
        {
            if (indiceI == null)
            {
                Console.WriteLine("La lista esta Llena!!");
                Console.ReadKey();
            }

            else if (indiceI == indiceF)
            {
                if (num == indiceI.val)
                {
                    valortemp = indiceI.val;
                    indiceI = null;
                    indiceF = null;

                    tamaño = tamaño - 1;

                }
                else
                {
                    Console.WriteLine("El dato No existe!!");
                    Console.ReadKey();
                }

            }
            else if (num > indiceI.val)
            {
                valortemp = indiceI.val;
                indiceT = indiceI;
                indiceI = indiceI.direccionder;
                indiceI.direccionizq = null;

                tamaño = tamaño - 1;
            }
            else
            {
                a = indiceI;
                s = indiceI.direccionder;
                while(num != s.val && s != indiceF)
                {
                    a = s;
                    s = s.direccionder;
                }

                if (s == indiceF)
                {
                    Console.WriteLine("El dato No existe");
                    Console.ReadKey();
                }
                else
                {
                    valortemp = s.val;
                    indiceT = s.direccionder;
                    indiceT.direccionizq = a;
                    a.direccionder = indiceT;

                    tamaño = tamaño - 1;
                }
            }

        }
        //Metodo que te despliega los datos por la izquierda
        public static void DespliegueI()
        {
            Console.WriteLine("Lista de tamaño: " + tamaño);

            if (tamaño == 0)
            {
                Console.WriteLine("Lista vacia!!");
            }
            indiceT = indiceI;
            Console.WriteLine("");

            while (indiceT != null)
            {
                Console.WriteLine("["+indiceT.val+"]");
                indiceT = indiceT.direccionder;
            }
            Console.WriteLine("");
        }
        //Metodo que te depliega los datos por la derecha
        public static void DespliegueD()
        {
            Console.WriteLine("Lista de tamaño: " + tamaño);

            if (tamaño == 0)
            {
                Console.WriteLine("Lista vacia!!");
            }
            indiceT = indiceF;
            Console.WriteLine("");

            while (indiceT != null)
            {
                Console.WriteLine("[" + indiceT.val + "]");
                indiceT = indiceT.direccionizq;
            }
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            //Valadez Leal Ricardo 19211744


            Console.Title = ("Manejo de lista enlazada Doble");
            //Todas las variables auxiliraes que usaremos


            string respuesta;

            //Creacion de un ciclo do while
            do
            {
                //Menu
                Console.WriteLine("MENU Manejo de Listas enlazadas Dobles " +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Ingresar sueldos" +
                "\n2) Elimimar sueldos" +
                "\n3) Despliegue por la izquierda" +
                "\n4) Despliegue por la derecha" +
                "\n5) Salir del programa");
                Console.Write("Opcion : ");


                respuesta = Console.ReadLine();
                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (respuesta)
                {
                    case "1":
                        //Caso para ingresar datos a la lista enlaza
                        do
                        {
                            Console.WriteLine("Lista enlazada tamaño Posicion: " + tamaño);
                            Console.WriteLine("Ingrese el sueldo que entrara a la lista enlazada doble");

                            num = float.Parse(Console.ReadLine());
                            //Llamamos el metodo ingresar
                            Ingresar();

                            Console.WriteLine("");
                            Console.WriteLine("Va ingresar otro dato [1]Si , [2]No");
                            respuesta = Console.ReadLine();

                            Console.Clear();

                        } while (respuesta.Equals("1"));

                        Console.Clear();

                        break;

                    case "2":
                        //Caso para eliminar datos
                        do
                        {
                            Console.WriteLine("Lista enlazada tamaño Posicion: " + tamaño);
                            Console.WriteLine("Quiere eliminar un dato de la lista enlazada [1]Si , [2]No");
                            respuesta = Console.ReadLine();

                            if (respuesta == "1")
                            {
                                //Llamamos al metodo borrar
                                Borrar();
                            }

                            Console.WriteLine("");
                            Console.WriteLine("Quiere quedarse eliminando [1]Si , [2]No");
                            respuesta = Console.ReadLine();
                            Console.Clear();

                        } while (respuesta.Equals("1"));

                        Console.Clear();

                        break;

                    case "3":
                        //Caso para el despliegue de datos por la izquierda 
                        Console.WriteLine("");

                        DespliegueI();

                        Console.WriteLine("");
                        Console.WriteLine("Presione cualquier tecla para regresar al menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    //Caso para el despliegue de datos por la izquierda 
                    case "4":
                        Console.WriteLine("");

                        DespliegueD();

                        Console.WriteLine("");
                        Console.WriteLine("Presione cualquier tecla para regresar al menu");
                        Console.ReadKey();
                        Console.Clear(); break;

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
            } while (respuesta != "5");

            Console.Read();
        }
    }
}
