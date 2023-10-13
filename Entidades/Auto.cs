using System;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        private int numeroPuertas;
        private ETraccion traccion;

        public Auto(string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
            : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.numeroPuertas = 4;
            this.traccion = ETraccion.Delantera;
        }

        public Auto(int numeroPuertas, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.numeroPuertas = numeroPuertas;
        }

        public Auto(ETraccion traccion, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.traccion = traccion;
        }
        
        public Auto(int numeroPuertas, ETraccion traccion, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.numeroPuertas = numeroPuertas;
            this.traccion = traccion;
        }

        public override void Arrancar()
        {
            Console.WriteLine("El auto está arrancando.");
        }

        public override void Detener()
        {
            Console.WriteLine("El auto se ha detenido.");
        }

        public override string ToString()
        {
            return $"Auto - Marca: {Marca}, Modelo: {Modelo}, Año: {AñoFabricacion}, Combustible:" +
                    $" {TipoCombustible}, Puertas: {numeroPuertas}, Tracción: {traccion}";
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Auto)
            {
                retorno = this == (Auto)obj;
            }
            return retorno;
        }

        public static bool operator ==(Auto a1, Auto a2)
        {
            return a1.marca == a2.marca && a1.modelo == a2.modelo;
        }

        public static bool operator !=(Auto a1, Auto a2)
        {
            return !(a1 == a2);
        }


    }
}
