using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CarouselAppLember
{
    public class ColorsPages : CarouselPage
    {
        private Dictionary<string, Color> colorDictionary;
        private StackLayout colorsLayout;

        public ColorsPages()
        {
            colorDictionary = new Dictionary<string, Color>
        {
            { "Red", Color.Red },
            { "Blue", Color.Blue },
            { "Green", Color.Green },
            { "Yellow", Color.Yellow }
        };

            colorsLayout = new StackLayout();

            RefreshColors(contentView);

            Children.Add(new ContentPage
            {
                Content = colorsLayout
            });
        }

        public void AddColor(string colorName)
        {
            if (!colorDictionary.ContainsKey(colorName))
            {
                colorDictionary.Add(colorName, GetRandomColor());
                RefreshColors(contentView);
            }
        }

        private void RefreshColors(ContentView contentView)
        {
            colorsLayout.Children.Clear();

            foreach (var color in colorDictionary)
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

                Children.Add(contentView);
            }
        }

        private Color GetRandomColor()
        {
            Random random = new Random();
            return Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
        }
    }


}
