namespace AndroidObjectives.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// 
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {
        /// <summary>
        /// 
        /// </summary>
        public LocationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void btnLocation_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    lblLatitude.Text = "Latitude: " + location.Latitude.ToString();
                    lblLongitude.Text = "Longitude:" + location.Longitude.ToString();

                    lblAccuracy.Text = "Accuracy:" + location.Accuracy.ToString();
                    lblAltitude.Text = "Altitude:" + location.Altitude.ToString();
                    lblAltitudeReferenceSystem.Text = "AltitudeReferenceSystem:" + location.AltitudeReferenceSystem.ToString();
                    lblCourse.Text = "Course:" + location.Course.ToString();
                    lblIsFromMockProvider.Text = "IsFromMockProvider:" + location.IsFromMockProvider.ToString();
                    lblSpeed.Text = "Speed:" + location.Speed.ToString();

                    lblTimestamp.Text = "Timestamp:" + location.Timestamp.ToString();
                    lblVerticalAccuracy.Text = "VerticalAccuracy:" + location.VerticalAccuracy.ToString();

                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }

        }

    }
}