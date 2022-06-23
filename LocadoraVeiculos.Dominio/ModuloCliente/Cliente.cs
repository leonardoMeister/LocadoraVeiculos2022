using LocadoraVeiculos.Dominio.shared;

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
    }
}
