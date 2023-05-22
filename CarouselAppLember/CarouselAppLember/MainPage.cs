using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CarouselAppLember
{
    public partial class MainPage : ContentPage
    {
        List<CarouselPage> ContentPages = new List<CarouselPage>() { new ColorsPages()};
        List<string> tekstid = new List<string>() { "Colors" };
        public MainPage()
        {
            Title = "Menu";

            StackLayout st1 = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions= LayoutOptions.Center,
                HorizontalOptions= LayoutOptions.Center,
                BackgroundColor = Color.White,
            };
            for (int i = 0; i < ContentPages.Count; i++)
            {
                Button button = new Button()
                {
                    Text = tekstid[i],
                    TabIndex = i,
                    BackgroundColor = Color.Gray,
                    TextColor = Color.Black,
                };
                button.Clicked += Navig_funktsion;
                st1.Children.Add(button);
            }
            Content = st1;


        }
        private async void Navig_funktsion(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            await Navigation.PushModalAsync(ContentPages[b.TabIndex]);
        }
    }
}