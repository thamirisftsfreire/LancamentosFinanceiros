using LF.Application.AppServices;
using LF.Application.Interfaces;
using LF.Application.ViewModels;
using LF.Domain.Entities;
using LF.Domain.Interfaces.Repositories;
using LF.Domain.Interfaces.Services;
using LF.Domain.Services;
using LF.Domain.Validations;
using LF.Infrastructure.Data.Context;
using LF.Infrastructure.Data.Interfaces;
using LF.Infrastructure.Data.Repository;
using LF.Infrastructure.Data.Uow;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.CrossCutting.Ioc
{
    public class Bootstrapper
    {
        public static void RegisterServices(Container container)
        {
            // App
            container.Register<ILancamentoFinanceiroAppService, LancamentoFinanceiroAppService>(Lifestyle.Scoped);
            container.Register<IBalancoAppService, BalancoAppService>(Lifestyle.Scoped);
            container.Register<LancamentoFinanceiroVM>(Lifestyle.Scoped);
            container.Register<BalancoVM>(Lifestyle.Scoped);

            // Domain
            container.Register<ILancamentoFinanceiroService, LancamentoFinanceiroService>(Lifestyle.Scoped);
            container.Register<IBalancoService, BalancoService>(Lifestyle.Scoped);
            container.Register<LancamentoConciliadoValidation>(Lifestyle.Scoped);
            container.Register<LancamentoFinanceiro>(Lifestyle.Scoped);
            container.Register<Balanco>(Lifestyle.Scoped);


            // Infra Dados
            container.Register<ILancamentoFinanceiroRepository, LancamentoFinanceiroRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<LFContext>(Lifestyle.Scoped);

        }
    }
}
