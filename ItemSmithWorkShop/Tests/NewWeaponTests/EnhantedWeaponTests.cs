using System;
using System.Text;
using ApprovalTests;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWorkShop.Items.Weapons;
using ItemSmithWorkShop.Items.MaterialTypes;
using ItemSmithWorkShop.Items.MagicEnchantments;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Tests.NewWeaponTests
{
	[TestClass]
	public class EnhantedWeaponTests
	{

		[TestMethod]
		public void TestPlusEnhancementWeapon()
		{
			// A weapon must be masterwork before it can be magical.
			// A magic weapon:
			//		Has a plus enhancement from 1 to 5
			//		Adds the plus enhancement to attack and damage
			//		Has a cost that is: Square the plus enhancement and then multiply by 2
			//		Adjusts the hardness and hit points based on plus modifier
			//		Must be a plus 1 before any special qualities can be added
			//		... more here to add
			//		PhbWeapon => ForgedWeapon => PlusWeapon => EnchantedWeapon
			var weaopn = new PhbWeapon("Dagger");
			weaopn.NameWeapon("My Magic Friend!");
			var silver = new AlchemicalSilver();
			var forgedWeapon = new ForgedWeapon(weaopn, silver);
			var plusWeapon = new PlusEnhancedWeapon(forgedWeapon, 1);
			plusWeapon.EnableLightGeneration();
			Approvals.Verify(plusWeapon.ToString());
		}

		[TestMethod]
		public void TestPlusMithralWeapon()
		{
			var plusWeapon = new PlusEnhancedWeapon(new ForgedWeapon(new PhbWeapon("Dagger"), new Mithral()), 3);
			Approvals.Verify(plusWeapon.ToString());
		}

		// Once we have a PlusEnchantedWeapon object we can proceed to enchant it with weapon special abilities.
		// An enchanted weapon should be able to have enchantments added to it one at a time
		// An enchanted weapon should be able to have enchantments removed from it at any time
		// When should the enchanted weapon be instantiated?

		[TestMethod]
		public void TestKeenAnarchicFlamingBurstDagger()
		{
			var plusWeapon = new PlusEnhancedWeapon(new ForgedWeapon(new PhbWeapon("Dagger"), new Masterwork()), 4);
			plusWeapon.NameWeapon("Boring dagger");
			var flamingBurst = new WeaponEnchantment("Flaming Burst");
			var keen = new WeaponEnchantment("Keen");
			var anarchic = new WeaponEnchantment("Anarchic");
			var distance = new WeaponEnchantment("Distance");
			plusWeapon.EnableLightGeneration();
			List<IWeaponEnchantment> enchantments = new List<IWeaponEnchantment>() { anarchic, distance, flamingBurst, keen, };
			var flamingBurstDagger = new EnchantedMagicWeapon(plusWeapon, enchantments);
			flamingBurstDagger.NameWeapon("Totally Awesome Slashy Pokey Death from Far Far Away!");
			var sb = new StringBuilder(string.Format("Min. Caster Lvl: {0}", flamingBurstDagger.MinimumCasterLevel));
			Approvals.Verify(flamingBurstDagger.ToString());
		}

		[Ignore]
		[TestMethod]
		public void TestBlah()
		{
			var dagger = new PhbWeapon("Dagger");
			var forgedDagger = new ForgedWeapon(new ForgedWeapon(dagger, new ColdIron()), new Masterwork());
			var distance = new WeaponEnchantment("Distance");
			var anarchic = new WeaponEnchantment("Anarchic");
			var keen = new WeaponEnchantment("Keen");
			var flameBurst = new WeaponEnchantment("Flaming Burst");
			//var flameBurst1 = new WeaponEnchantment("Flaming Burst");
			//var flameBurst2 = new WeaponEnchantment("Flaming Burst");
			var plusEnhancement = 4;
			List<WeaponEnchantment> enchantmentClump = new List<WeaponEnchantment>();
			enchantmentClump.Add(distance);
			enchantmentClump.Add(anarchic);
			enchantmentClump.Add(keen);
			enchantmentClump.Add(flameBurst);
			//enchantmentClump.Add(flameBurst1);
			//enchantmentClump.Add(flameBurst2);

			//var enchantmentTotals = from clump in enchantmentClump
			//                        select clump.CostModifier;

			var enchantmentTotals = enchantmentClump.Select(c => c.CostModifier).ToList();

			//var totalEnchantmentModifier = enchantmentTotals.ToList();
			enchantmentTotals.Add(plusEnhancement);

			var enchantmentTotal = enchantmentTotals.Sum();


			var prefixes = from clump in enchantmentClump
						   where clump.Affix.Contains("Pre")
						   select clump;

			var prefixCount = prefixes.Count();

			var suffixes = from clump in enchantmentClump
						   where clump.Affix.Contains("Suf")
						   select clump;

			var suffixCount = suffixes.Count();

			var casterLevels = from clump in enchantmentClump
							   select clump.MinimumCasterLevel;

			var highestCasterLevel = casterLevels.ToList();
			highestCasterLevel.Add((plusEnhancement * 3));

			var criticalDamage = from clump in enchantmentClump
								 where clump.DoesCriticalDamage == true
								 select clump;

			var critCount = criticalDamage.Count();

			var rangeMod = from clump in enchantmentClump
						   where clump.RangeIncrementModifier != 1
						   select clump.RangeIncrementModifier;
			double greatestRangeIncrease = rangeMod.Max();


			var sb = new StringBuilder();

			sb.Append(string.Format("+{0} ", plusEnhancement));

			foreach (var prefix in prefixes)
			{
				if (prefixCount > 1)
				{
					sb.Append(string.Format("{0} (+{1} bonus)", prefix.EnchantmentName, prefix.CostModifier));
					sb.Append(", ");
					prefixCount--;
				}
				else
				{
					sb.Append(string.Format("{0} (+{1} bonus)", prefix.EnchantmentName, prefix.CostModifier));
				}

			}

			sb.Append(string.Format(" {0}", forgedDagger.WeaponName));

			foreach (var suffix in suffixes)
			{

				while (suffixCount > 0)
				{
					sb.Append(" of ");
					sb.Append(string.Format("{0} (+{1} bonus)", suffix.EnchantmentName, suffix.CostModifier));
					suffixCount--;
				}

			}

			var critSb = new StringBuilder();

			foreach (var critDie in criticalDamage)
			{
				while (critCount > 0)
				{
					string critDice = string.Empty;
					if (forgedDagger.CriticalDamage == "x2")
					{
						critDice = "1d10";
					}
					else if (forgedDagger.CriticalDamage == "x3")
					{
						critDice = "2d10";
					}
					else
					{
						critDice = "3d10";
					}
					critSb.Append(string.Format(" '+{0} ({1})'", critDice, critDie.DamageType));

					critCount--;
				}
			}

			sb.Append(string.Format("{0}Total enchantment modifier: '{1}'", Environment.NewLine, enchantmentTotal));
			sb.Append(string.Format("{0}Total enhancement cost: '{1}'", Environment.NewLine, ((Math.Pow(enchantmentTotal, 2) * 2000) + forgedDagger.WeaponCost + forgedDagger.AdditionalEnchantmentCost)));
			sb.Append(string.Format("{0}Required caster level: {1}", Environment.NewLine, highestCasterLevel.Max()));
			sb.Append(string.Format("{0}Critical damage dice:{1}", Environment.NewLine, critSb));
			sb.Append(string.Format("{0}Range increment: {1} feet for {2} (was {3} feet for {4} feet)", Environment.NewLine, (forgedDagger.RangeIncrement * greatestRangeIncrease), (dagger.MaxRange * greatestRangeIncrease), dagger.RangeIncrement, dagger.MaxRange));

			Approvals.Verify(sb.ToString());
		}
	}
}
