using System.Collections.Generic;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class WeaponChangeSize
	{
		private static string damageKey;
		private static string sizeKey;
		private static Dictionary<string, double> scaleMultiplier;
		private static Dictionary<string, string> d4DamageScale;
		private static Dictionary<string, Dictionary<string, string>> scaledDamage;
		private static WeaponItem sizedWeapon;
		private static double sizeMultiplier;
		private static string newDamage;

		internal static WeaponItem ChangeWeaponSize(WeaponItem weapon, string size)
		{
			sizeKey = size;
			sizedWeapon = weapon;
			damageKey = weapon.GetDamage();
			GetSizingValues();
			SetNewSizingProperties();
			return sizedWeapon;
		}

		static WeaponChangeSize()
		{
			LoadSizingDictionaries();
		}

		private static void GetSizingValues()
		{
			sizeMultiplier = scaleMultiplier[sizeKey];
			newDamage = scaledDamage[damageKey][sizeKey];
		}

		private static void SetNewSizingProperties()
		{
			sizedWeapon.SetName(sizeKey);
			DetermineCostModifier();
			sizedWeapon.SetDamage(newDamage);
			sizedWeapon.SetWeight(sizeMultiplier);
			sizedWeapon.SetHardness(sizeMultiplier);
			sizedWeapon.SetHitPoints(sizeMultiplier);
			
		}

		private static void DetermineCostModifier()
		{
			if (sizeKey == "Small")
			{
				sizedWeapon.SetCost(1);
			}
			else
			{
				sizedWeapon.SetCost(sizeMultiplier);
			}
		}

		private static void LoadSizingDictionaries()
		{
			scaleMultiplier = new Dictionary<string, double>
			{
				{"Fine", 0.0625}, {"Diminutive", 0.125}, {"Tiny", 0.25}, {"Small", 0.5}, 
				{"Large", 2}, {"Huge", 4}, {"Gargantuan", 8}, {"Colossal", 16},
			};

			d4DamageScale = new Dictionary<string, string>
			{
				{"Fine", "No Meaningful Damage"}, {"Diminutive", "1"}, {"Tiny", "1d2"},
				{"Small", "1d3"}, {"Large", "1d6"}, {"Huge", "1d8"}, {"Gargantuan", "2d6"}, {"Colossal", "3d6"},
			};

			scaledDamage = new Dictionary<string, Dictionary<string, string>>
			{
				{"1d4", d4DamageScale},
			};
		}
	}
}
