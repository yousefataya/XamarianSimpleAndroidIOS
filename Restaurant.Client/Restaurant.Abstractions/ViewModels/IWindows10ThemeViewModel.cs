using System.Windows.Input;

namespace Restaurant.Abstractions.ViewModels
{
    public interface IWindows10ThemeViewModel :  INavigatableViewModel
    {
        ICommand GoCatalog { get; }

        ICommand GoBack { get; }

        string Name { get; set; }

        string Address { get; set; }

        string StreetName { get; set; }
    }
}
