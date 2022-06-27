using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase
    {
        public Cliente(string nome, string cpf, string endereco, string email, string telefone, string tipocliente, string cnh)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            TipoCliente = tipocliente;
            Cnh = cnh;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string TipoCliente { get; set; }
        public string Cnh { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                   _id == cliente._id &&
                   Nome == cliente.Nome &&
                   Cpf == cliente.Cpf &&
                   Endereco == cliente.Endereco &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   TipoCliente == cliente.TipoCliente &&
                   Cnh == cliente.Cnh;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id, Nome, Cpf, Endereco, Email, Telefone, TipoCliente, Cnh);
        }
    }
}
