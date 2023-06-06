using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Security.Cryptography.X509Certificates;


namespace CarouselAppLember
{
    public class ColorsPages : CarouselPage
    {
        public Dictionary<string, Color> сolorDictionary { get; set; }
        private StackLayout colorsLayout;

        public ColorsPages()
        {
            сolorDictionary = new Dictionary<string, Color>
            {
            { "Red", Color.Red },
            { "Blue", Color.Blue },
            { "Green", Color.Green },
            { "Yellow", Color.Yellow }
            };

            colorsLayout = new StackLayout();

            RefreshColors();

            Children.Add(new ContentPage
            {
                Content = colorsLayout
            });
        }

        public void AddColor(string colorName)
        {
            if (!сolorDictionary.ContainsKey(colorName))
            {
                сolorDictionary.Add(colorName, System.Drawing.Color.FromName(colorName));
                RefreshColors();
            }
        }

        private void RefreshColors()
        {
            Children.Clear();

            foreach (var color in сolorDictionary)
            {
                var contentView = new ContentView
                {
                    Content = new StackLayout
                    {
                        Children =
                    {
                        new Label
                        {
                            Text= color.Key,
                            FontSize= Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            HorizontalOptions= LayoutOptions.Center
                        },
                        new BoxView
                        {
                            Color= color.Value,
                            WidthRequest= 200,
                            HeightRequest= 200,
                            HorizontalOptions= LayoutOptions.Center,
                            VerticalOptions= LayoutOptions.CenterAndExpand
                        },
                        new Button
                        {
                            Text = "Tagasi",
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.End,
                            Command = new Command(async () =>
                            {
                                await Navigation.PushModalAsync(new MainPage());
                            })
                        }
                    }
                    }
                };

                Children.Add(new ContentPage
                {
                    Content = contentView
                });
            }
        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            return Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
        }
    }
}
