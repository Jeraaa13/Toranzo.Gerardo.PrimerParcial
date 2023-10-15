using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Garaje
    {
        private List<Vehiculo> vehiculos;

        public List<Vehiculo> Vehiculos
        {
            get { return vehiculos; }
        }

        public Garaje()
        {
            vehiculos = new List<Vehiculo>();
        }

        public static Garaje operator +(Garaje g1, Vehiculo v1)
        {
            if (!g1.vehiculos.Contains(v1))
            {
                g1.vehiculos.Add(v1);
            }
            return g1;
        }

        public static Garaje operator -(Garaje g1, Vehiculo v1)
        {
            if (g1.vehiculos.Contains(v1))
            {
                g1.vehiculos.Remove(v1);
            }
            return g1;
        }

        public static bool operator ==(Garaje g1, Vehiculo v1)
        {
            return g1.vehiculos.Contains(v1);
        }

        public static bool operator !=(Garaje g1, Vehiculo v1)
        {
            return !(g1 == v1);
        }

        public List<Vehiculo> OrdenarPorAñoDeFabricacion(bool ascendente)
        {
            List<Vehiculo> retorno = this.vehiculos;
            if (ascendente)
            {
                retorno = this.vehiculos.OrderBy(vehiculo => vehiculo.AñoFabricacion).ToList();
            }
            else
            {
                retorno = this.vehiculos.OrderByDescending(vehiculo => vehiculo.AñoFabricacion).ToList();
            }
            return retorno;
        }

        public List<Vehiculo> OrdenarPorMarcaAlfabeticamente(bool ascendente)
        {
            List<Vehiculo> retorno = this.vehiculos;
            if(ascendente)
            {
                retorno = this.vehiculos.OrderBy(vehiculo => vehiculo.Marca).ToList();
            }
            else
            {
                retorno = this.vehiculos.OrderByDescending(vehiculo => vehiculo.Marca).ToList();
            }
            return retorno;
        }
    }
}
