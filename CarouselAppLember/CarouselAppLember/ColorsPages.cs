using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CarouselAppLember
{
    public class ColorsPages : CarouselPage
    {
        public ColorsPages()
        {
            var colorDictionary = new Dictionary<string, Color>
            {
                { "Red", Color.Red},
                { "Blue", Color.Blue},
                { "Green", Color.Green},
                { "Yellow", Color.Yellow}
            };

            foreach (var color in colorDictionary)
            {
                var contentPage = new ContentPage
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

                Children.Add(contentPage);
            }
        }
    }
}
