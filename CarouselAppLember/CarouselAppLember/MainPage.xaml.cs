using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarouselApp
{
    public partial class MainPage : CarouselPage
    {
        public MainPage()
        {

            string[] colors = { "Red", "Blue", "Green", "Yellow" };

            for (int i = 0; i < colors.Length; i++)
            {
                var contentPage = new ContentPage
                {
                    Content = new StackLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                Text= colors[i],
                                FontSize= Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                HorizontalOptions= LayoutOptions.Center
                            },
                            new BoxView
                            {
                                Color= Color.FromHex(colors[i]),
                                WidthRequest= 200,
                                HeightRequest= 200,
                                HorizontalOptions= LayoutOptions.Center,
                                VerticalOptions= LayoutOptions.CenterAndExpand
                            }
                        }
                    }
                };

                Children.Add(contentPage);
            }
        }
    }
}
