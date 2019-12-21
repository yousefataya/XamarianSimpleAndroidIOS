using System;
using System.Diagnostics.CodeAnalysis;
using Autofac;
using Restaurant.Abstractions.Factories;
using Restaurant.Abstractions.ViewModels;
using Restaurant.Core.ViewModels;

namespace Restaurant.Core.Factories
{
    [ExcludeFromCodeCoverage]
    public class SelectRoleDetailViewModelFactory : ISelectRoleDetailViewModelFactory
    {
        private readonly IContainer _container;

        public SelectRoleDetailViewModelFactory(IContainer container)
        {
            _container = container;
        }

        public ISelectRoleDetails GetRoleDetailViewModel()
        {
            var value = _container.Resolve<SelectRoleBaseViewModel>();
            return value;
        }
    }
}
