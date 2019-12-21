using ReactiveUI;
using Restaurant.Abstractions.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Core.ViewModels
{
   public class SelectRoleContext : ReactiveObject, ISelectRoleViewModel
	{
		private string _orderby;

		public string OrderBy
		{
			get => _orderby;
			set => this.RaiseAndSetIfChanged(ref _orderby, value);
		}

		private ISelectRoleReactiveObject _selectRoleReactiveObject;

		public ISelectRoleReactiveObject SelectRoleViewModel
		{
			get => _selectRoleReactiveObject;
			set => this.RaiseAndSetIfChanged(ref _selectRoleReactiveObject, value);
		}
	}
}
