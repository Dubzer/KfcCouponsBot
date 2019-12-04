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
            foreach (var group in product.ModifierGroups)
            {
                if (group.Modifiers.Length == 0)
                    continue;

                string modifierString = null;
                int modifiersLength = group.Modifiers.Length;

                for (int i = 0; i < modifiersLength; i++)
                {
                    modifierString += $@"{group.Modifiers[i].Title.Ru}{(i + 1 != modifiersLength ? "/" : null)}";
                }

                modifiersTitles.Add(modifierString);
            }

            return $"*Комбо за {product.Price}₽* (ранее {product.OldPrice}₽)\n{string.Join("\n", modifiersTitles.Select((title, i) => $"{i + 1}. {title}"))}\n\n*Купон:* `{product.Coupon}`";
        }
    }
}