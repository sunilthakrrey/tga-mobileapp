
using Xamarin.Forms;

namespace ParentPortal.Models
{
    public class MyDayBoxComponenetModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageSource Type { get; set; }
        public int NoOfMorningtea { get; set; }
        public int NoOfFruits { get; set; }
        public int NoOfWater { get; set; }
        public int NoOfBootles { get; set; }
        public KidDetail Kid { get; set; }

    }
   
   
    public class KidDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ImageSource Avtaar { get; set; }

    }

}
