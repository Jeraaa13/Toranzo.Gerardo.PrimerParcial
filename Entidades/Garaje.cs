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
            set { vehiculos = value; }
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

        public void OrdenarPorAñoDeFabricacion(bool ascendente)
        {
            if (ascendente)
            {
                this.vehiculos = this.vehiculos.OrderBy(vehiculo => vehiculo.AñoFabricacion).ToList();
            }
            else
            {
                this.vehiculos = this.vehiculos.OrderByDescending(vehiculo => vehiculo.AñoFabricacion).ToList();
            }
        }

        public void OrdenarPorMarcaAlfabeticamente(bool ascendente)
        {
            if (ascendente)
            {
                this.vehiculos = this.vehiculos.OrderBy(vehiculo => vehiculo.Marca).ToList();
            }
            else
            {
                this.vehiculos = this.vehiculos.OrderByDescending(vehiculo => vehiculo.Marca).ToList();
            }
        }

    }
}
