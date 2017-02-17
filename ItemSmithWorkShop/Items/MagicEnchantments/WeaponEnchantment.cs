using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;
using ItemSmithWorkShop.Items.Data;

namespace ItemSmithWorkShop.Items.MagicEnchantments
{
	public class WeaponEnchantment : IWeaponEnchantment
	{
		// Weapon enchantments cannot be added unless the weapon is already a Plus 1 value
		// Weapon enchantments can be either a prefix or a suffix.
		// Enchantments have a Plus value which affects the total value of the weapon
		// Enchantments are either for Ranged weapons, or melee weapons
		//		Thrown and Projectile and Ammunition included
		// Enchantments usually do additional damage on a standard hit.
		// Enchantments can do additional damage on a critical hit
		// The enchantments have other effects that appear in the description
		// At least one enchantment affects the threat range of a weapon
		// Enchantments have an aura
		// Enchantments have a minimum caster level
		// Enchantments have feat and spell requirements to create
		// Enchantments may have additional requirements as well

		private WeaponEnchantmentTemplate weaponEnchantmentTemplate;

		public string EnchantmentName { get; private set; }
		public string Affix { get; private set; }
		public double CostModifier { get; private set; }
		public string WeaponUse { get; private set; }
		public string StandardDamageBonus { get; private set; }
		public double ThreatRangeModifier { get; private set; }
		public bool DoesCriticalDamage { get; private set; }
		public string DamageType { get; private set; }
		public string MagicAura { get; private set; }
		public double MinimumCasterLevel { get; private set; }
		public double RangeIncrementModifier { get; private set; }
		public string RequiredFeats { get; private set; }
		public string RequiredSpells { get; private set; }
		public string AdditionalRequirements { get; private set; }
		public string EnchantmentNotes { get; private set; }

		public WeaponEnchantment(string enchantmentKey)
		{
			weaponEnchantmentTemplate = EnchantmentData.RetrieveWeaponEnchantment(enchantmentKey);

			EnchantmentName = weaponEnchantmentTemplate.EnchantmentName;
			Affix = weaponEnchantmentTemplate.Affix;
			CostModifier = weaponEnchantmentTemplate.CostModifier;
			WeaponUse = weaponEnchantmentTemplate.WeaponUse;
			StandardDamageBonus = weaponEnchantmentTemplate.StandardDamageBonus;
			ThreatRangeModifier = weaponEnchantmentTemplate.ThreatRangeModifier;
			DoesCriticalDamage = weaponEnchantmentTemplate.DoesCriticalDamage;
			DamageType = weaponEnchantmentTemplate.DamageType;
			MagicAura = weaponEnchantmentTemplate.MagicAura;
			MinimumCasterLevel = weaponEnchantmentTemplate.MinimumCasterLevel;
			RangeIncrementModifier = weaponEnchantmentTemplate.RangeIncrementModifier;
			RequiredFeats = weaponEnchantmentTemplate.RequiredFeats;
			RequiredSpells = weaponEnchantmentTemplate.RequiredSpells;
			AdditionalRequirements = weaponEnchantmentTemplate.AdditionalRequirements;
			EnchantmentNotes = weaponEnchantmentTemplate.EnchantmentNotes;
		}

		public override string ToString()
		{
			return string.Format(
								"Enchantment: '{1}'{0}Affix: '{2}'{0}Cost Modifier: '+{3}'{0}Weapon Usage: '{4}'{0}Standard Damage Bonus: '{5}'{0}Threat Range Modifier: '{6}'{0}Critical Damage Bonus: '{7}'{0}Damage Type: '{8}'{0}Magic Aura: '{9}'{0}Minimum Caster Level: '{10}'{0}Range Increment Multiplier: '{11}'{0}Required Feats: '{12}'{0}Required Spells: '{13}'{0}Additional Requirements: '{14}'{0}Notes: '{15}'",
								Environment.NewLine,
								EnchantmentName,
								Affix,
								CostModifier,
								WeaponUse,
								StandardDamageBonus,
								ThreatRangeModifier,
								DoesCriticalDamage,
								DamageType,
								MagicAura,
								MinimumCasterLevel,
								RangeIncrementModifier,
								RequiredFeats,
								RequiredSpells,
								AdditionalRequirements,
								EnchantmentNotes
								);
		}
	}
}
