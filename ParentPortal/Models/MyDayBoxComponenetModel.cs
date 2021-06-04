
using System.Collections.Generic;
using Xamarin.Forms;

namespace ParentPortal.Models
{
    public class MyDayBoxComponenetModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageSource Type { get; set; }
        public string NoOfMorningtea { get; set; }
        public string NoOfFruits { get; set; }
        public string NoOfWater { get; set; }
        public string NoOfBootles { get; set; }
        public List<int> MorningTea
        {
            get
            {
                return GetList(NoOfMorningtea);
            }
        }
        public List<int> Fruits
        {
            get
            {
                return GetList(NoOfFruits);
            }
        }
        public List<int> WaterIntake
        {
            get
            {
                return GetList(NoOfWater);
            }
        }
        public List<int> Bottles
        {
            get
            {
                return GetList(NoOfBootles);
            }
        }
        public KidDetail Kid { get; set; }

        public List<int> GetList(string count)
        {
            List<int> retval = new List<int> { };
            int result;

            if (int.TryParse(count, out result))
            {
                for (int index = 0; index <= result - 1; index++)
                {
                    retval.Add(index);
                }
            }

            return retval;
        }

    }


    public class KidDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ImageSource Avtaar { get; set; }

    }

   

}
