using Banco;
using System;
using System.Collections.Generic;

namespace SistemaBancario
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Cuenta> cuentas = new List<Cuenta>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n--- Sistema Bancario ---");
                Console.WriteLine("1. Crear cuenta");
                Console.WriteLine("2. Realizar depósito");
                Console.WriteLine("3. Realizar retiro");
                Console.WriteLine("4. Realizar transferencia");
                Console.WriteLine("5. Consultar saldo");
                Console.WriteLine("6. Calcular intereses (solo cuentas de ahorro)");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearCuenta();
                        break;
                    case "2":
                        RealizarDeposito();
                        break;
                    case "3":
                        RealizarRetiro();
                        break;
                    case "4":
                        RealizarTransferencia();
                        break;
                    case "5":
                        ConsultarSaldo();
                        break;
                    case "6":
                        CalcularIntereses();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void CrearCuenta()
        {
            Console.WriteLine("\n--- Crear Cuenta ---");
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Ingrese la dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese el número de identificación: ");
            int numeroIdentificacion =int.Parse(Console.ReadLine());
            Cliente cliente = new Cliente(nombre, apellido, direccion, numeroIdentificacion);
            clientes.Add(cliente);

            Console.WriteLine("Tipo de cuenta:");
            Console.WriteLine("1. Cuenta Corriente");
            Console.WriteLine("2. Cuenta de Ahorros");
            Console.Write("Seleccione el tipo de cuenta: ");
            string tipoCuenta = Console.ReadLine();

            Console.Write("Ingrese el número de cuenta: ");
            int numeroCuenta = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el saldo inicial: ");
            decimal Saldo = Convert.ToDecimal(Console.ReadLine());

            if (tipoCuenta == "1")
            {
                Console.Write("Ingrese el descubierto permitido: ");
                decimal descubiertoPermitido = Convert.ToDecimal(Console.ReadLine());
                CuentaCorriente cuentaCorriente = new CuentaCorriente(numeroCuenta, Saldo, descubiertoPermitido);
                cuentas.Add(cuentaCorriente);
            }
            else if (tipoCuenta == "2")
            {
                Console.Write("Ingrese la tasa de interés: ");
                decimal tasaInteres = Convert.ToDecimal(Console.ReadLine());
                CuentaAhorros cuentaAhorros = new CuentaAhorros(numeroCuenta, Saldo, tasaInteres);
                cuentas.Add(cuentaAhorros);
            }

            Console.WriteLine("Cuenta creada exitosamente.");
        }

        static void RealizarDeposito()
        {
            Console.WriteLine("\n--- Realizar Depósito ---");
            Cuenta cuenta = BuscarCuenta();
            if (cuenta != null)
            {
                Console.Write("Ingrese el monto a depositar: ");
                decimal monto = Convert.ToDecimal(Console.ReadLine());
                cuenta.RealizarDeposito(monto);
            }
        }

        static void RealizarRetiro()
        {
            Console.WriteLine("\n--- Realizar Retiro ---");
            Cuenta cuenta = BuscarCuenta();
            if (cuenta != null)
            {
                Console.Write("Ingrese el monto a retirar: ");
                decimal monto = Convert.ToDecimal(Console.ReadLine());
                cuenta.RealizarRetiro(monto);
            }
        }

        static void RealizarTransferencia()
        {
            Console.WriteLine("\n--- Realizar Transferencia ---");
            Console.WriteLine("Cuenta origen:");
            Cuenta cuentaOrigen = BuscarCuenta();
            if (cuentaOrigen != null && cuentaOrigen is CuentaCorriente)
            {
                Console.WriteLine("Cuenta destino:");
                Cuenta cuentaDestino = BuscarCuenta();
                if (cuentaDestino != null)
                {
                    Console.Write("Ingrese el monto a transferir: ");
                    decimal monto = Convert.ToDecimal(Console.ReadLine());
                    ((CuentaCorriente)cuentaOrigen).RealizarTransferencia(cuentaDestino, monto);
                }
            }
            else
            {
                Console.WriteLine("La cuenta origen debe ser una cuenta corriente.");
            }
        }

        static void ConsultarSaldo()
        {
            Console.WriteLine("\n--- Consultar Saldo ---");
            Cuenta cuenta = BuscarCuenta();
            if (cuenta != null)
            {
                cuenta.ConsultarSaldo();
            }
        }

        static void CalcularIntereses()
        {
            Console.WriteLine("\n--- Calcular Intereses ---");
            Cuenta cuenta = BuscarCuenta();
            if (cuenta != null && cuenta is CuentaAhorros)
            {
                ((CuentaAhorros)cuenta).CalcularIntereses();
            }
            else
            {
                Console.WriteLine("La cuenta no es de tipo ahorro.");
            }
        }

        static Cuenta BuscarCuenta()
        {
            Console.Write("Ingrese el número de cuenta: ");
            int numeroCuenta = int.Parse(Console.ReadLine());
            foreach (var cuenta in cuentas)
            {
                if (cuenta.NumeroCuenta == numeroCuenta)
                {
                    return cuenta;
                }
            }
            Console.WriteLine("Cuenta no encontrada.");
            return null;
        }
        
    }
}
