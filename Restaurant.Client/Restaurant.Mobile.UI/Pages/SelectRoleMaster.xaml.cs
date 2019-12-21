using Restaurant.Abstractions.ViewModels;
using Restaurant.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant.Mobile.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectRoleMaster : BaseContentPage<SelectRolePageViewModel> /*, ISelectRolePage*/
    {
        public ListView ListView;

        public SelectRoleMaster()
        {
            InitializeComponent();
            this.BindingContext = new SelectRoleContext();
            ListView = MenuItemsListView;
        }

        class SelectRoleMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<SelectRoleMasterMenuItem> MenuItems { get; set; }

            public SelectRoleMasterViewModel()
            {
                MenuItems = new ObservableCollection<SelectRoleMasterMenuItem>(new[]
                {
                    new SelectRoleMasterMenuItem { Id = 0, Title = "Page 1" },
                    new SelectRoleMasterMenuItem { Id = 1, Title = "Page 2" },
                    new SelectRoleMasterMenuItem { Id = 2, Title = "Page 3" },
                    new SelectRoleMasterMenuItem { Id = 3, Title = "Page 4" },
                    new SelectRoleMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}