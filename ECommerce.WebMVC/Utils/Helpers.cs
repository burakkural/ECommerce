using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.WebMVC.Utils
{
    public static class Helpers
    {
        public static List<Gender> FillGender()
        {
            return new List<Gender>
            {
                new Gender{Id = 1 , GenderName = "Erkek"},
                new Gender{Id = 2 , GenderName = "Kadın"},
            };
        }

        public class Gender
        {
            public int Id { get; set; }
            public string GenderName { get; set; }
        }
    }
}
