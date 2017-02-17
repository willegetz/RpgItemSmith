using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemSmithWorkShop.Tests.ExceptionTests
{
	[TestClass]
	public class WeaponItemExceptionTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestWeaponNameEmptyThrowsError()
		{
			WeaponItemSmith.OrderItem(string.Empty);
		}

		[TestMethod]
		[ExpectedException(typeof(KeyNotFoundException))]
		public void TestWeaponNotInListThrowsException()
		{
			WeaponItemSmith.OrderItem("Awesome Blade");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestMagicEnhancementLessThanOneThrowsError()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			new MagicWeaponItem(weapon, -1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void TestExtraordinaryNameEmptyThrowsError()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItemSmith.OrderSpecialComponent(weapon, string.Empty);
		}

		[TestMethod]
		[ExpectedException(typeof(KeyNotFoundException))]
		public void TestExtraordinaryComponentNotInListThrowsException()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItemSmith.OrderSpecialComponent(weapon, "Shiny Thing");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void TestEnhancementBonusIsMoreThanPlusTen()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 5);
			EnchantedWeaponItem flamingWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			EnchantedWeaponItem icyBurstWeapon = WeaponEnchanter.RequestEnchantment(flamingWeapon, "Icy Burst");
			WeaponEnchanter.RequestEnchantment(icyBurstWeapon, "Vorpal");
		}
	}
}
