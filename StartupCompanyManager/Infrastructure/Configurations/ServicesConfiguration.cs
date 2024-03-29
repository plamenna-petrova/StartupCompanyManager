﻿using Autofac;
using Microsoft.Extensions.DependencyInjection;
using StartupCompanyManager.Application;
using StartupCompanyManager.Core.Facade;
using StartupCompanyManager.Core.Facade.SubSystems;
using StartupCompanyManager.Core.Factory.ConcreteCreators;
using StartupCompanyManager.Infrastructure.Repositories.Contracts;
using StartupCompanyManager.Infrastructure.Repositories.Implementation;
using StartupCompanyManager.Utilities.Interpreter.Expressions;

namespace StartupCompanyManager.Infrastructure.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IDepartmentRepository, DepartmentRepository>();
            serviceCollection.AddScoped<IInvestorRepository, InvestorRepository>();
            serviceCollection.AddScoped<ITeamRepository, TeamRepository>();
            serviceCollection.AddScoped<IProjectRepository, ProjectRepository>();
            serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            serviceCollection.AddScoped<ITaskRepository, TaskRepository>();
            serviceCollection.AddScoped<DepartmentsSubSystem>();
            serviceCollection.AddScoped<InvestorsSubSystem>();
            serviceCollection.AddScoped<TeamsSubSystem>();
            serviceCollection.AddScoped<ProjectsSubSystem>();
            serviceCollection.AddScoped<EmployeesSubSystem>();
            serviceCollection.AddScoped<TasksSubSystem>();
            serviceCollection.AddScoped<StartupCompanyManagerFacade>();
            serviceCollection.AddScoped<StartupCompanyManagerCommandConcreteCreator>();
            serviceCollection.AddScoped<ConsoleInputOperationExpression>();
            serviceCollection.AddScoped<IStartupCompanyManagerApplication, StartupCompanyManagerApplication>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
