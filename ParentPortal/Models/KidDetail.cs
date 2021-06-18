using Newtonsoft.Json;
using ParentPortal.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace ParentPortal.Models
{
   public class KidDetail: INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("avtar")]
        public string Avtaar { get; set; }

        [JsonIgnore]
        private string _isHighlighted;

        

        public string IsHighlighted
        {
            get
            {
                return _isHighlighted;
            }
            set
            {
                _isHighlighted = value;
                OnPropertyChanged(nameof(IsHighlighted));
                
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
