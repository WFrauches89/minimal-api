using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimal_api.Domain.DTO;
using minimal_api.Domain.Entities;
using minimal_api.Domain.Interfaces;
using minimal_api.Infra.Db;

namespace minimal_api.Domain.Services
{
    public class VeiculoServico : IVeiculoServico
    {
        private readonly DbContextInfra _contexto;
        public VeiculoServico(DbContextInfra contexto)
        {
            _contexto = contexto;
        }

        public List<Veiculo> GetAll(int? page = 1, string? model = null, string? brand = null)
        {
            var queryToSearch = _contexto.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(model))
            {
                queryToSearch = queryToSearch.Where(veic => EF.Functions.Like(veic.Modelo.ToLower(), $"{model}"));
            }


            if (!string.IsNullOrEmpty(brand))
            {
                queryToSearch = queryToSearch.Where(veic => EF.Functions.Like(veic.Marca.ToLower(), $"{brand}"));
            }

            int itemsPage = 10;

            if (page != null)
            {
                queryToSearch = queryToSearch.Skip(((int)page - 1) * itemsPage).Take(itemsPage);
            }

            return queryToSearch.ToList();
        }


        public Veiculo? GetByID(int id)
        {
            var veiculoBuscado = _contexto.Veiculos.Find(id);
            if (veiculoBuscado == null)
            {
                return null;
            }
            return veiculoBuscado;

        }

        public void NewVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Add(veiculo);
            _contexto.SaveChanges();
        }

        public void UpdateVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();
        }

        public void DeleteVeiculo(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo);
            _contexto.SaveChanges();

        }


    }
}