using System;
using System.Linq;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities
{
	public class WeaponEnchanter
	{
		public static EnchantedWeaponItem RequestEnchantment(WeaponItemWeaver magicWeapon, string enchantment)
		{
			var newEnchantment = new WeaponEnchantment(new EnchantmentOrder(EnchantmentDictionary.GetEnchantmentData(enchantment)));
			return new EnchantedWeaponItem(magicWeapon, newEnchantment);
		}
	}
}
