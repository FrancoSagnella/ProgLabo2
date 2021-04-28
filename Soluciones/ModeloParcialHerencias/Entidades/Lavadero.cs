using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lavadero
    {
        private List<Vehiculos> vehiculos;
        private float precioAuto;
        private float precioCamion;
        private float precioMoto;

        private Lavadero()
        {
            vehiculos = new List<Vehiculos>();
            this.precioAuto = 0;
            this.precioCamion = 0;
            this.precioMoto = 0;
        }

        public Lavadero(float precioAuto):this()
        {
            this.precioAuto = precioAuto;
        }
        public Lavadero(float precioCamion, float precioAuto) : this(precioAuto)
        {
            this.precioCamion = precioCamion;
        }
        public Lavadero(float precioMoto, float precioCamion, float precioAuto):this(precioCamion, precioAuto)
        {
            this.precioMoto = precioMoto;
        }

        public string GetLavadero
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                //sb.AppendLine("********Precios Vigentes*********");
                sb.AppendFormat("Precio por auto: {0} - \n", this.precioAuto);
                sb.AppendFormat("Precio por camion: {0} - \n", this.precioCamion);
                sb.AppendFormat("Precio por moto: {0} - \n\n", this.precioMoto);
                //sb.AppendLine("**************Vehiculos***************");

                //foreach(Vehiculos item in this.vehiculos)
                //{
                  //  sb.AppendLine(item.Mostrar());
                //}
                return sb.ToString();
            }
        }
        public List<Vehiculos> Vehiculos
        {
            get
            {
                return this.vehiculos;
            }
        }

        public double MostrarTotalFacturado()
        {
            double total = this.MostrarTotalFacturado(EVehiculos.Auto) + 
                           this.MostrarTotalFacturado(EVehiculos.Camion) +
                           this.MostrarTotalFacturado(EVehiculos.Moto);

            return total;
        }
        public double MostrarTotalFacturado(EVehiculos tipoVehiculo)
        {
            double total = 0;

            foreach(Vehiculos item in this.vehiculos)
            {
                switch (tipoVehiculo)
                {
                    case EVehiculos.Auto:

                        if(item is Auto)
                            total += this.precioAuto;
                        
                        break;

                    case EVehiculos.Camion:
                        if(item is Camion)
                            total += this.precioCamion;

                        break;

                    case EVehiculos.Moto:

                        if(item is Moto)
                            total += this.precioMoto;

                        break;
                }
            }

            return total;
        }
        public static int OrdenarVehiculosPorPatente(Vehiculos v1, Vehiculos v2)
        {
            return String.Compare(v1.Patente, v2.Patente);
        }
        public int OrdenarVehiculosPorMarca(Vehiculos v1, Vehiculos v2)
        {
            return String.Compare(v1.Marca.ToString(), v2.Marca.ToString());
        }

        public static bool operator ==(Lavadero l, Vehiculos v)
        {
            bool retorno = false;

            foreach(Vehiculos item in l.vehiculos)
            {
                if(item == v)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Lavadero l, Vehiculos v)
        {
            return !(l == v);
        }
        public static Lavadero operator +(Lavadero l, Vehiculos v)
        {
            if(l != v)//si no esta en el lavadero, lo agrego
            {
                l.vehiculos.Add(v);
            }
            return l;
        }
        public static Lavadero operator -(Lavadero l, Vehiculos v)
        {
            int index = l | v;
            if(index != -1)
            {
                l.vehiculos.RemoveAt(index);
            }
            return l;
        }
        public static int operator |(Lavadero l, Vehiculos v)//Me obtiene el indice de un elemento
        {
            int ret = -1;
            int cont = 0;
            foreach(Vehiculos item in l.vehiculos)
            {
                if(item == v)
                {
                    ret = cont;
                    break;
                }
                cont++;
            }
            return ret;
        }
    }
}
