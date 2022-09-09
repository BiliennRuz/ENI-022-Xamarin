using MeteoForms.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(MeteoForms.Droid.DependencyService.Toast))]
namespace MeteoForms.Droid.DependencyService
{
    
    public class Toast : ToastInterface
    {
        public void ShowToast(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, 
                 message, Android.Widget.ToastLength.Long).Show();

            // Toast.makeText(this, "Message", Toast.LENGTH_LONG).show();
        }
    }
}