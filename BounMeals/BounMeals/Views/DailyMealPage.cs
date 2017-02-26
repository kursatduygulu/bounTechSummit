using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace BounMeals
{
    public partial class DailyMealPage : ContentPage
    {
        public DailyMealPage() : this(new DailyMealViewModel())
        {
            
        }

        public DailyMealPage(DailyMealViewModel dailyMealVM)
        {
            InitializeComponent();

            CultureInfo turkishCulture = new CultureInfo("tr-TR");
            HeaderLabel.Text = String.Format("{0} tarihine ait yemek listesi", dailyMealVM.MealDate.ToString("D", turkishCulture));
            MealList.ItemsSource = dailyMealVM.Lunch;
        }

        protected async void ShowMealOptions(object sender, ItemTappedEventArgs e)
        {
            string mealName = e.Item.ToString();
            string mealInstructionsText = String.Format("{0} tarifini Google'da ara", mealName.Trim());
            string mealImagesText = String.Format("{0} Google Görseller'de ara", mealName.Trim());

            string selectedAction = await DisplayActionSheet("Seçenekler",
                                                       "İptal",
                                                       null,
                                                       mealInstructionsText,
                                                       mealImagesText);

            if (selectedAction.Equals(mealInstructionsText))
            {
                Device.OpenUri(new Uri("http://www.google.com/search?q=" + mealName + " tarifi"));
            }
            else if (selectedAction.Equals(mealImagesText))
            {
                Device.OpenUri(new Uri("http://www.google.com/search?q=" + mealName + "&tbm=isch"));
            }
        }
    }
}
