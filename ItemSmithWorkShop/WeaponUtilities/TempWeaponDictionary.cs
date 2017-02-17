using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.AdventureItemUtilities;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class TempWeaponDictionary : AdventureItem
	{
		private static Dictionary<string, WeaponData> genericWeapons;

		static TempWeaponDictionary()
		{
			LoadWeaponDictionary();
		}

		public static WeaponData GetWeaponData(string weapon)
		{
			if (genericWeapons.ContainsKey(weapon))
			{
				return genericWeapons[weapon];
			}
			throw new KeyNotFoundException(string.Format("The Weapon '{0}' is not present in this collection of weapons.", weapon));
		}

		private static void LoadWeaponDictionary()
		{
			genericWeapons = new Dictionary<string, WeaponData>(StringComparer.OrdinalIgnoreCase)
			{
				{ "Dagger", new WeaponData { WeaponName = "Dagger", WeaponCategory = "Light Melee", WeaponProficiencyRequirement = "Simple Weapon", WeaponDamage = "1d4", WeaponThreatRange = 19, WeaponCritical = "x2", WeaponDamageType = "Piercing or Slashing", WeaponHardness = 10, WeaponHitPoints = 2, BasePrice = 2, WeaponWeight = 1, WeaponText = string.Format("Dagger: The dagger is a common secondary weapon. You get a +2 bonus on{0}\tSleight of Hand checks made to conceal a dagger on your body.", Environment.NewLine) } },
				{ "Short Sword", new WeaponData { WeaponName = "Short Sword", WeaponCategory = "Light Melee", WeaponProficiencyRequirement = "Martial Weapon", WeaponDamage = "1d6", WeaponThreatRange = 19, WeaponCritical = "x2", WeaponDamageType = "Slashing", WeaponHardness = 10, WeaponHitPoints = 2, BasePrice = 10, WeaponWeight = 2, WeaponText = "Short Sword: This sword is popular as an off-hand weapon." } },
				{ "Heavy Crossbow", new WeaponData { WeaponName = "Heavy Crossbow", WeaponCategory = "Ranged", WeaponProficiencyRequirement = "Simple Weapon", WeaponDamage = "1d10", WeaponThreatRange = 19, WeaponCritical = "x2", WeaponDamageType = "Piercing", RangeIncrement = "120 feet", WeaponHardness = 5, WeaponHitPoints = 5, BasePrice = 50, WeaponWeight = 8, WeaponText = string.Format("Heavy Crossbow: You  draw a heavy crossbow back by turning a small winch.{0}\tLoading a heavy crossbow is a full-round action that provokes\n\tan attack of opportunity.{0}\tNormally, operating a heavy crossbow requires two hands.\n\tHowever, you can shoot, but not load, a heavy crossbow with one{0}\thand at a -4 penalty on attack rolls. You can shoot a heavy crossbow{0}\twith each hand, but you take a penalty on attack rolls as if attacking{0}\twith two one-handed weapons.{0}\tThis penalty is cumulative with the penalty for one-handed firing.", Environment.NewLine) } },
				{ "Quarterstaff", new WeaponData { WeaponName = "Quarterstaff", WeaponCategory = "Two-Handed Melee", WeaponProficiencyRequirement = "Simple Weapon", WeaponDamage = "1d6/1d6", WeaponThreatRange = 20, WeaponCritical = "x2", WeaponDamageType = "Bludgeoning", WeaponHardness = 5, WeaponHitPoints = 10, BasePrice = 0, WeaponWeight = 4, WeaponText = "I am a quarterstaff" } },
				{ "Dwarven Urgrosh A", new WeaponData { WeaponName = "Dwarven Urgrosh", WeaponPart = "Axe Head", WeaponCategory = "Two-Handed Melee", WeaponProficiencyRequirement = "Exotic Weapon", WeaponDamage = "1d8", WeaponThreatRange = 20, WeaponCritical = "x2", WeaponDamageType = "Slashing", WeaponHardness = 5, WeaponHitPoints = 10, BasePrice = 50, WeaponWeight = 12, WeaponText = string.Format("Dwarvern Urgosh, Axe Head: A dwarven urgrosh is a double weapon.{0}\tThis is the axe head.", Environment.NewLine) } },
				{ "Dwarven Urgrosh B", new WeaponData { WeaponName = "Dwarven Urgrosh", WeaponPart = "Spear Head", WeaponDamage = "1d6", WeaponThreatRange = 20, WeaponCritical = "x2", WeaponDamageType = "Piercing", WeaponHardness = 5, WeaponHitPoints = 10, WeaponWeight = 12, BasePrice = 50, WeaponText = string.Format("Dwarven Urgosh, Spear Head: A dwarven urgrosh is a double weapon.{0}\tThis is the spear head.", Environment.NewLine) } },
				{ "", new WeaponData { WeaponName = "No Weapon Selected", WeaponCategory = "", WeaponProficiencyRequirement = "", WeaponDamage = "", WeaponThreatRange = 20, WeaponCritical = "", WeaponDamageType = "", WeaponHardness = 0, WeaponHitPoints = 0, BasePrice = 0, WeaponWeight = 0, WeaponText = "" } },
			};
		}
	}
}
