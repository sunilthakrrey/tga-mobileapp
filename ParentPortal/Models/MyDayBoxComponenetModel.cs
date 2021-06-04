
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
        public List<int> Fruites
        {
            get
            {
                List<int> retval = new List<int> { };
                int result;

                if (int.TryParse(NoOfFruits, out result))
                {
                    for (int index = 0; index <= result - 1; index++)
                    {
                        retval.Add(index);
                    }
                }

                return retval;
            }
        }
        public KidDetail Kid { get; set; }

    }


    public class KidDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ImageSource Avtaar { get; set; }

    }

}
