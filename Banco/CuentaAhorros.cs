using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    internal class CuentaAhorros:Cuenta
    {
        private decimal tasaInteres;
        public CuentaAhorros(int numCuenta, decimal Saldo, decimal tasaInteres)
            : base(numCuenta, Saldo)
        {
            TasaInteres = tasaInteres;
        }

        public decimal TasaInteres { get => tasaInteres; set => tasaInteres = value; }

        public void CalcularIntereses()
        {
            decimal intereses = Saldo * TasaInteres;
            Saldo += intereses;
            Console.WriteLine($"Intereses calculados: {intereses:C}");
        }
    }
}

