using System.Windows.Input;

namespace Restaurant.Abstractions.ViewModels
{
    public interface ISelectRolePage : INavigatableViewModel
    {
        ICommand GoWorker { get; }

        ICommand GoCustomer { get; }

        string Mobile { get; set; }

        string Address { get; set; }

        string PersonName { get; set; }

    }
}
