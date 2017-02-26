using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;

namespace BounMeals
{
    public class DailyMealViewModel: INotifyPropertyChanged
    {
        [JsonProperty(PropertyName = "date")]
        public DateTime MealDate { get; set; }

        private List<string> lunch;

        [JsonProperty(PropertyName = "lunch")]
        public List<string> Lunch 
        { 
            get
            {
                return lunch;
            }
            set
            {
                lunch = value;
                OnPropertyChanged(nameof(Lunch));
            }
        }

        [JsonProperty(PropertyName = "dinner")]
        public List<string> Dinner { get; set; }

        public string LunchJoined
        {
            get
            {
                return String.Join(" / ", Lunch);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
