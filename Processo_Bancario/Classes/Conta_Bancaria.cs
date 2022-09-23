using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processo_Bancario
{
    class Conta_Bancaria
    {
        public int      Conta   { get; private set; }
        public string   Titular { get; set; }
        public double   Saldo   { get; private set; }

        public Conta_Bancaria(int conta, string titular, double depositoInicial)
        {
            Conta   = conta;
            Titular = titular;
            Deposito(depositoInicial);
        }

        public Conta_Bancaria(int conta, string titular)
        {
            Conta   = conta;
            Titular = titular;
        }

        public override string ToString()
        {
            //// Primeira Forma que aprendi
            //return "Conta: " + Conta
            //    + ", Titular: " + Titular
            //    + ", Saldo: $" + Saldo.ToString("F2");

            // Segunda forma que aprendi
            return String.Format("Conta: {0}, Titular: {1}, Saldo: ${2}", Conta, Titular, Saldo.ToString("F2"));

            ////Terceira forma que aprendi
            //return $"Conta: {Conta}, Titular: {Titular}, Saldo: ${Saldo.ToString("F2")}";
        }

        public void Deposito(double valor)
        {
            if (valor <= 0)
            {
                Console.WriteLine("O valor informado para depósito é inválido. Abortando...");
                Environment.Exit(0);
            }

            Saldo += valor;
        }

        public void Saque(double valor)
        {
            Saldo -= valor + 5;
        }
    }
}
