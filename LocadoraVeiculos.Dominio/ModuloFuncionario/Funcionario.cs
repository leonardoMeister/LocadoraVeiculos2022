using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public Funcionario(string nome, string login, string senha, decimal salario, DateTime dataadmicao, string tipoperfil)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Salario = salario;
            DataAdmicao = dataadmicao;
            TipoPerfil = tipoperfil;
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmicao { get; set; }
        public string TipoPerfil { get; set; }
    }
}
