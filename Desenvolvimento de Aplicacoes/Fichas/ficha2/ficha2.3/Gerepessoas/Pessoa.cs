using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerepessoas
{
     class Pessoa
    {
        public string Nome { get; }
        public DateTime DtaNascimento { get; }
        public string Morada { get; }
        public int Pontuacao { get; }

        public override string ToString()
        {
            return (Nome + "(" + Idade() + ")" + Pontuar());
        }

        // Constructor = metodo especial dentro de uma class
        // mesmo nome que uma classe 
        // Pode ser usado para atribuir argumentos a parametros quando se cria o objeto 
        public Pessoa (string Nome, DateTime DtaNascimento, string Morada)
        {
            this.Nome = Nome;
            this.DtaNascimento = DtaNascimento; 
            this.Morada = Morada;
            this.Pontuacao = 0;

            
        }

        public int Idade()
        {
            // Guardar a data de hoje
            var today = DateTime.Today;

            //Calcular a idade 
            int age = today.Year - DtaNascimento.Year;
            return age;
        }


        public int Pontuar()
        {
            return 0;
        }

    }
}
