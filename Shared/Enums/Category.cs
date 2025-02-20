using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Enums
{
    public enum Category
    {
        Animals,
        Food,
        Countries
    }
    public static class ExtendedCategory
    {
        public static Category GetCategory(this string categoryName)
        {
            switch (categoryName)
            {
                case "Animals":
                    return Category.Animals;
                case "Food":
                    return Category.Food;
                case "Countries":
                    return Category.Countries;
            }
            return new Category();
        }
    }
}
