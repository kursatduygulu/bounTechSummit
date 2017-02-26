using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BounMeals
{
    public partial class MonthlyMealListPage : ContentPage
    {
        MealsViewModel mealsVM;
        public MonthlyMealListPage()
        {
            InitializeComponent();
            mealsVM = new MealsViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ProgressBar.IsRunning = true;

            await mealsVM.Initialize();
            MonthlyList.ItemsSource = mealsVM.DailyMeals;

            ProgressBar.IsRunning = false;
            ProgressBar.IsVisible = false;
        }

        protected async void SelectMeal(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new DailyMealPage((DailyMealViewModel)e.Item));
        }
    }
}
