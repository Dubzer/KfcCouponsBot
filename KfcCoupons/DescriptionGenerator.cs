using System.Collections.Generic;
using System.Linq;
using KfcCoupons.Models;

namespace KfcCoupons
{
    public class DescriptionGenerator
    {
        public string Generate(Product product)
        {
            var modifiersTitles = new List<string>();
            foreach (ModifierGroup group in product.ModifierGroups.Where(group => group.Modifiers.Length != 0))
            {
                int modifiersLength = group.Modifiers.Length;

                // Using detailed title if there aren't many elements here,
                // or generic title for a large number of elements
                string modifierString = modifiersLength < 3
                    ? string.Join('/', group.Modifiers.Select(modifier => $@"{modifier.Title}"))
                    : group.Title;

                modifiersTitles.Add(modifierString);
            }

            return $"*Комбо за {product.Price}₽* (ранее {product.OldPrice}₽)\n{GetNumberedList(modifiersTitles)}\n\n*Купон:* `{product.Coupon}`";
        }

        private static string GetNumberedList(IEnumerable<string> list) => string.Join("\n", list.Select((title, i) => $"*{i + 1}*. {title}"));
    }
}