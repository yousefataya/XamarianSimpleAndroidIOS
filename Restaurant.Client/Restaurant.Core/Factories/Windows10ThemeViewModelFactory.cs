using System;
using System.Diagnostics.CodeAnalysis;
using Autofac;
using Restaurant.Abstractions.Factories;
using Restaurant.Abstractions.ViewModels;
using Restaurant.Core.ViewModels;
namespace Restaurant.Core.Factories
{
   public class Windows10ThemeViewModelFactory : IWindows10ThemeViewModelFactory
    {
        private readonly IContainer _container;

        public Windows10ThemeViewModelFactory(IContainer container)
        {
            _container = container;
        }

        public IWindows10ThemeViewModel GetWindows10ThemeViewModel()
        {
            var value = _container.Resolve<Windows10ThemeViewModel>();
            return value;
        }
    }
}
