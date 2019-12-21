using System;
using System.Diagnostics.CodeAnalysis;
using Autofac;
using Restaurant.Abstractions.Factories;
using Restaurant.Abstractions.ViewModels;
using Restaurant.Core.ViewModels;

namespace Restaurant.Core.Factories
{
    [ExcludeFromCodeCoverage]
    public class ResturantInfoViewModelFactory : IResturantInfoViewModelFactory
    {
        private readonly IContainer _container;

        public ResturantInfoViewModelFactory(IContainer container)
        {
            _container = container;
        }

        public IRestaruantInfoViewModel GetRestaruantInfoViewModel()
        {
            var value = _container.Resolve<SelectResturantInfoViewModel>();
            return value;
        }
    }
}
