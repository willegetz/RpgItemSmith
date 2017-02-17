using System;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.Interfaces;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class EnchantmentData : ILineItems
	{
		public string EnchantmentName;
		public string EnchantmentDamage;
		public string EnchantmentCriticalDamage;
		public int MinimumCasterLevel;
		public int EnhancementBonus;
		public string DamageType;
		public string CreationRequirements;
		public string EnchantmentDescription;

		public override string ToString()
		{
			return string.Format("Name: {1}{0}Enhancement Bonus: '{2}'{0}Minimum Caster Level: '{3}'{0}Damage: '{4}'{0}Critical Damage: '{5}'{0}Damage Type: '{6}'{0}Creation Requirements:{0}{7}{0}Description:{0}\t{8}",
				Environment.NewLine,
				EnchantmentName,
				EnhancementBonus,
				MinimumCasterLevel,
				EnchantmentDamage,
				EnchantmentCriticalDamage,
				DamageType,
				CreationRequirements,
				EnchantmentDescription);
		}
	}
}
