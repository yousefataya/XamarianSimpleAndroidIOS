using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Abstractions.ViewModels
{
   public interface ISelectRoleDetailsViewModel
    {
        string OrderBy { get; set; }
        ISelectRoleReactiveObject SelectRoleViewModel { get; set; }
    }
}
