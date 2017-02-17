using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.MaterialTypes
{
	public class Mithral : IMaterialComponent
	{
		// The mithral material type is interesting.
		// Mithral armor are one category lighter: Heavy => Medium, Medium => Light, Light => Light
		//		Should the armor categories be an enum? Heavy = 3, Medium = 2, Light = 1?
		//			0 could be for clothes or robes or some other non armor designation.
		//		Mithral could check the armor category and decrease its value by 1 to no less than 1.
		// Spell failure chances are reduced for armor and shields: 10% reduction
		// Max dex bonus is reduced by 2.
		//		This means that an armor that has a "Max Dex = 2" would become "Max Dex = 4"
		//			In essence, the max dex bonus is INCREASED, not reduced as it states in the DMG.
		// Armor check penalties are reduced by 3, to a minimum of 0
		// Item weight is reduced by half
		// Weapons or armor fashioned are always masterwork
		//		Weapons receive a +1 enhancement bonus to hit
		//		
		// Cost modifiers include masterwork price:
		//		Light armor: +1000 gold
		//		Medium armor: +4000 gold
		//		Heavy armor: +9000 gold
		//		Shield: +1000 gold
		//		Other items: +500 gold per pound

		// There are three categories for this class
		//		1) Armor and shields
		//		2) Weapons
		//		3) Other items

		// Mithral has 30 hit points per inch, and a hardness of 15

		// I don't know how I am going to apply these values, yet.

		public string ComponentName { get { return "Mithral"; } }
		public double WeaponCostModifier { get { return 500; } }
		public bool IsMasterwork { get { return true; } }
		public string ToHitBonus { get { return "+1"; } }
		public double DamageBonus { get { return 0; } }


		private const double lightArmorCostModifier = 1000;
		private const double mediumArmorCostModifier = 4000;
		private const double heavyArmorCostModifier = 9000;
		private const double shieldCostModifier = 1000;
		private const double itemCostModifier = 500;
		private const double itemWeightModifier = 0.5;
		private const double spellFailureReduction = 0.1;
		private const double maxDexReduction = -2;
		private const double armorCheckPenaltyReduction = -3;
		public string componentInfo = string.Format("Mithral is a very rare, silvery, glistening metal{0}{1}that is lighter than iron but just as hard.", Environment.NewLine, "\t");

		public double LightArmorCostModifier { get { return lightArmorCostModifier; } }
		public double MediumArmorCostModifier { get { return mediumArmorCostModifier; } }
		public double HeavyArmorCostModifier { get { return heavyArmorCostModifier; } }
		public double ShieldCostModifier { get { return shieldCostModifier; } }
		public double ItemCostModifier { get { return itemCostModifier; } }
		public double ItemWeightModifier { get { return itemWeightModifier; } }
		public double SpellFailureReduction { get { return spellFailureReduction; } }
		public double MaxDexReduction { get { return maxDexReduction; } }
		public double ArmorCheckPenaltyReduction { get { return armorCheckPenaltyReduction; } }
		public string ComponentInfo { get {return componentInfo;}}

		public double ApplyCostModifier(IWeapon weapon)
		{
			return weapon.WeaponCost + (weapon.Weight * WeaponCostModifier);
		}

		public double ApplyWeightModifier(IWeapon weapon)
		{
			return weapon.Weight * ItemWeightModifier;
		}

		public override string ToString()
		{
			string currency = "gold pieces";
			return string.Format("Material:{1}'{3}'{0}Armor Cost Modifiers:{0}{1}Light:{1}'{4}' {2}{0}{1}Medium:{1}'{5}' {2}{0}{1}Heavy:{1}'{6}' {2}{0}Shield Cost Modifier:{1}'{7}' {2}{0}Weapon Cost Modifier:{1}'{8}' {2} per pound{0}Item Cost Modifier:{1}'{9}' {2} per pound{0}Spell Failure Reduction:{1}'{10}%'{0}Max Dex Reduction:{1}'{11}'{0}Armor Check Penalty Reduction:{1}'{12}'{0}This Material Bestows \"Masterwork\" Qualities: '{13}'",
									Environment.NewLine, 
									"\t", 
									currency, 
									ComponentName, 
									LightArmorCostModifier, 
									MediumArmorCostModifier, 
									HeavyArmorCostModifier, 
									ShieldCostModifier,
									WeaponCostModifier,
									ItemCostModifier,
									(SpellFailureReduction * 100),
									MaxDexReduction,
									ArmorCheckPenaltyReduction,
									IsMasterwork
								);
		}


		#region IMaterialComponent Members


		public double GetAdditionalEnchantmentCost()
		{
			return 0;
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
			return weapon.Weight * ItemWeightModifier;
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
