using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using LocadoraVeiculos.Dominio.shared;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase
    {
        public string Modelo;
        public string Placa;
        public string Marca;
        public string Cor;
        public string TipoCombustivel;
        public decimal CapacidadeTanque;
        public DateTime Ano;
        public decimal Quilometragem;
        public byte[] Foto;

        public GrupoVeiculos GrupoVeiculos;

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

        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&
                   _id == veiculo._id &&
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
            hash.Add(_id);
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