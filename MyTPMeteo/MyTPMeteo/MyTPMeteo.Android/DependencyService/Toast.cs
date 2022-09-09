
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyTPMeteo.DependencyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyTPMeteo.Droid.DependencyService.ShowToast))]

namespace MyTPMeteo.Droid.DependencyService
{
    class ShowToast : ToastInterface
    {
        public void toast(string message)
        {
            
        }
    }
}