﻿using FluentValidation.Results;
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

namespace InvilliaDDD.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.RegisterGame();

            services.AddScoped<GameManagerContext>();
        }

        private static void RegisterGame(this IServiceCollection services)
        {
            services.AddScoped<IGameAppService, GameAppService>();

            services.AddScoped<IRequestHandler<RegisterNewGameCommand, ValidationResult>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGameCommand, ValidationResult>, GameCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteGameCommand, ValidationResult>, GameCommandHandler>();

            services.AddScoped<IGameRepository, GameRepository>();
        }
    }
}
