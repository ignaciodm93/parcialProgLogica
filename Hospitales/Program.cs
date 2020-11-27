using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitales
{

    class Program
    {

        static Hospital Aleman = new Hospital("Aleman", "Roma 753", EEspecialidad.ClinicaGeneral);

        static Hospital Quemado = new Hospital("Del Quemado", "Avenida Light my Fire 1967", EEspecialidad.Quemaduras);

        static Hospital RicardoGutierrez = new Hospital("Dr Ricardo Gutierrez", "Avenida Belgrano 3243", EEspecialidad.Pediatria);

        static List<Paciente> Curados = new List<Paciente>();

        static void Main(string[] args)
        {

            PreguntarCargaAutomatica();

            Console.Clear();

            Menu();

            Console.ReadKey();
        }


        /// <summary>
        /// Metodo para cargar informacion de base de manera automatica.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="Q"></param>
        /// <param name="R"></param>
        public static void PreguntarCargaAutomatica()
        {

            Console.WriteLine("¿Deseas cargar datos automaticamente?");
            Console.WriteLine("1. Si \n2. No");

            int ans = validarInt(1, 2);

            if (ans == 1)
            {


                Paciente Mu = new Paciente("Mu", 12, EDolencia.DolorDeCabeza);
                Paciente Aldebaran = new Paciente("Aldebaran", 17, EDolencia.QuemaduraGeneral);
                Paciente Saga = new Paciente("Saga", 29, EDolencia.Gripezinha);
                Paciente Mefisto = new Paciente("Mefisto", 11, EDolencia.DolorDeEspalda);
                Paciente Aioria = new Paciente("Aioria", 33, EDolencia.DolorDeCabeza);
                Paciente Shaka = new Paciente("Shaka", 20, EDolencia.QuemaduraAguaCaliente);
                Paciente Dohko = new Paciente("Dohko", 45, EDolencia.Gripezinha);
                Paciente Milo = new Paciente("Milo", 30, EDolencia.DolorDeCabeza);
                Paciente Aioros = new Paciente("Aioros", 60, EDolencia.QuemaduraAguaCaliente);

                DerivarPaciente(Mu);
                DerivarPaciente(Aldebaran);
                DerivarPaciente(Saga);
                DerivarPaciente(Mefisto);
                DerivarPaciente(Aioria);
                DerivarPaciente(Shaka);
                DerivarPaciente(Dohko);
                DerivarPaciente(Milo);
                DerivarPaciente(Aioros);


                Medico Seiya = new Medico("Seiya", 54, "Avenida Cramer 1976", 1993);
                Medico Hyoga = new Medico("Hyoga", 36, "Paso del cisne 1770", 4001);
                Medico Ikki = new Medico("Ikki", 41, "Fenix 66", 2004);
                Medico Shun = new Medico("Shun", 37, "Pasaje Cadenas 206", 1003);


                Aleman.AgregarMedico(Seiya);
                Aleman.AgregarMedico(Hyoga);
                Quemado.AgregarMedico(Ikki);
                RicardoGutierrez.AgregarMedico(Shun);


                Console.WriteLine("Datos cargados automaticamente, presione cualquier tecla para continuar..");
                Console.ReadKey();

            }




        }


        /// <summary>
        /// Metodo para ejecutar el menu.
        /// </summary>
        public static void Menu()
        {

            int res = 0;

            do
            {
                Console.Clear();

                Console.WriteLine("*************SISTEMA DE SALUD*************");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("¿En que podemos ayudarlo?");
                Console.WriteLine("1. Ingresar un nuevo paciente.");//tambien lo derivará
                Console.WriteLine("2. Ver Pacientes.");
                Console.WriteLine("3. Ver Medicos.");
                Console.WriteLine("4. Ver Informacion del Hospital.");
                Console.WriteLine("5. Atender paciente/es.");
                Console.WriteLine("6. Ver curados");
                Console.WriteLine("7. Salir del sistema.");

                Console.WriteLine("");
                CalcularEstadisticas();

                res = validarInt(1, 7);
               
                switch (res)
                {
                    case 1:

                        IngresarPaciente();
                        break;
                    case 2:
                        Console.Clear();

                        subInformacion("p");

                        int seleccion = validarInt(1, 3);

                        switch (seleccion)
                        {
                            case 1:
                                Aleman.obtenerPacientes();
                                break;
                            case 2:
                                Quemado.obtenerPacientes();
                                break;
                            case 3:
                                RicardoGutierrez.obtenerPacientes();
                                break;
                        }

                        Console.WriteLine("\nPresione cualquier tecla para volver al menu.");
                        Console.ReadKey();
                        

                        break;

                    case 3:
                        Console.Clear();

                        subInformacion("m");

                        int seleccion2 = validarInt(1, 3);

                        switch (seleccion2)
                        {
                            case 1:
                                Aleman.obtenerMedicos();
                                break;
                            case 2:
                                Quemado.obtenerMedicos();
                                break;
                            case 3:
                                RicardoGutierrez.obtenerMedicos();
                                break;
                        }

                        Console.WriteLine("\nPresione cualquier tecla para volver al menu.");
                        Console.ReadKey();

                        break;

                    case 4:
                        Console.Clear();

                        subInformacion("h");

                        int seleccion3 = validarInt(1, 3);

                        switch (seleccion3)
                        {
                            case 1:
                                Aleman.getInformacionHospital();
                                break;
                            case 2:
                                Quemado.getInformacionHospital();
                                break;
                            case 3:
                                RicardoGutierrez.getInformacionHospital();
                                break;
                        }


                        Console.WriteLine("\nPresione cualquier tecla para volver al menu.");
                        Console.ReadKey();

                        break;

                    case 5:

                        atenderPaciente();

                        break;
                    case 6:

                        VerCurados();

                        break;
                    case 7:
                        Console.WriteLine("\nGracias por usar nuestro sistema de salud!");
                        Console.WriteLine("Presione cualquier tecla..");
                        Console.ReadKey();
                        break;
                }



                


            } while (res != 7);


        }

     
        /// <summary>
        /// Metodo para ingresar un nuevo paciente al sistema de salud
        /// </summary>
        public static void IngresarPaciente()
        {
            Console.Clear();

            Console.WriteLine("¿Nombre del nuevo paciente a ingresar?");
            string nuevoNombre = ValidarString();

            Console.WriteLine("¿Que edad tiene?");
            int nuevaEdad = validarInt(0, 110);

            Console.WriteLine("¿Que dolencia tiene?");
            Console.WriteLine("1. Dolor de cabeza \n2. Dolor de espalda\n3. Quemadura por Agua Caliente\n4. Quemadura General\n5. Gripe");
            int dolor = validarInt(1, 5);

            EDolencia nuevaDolencia = 0;

            switch (dolor)
            {
                case 1:
                    nuevaDolencia = EDolencia.DolorDeCabeza;
                    break;
                case 2:
                    nuevaDolencia = EDolencia.DolorDeEspalda;
                    break;
                case 3:
                    nuevaDolencia = EDolencia.QuemaduraAguaCaliente;
                    break;
                case 4:
                    nuevaDolencia = EDolencia.QuemaduraGeneral;
                    break;
                case 5:
                    nuevaDolencia = EDolencia.Gripezinha;
                    break;
            }


            Paciente nuevoPaciente = new Paciente(nuevoNombre, nuevaEdad, nuevaDolencia);

            DerivarPaciente(nuevoPaciente);

        }

        /// <summary>
        /// Metodo para derivar a los pacientes automaticamente cuando ingresan al sistema de salud.
        /// </summary>
        /// <param name="nuevoPaciente"></param>
        public static void DerivarPaciente(Paciente nuevoPaciente) 
        {

            if (nuevoPaciente.getEdad() < 15)
            {
                RicardoGutierrez.agregarPaciente(nuevoPaciente);
            }
            else
            {
                int valorDolencia = nuevoPaciente.getIndicadorDolencia();

                if (valorDolencia == 1 || valorDolencia == 2 || valorDolencia == 5)
                {
                    Aleman.agregarPaciente(nuevoPaciente);
                }
                else
                {
                    Quemado.agregarPaciente(nuevoPaciente);
                }
            }

        
        }


        /// <summary>
        /// Metodo para atender pacientes.
        /// </summary>
        public static void atenderPaciente()
        {

            Hospital hospitalATrabjar= escogerHospital();
            int cuenta = 1;

            Console.WriteLine("\nResultados encontrados:");
                foreach (Paciente p in hospitalATrabjar.devolverPacientes())
                {
                Console.WriteLine("{0}. {1}", cuenta, p.getNombrePaciente());
                cuenta++;
                }
            Console.WriteLine("{0}. Salir", cuenta);

            Console.WriteLine("\n¿A quien deseas atender?");

            int pacienteEscogido = validarInt(1, cuenta+1);

            if (pacienteEscogido != cuenta+1)
            {   

                cuenta = 1;

                string nombrePaciente = "";

                foreach (Paciente p in hospitalATrabjar.devolverPacientes())
                {
                    if (cuenta == pacienteEscogido)
                    {
                        nombrePaciente = p.getNombrePaciente();
                    }

                    cuenta++;
                }



                if (nombrePaciente != "")
                {
                    hospitalATrabjar.buscarPaciente(nombrePaciente);

                    Curados.Add(hospitalATrabjar.buscarPaciente(nombrePaciente));               

                    hospitalATrabjar.curarPaciente(hospitalATrabjar.buscarPaciente(nombrePaciente));

                    Console.WriteLine("El paciente {0} se curó con exito", nombrePaciente);
                }
                     

                
            }



            Console.ReadKey();
        }

        /// <summary>
        /// Metodo para... chan chan.. escoger hospital.
        /// </summary>
        /// <returns></returns>
        public static Hospital escogerHospital()
        {
            Console.WriteLine("¿Sobre que hospital deseas trabajar?");
            Console.WriteLine("1. Aleman");
            Console.WriteLine("2. Quemados");
            Console.WriteLine("3. Ricardo Gutierrez");

            int ans = validarInt(1, 3);

            if (ans == 1)
            {
                return Aleman;
            }
            else if (ans == 2)
            {
                return Quemado;
            }
            else
            {
                return RicardoGutierrez;
            }

        }



        /// <summary>
        /// Metodo para mostrar las opciones disponibles.
        /// </summary>
        /// <param name="i"></param>
        public static void subInformacion(string i)
        {


            if (i == "p")
            {
                Console.WriteLine("¿De que Hospital quieres ver los pacientes?");
            }
            else if (i == "m")
            {
                Console.WriteLine("¿De que Hospital quieres ver los medicos?");
            }
            else
            {
                Console.WriteLine("¿De que hospital quieres ver la informacion?");
            }


            Console.WriteLine("1. Hospital Aleman.\n2. Hospital del Quemado\n3. Hospital Ricardo Gutierrez."); 

        }



        /// <summary>
        /// Metodo para validar enteros, tomando los extremos como parametros.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int validarInt(int a, int b)
        {

            //Console.WriteLine("Ingrese un numero entre {0} y {1}", a , b);

            int numero = 0;

            do
            {

                int.TryParse(Console.ReadLine(), out numero);

                if (numero < a || numero > b)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un numero valido.");
                    Console.ResetColor();
                }

            } while (numero < a || numero > b);

            return numero;
        }

        
        /// <summary>
        /// Metodo para recorrer los curados
        /// </summary>
        public static void VerCurados()
        {
            foreach (Paciente curado in Curados)
            {

                if (curado.getEstado() == "En tratamiento")
                {
                    curado.setEstado(true);
                }


                curado.getInfoPaciente();
            }

            if (Curados.Count() < 1)
            {
                Console.WriteLine("\nNo hay pacientes curados :( murieros todos.");
            }

            Console.WriteLine("Presione una tecla para continuar..");
            Console.ReadKey();

        }

        
        /// <summary>
        /// Metodo para validar string
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string ValidarString()
        {
    
            int basura;
            string texto;

            do
            {
                texto = Console.ReadLine();

                if (string.IsNullOrEmpty(texto) || (int.TryParse(texto, out basura)) == true || string.IsNullOrWhiteSpace(texto))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El texto esta vacio o es nulo, intente nuevamente.");
                    Console.ResetColor();
                }
                

            } while (string.IsNullOrEmpty(texto) || (int.TryParse(texto, out basura)) == true || string.IsNullOrWhiteSpace(texto));


            return texto;
        }
        
        
        /// <summary>
        /// Metodo para mostrar la cantidad de recuperados e internados, en el Menu.
        /// </summary>
        public static void CalcularEstadisticas()
        {
            int curados = 0;
            int internados = 0;

            curados = Curados.Count();

            int aleman = Aleman.devolverPacientes().Count();
            int quemado = Quemado.devolverPacientes().Count();
            int RGutierrez = RicardoGutierrez.devolverPacientes().Count();

            internados = aleman + quemado + RGutierrez;

            //internados =+ RicardoGutierrez.devolverPacientes().Count();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total de pacientes internados: {0}", internados);
            Console.ResetColor();

            Console.WriteLine("Aleman: {0}", aleman);
            Console.WriteLine("Quemados: {0}", quemado);
            Console.WriteLine("Ricardo Gutierrez: {0}", RGutierrez);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Total de pacientes curados: {0}", curados);

            Console.ResetColor();
        }


    }
}
