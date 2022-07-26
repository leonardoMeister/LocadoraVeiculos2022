using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string TipoCombustivel { get; set; }
        public decimal CapacidadeTanque { get; set; }
        public DateTime Ano { get; set; }
        public decimal Quilometragem { get; set; }
        public byte[] Foto { get; set; }

        public GrupoVeiculos GrupoVeiculos { get; set; }
        public Guid GrupoVeiculosId { get; set; }

        public Veiculo()
        {

        }

        public Veiculo(string modelo, string placa, string marca, string cor, string tipoCombustivel, 
            decimal capacidadeTanque, DateTime ano, decimal quilometragem, byte[] foto, GrupoVeiculos grupoVeiculos)
        {
            Modelo = modelo;
            Placa = placa;
            Marca = marca;
            Cor = cor;
            TipoCombustivel = tipoCombustivel;
            CapacidadeTanque = capacidadeTanque;
            Ano = ano;
            Quilometragem = quilometragem;
            Foto = foto;
            GrupoVeiculos = grupoVeiculos;
        }
        public Veiculo Clone()
        {
            return MemberwiseClone() as Veiculo;
        }
        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   Modelo == veiculo.Modelo &&
                   Placa == veiculo.Placa &&
                   Marca == veiculo.Marca &&
                   Cor == veiculo.Cor &&
                   TipoCombustivel == veiculo.TipoCombustivel &&
                   CapacidadeTanque == veiculo.CapacidadeTanque &&
                   Quilometragem == veiculo.Quilometragem;
                   
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Modelo);
            hash.Add(Placa);
            hash.Add(Marca);
            hash.Add(Cor);
            hash.Add(TipoCombustivel);
            hash.Add(CapacidadeTanque);            
            hash.Add(Quilometragem);                        
            return hash.ToHashCode();
        }
    }
}