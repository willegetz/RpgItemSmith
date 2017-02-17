using System;
using System.Linq;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities
{
	public class EnchantmentOrder
	{
		public string Name { get; private set; }
		public string Damage { get; private set; }
		public string CriticalDamage { get; private set; }
		public int CasterLevel { get; private set; }
		public int EnhancementBonus { get; private set; }
		public string DamageType { get; private set; }
		public string Requirements { get; private set; }
		public string Description { get; private set; }

		public EnchantmentOrder(EnchantmentData enchantmentData)
		{
			EnchantmentInformation(enchantmentData);
		}

		private void EnchantmentInformation(EnchantmentData enchantment)
		{
			Name = enchantment.EnchantmentName;
			Damage = enchantment.EnchantmentDamage;
			CriticalDamage = enchantment.EnchantmentCriticalDamage;
			CasterLevel = enchantment.MinimumCasterLevel;
			EnhancementBonus = enchantment.EnhancementBonus;
			DamageType = enchantment.DamageType;
			Requirements = enchantment.CreationRequirements;
			Description = enchantment.EnchantmentDescription;
		}
	}
}
