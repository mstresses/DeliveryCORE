﻿using DAO.Context;
using DTO;
using DTO.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository;

namespace DAO.Repositories.ClienteRepository
{
    public class RestauranteRepository : GenericRepository<Restaurante>, IRestauranteRepository
    {
        public RestauranteRepository(DeliveryContext dbContext) : base(dbContext)
        {
        }
    }
}