using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegados.Consola
{
    //DEFINO UN TIPO DE DELEGADO 'DELEGADODEMIFUNCION' CON LA FIRMA
    //QUE VAN A TENER QUE RESPETAR TODAS LAS FUNCIONES MANEJADAS POR LOS
    //OBJETOS DELEGADOS.
    public delegate void DelegadoDeMiFuncion(Int32 num1, Int32 num2);

    class Program
    {

        #region Metodos con la misma firma del Delegado

        public static void Sumar(int numero1, int numero2)
        {
            Console.WriteLine("La Suma es: {0}", numero1 + numero2);
        }

        public static void Restar(int numero1, int numero2)
        {
            Console.WriteLine("La Resta  es: {0}", numero1 - numero2);
        }

        #endregion

        static void Main(string[] args)
        {
            //INSTANCIO UN OBJETO DEL TIPO DELEGADO 'DELEGADODEMIFUNCION'
            //AL CONSTRUCTOR LE PASO COMO PARAMETRO LA DIRECCION DE MEMORIA
            //DEL METODO QUE SE VA A EJECUTAR CUANDO SEA INVOCADO
            DelegadoDeMiFuncion MiDelegado = new DelegadoDeMiFuncion(Program.Sumar);
            
            Console.WriteLine("Se creo una instacia del delegado 'DelegadoDeMiFuncion' " +
                                "con el siguiente método:");

            //CON LA PROPIEDAD 'METHOD' OBTENGO EL ULTIMO METODO DE LA
            //LISTA DE INVOCACIONES DEL DELEGADO
            Console.WriteLine(MiDelegado.Method.ToString());

            Console.Clear();

            //PARA AGREGAR METODOS A LA LISTA DE INVOCACION DE UN DELEGADO:
            //CREO NUEVOS DELEGADOS (con la misma firma) Y LOS COMBINO...
            DelegadoDeMiFuncion MiDelegado2 = new DelegadoDeMiFuncion(Program.Restar);

            //UTILIZANDO EL METODO 'COMBINE'
            MiDelegado = (DelegadoDeMiFuncion)DelegadoDeMiFuncion.Combine(MiDelegado, MiDelegado2);
            
            //INCLUSIVE LOS PUEDO CONVINAR EN DISTINTOS AMBITOS
            ClaseDelegado cd = new ClaseDelegado();

            DelegadoDeMiFuncion MiDelegado3 = new DelegadoDeMiFuncion(cd.Dividir);
            
            //OBTENGO LA INSTANCIA QUE CONTIENE EL METODO DEL DELEGADO
            Console.WriteLine(MiDelegado3.Target.ToString());

            Console.Clear();            
            
            MiDelegado = (DelegadoDeMiFuncion)DelegadoDeMiFuncion.Combine(MiDelegado, MiDelegado3);

            Console.WriteLine("Se muestra la lista de métodos del delegado:");
            Console.WriteLine();

            //EL METODO 'GETINVOCATIONLIST' DEVUELVE LA COLECCION DE METODOS
            //QUE POSEE EL DELEGADO EN SU LISTA DE INVOCACION
            foreach (DelegadoDeMiFuncion delegadoAux in MiDelegado.GetInvocationList())
	        {
		        Console.WriteLine(delegadoAux.Method.ToString());
	        }

            Console.Clear();

            //OTRA FORMA DE AGREGAR NUEVOS METODOS A LA LISTA DE INVOCACIONES
            //ES CON LA CREACION DE NUEVAS INSTANCIAS REFERENCIADAS A UNA FUNCION
            MiDelegado = (DelegadoDeMiFuncion)DelegadoDeMiFuncion.Combine(MiDelegado,
                                                     new DelegadoDeMiFuncion(ClaseDelegado.Multiplicar));

            Console.WriteLine("Se muestra la lista de métodos del " +
                              "delegado después de agregar el método Multiplicar:");
  

            foreach (DelegadoDeMiFuncion delegadoAux in MiDelegado.GetInvocationList())
	        {
		        Console.WriteLine(delegadoAux.Method.ToString());
	        }
           
            Console.Clear();

            Console.WriteLine("Se duplica la lista del delegado:");

            MiDelegado = (DelegadoDeMiFuncion)DelegadoDeMiFuncion.Combine(MiDelegado, MiDelegado);

            foreach (DelegadoDeMiFuncion delegadoAux in MiDelegado.GetInvocationList())
	        {
		        Console.WriteLine(delegadoAux.Method.ToString());
	        }

            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Las operaciones arrojan los siguientes resultados:");

            //INVOCO A LOS METODOS DE LA LISTA DE INVOCACIONES

            //UTILIZANDO EL METODO INVOKE EXPLICITAMENTE
            MiDelegado.Invoke(15, 20);

            //O IMPLICITAMENTE
            MiDelegado(10, 5);

            Console.Clear();

            Console.WriteLine("Las operaciones arrojan los siguientes resultados:");

            //OTRA FORMA...
            cd.Calcular(5, Program.Sumar, 10);

            Console.Clear();

            Console.WriteLine("Al pasarle como parámetro el delegado con todos " +
                              "los métodos cargados arroja los siguientes resultados:");

            cd.Calcular(6, MiDelegado, 12);

            Console.ReadLine();
        }
    }
}
