using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase
    {

        public Funcionario(string nome, string login, string senha, decimal salario, DateTime dataAdmicao, string tipoPerfil)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Salario = salario;
            DataAdmicao = dataAdmicao;
            TipoPerfil = tipoPerfil;
        }

        public Funcionario()
        {
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmicao { get; set; }
        public string TipoPerfil { get; set; }
        public override bool Equals(object obj)
        {
            return obj is Funcionario funcionario &&
                   Id == funcionario.Id &&
                   Nome == funcionario.Nome &&
                   Login == funcionario.Login &&
                   Senha == funcionario.Senha &&
                   Salario == funcionario.Salario &&
                   DataAdmicao.Date == funcionario.DataAdmicao.Date &&
                   TipoPerfil == funcionario.TipoPerfil;
        }
        public override string ToString()
        {
            return Nome;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Login, Senha, Salario, DataAdmicao, TipoPerfil);
        }
    }
}
