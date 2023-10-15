using System;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        private int cilindrada;
        private ETipoRuedas tipoRuedas;

        public int Cilindrada
        {
            get { return cilindrada; }
            set { this.cilindrada = value; }
        }

        public ETipoRuedas TipoRuedas
        {
            get { return tipoRuedas; }
            set { this.tipoRuedas = value; }
        }


        public Moto(string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
            : base(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cilindrada = 125;
            this.tipoRuedas = ETipoRuedas.RuedasNormales;
        }

        public Moto(int cilindrada, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cilindrada = cilindrada;
        }

        public Moto(ETipoRuedas tipoRuedas, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.tipoRuedas = tipoRuedas;
        }

        public Moto(int cilindrada, ETipoRuedas tipoRuedas, string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible)
                : this(marca, modelo, añoFabricacion, tipoCombustible)
        {
            this.cilindrada = cilindrada;
            this.tipoRuedas = tipoRuedas;
        }

        public override void Arrancar()
        {
            Console.WriteLine("La moto está arrancando.");
        }

        public override void Detener()
        {
            Console.WriteLine("La moto se ha detenido.");
        }

        public override string ToString()
        {
            return $"Moto - Marca: {Marca}, Modelo: {Modelo}, Año: {AñoFabricacion}, Combustible: {TipoCombustible}, Cilindrada: {cilindrada} cc, Tipo: {tipoRuedas}";
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Moto)
            {
                retorno = this == (Moto)obj;
            }
            return retorno;
        }
        public static bool operator ==(Moto m1, Moto m2)
        {
            return m1.cilindrada == m2.cilindrada && m1.tipoRuedas == m2.tipoRuedas;
        }

        public static bool operator !=(Moto m1, Moto m2)
        {
            return !(m1 == m2);
        }
    }
}
