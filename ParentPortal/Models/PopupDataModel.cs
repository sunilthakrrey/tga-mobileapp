using System.Windows.Input;

namespace ParentPortal.Models
{
    public class PopupDataModel
    {
        public string Message { get; set; }

        public ICommand PopUpNavigatioButtonCommand { get; set; }
    }
}
