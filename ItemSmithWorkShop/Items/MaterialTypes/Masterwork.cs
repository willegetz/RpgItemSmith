using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.MaterialTypes
{
	public class Masterwork : IMaterialComponent
	{
		// Masterwork applies to weapons, armor, and shields.
		// Depending on what is needed, Masterwork will do its thing.
		// Weapon adjustments will be made to weapons.
		// Armor adjustments will be made to armor.
		// Shield adjustments will be made to shields
		// Items that are not weapons, armor, and shields can also be made masterwork

		// Weapons
		// Attack roll bonus: +1 Enchantment
		// Cost is an additional 300 gold pieces

		// Armor and Shields
		// Armor check penalty is reduced by 1
		// Cost is an additional 150 gold pieces


		public string ComponentName { get { return "Masterwork"; } }
		public double WeaponCostModifier { get { return 300; } }
		public bool IsMasterwork { get { return true; } }
		public string ToHitBonus { get { return "+1"; } }
		public double DamageBonus { get { return 0; } }
		public string ComponentInfo { get { return "This is a finely crafted weapon of masterwork quality"; } }


		#region IMaterialComponent Members


		public double ApplyCostModifier(IWeapon weaopn)
		{
			return weaopn.WeaponCost + WeaponCostModifier;
		}

		public double GetAdditionalEnchantmentCost()
		{
			return 0;
		}

		public bool VerifyMasterwork(IWeapon weapon)
		{
			{
				if (weapon.IsMasterwork)
				{
					return weapon.IsMasterwork;
				}
				else
				{
					return IsMasterwork;
				}
			}
		}

		public string AppendSpecialInfo(IWeapon weapon)
		{
			return string.Format("{1}{0}{2}", Environment.NewLine, weapon.SpecialInfo, ComponentInfo);
		}

		public double ApplyWeightModifer(IWeapon weapon)
		{
			return weapon.Weight;
		}

		public string ApplyToHitModifier()
		{
			return ToHitBonus;
		}

		public double ApplyDamageModifier(IWeapon weapon)
		{
			return 0;
		}

		#endregion
	}
}
