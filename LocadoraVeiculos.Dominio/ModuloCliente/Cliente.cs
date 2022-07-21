using LocadoraVeiculos.Dominio.shared;
using System;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase
    {

        public Cliente(string nome, string cpf, string endereco, string email, string telefone, string tipocliente, string cnpj)
        {
            Cnpj = cnpj;
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            TipoCliente = tipocliente;

        }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string TipoCliente { get; set; }
        public Cliente Clone()
        {
            return MemberwiseClone() as Cliente;
        }
        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                   Id == cliente.Id &&
                   Cnpj == cliente.Cnpj &&
                   Nome == cliente.Nome &&
                   Cpf == cliente.Cpf &&
                   Endereco == cliente.Endereco &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   TipoCliente == cliente.TipoCliente;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Cnpj);
            hash.Add(Nome);
            hash.Add(Cpf);
            hash.Add(Endereco);
            hash.Add(Email);
            hash.Add(Telefone);
            hash.Add(TipoCliente);
            return hash.ToHashCode();
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
