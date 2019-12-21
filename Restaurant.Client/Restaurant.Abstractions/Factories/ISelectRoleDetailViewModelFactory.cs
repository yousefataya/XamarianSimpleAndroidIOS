using Restaurant.Abstractions.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Abstractions.Factories
{
   public interface ISelectRoleDetailViewModelFactory
    {
        ISelectRoleDetails GetRoleDetailViewModel();

    }
}
