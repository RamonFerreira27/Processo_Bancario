using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processo_Bancario
{
    class Program
    {
        static void Main(string[] args)
        {
            Conta_Bancaria conta = CriarConta();
            if (conta == null)
            {
                Console.WriteLine("\nHouve algum erro na criação da conta. Abortando...");
                Environment.Exit(0);
            }

            Console.WriteLine("\nDados da conta:");
            Console.WriteLine(conta);

            RealizarOperacao("depósito", ref conta);
            RealizarOperacao("saque", ref conta);

            Console.ReadKey();
        }

        private static void RealizarOperacao(string acao, ref Conta_Bancaria conta)
        {
            double valor = -1.0;

            Console.Write(String.Format("\nEntre um valor para {0}: ", acao));
            string entrada = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine(String.Format("O valor informado para {0} é inválido. Abortando...", acao));
                Environment.Exit(0);
            }

            if (!Double.TryParse(entrada, out valor))
            {
                Console.WriteLine(String.Format("Erro ao converter o valor de {0}. Abortando...", acao));
                Environment.Exit(0);
            }

            if (acao.Equals("saque"))
                conta.Saque(valor);
            else
                conta.Deposito(valor);

            Console.WriteLine("\nDados de conta atualizados:");
            Console.WriteLine(conta);
        }

        private static Conta_Bancaria CriarConta()
        {
            Conta_Bancaria conta = null;

            Console.Write("Entre o número da conta: ");
            string entrada = ResgatarValorDigitado("Número");
            if (!Int32.TryParse(entrada, out int numero))
            {
                Console.WriteLine("\nO valor informado é inválido para este campo. Valor: {0} | Campo: Número", entrada);
                Environment.Exit(0);
            }

            Console.Write("Entre o titular da conta: ");
            string titular = ResgatarValorDigitado("Titular");

            Console.Write("Haverá depósito inicial (s/n)? ");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.S:
                    {
                        Console.Write("\nEntre o valor de depósito inicial: ");
                        entrada = ResgatarValorDigitado("Número");
                        if (!Double.TryParse(entrada, out double depositoInicial))
                        {
                            Console.WriteLine("\nO valor informado é inválido para este campo. Valor: {0} | Campo: Depósito Inicial", entrada);
                            Environment.Exit(0);
                        }

                        conta = new Conta_Bancaria(numero, titular, depositoInicial);
                        break;
                    }
                case ConsoleKey.N:
                    conta = new Conta_Bancaria(numero, titular);
                    break;
                default:
                    Console.WriteLine("\nOperação desconhecida. Abortando...");
                    Environment.Exit(0);
                    return null;
            }

            return conta;
        }

        private static string ResgatarValorDigitado(string campo)
        {
            string entrada = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("\nO valor informado é inválido para este campo. Valor: {0} | Campo: {1}", entrada, campo);
                Environment.Exit(0);
            }

            return entrada;
        }
    }
}
