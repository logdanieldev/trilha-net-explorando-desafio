using System;
using System.Collections.Generic;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
            // É uma boa prática inicializar a lista para evitar erros de referência nula.
            Hospedes = new List<Pessoa>();
        }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            // Também inicializamos a lista neste construtor.
            Hospedes = new List<Pessoa>();
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // VERIFICAÇÃO: A capacidade da suíte deve ser maior ou igual ao número de hóspedes.
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // LANÇAMENTO DE EXCEÇÃO: Caso a capacidade seja menor que o número de hóspedes.
                throw new ArgumentException("A quantidade de hóspedes excede a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // RETORNO: Retorna a contagem de itens na lista de Hóspedes.
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // CÁLCULO BASE: DiasReservados multiplicado pelo ValorDiaria da Suíte.
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // REGRA DE DESCONTO: Se os dias reservados forem 10 ou mais, aplica um desconto de 10%.
            if (DiasReservados >= 10)
            {
                // Aplica o desconto de 10% sobre o valor total.
                valor -= valor * 0.10m; // ou valor *= 0.90m;
            }

            return valor;
        }
    }
}