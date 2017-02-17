using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.MaterialTypes
{
	public class ColdIron : IMaterialComponent
	{
		// Cold iron is not for armor.
		// Cold iron weapons cost twice as much to make.
		//		A weapon that costs 2 gold pieces to make cost 4 if they are made of cold iron.
		// Magic enchantments cost and additional 2,000 gold pieces.
		//		This additional cost is applied after the standard cost is deduced.
		// A double weapon that only has one head made of cold iron increases its price by 50%.
		// Cold iron has 30 points per inch of thickness and hardness of 10

		private const string componentName = "Cold Iron";
		private const double weaponCostModifier = 2;
		private const bool isMasterowrk = false;
		private const double magicEnchantmentCostModification = 2000;

		private string coldIronSpecialInfo = "This iron mined deep underground, known for its\r\teffectiveness against fey creatures, is forged at a\r\tlower temperature to preserve its delicate properties.";

		public string ComponentName { get { return componentName; } }
		public double WeaponCostModifier { get { return weaponCostModifier; } }
		public bool IsMasterwork { get { return isMasterowrk; } }
		public string ToHitBonus { get { return string.Empty; } }
		public double DamageBonus { get { return 0; } }
		public string ComponentInfo { get  {return coldIronSpecialInfo; }}
		 
		public double MagicEnchantmentCostModification { get { return magicEnchantmentCostModification; } }

		public override string ToString()
		{
			return string.Format("Material:{1}'{2}'{0}Cost Multiplier:{1}'x{3} to base cost'{0}Additional Cost to Enchant:{1}'{4} gold pieces'{0}This Material Bestows \"Masterwork\" Qualities: '{5}'{0}Special Info: {6}",
									Environment.NewLine,
									"\t",
									ComponentName,
									WeaponCostModifier,
									MagicEnchantmentCostModification,
									IsMasterwork,
									ComponentInfo
								);
		}

		public double ApplyCostModifier(IWeapon weaopn)
		{
			return weaopn.WeaponCost * WeaponCostModifier;
		}

		public double GetAdditionalEnchantmentCost()
		{
			return MagicEnchantmentCostModification;
		}

		public bool VerifyMasterwork(IWeapon weapon)
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
	}
}
