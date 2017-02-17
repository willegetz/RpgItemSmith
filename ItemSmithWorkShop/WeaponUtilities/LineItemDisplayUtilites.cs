using System;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.Interfaces;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class LineItemDisplayUtilites : ILineItems
	{
		public static string BasicDisplay(WeaponData weapon)
		{
			return string.Format("Name: '{1}'{0}Base Price: '{2} gp'{0}Weight: '{3} pound(s)'{0}Damage: '{4} [{5}-20/{6}]' {7}{0}Range Increment: '{8} feet'{0}Hardness: '{9}'{0}Hit Points: '{10}'{0}{11}",
				Environment.NewLine,
				weapon.WeaponName,
				weapon.BasePrice,
				weapon.WeaponWeight,
				weapon.WeaponDamage,
				weapon.WeaponThreatRange,
				weapon.WeaponCritical,
				weapon.WeaponDamageType,
				weapon.RangeIncrement,
				weapon.WeaponHardness,
				weapon.WeaponHitPoints,
				weapon.WeaponText);
		}

		public static string BasicIngotDisplay(MaterialComponentData ingotInfo)
		{
			return string.Format("Name: {1}{0}Cost Modifier: '{2} gold pieces'{0}\tAdditional Cost: '{3}'{0}Weight Multiplier: '{4}'{0}Is Masterwork: '{5}'{0}Masterwork Cost: '{6}'{0}To Hit Bonus: '{7}'{0}Damage Modifier: '{8}'{0}Description:{0}\t{9}",
				Environment.NewLine,
				ingotInfo.Name,
				ingotInfo.ComponentCostModifier,
				ingotInfo.AdditionalCostModifier,
				ingotInfo.ComponentWeightModifier,
				ingotInfo.IsMasterwork,
				ingotInfo.MasterworkCostModifier,
				ingotInfo.ToHitBonus,
				ingotInfo.ComponentDamageModifier,
				ingotInfo.ComponentDescription);
		}

		public static string BasicSpecialAbilityDisplay(EnchantmentData specialAbilityInfo)
		{
			return string.Format("Name: {1}{0}Enhancement Bonus: '{2}'{0}Minimum Caster Level: '{3}'{0}Damage: '{4}'{0}Critical Damage: '{5}'{0}Damage Type: '{6}'{0}Creation Requirements:{0}{7}{0}Description:{0}\t{8}",
				Environment.NewLine,
				specialAbilityInfo.EnchantmentName,
				specialAbilityInfo.EnhancementBonus,
				specialAbilityInfo.MinimumCasterLevel,
				specialAbilityInfo.EnchantmentDamage,
				specialAbilityInfo.EnchantmentCriticalDamage,
				specialAbilityInfo.DamageType,
				specialAbilityInfo.CreationRequirements,
				specialAbilityInfo.EnchantmentDescription);
		}
	}
}
