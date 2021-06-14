using Android.App;
using Android.Content;
using Android.OS;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.Android;

namespace ParentPortal.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity:FormsAppCompatActivity
    {

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }
        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            // Performe some startup work that takes a bit of time.
            await Task.Delay(4000); // Simulate a bit of startup work.
            // Startup work is finished - starting MainActivity
            StartActivity(new Intent(Application.ApplicationContext, typeof(MainActivity)));
        }
    }
}