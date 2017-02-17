using System;
using System.Linq;
using ItemSmithWorkShop.WeaponUtilities;
using ItemSmithWorkShop.AdventureItems.Interfaces;

namespace ItemSmithWorkShop
{
	public class ItemTicket : ILineItems
	{
		internal static WeaponData GetWeaponTicket(string weaponName)
		{
			return TempWeaponDictionary.GetWeaponData(weaponName);
		}

		public static MaterialComponentData GetMaterialIngot(string ingotName)
		{
			return MaterialComponentDictionary.GetComponentData(ingotName);
		}

		public static EnchantmentData GetSpecialAbilityTicket(string specialAbilityName)
		{
			var specialAbilityInfo = EnchantmentDictionary.GetEnchantmentData(specialAbilityName);
			return specialAbilityInfo;
		}
	}
}
