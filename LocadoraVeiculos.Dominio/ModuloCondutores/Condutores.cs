using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloCondutores
{
    public class Condutores:EntidadeBase
    {

        public Condutores(string nome, string cpf, string endereco, string email, string telefone, string cnh, string validadeCnh)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            Cnh = cnh;
            ValidadeCnh = validadeCnh;
        }

        public Condutores()
        {
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnh { get; set; }
        public string ValidadeCnh { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Condutores condutores &&
                   Id == condutores.Id &&
                   Nome == condutores.Nome &&
                   Cpf == condutores.Cpf &&
                   Endereco == condutores.Endereco &&
                   Email == condutores.Email &&
                   Telefone == condutores.Telefone &&
                   Cnh == condutores.Cnh &&
                   ValidadeCnh == condutores.ValidadeCnh;
        }
        public override string ToString()
        {
            return Nome;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Cpf, Endereco, Email, Telefone, Cnh, ValidadeCnh);
        }
    }
}
