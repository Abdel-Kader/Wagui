using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wagui.Models;
using Wagui.Views.Agriculteur;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wagui.Views.Inscription
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IAgriculteur3 : ContentPage
    {
        public SignInCompletModel signInCompletModel;
        MediaFile file;
        public IAgriculteur3()
        {
            InitializeComponent();
            signInCompletModel = new SignInCompletModel();
            MessagingCenter.Subscribe<SignInCompletModel, string>(this, "Alert", async (sender, username) =>
            {
                if (username == "Yess")
                {
                    await DisplayAlert("Alert", "Félicitation vous venez de compléter votre inscription ! Vous serez redirigez sur la page d'acceuil", "Fermer");
                    Navigation.InsertPageBefore(new AgriculteurHome(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Alert", username, "OK");
                }

            });
            this.BindingContext = signInCompletModel;

        }

        private async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        
        private async void Cancel_click(object sender, EventArgs e)
        {
            Application.Current.Properties["step"] = "cancel3";
            Navigation.InsertPageBefore(new AgriculteurHome(), this);
            await Navigation.PopAsync();
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported && !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Camera non dispobible", "Camera non trouvé", "OK");
                return;
            }
            else
            {
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
                        Profil.IsVisible = true;
                        Profil.Source = ImageSource.FromStream(() =>
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
                        Profil.IsVisible = true;
                        Profil.Source = ImageSource.FromStream(() =>
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
        /*
        public async void UploadFile(object sender, EventArgs e)
        {
            var content = new MultipartFormDataContent
            {
                {
                    new StreamContent(file.GetStream()),
                    "\"file\"",
                    $"\"{file.Path}\""
                }
            };
            var httpClient = new HttpClient();
            var uploadService = "http://www.waguispace.com/mobile/account_api/photo/";
            var httpResponse = await httpClient.PostAsync(uploadService, content);

           await DisplayAlert("alert", httpResponse.Content.ReadAsStringAsync().ToString(), "fermer");
        }
        */
    }
}