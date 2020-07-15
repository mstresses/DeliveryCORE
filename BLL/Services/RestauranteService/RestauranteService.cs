﻿using BLL.Interfaces;
using BLL.Validators;
using Common;
using Common.Extensions;
using DAO;
using DAO.Interfaces;
using DTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class RestauranteService : RestauranteValidator, IRestauranteService
    {
        private IRestauranteRepository _restauranteRepository;

        public RestauranteService(IRestauranteRepository restauranteRepository)
        {
            this._restauranteRepository = restauranteRepository;
        }

        public async Task Insert(Restaurante restaurante)
        {
            try
            {
                await _restauranteRepository.Insert(restaurante);
            }
            catch (Exception ex)
            {
                List<Error> error = new List<Error>();
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("UQ"))
                {
                    error.Add(new Error() { FieldName = "CNPJ", Message = "CNPJ já cadastrado" });
                    throw new Exception();
                }

                var resposta = restaurante.CNPJ.IsValidCNPJ();
                if (resposta != "") error.Add(new Error() { FieldName = "CNPJ", Message = "CNPJ INVÁLIDO =" + resposta });

                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task Update(Restaurante restaurante)
        {
            try
            {
                await _restauranteRepository.Update(restaurante);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task Delete(Restaurante restaurante)
        {
            try
            {
                await _restauranteRepository.Delete(restaurante);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        Task<List<Restaurante>> IRestauranteService.GetRestaurantes()
        {
            return _restauranteRepository.GetRestaurantes();

        }

        public async Task<List<Restaurante>> GetRestaurantesByCategorias(string categoria)
        {
            return await _restauranteRepository.GetRestaurantesByCategorias(categoria);
        }
    }
}