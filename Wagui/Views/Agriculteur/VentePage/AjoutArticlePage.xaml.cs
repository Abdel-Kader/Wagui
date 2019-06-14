using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wagui.Views.Agriculteur.VentePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjoutArticlePage : ContentPage
    {
        public AjoutArticlePage()
        {
            InitializeComponent();
        }

        private async void Take_photo1(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported && !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Camera non dispobible", "Camera non trouvé", "OK");
                return;
            }
            else
            {
                MediaFile file;
                var source = await DisplayActionSheet("Voulez voulez prendre une photo ou en choisir dans la galerie ?", "Annuler", null, "Galerie", "Camera");
                switch (source)
                {
                    case "Annuler":
                        file = null;
                        break;
                    case "Galerie":
                        file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                        {
                            PhotoSize = PhotoSize.Small
                        });
                        if (file == null)
                            return;
                        //await DisplayAlert("File Path", file.Path, "Ok");
                       // imagContent.IsVisible = true;
                        MainImage1.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                        break;
                    case "Camera":
                        file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                        {
                            Directory = "Images",
                            SaveToAlbum = true,
                        });

                        if (file == null)
                            return;
                        //await DisplayAlert("File Path", file.Path, "Ok");
                       // imagContent.IsVisible = true;
                        MainImage1.Source = ImageSource.FromStream(() =>
                        {
                            var stream = file.GetStream();
                            file.Dispose();
                            return stream;
                        });
                        break;
                    default:
                        break;
                }

            }


        }

        private async void Take_photo2(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported && !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Camera non dispobible", "Camera non trouvé", "OK");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(
               new StoreCameraMediaOptions
               {
                   Directory = "Images",
                   SaveToAlbum = true,
               });

                if (file == null)
                    return;
                //await DisplayAlert("File Path", file.Path, "Ok");
               // imagContent.IsVisible = true;
                MainImage2.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }


        }

        private async void Take_photo3(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported && !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Camera non dispobible", "Camera non trouvé", "OK");
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(
               new StoreCameraMediaOptions
               {
                   Directory = "Images",
                   SaveToAlbum = true,
               });

                if (file == null)
                    return;
                // await DisplayAlert("File Path", file.Path, "Ok");
              //  imagContent.IsVisible = true;
                MainImage3.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }


        }

       

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}