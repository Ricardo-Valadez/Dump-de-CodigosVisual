using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usando_Listas_Enlazadas_Circulares
{
    class Program
    {
        //Variables auxiliares goblales incluyendo los de las clases 
        static Nodo indiceI;
        static Nodo indiceF;
        static Nodo indiceT;
        static Nodo indiceA;
        static Nodo indiceS;

        static String pais;
        static String valortemp;
        static int tamaño = 0;

        //Clase Nodo
        class Nodo
        {
            public string val;
            public Nodo direccion;
        }

        //Metodo para ingresar un dato en lista enlazada
        public static void Ingresar()
        {
            if (indiceI == null)
            {
                indiceI = new Nodo();
                indiceI.val = pais;
                indiceF = indiceI;
                indiceF.direccion = indiceI;

            }
            else
            {
                if (string.Compare(pais,indiceI.val)<0)
                {
                    indiceT = new Nodo()
                    {
                        val = pais,
                        direccion = indiceI
                    };

                    indiceI = indiceT;
                    indiceF.direccion = indiceI;
                                                            
                }
                else if (string.Compare(pais,indiceF.val)>0)
                {
                    indiceT = new Nodo()
                    {
                        val = pais,
                        direccion = indiceI
                    };

                    indiceF.direccion = indiceT;
                    indiceF = indiceT;
                }
                else
                {
                    indiceA = indiceI;
                    indiceS = indiceI.direccion;

                    while (string.Compare(pais, indiceS.val) > 0)
                    {
                        indiceA = indiceS;
                        indiceS = indiceS.direccion;
                    }


                    indiceT = new Nodo()
                    {
                        val = pais,
                        direccion = indiceS
                    };

                    indiceA.direccion = indiceT;
                }

            }

            tamaño = tamaño + 1;
        }
        //Metodo para borrar los datos en la lista enlazada
        public static void Borrar()
        {
            if (indiceI == null)
            {
                Console.WriteLine("La Lista Esta Vacia!!");
                Console.ReadKey();
            }
            else if (indiceI == indiceF)
            {
                if (pais == indiceA.val)
                {
                    valortemp = indiceI.val;

                    indiceI = null;
                    indiceF = null;

                    Console.WriteLine("Se elimino: " + valortemp);
                    Console.ReadKey();

                    tamaño = tamaño - 1;
                }
                else
                {
                    Console.WriteLine("El dato no Existe!!");
                    Console.ReadKey();
                }
            }
            else if (pais == indiceA.val)
            {
                valortemp = indiceA.val;

                indiceT = indiceI;
                indiceI = indiceI.direccion;
                indiceT = null;
                indiceF.direccion = indiceI;

                tamaño = tamaño - 1;
            }
            else if (pais == indiceF.val)
            {
                valortemp = indiceF.val;

                indiceA = indiceI;
                indiceS = indiceI.direccion;

                while (indiceS != indiceF)
                {
                    indiceA = indiceS;
                    indiceS = indiceS.direccion;
                }

                indiceF = indiceA;
                indiceS = null;
                indiceF.direccion = indiceI;

                Console.WriteLine("Se elimino: " + valortemp);
                Console.ReadKey();

                tamaño = tamaño - 1;
            }
            else
            {
                indiceA = indiceI;
                indiceS = indiceI.direccion;

                while(pais != indiceA.val && indiceS != indiceF)
                {
                    indiceA = indiceS;
                    indiceS = indiceS.direccion;
                }

                if (indiceS == indiceF)
                {
                    Console.WriteLine("El dato no Existe!!");
                    Console.ReadKey();
                }
                else
                {
                    valortemp = indiceS.val;
                    indiceA = indiceT.direccion;
                    indiceS = indiceI;


                    Console.WriteLine("Se elimino: " + valortemp);
                    Console.ReadKey();

                    tamaño = tamaño - 1;
                }
            }
            
        }
        //Metodo que despliega todos los datos de la lista enlazasa
        public static void Despliegue()
        {
            Console.WriteLine("Tamaño de la lista: " + tamaño);
            Console.WriteLine("");

            if(indiceI != null)
            {
                indiceA = indiceI;
                indiceS = indiceI.direccion;

                Console.WriteLine("[" + indiceA.val + "]");

                while (indiceS != indiceA)
                {
                    Console.WriteLine("[" + indiceS.val + "]");
                    indiceS = indiceS.direccion;
                }
                Console.WriteLine("");
            }
            else
            {
                indiceA = indiceS = null;
                Console.WriteLine("La lista esta Vacia!!");
            }


        }

        static void Main(string[] args)
        {
            //Valadez Leal Ricardo 19211744

            Console.Title = ("Manejo de lista enlazada circular");
            //Todas las variables auxiliraes que usaremos

            string respuesta;

            //Creacion de un ciclo do while
            do
            {
                //Menu
                Console.WriteLine("MENU Listas Enlazadas Circulares" +
                "\n---------------------------------");
                Console.WriteLine("Elige una opcion\n" +
                "\n1) Ingresar Ciudades" +
                "\n2) Elimimar Ciudades" +
                "\n3) Despliegue de Ciudades" +
                "\n4) Salir del programa");
                Console.Write("Opcion : ");


                respuesta = Console.ReadLine();
                Console.Clear();

                //Mediante un swich creamos un menu que puede realizar varias acciones 
                switch (respuesta)
                {
                    case "1":
                        //Caso para ingresar datos a la lista enlazada
                        do
                        {
                            Console.WriteLine("Lista tamaño Posicion: " + tamaño);
                            Console.WriteLine("Ingrese la ciudad que entrara a la lista enlazada");

                            pais = Console.ReadLine();
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
                            Console.WriteLine("Lista tamaño Posicion: " + tamaño);
                            Console.WriteLine("Quiere eliminar un dato de la lista [1]Si , [2]No");
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
                        //Caso para el despliegue de datos 
                        Console.WriteLine("Lista tamaño Posicion: " + tamaño);
                        Console.WriteLine("");

                        Despliegue();

                        Console.WriteLine("");
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
            } while (respuesta != "4");

            Console.Read();
        }
    }
}
    

