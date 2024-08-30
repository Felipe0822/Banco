using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    internal class Cuenta
    {
        private int numeroCuenta;
        private decimal  saldo;
       
        public Cuenta(int numCuenta, decimal saldo)
        {
            this.numeroCuenta = numCuenta;
            this.saldo = saldo;
        }

        public int NumeroCuenta { get => numeroCuenta; set => numeroCuenta = value; }
        public decimal Saldo { get => saldo; set => saldo = value; }

        public void ConsultarSaldo()
        {
            Console.WriteLine($"Saldo actual: {Saldo}");
        }
        public void RealizarDeposito(decimal monto)
        {
            Saldo += monto;
            Console.WriteLine($"Deposito realizado: {monto} Saldo actual: {Saldo}");
        }
        public virtual bool RealizarRetiro(decimal monto)
        {
            if (Saldo >= monto)
            {
                Saldo -= monto;
                Console.WriteLine($"Retiro exitoso de {monto:C}. Saldo actual: {Saldo:C}");
                return true;  // Retiro exitoso
            }
            else
            {
                Console.WriteLine("Fondos insuficientes.");
                return false; // Retiro fallido
            }
        }



    }
}
