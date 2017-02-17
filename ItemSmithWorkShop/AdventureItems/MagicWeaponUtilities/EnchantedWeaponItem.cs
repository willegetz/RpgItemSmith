using System;
using System.Linq;

namespace ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities
{
	public class EnchantedWeaponItem : WeaponItemWeaver
	{
		private const int MaxEnhancementBonus = 10;

		private const int PlayerXpInvestment = 25;
		private const int PlayerMaterialInvestment = 2;
		private const int MagicWeaponCostMultiplier = 2000;
		private const int HardnessAdjustmentForMagicMultiplier = 2;
		private const int HitPointAdjustmentForMagicMultiplier = 10;
		private const int GoldCostPerDay = 1000;
		
		readonly WeaponItemWeaver weaponItem;
		readonly WeaponEnchantment enchantment;

		public EnchantedWeaponItem(WeaponItemWeaver magicWeapon, WeaponEnchantment newEnchantment)
		{
			if ((magicWeapon.GetEnhancementBonusForCost() + newEnchantment.GetEnhancementBonusForCost()) > MaxEnhancementBonus)
			{
				throw new ArgumentOutOfRangeException(string.Format("'{0}' enchantment of '+{1}' value cannot be added to '{2}' of '+{3}' value.{4}Enchantment bonus cannot exceed '+10'", newEnchantment.GetName(), newEnchantment.GetEnhancementBonusForCost(), magicWeapon.GetName(), magicWeapon.GetEnhancementBonusForCost(), Environment.NewLine));
			}
			weaponItem = magicWeapon;
			enchantment = newEnchantment;
		}

		public override string GetName()
		{
			return string.Format("{0}, {1}", weaponItem.GetName(), enchantment.GetName());
		}

		public override int GetEnhancementBonus()
		{
			return weaponItem.GetEnhancementBonus();
		}

		public override int GetEnhancementBonusForCost()
		{
			return weaponItem.GetEnhancementBonusForCost() + enchantment.GetEnhancementBonus();
		}

		private double GetEnhancementCost()
		{
			return (Math.Pow(GetEnhancementBonusForCost(), 2) * MagicWeaponCostMultiplier);
		}

		public override double GetCost()
		{
			return GetWeaponCost() + GetAdditionalMagicCostModifier() + GetEnhancementCost();
		}

		public override double GetWeaponCost()
		{
			return weaponItem.GetWeaponCost();
		}

		public override double GetAdditionalMagicCostModifier()
		{
			return weaponItem.GetAdditionalMagicCostModifier();
		}

		public override string GetDamage()
		{
			if (string.IsNullOrEmpty(enchantment.GetDamage()))
			{
				return string.Format("{0}", weaponItem.GetDamage());
			}
			return string.Format("{0}{1}({2})", weaponItem.GetDamage(), enchantment.GetDamage(), enchantment.GetDamageType());
		}

		public override string GetThreat()
		{
			return weaponItem.GetThreat();
		}

		public override string GetEnchantmentCriticalDamage()
		{
			if (string.IsNullOrEmpty(enchantment.GetEnchantmentCriticalDamage()))
			{
				return string.Empty;
			}
			return string.Format("{0}({1})", enchantment.GetEnchantmentCriticalDamage(), enchantment.GetDamageType());
		}

		public override string GetDamageType()
		{
			return string.Format("{0}", weaponItem.GetDamageType());
		}

		public override double GetModifiedHardness()
		{
			return weaponItem.GetModifiedHardness() + (enchantment.GetEnhancementBonus() * HardnessAdjustmentForMagicMultiplier);
		}

		public override double GetModifiedHitPoints()
		{
			return weaponItem.GetModifiedHitPoints() + (enchantment.GetEnhancementBonus() * HitPointAdjustmentForMagicMultiplier);
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight();
		}

		public override double GetMinimumCasterLevel()
		{
			if (enchantment.GetCasterLevelRequired() >= weaponItem.GetMinimumCasterLevel())
			{
				return enchantment.GetCasterLevelRequired();
			}
			return weaponItem.GetMinimumCasterLevel();
		}

		public override string GetDescription()
		{
			return string.Format("{0}{1}{2}", weaponItem.GetDescription(), Environment.NewLine, enchantment.GetDescription());;
		}

		public override double GetDaysToCreate()
		{
			return GetEnhancementCost() / GoldCostPerDay;
		}

		public override double GetCreationXpCost()
		{
			return GetEnhancementCost() / PlayerXpInvestment;
		}

		public override double GetCreationRawMaterialCost()
		{
			return (GetEnhancementCost() / PlayerMaterialInvestment) + weaponItem.GetWeaponCost() + weaponItem.GetAdditionalMagicCostModifier();
		}

		public override string GetCreationRequirements()
		{
			return string.Format("{0}{1}{2}", weaponItem.GetCreationRequirements(), Environment.NewLine, enchantment.GetCreationRequirements());
		}
	}
}