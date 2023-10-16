using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camion : Vehiculo
    {
        private double cargaMaxima;
        private int numeroEjes;

        public double CargaMaxima
        {
            get { return cargaMaxima; }
            set { this.cargaMaxima = value; }
        }

        public int NumeroEjes
        {
            get { return numeroEjes; }
            set { this.numeroEjes = value; }
        }

        public Camion()
        {
            this.cargaMaxima = 17000;
            this.numeroEjes = 2;
        }

        public Camion(string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
            : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cargaMaxima = 17000;
            this.numeroEjes = 2;
        }

        public Camion(double cargaMaxima, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cargaMaxima = cargaMaxima;
        }

        public Camion(int numeroEjes, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.numeroEjes = numeroEjes;
        }

        public Camion(double cargaMaxima, int numeroEjes, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cargaMaxima = cargaMaxima;
            this.numeroEjes = numeroEjes;
        }

        public override void Arrancar()
        {
            Console.WriteLine("El camión está arrancando.");
        }

        public override void Detener()
        {
            Console.WriteLine("El camión se ha detenido.");
        }

        public override string ToString()
        {
            return $"Camión - Marca: {Marca}, Modelo: {Modelo}, Año: {AñoFabricacion}, Combustible: {TipoCombustible}, Carga Máxima: {cargaMaxima} toneladas, Ejes: {numeroEjes}";
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Camion)
            {
                retorno = this == (Camion)obj;
            }
            return retorno;
        }

        public static bool operator ==(Camion c1, Camion c2)
        {
            return c1.numeroEjes == c2.numeroEjes && c1.cargaMaxima == c2.cargaMaxima;
        }

        public static bool operator !=(Camion camion1, Camion camion2)
        {
            return !(camion1 == camion2);
        }
    }
}