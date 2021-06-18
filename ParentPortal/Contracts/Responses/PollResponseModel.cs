using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using System.Linq;
namespace ParentPortal.Contracts.Responses
{
    public class PollResponseModel : BaseMultipleRecordResponse<PollData>
    {

    }
    public class PollData
    {
        public int? id { get; set; }
        public string Question { get; set; }
        [JsonProperty("options")]
        public List<PollOption> Options { get; set; }
        public bool IsAnswerSubmitted
        {
            get
            {
                return Options != null && Options.Any(x => x.IsSelected);
            }
        }
    }
    public class PollOption : INotifyPropertyChanged
    {
        [JsonProperty("value")]
        public int Value { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        private bool _isselected = false;
        [JsonProperty("isSelected")]
        public bool IsSelected
        {
            get
            {
                return _isselected;
            }
            set
            {
                _isselected = value;
                BackgroundColor = _isselected ? Color.FromHex("#A0D083") : Color.White;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        [JsonIgnore]
        private Color _backgorundColor = Color.White;
        public Color BackgroundColor
        {
            get
            {
                return _backgorundColor;
            }
            set
            {
                _backgorundColor = value;
                OnPropertyChanged(nameof(BackgroundColor));

            }
        }
        [JsonIgnore]
        public string _optionIndex;
        [JsonIgnore]
        public string OptionIndex
        {
            get
            {
                return _optionIndex;
            }
            set
            {
                _optionIndex = value;
                OnPropertyChanged(nameof(OptionIndex));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
