using ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using ItemSmithWorkShop.WeaponUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities;

namespace ItemSmithWorkShop.Tests.WeaponTests
{
	[TestClass]
	public class MagicEnhancementWeaponTest
	{
		[TestMethod]
		public void TestCreateMagicWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			Approvals.Verify(DisplayUtilities.BasicMagicalDisplay(magicWeapon));
		}

		[TestMethod]
		public void TestCreateMagicAdamantineWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon adamantineWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Adamantine");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(adamantineWeapon, 1);
			Approvals.Verify(DisplayUtilities.BasicMagicalDisplay(magicWeapon));
		}

		[TestMethod]
		public void TestCreateMagicAlchemicalSilverWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon silverWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Silver");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(silverWeapon, 1);
			Approvals.Verify(DisplayUtilities.BasicMagicalDisplay(magicWeapon));
		}

		[TestMethod]
		public void TestCreateMagicColdIronWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon ironWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Cold Iron");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(ironWeapon, 1);
			Approvals.Verify(DisplayUtilities.BasicMagicalDisplay(magicWeapon));
		}

		[TestMethod]
		public void TestCreateMagicDarkwoodWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon darkwoodWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Darkwood");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(darkwoodWeapon, 1);
			Approvals.Verify(DisplayUtilities.BasicMagicalDisplay(magicWeapon));
		}

		[TestMethod]
		public void TestCreateMagicMithralWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon mithralWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Mithral");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(mithralWeapon, 1);
			Approvals.Verify(DisplayUtilities.BasicMagicalDisplay(magicWeapon));
		}

		[TestMethod]
		public void TestDisplayFullMagicItemText()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(magicWeapon));
		}

		[TestMethod]
		public void TestDisplayMaxEnhancedWeaponItem()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 5);
			Approvals.Verify(DisplayUtilities.FullMagicalDisplay(magicWeapon));
		}
	}
}
