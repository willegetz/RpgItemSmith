using System;
using System.Linq;

namespace ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities
{
	public class WeaponEnchantment : WeaponItemWeaver
	{
		private readonly string name;
		private readonly string damage;
		private readonly string criticalDamage;
		private readonly string damageType;
		private readonly int casterLevel;
		private readonly int enhancementBonus;
		private readonly string requirements;
		private readonly string description;

		public WeaponEnchantment(EnchantmentOrder enchantment)
		{
			name = enchantment.Name;
			damage = enchantment.Damage;
			damageType = enchantment.DamageType;
			criticalDamage = enchantment.CriticalDamage;
			casterLevel = enchantment.CasterLevel;
			enhancementBonus = enchantment.EnhancementBonus;
			requirements = enchantment.Requirements;
			description = enchantment.Description;
		}

		public override string GetName()
		{
			return name;
		}

		public override string GetDamage()
		{
			return damage;
		}

		public override string GetEnchantmentCriticalDamage()
		{
			return criticalDamage;
		}

		public override int GetCasterLevelRequired()
		{
			return casterLevel;
		}

		public override int GetEnhancementBonusForCost()
		{
			return enhancementBonus;
		}

		public override int GetEnhancementBonus()
		{
			return enhancementBonus;
		}

		public override string GetDamageType()
		{
			return damageType;
		}

		public override string GetCreationRequirements()
		{
			return requirements;
		}

		public override string GetDescription()
		{
			return description;
		}
	}
}
