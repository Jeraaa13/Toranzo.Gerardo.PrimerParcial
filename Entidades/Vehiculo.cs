namespace Entidades
{
    public abstract class Vehiculo
    {
        protected string marca;
        protected string modelo;
        protected int añoFabricacion;
        protected ETipoCombustible tipoCombustible;

        public string Marca
        {
            get { return this.marca; }
            set { this.marca = value; }
        }
        public string Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }
        public int AñoFabricacion
        {
            get { return this.añoFabricacion; }
            set { this.añoFabricacion = value; }
        }
        public ETipoCombustible TipoCombustible
        {
            get { return this.TipoCombustible; }
            set { this.tipoCombustible = value; }
        }

        public Vehiculo(string marca, string modelo)
        {
            this.marca = marca;
            this.modelo = modelo;
        }
        public Vehiculo(string marca, string modelo, int añoFabricacion) : this(marca, modelo)
        {
            this.añoFabricacion = añoFabricacion;
        }

        public Vehiculo(string marca, string modelo, int añoFabricacion, ETipoCombustible tipoCombustible) 
            : this(marca, modelo, añoFabricacion)
        {
            this.tipoCombustible = tipoCombustible;
        }
        public abstract void Arrancar();

        public virtual void Detener()
        {
            Console.WriteLine("El vehículo se ha detenido.");
        }

        public override string ToString()
        {
            return $"Marca: {Marca}, Modelo: {Modelo}, Año de Fabricación: {AñoFabricacion}, " +
                $"Tipo de Combustible: {TipoCombustible}";
        }

        public override bool Equals(object? obj)
        {
            bool retorno = false;
            if (obj is Vehiculo)
            {
                retorno = this == (Vehiculo)obj;
            }
            return retorno;
        }

        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.marca == v2.marca && v1.modelo == v2.modelo;
        }

        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}