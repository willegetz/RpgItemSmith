using System;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.WeaponSpecialQualities;
using ItemSmithWorkShop.WeaponUtilities;
using ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites
{
	public class WeaponItemSmith
	{
		public static WeaponItem OrderItem(string order)
		{
			if (string.IsNullOrEmpty(order))
			{
				throw new ArgumentNullException(string.Format("Weapon Name: '{0}'", order), "The name of the weapon must be specified");
			}
			return new WeaponItem(new WeaponOrder(TempWeaponDictionary.GetWeaponData(order)));
		}

		internal static WeaponItem SizeWeapon(WeaponItem weapon, string size)
		{
			var sizedWeapon = WeaponChangeSize.ChangeWeaponSize(weapon, size);
			return sizedWeapon;
		}

		public static ExtraordinaryQualityWeapon OrderSpecialComponent(WeaponItemWeaver weapon, string materialComponent)
		{
			if (weapon == null)
			{
				throw new ArgumentNullException(string.Format("There is no weapon to make.{0}Please select a weapon", Environment.NewLine));
			}
			if (string.IsNullOrEmpty(materialComponent))
			{
				throw new ArgumentNullException(string.Format("Material Component Name: '{0}' for '{1}'", materialComponent, weapon.GetName()), "The name of the material must be specified");
			}
			var component = new MaterialComponentOrder(MaterialComponentDictionary.GetComponentData(materialComponent));
			return new ExtraordinaryQualityWeapon(weapon, component);
		}

		/*
		* Proofs of Concept 
		*/

		public static MasterworkWeaponItem OrderBlah(WeaponOrder weapon, string materialComponent)
		{
			var component = new MaterialComponentOrder(MaterialComponentDictionary.GetComponentData(materialComponent));
			return new MasterworkWeaponItem(weapon, component);
		}

		internal static WeaponOrder OrderBlah(string p)
		{
			return new WeaponOrder(TempWeaponDictionary.GetWeaponData(p));
		}
	}
}
