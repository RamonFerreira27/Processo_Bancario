using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processo_Bancario {
    class Conta_Bancaria {
        private int _conta;
        private string _titular;
        private double _saldo;

        public int Conta {
            get { return _conta; }
            private set { _conta = value; }
        }
        public string Titular {
            get { return _titular; }
            set { _titular = value; }
        }
        public double Saldo {
            get { return _saldo; }
            private set { _saldo = value; }
        }

        public Conta_Bancaria(int conta, string titular, double depositoInicial) {
            Conta = conta;
            Titular = titular;
            Deposito(depositoInicial);
        }
        public Conta_Bancaria(int conta, string titular) {
            Conta = conta;
            Titular = titular;
        }

        public override string ToString() {
            return "Conta: " + Conta
                + ", Titular: " + Titular
                + ", Saldo: $" + Saldo.ToString("F2");
        }

        public void Deposito(double valor) {
            if (valor > 0) {
                Saldo += valor;
            }
            else {
                Environment.Exit(0);
            }
        }
        public void Saque(double valor) {
            Saldo -= valor + 5;
        }
    }
}
