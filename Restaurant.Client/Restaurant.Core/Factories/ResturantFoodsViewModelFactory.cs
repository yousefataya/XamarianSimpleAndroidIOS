using System;
using System.Diagnostics.CodeAnalysis;
using Autofac;
using Restaurant.Abstractions.Factories;
using Restaurant.Abstractions.ViewModels;
using Restaurant.Core.ViewModels;
namespace Restaurant.Core.Factories
{
   public class ResturantFoodsViewModelFactory : IResturantFoodsViewModelFactory
    {

        private readonly IContainer _container;

        public ResturantFoodsViewModelFactory(IContainer container)
        {
            _container = container;
        }

        public IResturantFoodsViewModel GetResturantFoodsViewModel()
        {
            var value = _container.Resolve<SelectResturantFoodsViewModel>();
            return value;
        }

    }
}
