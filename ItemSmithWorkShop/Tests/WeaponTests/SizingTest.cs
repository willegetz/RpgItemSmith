using ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using ItemSmithWorkShop.WeaponUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;

namespace ItemSmithWorkShop.Tests.WeaponTests
{
	[TestClass]
	public class SizingTest
	{
		[TestMethod]
		public void TestSmallSizeWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Small");
			Approvals.Verify(DisplayUtilities.BasicDisplay(sizedWeapon));
		}

		[TestMethod]
		public void TestLargeSizeWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Large");
			Approvals.Verify(DisplayUtilities.BasicDisplay(sizedWeapon));
		}

		[TestMethod]
		public void TestSmallAdamantineWeapon()
		{
			var weapon = WeaponItemSmith.OrderItem("Dagger");
			var sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Small");
			var adamantineWeapon = WeaponItemSmith.OrderSpecialComponent(sizedWeapon, "Adamantine");
			Approvals.Verify(DisplayUtilities.BasicDisplay(adamantineWeapon));
		}

		[TestMethod]
		public void TestLargePlus3Weapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Large");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(sizedWeapon, 3);
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(magicWeapon));
		}

		[TestMethod]
		public void TestLargePlus3FlamingWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Large");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(sizedWeapon, 3);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}

		[TestMethod]
		public void TestLargePlus3FlamingIcyBurstWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Large");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(sizedWeapon, 3);
			EnchantedWeaponItem flamingWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			EnchantedWeaponItem icyBurstWeapon = WeaponEnchanter.RequestEnchantment(flamingWeapon, "Icy Burst");
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(icyBurstWeapon));
		}
	}
}
