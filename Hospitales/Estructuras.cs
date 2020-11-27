using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitales
{


    struct Hospital
    {
        string nombre;
        string direccion;
        List<Medico> medicos;
        List<Paciente> pacientes;
        EEspecialidad especialidad;

        public Hospital(string auxNombre, string auxDireccion, EEspecialidad auxEspecialdad)
        {
           nombre = auxNombre;
           direccion = auxDireccion;
           medicos = new List<Medico>();
           pacientes = new List<Paciente>();
           especialidad = auxEspecialdad;
        }

        /// <summary>
        /// Metodo para obtener toda la informacion junta del hospital.
        /// </summary>
        public void getInformacionHospital()
        {


            Console.WriteLine("----------FICHA DEL HOSPITAL----------");
            Console.WriteLine("Nombre: {0}", nombre);
            Console.WriteLine("Dirección: {0}", direccion);
            Console.WriteLine("Especialidad: {0}", getEspecialidad());
            Console.WriteLine("--------------------------------------");
            
            Console.WriteLine("\n¿Deseas acceder a la informacion de medicos y pacientes?");
            Console.WriteLine("1. Si \n2. No");

            int numero = 0;

            do
            {
                int.TryParse(Console.ReadLine(), out numero);

                if (numero < 1 || numero > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingrese un numero valido.");
                    Console.ResetColor();
                }

            } while (numero < 1 || numero > 2);

            if (numero == 1)
            {
                obtenerMedicos();
                Console.WriteLine("\nPresione una tecla para continuar..");
                Console.ReadKey();
                obtenerPacientes();
            }

            


        }


        /// <summary>
        /// Metodo para obtener la info de todos los medicos, accediendo al metodo getIntoMedico, particular del struct Medico
        /// </summary>
        /// <param name="medicos"></param>
        public void obtenerMedicos()
        {
            Console.Clear();

            Console.WriteLine("*****MEDICOS DEL HOSPITAL {0}******\n", nombre.ToUpper());

            foreach (Medico m in medicos)
            {
                m.getInfoMedico();
            }


        }

        /// <summary>
        /// Metodo para obtener pacientes
        /// </summary>
        public void obtenerPacientes()
        {
            Console.Clear();

            Console.WriteLine("*****PACIENTES DEL HOSPITAL {0}******\n", nombre.ToUpper());

            foreach (Paciente p in pacientes)
            {
                p.getInfoPaciente();
            }
        }

        /// <summary>
        /// Metodo para obtener los pacientes de un hospital
        /// </summary>
        /// <returns></returns>
        public List<Paciente> devolverPacientes()
        {
            return pacientes;
        }

        /// <summary>
        /// Metodo para buscar y devolver un paciente usando su nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Paciente buscarPaciente(string nombre)
        {
            Paciente pac = new Paciente();

            foreach (Paciente p in pacientes)
            {
                if (p.getNombrePaciente() == nombre)
                {
                    pac = p;
                }
            }

            return pac;
        }


        /// <summary>
        /// Metodo para agregar medicos
        /// </summary>
        public void agregarPaciente(Paciente pacienteNuevo)
        {
            pacientes.Add(pacienteNuevo);
        }

        /// <summary>
        /// Metodo para sacar el paciente de una lista.
        /// </summary>
        /// <param name="p"></param>
        public void curarPaciente(Paciente p)
        {
            pacientes.Remove(p);
        }


        /// <summary>
        /// Metodo para agergar medico.
        /// </summary>
        /// <param name="medicoNuevo"></param>
        public void AgregarMedico(Medico medicoNuevo)
        {
            medicos.Add(medicoNuevo);
        }

        #region Getters
        public string getNombre()
        {
            return nombre;
        }

        public string getEspecialidad()
        {
            if ((int)especialidad == 3)
            {
                string cg = "Clinica General";
                return cg;
            }
            return especialidad.ToString();
        }

        public string getDireccion()
        {
            return direccion;
        }
        #endregion

        



    }




    enum EEspecialidad
    {
        Pediatria = 1, 
        Quemaduras = 2,
        ClinicaGeneral = 3
    }


    struct Medico
    {
        string nombre;
        int edad;
        string direccion;
        int nLicencia;

        public Medico(string auxNombre, int auxEdad, string auxDireccion, int auxNLicencia)
        {
            nombre = auxNombre;
            edad = auxEdad;
            direccion = auxDireccion;
            nLicencia = auxNLicencia;
        }

        /// <summary>
        /// Metodo para obtener la informacion del medico
        /// </summary>
        public void getInfoMedico()
        {
            
            Console.WriteLine("-----------FICHA DEL MEDICO-----------");
            Console.WriteLine("Nombre: {0}", nombre);
            Console.WriteLine("Edad: {0}", edad);
            Console.WriteLine("Dirección: {0}", direccion);
            Console.WriteLine("Número de licencia: {0}", nLicencia);
            Console.WriteLine("--------------------------------------\n");
        }


        #region Getters
        public string getNombreMedico()
        {
            return nombre;
        }

        public int getNLicencia()
        {
            return nLicencia;
        }

        public string getDireccion()
        {
            return direccion;
        }

        public int getEdad()
        {
            return edad;
        }
        #endregion



        #region Setters
        public void setEdad(int nuevaEdad)
        {
            edad = nuevaEdad;
        }

        public void setDireccion(string nuevaDireccion)
        {
            direccion = nuevaDireccion;
        }
        #endregion



    }


    struct Paciente
    {
        string nombre;
        int edad;
        EDolencia dolencia;
        bool sano;
        string estado;

        public Paciente(string auxNombre, int auxEdad, EDolencia auxDolencia)
        {
            nombre = auxNombre;
            edad = auxEdad;
            dolencia = auxDolencia;
            sano = false;
            estado = "En tratamiento";
        }


        /// <summary>
        /// Metodo para obtener los datos actuales del paciente.
        /// </summary>
        public void getInfoPaciente()
        {
            string estado;



            Console.WriteLine("----------FICHA DEL PACIENTE----------");
            Console.WriteLine("Nombre: {0}", nombre);
            Console.WriteLine("Edad: {0}", edad);
            Console.WriteLine("Dolencia: {0}", getDolenciaPaciente());
            Console.WriteLine("Estado: {0}", getEstado());
            Console.WriteLine("--------------------------------------\n");

        }


        #region Getters
        public string getNombrePaciente()
        {
            return nombre;
        }

        public int getIndicadorDolencia()
        {
            return (int)dolencia;
        }

        public string getDolenciaPaciente()
        {
            int indicadorDolencia = getIndicadorDolencia();
            string dolor = "";

            if (indicadorDolencia == 1 )
            {
                dolor = "Dolor de cabeza";
            }
            else if (indicadorDolencia == 2)
            {
                dolor = "Dolor de espalda";
            }
            else if (indicadorDolencia == 3)
            {
                dolor = "Quemadura de agua caliente";
            }
            else if (indicadorDolencia == 4)
            {
                dolor = "Quemadura general";
            }
            else if (indicadorDolencia == 5)
            {
                dolor = "Gripe";
            }
            else
            {
                dolor = "sano";
            }


            return dolor;
            
        }

        public string getEstado()
        {
            return estado;
        }

        public int getEdad()
        {
            return edad;
        }
        #endregion


        /// <summary>
        /// Set especial
        /// </summary>
        /// <param name="nuevoEstado"></param>
        public void setEstado(bool nuevoEstado)
        {
            //string estado;

            if (nuevoEstado == false)
            {
                estado = "En tratamiento";
            }
            else
            {
                sano = true;
                estado = "Curado";
                dolencia = EDolencia.Sano;
            }
        }



    }

    enum EDolencia
    {
        DolorDeCabeza = 1,
        DolorDeEspalda = 2,
        QuemaduraAguaCaliente = 3,
        QuemaduraGeneral = 4,
        Gripezinha = 5,
        Sano = 6
    }




}
