using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    internal class CuentaCorriente:Cuenta
    {
        private decimal descubiertoPermitido;
        public CuentaCorriente(int numeroCuenta, decimal saldoInicial, decimal descubiertoPermitido)
           : base(numeroCuenta, saldoInicial)
        {
            DescubiertoPermitido = descubiertoPermitido;
        }
        public decimal DescubiertoPermitido { get => descubiertoPermitido; set => descubiertoPermitido = value; }
        public void RealizarTransferencia(Cuenta destino, decimal monto)
        {
            if (RealizarRetiro(monto)) 
            {
                destino.RealizarDeposito(monto);
                Console.WriteLine($"Transferencia realizada de {monto:C} a la cuenta {destino.NumeroCuenta}");
            }
            else
            {
                Console.WriteLine("Transferencia fallida. Fondos insuficientes.");
            }
        }


    }
}
