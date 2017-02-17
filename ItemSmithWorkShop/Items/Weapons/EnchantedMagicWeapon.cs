using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.Weapons
{
	public class EnchantedMagicWeapon : IEnchantedMagicWeapon
	{
		// EnhantedMagicWeapon is made from a PlusEnhancedWeapon
		//		A weapon that is passed in that is not a PlusEnhancedWeapon must be made such.
		//			Perhaps the implementation of a "Magic Weapon" Interface?

		// DamageBonus (IForgedWeapon) and StandardDamageBonus (IWeaponEnchantment) seem to be the same.
		//		Will have to see how it plays out

		private PlusEnhancedWeapon plusWeapon;

		private List<IWeaponEnchantment> enchantments;
		private Dictionary<string, string> criticalDamages;

		private double enhancementCostMultiplier = 2000;
		private double creationDaysMultiplier = 0.001;
		private double creationCostMultiplier = 0.5;
		private double creationXpCost = 0.04;



		#region IWeapon Members

		public string WeaponName { get; private set; }

		public string GivenName { get; private set; }

		public string Proficiency { get; private set; }

		public string WeaponUse { get; private set; }

		public string WeaponCategory { get; private set; }

		public string WeaponSubCategory { get; private set; }

		public string WeaponSize { get; private set; }

		public double WeaponCost { get; private set; }

		public string Damage { get; private set; }

		public double ThreatRangeLowerBound { get; private set; }

		public string ThreatRange { get; private set; }

		public string CriticalDamage { get; private set; }

		public string DamageType { get; private set; }

		public double Weight { get; private set; }

		public double Hardness { get; private set; }

		public double HitPoints { get; private set; }

		public string SpecialInfo { get; private set; }

		public bool IsMasterwork { get { return true; } }

		public double RangeIncrement { get; private set; }

		public double MaxRange { get; private set; }

		public bool IsBow { get; private set; }

		#endregion

		#region IForgedWeapon Members

		public double AdditionalEnchantmentCost { get; private set; }

		public string ToHitModifier { get; private set; }

		public double DamageBonus { get; private set; }

		public string ComponentName { get; private set; }

		#endregion

		#region IPlusEnhancedWeapon Members

		public double PlusEnhancement { get; private set; }

		public double MinimumCasterLevel { get; private set; }

		public string MagicAura { get; private set; }

		public string GeneratesLight { get; private set; }

		public string RequiredFeats { get; private set; }

		public double CreationTime
		{
			get { return BaseEnhancementCost * creationDaysMultiplier; }
		}

		public double RawMaterialCost
		{
			get { return WeaponCost + (BaseEnhancementCost * creationCostMultiplier); }
		}

		public double CreationXpCost
		{
			get { return BaseEnhancementCost * creationXpCost; }
		}

		private double baseEnhancementCost;
		public double BaseEnhancementCost 
		{
			get { return baseEnhancementCost; }
			private set
			{
				baseEnhancementCost = Math.Pow(CostModifier, 2) * enhancementCostMultiplier;
			}
		}

		public double BaseItemCost
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsMagical { get { return true; } }

		#endregion

		#region IWeaponEnchantment Members

		public string EnchantmentName
		{
			get { throw new NotImplementedException(); }
		}

		public string Affix
		{
			get { throw new NotImplementedException(); }
		}

		private double costModifier;
		public double CostModifier
		{
			get { return costModifier; }
			private set
			{
				costModifier = value;
				BaseEnhancementCost = value;
			}
		}

		public string StandardDamageBonus
		{
			get 
			{
				var damageBonusList = new StringBuilder();
				
				var damageBonusGroup = enchantments.Where(d => !string.IsNullOrEmpty(d.StandardDamageBonus)).ToList();
				damageBonusGroup.ForEach(d =>  AppendBonusDamageInfo(damageBonusList, d.StandardDamageBonus, d.DamageType));
				return damageBonusList.ToString();
			}
		}

		public bool DoesCriticalDamage
		{
			get { throw new NotImplementedException(); }
		}

		public double ThreatRangeModifier
		{
			get
			{
				return enchantments.Select(t => t.ThreatRangeModifier).ToList().Max();
			}
		}

		public double RangeIncrementModifier
		{
			get
			{
				return enchantments.Select(r => r.RangeIncrementModifier).ToList().Max();
			}
		}

		public string RequiredSpells { get; private set; }

		public string AdditionalRequirements { get; private set; }

		public string EnchantmentNotes
		{
			get { throw new NotImplementedException(); }
		}
		#endregion

		// Non interface implemented properties
		public List<IWeaponEnchantment> prefixes
		{
			get
			{
				return	enchantments.Where(p => p.Affix.Contains("Pre")).ToList();
			}
		}

		public List<IWeaponEnchantment> suffixes
		{
			get
			{
				return enchantments.Where(s => s.Affix.Contains("Suf")).ToList();
			}
		}

		public string CriticalDamageBonus
		{ 
			get
			{
				var critDamageList = new StringBuilder();
				var critDamages = enchantments.Where(c => c.DoesCriticalDamage.Equals(true)).ToList();
				critDamages.ForEach(c => AppendBonusDamageInfo(critDamageList, criticalDamages[plusWeapon.CriticalDamage], c.DamageType));
				return critDamageList.ToString();
			}
		}

		public double ModifiedRangeIncrement { get; private set; }

		public double ModifiedMaxRange { get; private set; }

		public double TotalCost
		{
			get
			{
				return WeaponCost + BaseEnhancementCost + AdditionalEnchantmentCost;
			}
		}

		public string ModifiedDamage
		{
			get
			{
				var modifiedDamage = DamageBonus + PlusEnhancement;
				if (modifiedDamage == 0)
				{
					return string.Empty;
				}
				else if (modifiedDamage > 0)
				{
					return string.Format(" +{0}", modifiedDamage);
				}
				return modifiedDamage.ToString();
			}
		}

		public EnchantedMagicWeapon(IWeapon weapon, List<IWeaponEnchantment> weaponEnchantments)
		{
			enchantments = new List<IWeaponEnchantment>();
			LoadCriticalDamageDictionary();

			plusWeapon = QualifyWeapon(weapon);
			enchantments.AddRange(weaponEnchantments);

			// IWeapon
			WeaponName = plusWeapon.WeaponName;
			GivenName = plusWeapon.GivenName;
			Proficiency = plusWeapon.Proficiency;
			WeaponUse = plusWeapon.WeaponUse;
			WeaponCategory = plusWeapon.WeaponCategory;
			WeaponSubCategory = plusWeapon.WeaponSubCategory;
			WeaponSize = plusWeapon.WeaponSize;
			WeaponCost = plusWeapon.WeaponCost;
			Damage = plusWeapon.Damage;
			ThreatRangeLowerBound = plusWeapon.ThreatRangeLowerBound;
			CriticalDamage = plusWeapon.CriticalDamage;
			DamageType = plusWeapon.DamageType;
			Weight = plusWeapon.Weight;
			Hardness = plusWeapon.Hardness;
			HitPoints = plusWeapon.HitPoints;
			RangeIncrement = plusWeapon.RangeIncrement;
			MaxRange = plusWeapon.MaxRange;
			IsBow = plusWeapon.IsBow;
			
			//IForgedWeapon
			AdditionalEnchantmentCost = plusWeapon.AdditionalEnchantmentCost;
			ToHitModifier = plusWeapon.ToHitModifier;
			DamageBonus = plusWeapon.DamageBonus;
			ComponentName = plusWeapon.ComponentName;

			//IPlusEnhancedWeapon
			PlusEnhancement = plusWeapon.PlusEnhancement;
			GeneratesLight = plusWeapon.GeneratesLight;
			RequiredFeats = plusWeapon.RequiredFeats;

			//IWeaponEnhancement

			// Properties needing method assignments
			//		IWeapon
			CostModifier = TallyCostModifiers();
			ThreatRange = CalculateThreatRange();
			//		IPlusWeapon and IWeaponEnchantment
			MinimumCasterLevel = DetermineMinimumCasterLevel(plusWeapon.MinimumCasterLevel);
			MagicAura = AssembleAuras();
			//		IWeaponEnchantment
			RequiredSpells = AssembleRequiredSpells();
			AdditionalRequirements = AssembleAdditionalRequirements();
			//		Non interface implemented properties
			ModifiedRangeIncrement = CalculateRangeModifier(plusWeapon.RangeIncrement);
			ModifiedMaxRange = CalculateRangeModifier(plusWeapon.MaxRange);

			SpecialInfo = AppendSpecialInfo();
		}

		private void LoadCriticalDamageDictionary()
		{
			criticalDamages = new Dictionary<string, string>()
			{
						 {"x2", "1d10"},
						 {"x3", "2d10"},
						 {"x4", "3d10"},
			};
		}

		private PlusEnhancedWeapon QualifyWeapon(IWeapon weapon)
		{
			return weapon.IsMagical ? weapon as PlusEnhancedWeapon : new PlusEnhancedWeapon(weapon, 1);
		}

		public void NameWeapon(string givenName)
		{
			GivenName = givenName;
		}

		private double TallyCostModifiers()
		{
			return enchantments.Select(c => c.CostModifier).ToList().Sum() + PlusEnhancement;
		}

		private string CalculateThreatRange()
		{
			return ThreatRangeModifier == 0 ? FormattedThreatRange(ThreatRangeLowerBound) : FormattedThreatRange(NewLowerBound());
		}

		private string FormattedThreatRange(double lowerBound)
		{
			return string.Format("{0}-20", lowerBound);
		}

		private double NewLowerBound()
		{
			return 21 - (((20 - ThreatRangeLowerBound) + 1) * ThreatRangeModifier);
		}

		private double CalculateRangeModifier(double range)
		{
			return RangeIncrementModifier == 0 ? range : (range * RangeIncrementModifier);
		}

		private double DetermineMinimumCasterLevel(double enhancementCasterLevel)
		{
			var minimumEnchantmentCasterLevel = enchantments.Select(e => e.MinimumCasterLevel).ToList();
			minimumEnchantmentCasterLevel.Add(enhancementCasterLevel);

			return minimumEnchantmentCasterLevel.Max();
		}

		private string AssembleAuras()
		{
			var auras = new StringBuilder();
			auras.AppendLine("Magic Auras");

			AssembledInformationDisplay(auras, "\t", "Enhancement", plusWeapon.MagicAura);
			enchantments.ForEach(e => AssembledInformationDisplay(auras, "\t", e.EnchantmentName, e.MagicAura));
			return auras.ToString();
		}

		private string AssembleRequiredSpells()
		{
			var enchantmentSpells = new StringBuilder();
			var requiredSpellsList = enchantments.Where(e => !string.IsNullOrEmpty(e.RequiredSpells)).ToList();

			enchantmentSpells.AppendLine("Required Spells");
			requiredSpellsList.ForEach(e => AssembledInformationDisplay(enchantmentSpells, "\t", e.EnchantmentName, e.RequiredSpells));
			return enchantmentSpells.ToString();
		}

		// Display related
		private string AssembleAdditionalRequirements()
		{
			var additionalRequirementsCollection = new StringBuilder();
			var requirements = enchantments.Where(e => !string.IsNullOrEmpty(e.AdditionalRequirements)).ToList();

			additionalRequirementsCollection.AppendLine("Additional Creation Requirements");

			requirements.ForEach(e => AssembledInformationDisplay(additionalRequirementsCollection, "\t", e.EnchantmentName, e.AdditionalRequirements));
			return additionalRequirementsCollection.ToString();
		}

		// Display related
		private string AppendSpecialInfo()
		{
			var notesCollection = new StringBuilder();

			enchantments.ForEach(e =>  AssembledInformationDisplay(notesCollection, "", e.EnchantmentName, e.EnchantmentNotes));
			return string.Format("{1}{0}{0}Enchantment Information{0}{2}", Environment.NewLine, plusWeapon.SpecialInfo, notesCollection);
		}

		// Display related
		private string BuildWeaponName()
		{
			var name = new StringBuilder();
			
			var namePrefixes = BuildWeaponNamePrefixes();
			var nameSuffixes = BuildWeaponNameSuffixes();
			
			name.Append(string.Format("+{0}{1}{2}{3}", PlusEnhancement, namePrefixes, WeaponName, nameSuffixes));
			return name.ToString();
		}

		// Display related
		private string BuildWeaponNamePrefixes()
		{
			var weaponNamePrefixes = new StringBuilder();
			prefixes.ForEach(p => weaponNamePrefixes.Append(string.Format(" {0},", p.EnchantmentName)));
			return weaponNamePrefixes.Remove(weaponNamePrefixes.Length - 1, 1).Append(" ").ToString();
		}

		// Display related
		private string BuildWeaponNameSuffixes()
		{
			var weaopnNameSuffixes = new StringBuilder();
			suffixes.ForEach(s => weaopnNameSuffixes.Append(string.Format(" of {0}", s.EnchantmentName)));
			return weaopnNameSuffixes.ToString();
		}

		// Display related
		private string BuildEnhancementBreakdown()
		{
			var breakdown = new StringBuilder();
			breakdown.Append(string.Format("+{0} [", CostModifier));
			breakdown.Append(string.Format("+{0} for Plus Enhancement,", PlusEnhancement));
			enchantments.ForEach(e => EnhancementBreakdownLogic(breakdown, e));
			breakdown.Remove(breakdown.Length - 1, 1).Append("]");

			return breakdown.ToString();
		}

		// Display related
		private string EnhancementBreakdownLogic(StringBuilder breakdown, IWeaponEnchantment enchantment)
		{
			breakdown.Append(string.Format(" +{0} for {1},", enchantment.CostModifier, enchantment.EnchantmentName));
			return breakdown.ToString();
		}

		// Display related
		private string BuildDamageOutput()
		{
			return string.Format("{0}{1}{2} [{3}/{4}]{5}, {6}", Damage, ModifiedDamage, StandardDamageBonus, ThreatRange, CriticalDamage, CriticalDamageBonus, DamageType);
		}

		// Display related
		private string BuildRangeInfo()
		{
			if (RangeIncrementModifier != 1)
			{
				return string.Format("{0} foot increment (was {1} foot increment) for {2} total feet (was {3} total feet)", ModifiedRangeIncrement, RangeIncrement, ModifiedMaxRange, MaxRange);
			}
			return string.Format("{0} foot increment for {1} total feet", RangeIncrement, MaxRange);
		}

		// Display related
		private string BuildType()
		{
			if (!string.IsNullOrEmpty(WeaponSubCategory))
			{
				return string.Format("{0} {1}, {2}", WeaponCategory, WeaponUse, WeaponSubCategory);
			}
			return string.Format("{0} {1}", WeaponCategory, WeaponUse);
		}

		// Display related
		private StringBuilder AssembledInformationDisplay(StringBuilder builderName, string formatter,  string enchantmentName, string enchantmentProperty)
		{
			return builderName.AppendLine(string.Format("{0}{1}: {2}", formatter, enchantmentName, enchantmentProperty));
		}

		// Display related
		private StringBuilder AppendBonusDamageInfo(StringBuilder builderName, string bonusDamage, string damageType)
		{
			return builderName.Append(string.Format(" +{0} ({1})", bonusDamage, damageType));
		}

		// Display related
		public override string ToString()
		{
			var displayWeapon = new StringBuilder();
			displayWeapon.AppendLine(string.Format("Given Name: {0}", GivenName));
			displayWeapon.AppendLine(string.Format("Weapon: {0}", BuildWeaponName()));
			displayWeapon.AppendLine(string.Format("Special Component(s): {0}", ComponentName));
			displayWeapon.AppendLine(string.Format("Weapon Size: {0}", WeaponSize));
			displayWeapon.AppendLine(string.Format("Proficiency: {0}", Proficiency));
			displayWeapon.AppendLine(string.Format("Type: {0}", BuildType()));
			displayWeapon.AppendLine(string.Format("Enhancement Total: {0}", BuildEnhancementBreakdown()));
			displayWeapon.AppendLine(string.Format("Weapon Cost: {0} gold pieces", TotalCost));
			displayWeapon.AppendLine(string.Format("To Hit: +{0}", PlusEnhancement));
			displayWeapon.AppendLine(string.Format("Standard Damage: {0}", BuildDamageOutput()));
			displayWeapon.AppendLine(string.Format("Range: {0}", BuildRangeInfo()));
			displayWeapon.AppendLine(string.Format("Weight: {0} pound(s)", Weight));
			displayWeapon.AppendLine(string.Format("Hardness: {0}", Hardness));
			displayWeapon.AppendLine(string.Format("Hit Points: {0}", HitPoints));
			displayWeapon.AppendLine();
			displayWeapon.AppendLine("Special Information");
			displayWeapon.Append(SpecialInfo);
			displayWeapon.AppendLine(GeneratesLight);
			displayWeapon.AppendLine();
			displayWeapon.AppendLine("Creation Information");
			displayWeapon.AppendLine(string.Format("Required Feats: {0}", RequiredFeats));
			displayWeapon.AppendLine(string.Format("Minimum Caster Level: {0}", MinimumCasterLevel));
			displayWeapon.Append(RequiredSpells);
			displayWeapon.Append(MagicAura);
			displayWeapon.AppendLine(string.Format("Material Cost: {0} gp", RawMaterialCost));
			displayWeapon.AppendLine(string.Format("Experience Cost: {0} xp", CreationXpCost));
			displayWeapon.AppendLine(string.Format("Time Cost: {0} days", CreationTime));
			return displayWeapon.ToString();
		}
	}
}