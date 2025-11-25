namespace ExamenFinalDaniel.Models
{
    public class CalculadoraUML
    {
        public double Numero1 {get; set;}  

        public double Numero2 { get; set; }



        public double Sumar()
        {
            return Numero1 + Numero2;
        }

        public double Restar()
        {
            return Numero1 - Numero2;
        }

        public double Multiplicar()
        {
            return Numero1 * Numero2;
        }

        public double Dividir()
        {
            if (Numero2 == 0)
            {
                throw new DivideByZeroException("No se puede dividir entre cero.");
            }

            return Numero1 / Numero2;
        }
    }
}
