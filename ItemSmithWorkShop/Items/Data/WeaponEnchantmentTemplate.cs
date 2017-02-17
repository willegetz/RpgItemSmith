using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.Data
{
	public class WeaponEnchantmentTemplate : IWeaponEnchantment
	{
		public string enchantmentName;
		public string EnchantmentName
		{
			get { return enchantmentName; }
			private set { enchantmentName = value; }
		}

		public string affix;
		public string Affix
		{
			get { return affix; }
			private set { affix = value; }
		}

		public double costModifier;
		public double CostModifier
		{
			get { return costModifier; }
			private set { costModifier = value; }
		}

		public string weaponUse;
		public string WeaponUse
		{
			get { return weaponUse; }
			private set { weaponUse = value; }
		}

		public string standardDamageBonus;
		public string StandardDamageBonus
		{
			get { return standardDamageBonus; }
			private set { standardDamageBonus = value; }
		}

		public double threatRangeModifier;
		public double ThreatRangeModifier
		{
			get { return threatRangeModifier; }
			private set { threatRangeModifier = value; }
		}

		public bool doesCriticalDamage;
		public bool DoesCriticalDamage
		{
			get { return doesCriticalDamage; }
			private set { doesCriticalDamage = value; }
		}

		public string damageType;
		public string DamageType
		{
			get { return damageType; }
			private set { damageType = value; }
		}

		public string magicAura;
		public string MagicAura
		{
			get { return magicAura; }
			private set { magicAura = value; }
		}

		public double minimumCasterLevel;
		public double MinimumCasterLevel
		{
			get { return minimumCasterLevel; }
			private set { minimumCasterLevel = value; }
		}

		public double rangeIncrementModifier;
		public double RangeIncrementModifier
		{
			get { return rangeIncrementModifier; }
			private set { rangeIncrementModifier = value; }
		}

		public string requiredFeats;
		public string RequiredFeats
		{
			get { return requiredFeats; }
			private set { requiredFeats = value; }
		}

		public string requiredSpells;
		public string RequiredSpells
		{
			get { return requiredSpells; }
			private set { requiredSpells = value; }
		}

		public string additionalRequirements;
		public string AdditionalRequirements
		{
			get { return additionalRequirements; }
			private set { additionalRequirements = value; }
		}

		public string enchantmentNotes;
		public string EnchantmentNotes
		{
			get { return enchantmentNotes; }
			private set { enchantmentNotes = value; }
		}

		public WeaponEnchantmentTemplate()
		{
			EnchantmentName = enchantmentName;
			Affix = affix;
			CostModifier = costModifier;
			WeaponUse = weaponUse;
			StandardDamageBonus = standardDamageBonus;
			ThreatRangeModifier = threatRangeModifier;
			DoesCriticalDamage = doesCriticalDamage;
			DamageType = damageType;
			MagicAura = magicAura;
			MinimumCasterLevel = minimumCasterLevel;
			RangeIncrementModifier = rangeIncrementModifier;
			RequiredFeats = requiredFeats;
			RequiredSpells = requiredSpells;
			AdditionalRequirements = additionalRequirements;
			EnchantmentNotes = enchantmentNotes;
		}
	}
}
