using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.MaterialTypes
{
	public class AlchemicalSilver : IMaterialComponent
	{
		// Alchemical siver can be applied to:
		//		Ammunition: +2 gold
		//		Light weapons: +20 gold
		//		One Handed weapons, or one head of a double weapon: +90 gold
		//		Two-handed weapons, or both heads of a double weapon: +180 gold
		// Weapons always receive a -1 to damage roll
		// Alchemical silver does not work on rare materials

		private const double ammunitionCostModifier = 2;
		private const double lightWeaponCostModifier = 20;
		private const double oneHandedWeaponCostModifier = 90;
		private const double twoHandedWeaponCostModifier = 180;
		private const double weaponDamageBonus = -1;

		public string ComponentName
		{
			get { return "Alchemical Silver"; ; }
		}

		// The multiple cost modifiers based on the kind of weapon calls into question the need for this property.
		public double WeaponCostModifier
		{
			get { return 0; }
		}

		public bool IsMasterwork
		{
			get { return false; }
		}

		public string ToHitBonus
		{
			get { return string.Empty; }
		}

		public double DamageBonus
		{
			get { return weaponDamageBonus; }
		}

		public string ComponentInfo
		{
			get { return "I am an alchemical silver weapon"; }
		}

		public double ApplyCostModifier(IWeapon weapon)
		{
			if (weapon.WeaponCategory.Contains("Light"))
			{
				return weapon.WeaponCost + lightWeaponCostModifier;
			}
			return weapon.WeaponCost;
		}

		public string AppendSpecialInfo(IWeapon weapon)
		{
			return string.Format("{1}{0}{2}", Environment.NewLine, weapon.SpecialInfo, ComponentInfo);
		}

		public string ApplyToHitModifier()
		{
			return ToHitBonus;
		}

		public double ApplyDamageModifier(IWeapon weapon)
		{
			if (weapon.IsBow)
			{
				return 0;
			}
			return DamageBonus;
		}

		public bool VerifyMasterwork(IWeapon weapon)
		{
			return IsMasterwork;
		}

		public double ApplyWeightModifer(IWeapon weapon)
		{
			return weapon.Weight;
		}

		public double GetAdditionalEnchantmentCost()
		{
			return 0;
		}
	}
}
