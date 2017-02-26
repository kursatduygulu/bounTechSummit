using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace BounMeals
{
    public class MealsViewModel: INotifyPropertyChanged
    {
        public async Task Initialize()
        {
            MealsApi m = new MealsApi();
            dailyMeals = await m.GetAllMeals();
        }

        public MealsViewModel()
        {
        }

        List<DailyMealViewModel> dailyMeals;

        public List<DailyMealViewModel> DailyMeals
        {
            get
            {
                return dailyMeals;
            }
            set
            {
                dailyMeals = value;
                OnPropertyChanged(nameof(DailyMeals));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
