using ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.Tests.WeaponTests
{
	[TestClass]
	public class EnchantedWeaponTest
	{
		[TestMethod]
		public void TestFlamingEnchantment()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}

		[TestMethod]
		public void TestFlamingAdamantineWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon adamantineWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Adamantine");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(adamantineWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}

		[TestMethod]
		public void TestFlamingSilverWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon silverWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Silver");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(silverWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}

		[TestMethod]
		public void TestFlamingColdIreonWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon ironWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Cold Iron");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(ironWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}

		[TestMethod]
		public void TestFlamingDarkwoodItem()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon darkwoodWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Darkwood");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(darkwoodWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}

		[TestMethod]
		public void TestFlamingMithralItem()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon mithralWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Mithral");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(mithralWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}

		[TestMethod]
		public void TestWeaponEnchanter()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}

		[TestMethod]
		public void TestDoubleWeaponEnchanter()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			EnchantedWeaponItem doubleEnchantedWeapon = WeaponEnchanter.RequestEnchantment(enchantedWeapon, "Flaming");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(doubleEnchantedWeapon));
		}

		[TestMethod]
		public void TestFlamingIcyBurstDagger()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			EnchantedWeaponItem flamingWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			EnchantedWeaponItem icyBurstWeapon = WeaponEnchanter.RequestEnchantment(flamingWeapon, "Icy Burst");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(icyBurstWeapon));
		}

		[TestMethod]
		public void TestVorpaldagger()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Vorpal");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}
	}
}
