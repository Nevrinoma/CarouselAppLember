using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CarouselAppLember
{
    public partial class MainPage : ContentPage
    {
        List<CarouselPage> ContentPages = new List<CarouselPage>() { new ColorsPages() };
        List<string> tekstid = new List<string>() { "Colors" };
        Entry colorEntry;
        ColorsPages colorsPages;
        ColorsPages clrsnames = new ColorsPages();
        Label clrs = new Label();

        public MainPage()
        {
            Title = "Menu";

            StackLayout st1 = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
            };

            colorEntry = new Entry()
            {
                Placeholder = "Enter color name"
            };

            Button addButton = new Button()
            {
                Text = "Add",
                BackgroundColor = Color.Gray,
                TextColor = Color.Black
            };
            addButton.Clicked += AddButton_Clicked;

            
            
              


            st1.Children.Add(colorEntry);
            st1.Children.Add(addButton);
            st1.Children.Add(clrs);

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

            colorsPages = (ColorsPages)ContentPages[0];
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {

            clrs.Text = "Colors:";
            clrs.HeightRequest = 200;
            clrs.WidthRequest= 200;
            foreach (var item in clrsnames.сolorDictionary)
            {
                clrs.Text += item.Key.ToString()+" ";
            }

            string colorName = colorEntry.Text;
            if (!string.IsNullOrEmpty(colorName))
            {
                colorsPages.AddColor(colorName);
                colorEntry.Text = string.Empty;
            }
        }

        private async void Navig_funktsion(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            await Navigation.PushModalAsync(ContentPages[b.TabIndex]);
        }

        

    }

}