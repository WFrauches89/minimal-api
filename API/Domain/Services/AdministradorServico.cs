using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using minimal_api.Domain.DTO;
using minimal_api.Domain.Entities;
using minimal_api.Domain.Enum;
using minimal_api.Domain.Interfaces;
using minimal_api.Domain.ModelViews;
using minimal_api.Infra.Db;

namespace minimal_api.Domain.Services
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContextInfra _contexto;
        public AdministradorServico(DbContextInfra contexto)
        {
            _contexto = contexto;
        }

        public Administrador Create(Administrador administrador)
        {
            _contexto.Administradores.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public Administrador? GetAdministradorById(int id)
        {
            return _contexto.Administradores.Where(v => v.Id == id).FirstOrDefault();

        }


        public List<Administrador> GetAll(int? page)
        {
            var query = _contexto.Administradores.AsQueryable();

            int itensPorPagina = 10;

            if (page != null)
                query = query.Skip(((int)page - 1) * itensPorPagina).Take(itensPorPagina);

            return query.ToList();

        }

        public Administrador? Login(LoginDTO login)
        {
            var admin = _contexto.Administradores.Where(
                adm => adm.Email == login.Email && adm.Senha == login.Senha
            ).FirstOrDefault();

            return (admin);

        }


    }
}