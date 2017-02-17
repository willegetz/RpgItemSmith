using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;
using ItemSmithWorkShop.Items.MaterialTypes;

namespace ItemSmithWorkShop.Items.Weapons
{
	// A forged weapon needs to keep track of its weapon attributes.
	// A forged weapon also needs to keep track of its material component parts.
	// 
	public class ForgedWeapon : IForgedWeapon
	{
		public string GivenName { get; private set; }

		public string WeaponName { get; private set; }

		public string Proficiency { get; private set; }

		public string WeaponUse { get; private set; }

		public string WeaponCategory { get; private set; }

		public string WeaponSubCategory { get; private set; }

		public string WeaponSize { get; private set; }

		public double WeaponCost { get; private set; }

		public string ToHitModifier { get; private set; }

		public string Damage { get; private set; }

		public double DamageBonus { get; private set; }

		public double ThreatRangeLowerBound { get; private set; }

		public string ThreatRange { get; private set; }

		public string CriticalDamage { get; private set; }

		public double RangeIncrement { get; private set; }

		public double MaxRange { get; private set; }

		public double Weight { get; private set; }

		public double Hardness { get; private set; }

		public double HitPoints { get; private set; }

		public string DamageType { get; private set; }

		public string SpecialInfo { get; private set; }

		public string ComponentName { get; private set; }

		public bool IsMasterwork { get; private set; }

		public bool IsMagical { get { return false; } }

		public double AdditionalEnchantmentCost { get; private set; }

		public bool IsBow { get; private set; }

		// These two constructors are indicative of a needed abstraction.
		public ForgedWeapon(IWeapon weapon, IMaterialComponent component)
		{
			GivenName = weapon.GivenName;
			Damage = weapon.Damage;
			CriticalDamage = weapon.CriticalDamage;
			DamageType = weapon.DamageType;
			MaxRange = weapon.MaxRange;
			Proficiency = weapon.Proficiency;
			RangeIncrement = weapon.RangeIncrement;
			ThreatRange = weapon.ThreatRange;
			ThreatRangeLowerBound = weapon.ThreatRangeLowerBound;
			WeaponCategory = weapon.WeaponCategory;
			WeaponName = string.Format("{0} {1}", component.ComponentName, weapon.WeaponName);
			WeaponSize = weapon.WeaponSize;
			WeaponSubCategory = weapon.WeaponSubCategory;
			WeaponUse = weapon.WeaponUse;
			Hardness = weapon.Hardness;
			HitPoints = weapon.HitPoints;
			IsBow = weapon.IsBow;

			Weight = component.ApplyWeightModifer(weapon);
			ToHitModifier = component.ApplyToHitModifier();
			WeaponCost = component.ApplyCostModifier(weapon);
			SpecialInfo = component.AppendSpecialInfo(weapon);
			IsMasterwork = component.VerifyMasterwork(weapon);
			DamageBonus = component.ApplyDamageModifier(weapon);
			ComponentName = component.ComponentName;
			AdditionalEnchantmentCost = component.GetAdditionalEnchantmentCost();
		}

		public ForgedWeapon(ForgedWeapon weapon, IMaterialComponent component)
		{
			ComponentName = string.Format("{0}, {1}",weapon.ComponentName, component.ComponentName);
			GivenName = weapon.GivenName;
			WeaponName = string.Format("{0} {1}", component.ComponentName, weapon.WeaponName);
			Proficiency = weapon.Proficiency;
			WeaponCategory = weapon.WeaponCategory;
			WeaponSubCategory = weapon.WeaponSubCategory;
			WeaponUse = weapon.WeaponUse;
			Damage = weapon.Damage;
			CriticalDamage = weapon.CriticalDamage;
			DamageType = weapon.DamageType;
			MaxRange = weapon.MaxRange;
			RangeIncrement = weapon.RangeIncrement;
			ThreatRange = weapon.ThreatRange;
			ThreatRangeLowerBound = weapon.ThreatRangeLowerBound;
			WeaponSize = weapon.WeaponSize;
			Hardness = weapon.Hardness;
			HitPoints = weapon.HitPoints;

			WeaponCost = component.ApplyCostModifier(weapon);
			AdditionalEnchantmentCost = weapon.AdditionalEnchantmentCost;
			ToHitModifier = component.ApplyToHitModifier();
			DamageBonus = weapon.DamageBonus;
			Weight = component.ApplyWeightModifer(weapon);
			SpecialInfo = component.AppendSpecialInfo(weapon);
			IsMasterwork = component.VerifyMasterwork(weapon);
		}

		public void NameWeapon(string name)
		{
			GivenName = name;
		}

		private string DisplayDamage()
		{
			if (!(DamageBonus == 0))
			{
				return string.Format("{0} {1}", Damage, DamageBonus);
			}
			return Damage;
		}

		public override string ToString()
		{
			return string.Format("Given Name: '{1}'{0}Special Components: '{2}'{0}Weapon Name: '{3}'{0}This Weapon is Masterwork Quality: '{4}'{0}Weaopn Proficiency: '{5}'{0}Weapon Category: '{7} {6}, {8}'{0}Weapon Size: '{9}'{0}Weapon Cost: '{10}' gold pieces{0}Extra Cost When Made Magical: '{11}' gold pieces{0}To Hit Bonus: '{12}'{0}Damage: '{13}' [{14}/{15}] {16}{0}Range Increment: '{17} feet ['{18}' feet max]'{0}Weight: '{19} pounds'{0}Hardness: '{20}'{0}Hit Points: '{21}'{0}Special: {22}",
									Environment.NewLine, 
									GivenName, 
									ComponentName, 
									WeaponName,
									IsMasterwork,
									Proficiency,
									WeaponUse,
									WeaponCategory,
									WeaponSubCategory,
									WeaponSize,
									WeaponCost,
									AdditionalEnchantmentCost,
									ToHitModifier,
									DisplayDamage(), 
									ThreatRange, 
									CriticalDamage,
									DamageType,
									RangeIncrement,
									MaxRange,
									Weight,
									Hardness,
									HitPoints,
									SpecialInfo
								);
		}
	}
}
