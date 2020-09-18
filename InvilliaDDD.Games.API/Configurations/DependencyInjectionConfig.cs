using FluentValidation.Results;
using InvilliaDDD.Core.Communication;
using InvilliaDDD.Core.Communication.Mediator;
using InvilliaDDD.GameManager.Application.Interfaces;
using InvilliaDDD.GameManager.Application.Services;
using InvilliaDDD.GameManager.Data;
using InvilliaDDD.GameManager.Data.Repository;
using InvilliaDDD.GameManager.Domain.Commands.Games;
using InvilliaDDD.GameManager.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvilliaDDD.GameManager.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.RegisterGame();

            services.AddScoped<GameManagerContext>();
        }

        private static void RegisterGame(this IServiceCollection services)
        {
            services.AddScoped<IGameAppService, GameAppService>();

            services.AddScoped<IRequestHandler<RegisterNewGameCommand, ResponseResult>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGameCommand, ResponseResult>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteGameCommand, ResponseResult>, GameCommandHandler>();

            services.AddScoped<IGameRepository, GameRepository>();
        }
    }
}
