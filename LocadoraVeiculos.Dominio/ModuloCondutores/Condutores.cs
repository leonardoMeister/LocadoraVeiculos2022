using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloCondutores
{
    public class Condutores:EntidadeBase
    {
        public Condutores(string nome, string cpf, string endereco, string email, string telefone, string cnh, string validadecnh)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            Cnh = cnh;
            ValidadeCnh = validadecnh;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnh { get; set; }
        public string ValidadeCnh { get; set; }
    }
}
