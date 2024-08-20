using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Domain.DTO;
using minimal_api.Domain.Entities;
using minimal_api.Domain.ModelViews;

namespace minimal_api.Domain.Interfaces
{
    public interface IAdministradorServico
    {
        Administrador? Login(LoginDTO login);

        Administrador Create(Administrador administrador);

        List<Administrador> GetAll(int? page);

        Administrador? GetAdministradorById(int id);

    }
}