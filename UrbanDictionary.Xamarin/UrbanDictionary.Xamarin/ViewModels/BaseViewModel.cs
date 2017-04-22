﻿using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Xamarin.Services;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        [MvxInject]
        public IDialogService DialogService { get; set; }

        [MvxInject]
        public INetworkService NetworkService { get; set; }

        public BaseViewModel()
        {
            
        }

        protected void ShowError()
        {
            var message = NetworkService.IsConnected ? "Something went wrong" : "Please check your internet status";
            var title = "Error";
            DialogService.ShowDialogAsync(title, message, "OK");
        }
    }
}
