using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using minimal_api.Domain.DTO;
using minimal_api.Domain.Entities;

namespace minimal_api.Domain.Interfaces
{
    public interface IVeiculoServico
    {
        List<Veiculo> GetAll(int? page = 1, string? nome = null, string? marca = null);
        Veiculo? GetByID(int id);
        void NewVeiculo(Veiculo veiculo);
        void UpdateVeiculo(Veiculo veiculo);
        void DeleteVeiculo(Veiculo veiculo);
    }
}