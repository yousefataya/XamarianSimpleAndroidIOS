using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Abstractions.ViewModels
{
   public interface ISelectRoleReactiveObject
    {

        DateTime transactionDate { get; set; }
        string   PersonName { get; set; }
        string   Address { get; set; }
        string   MobileNumber { get; set; }

    }
}
