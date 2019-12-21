using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Restaurant.Abstractions.ViewModels
{
   public interface IResturantFoodsViewModel : INavigatableViewModel
    {
        ICommand GoCatalog { get; }

        ICommand GoBack { get; }

        string Name { get; set; }

        string Price { get; set; }

        string Size { get; set; }

    }
}
