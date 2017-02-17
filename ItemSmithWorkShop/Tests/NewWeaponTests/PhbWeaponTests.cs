using System.Text;
using ApprovalTests;
using ItemSmithWorkShop.Items.MaterialTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWorkShop.Items.MagicEnchantments;
using System;
using System.Linq;
using System.Collections.Generic;
using ItemSmithWorkShop.Items.Weapons;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Tests.NewWeaponTests
{
	[TestClass]
	public class PhbWeaponTests
	{
		[TestMethod]
		public void TestDisplayDagger()
		{
			var dagger = new PhbWeapon("Dagger");
			Approvals.Verify(dagger.ToString());
		}

		[TestMethod]
		public void TestDisplayMithral()
		{
			var mithral = new Mithral();
			Approvals.Verify(mithral.ToString());
		}

		[TestMethod]
		public void TestDisplayAnarchicEnchantment()
		{
			var anarchic = new WeaponEnchantment("Anarchic");
			Approvals.Verify(anarchic.ToString());
		}

		[TestMethod]
		public void TestDisplayFlamingBurstEnchantment()
		{
			var flameBurst = new WeaponEnchantment("Flaming Burst");
			Approvals.Verify(flameBurst.ToString());
		}

		[TestMethod]
		public void TestDisplayDistanceEnchantment()
		{
			var distance = new WeaponEnchantment("Distance");
			Approvals.Verify(distance.ToString());
		}

		[TestMethod]
		public void TestDisplayKeenEnchantment()
		{
			var keen = new WeaponEnchantment("Keen");
			Approvals.Verify(keen.ToString());
		}

		[TestMethod]
		public void TestDisplayColdIron()
		{
			var coldIron = new ColdIron();
			Approvals.Verify(coldIron.ToString());
		}

		[TestMethod]
		public void TestForgeMithralWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var mithral = new Mithral();
			var forgedDagger = new ForgedWeapon(dagger, mithral);
			forgedDagger.NameWeapon("Carlyle's Special Greeting");
			Approvals.Verify(forgedDagger.ToString());
		}

		[TestMethod]
		public void TestForgeColdIronWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var coldIron = new ColdIron();
			var forgedDagger = new ForgedWeapon(dagger, coldIron);
			forgedDagger.NameWeapon("Krus Hakhar");
			Approvals.Verify(forgedDagger.ToString());
		}

		[TestMethod]
		public void TestMasterworkColdIronWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var coldIron = new ColdIron();
			var forgedDagger = new ForgedWeapon(dagger, coldIron);
			var masterwork = new Masterwork();
			var masterworkColdIronDagger = new ForgedWeapon(forgedDagger, masterwork);
			Approvals.Verify(masterworkColdIronDagger.ToString());
		}

		[TestMethod]
		public void TestForgedAlchemicalSilverWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var silver = new AlchemicalSilver();
			var forgedDagger = new ForgedWeapon(dagger, silver);
			Approvals.Verify(forgedDagger.ToString());
		}

		[TestMethod]
		public void TestMasterworkAlchemicalSilverWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var silver = new AlchemicalSilver();
			var forgedDagger = new ForgedWeapon(dagger, silver);
			var masterwork = new Masterwork();
			var masterworkSilverDagger = new ForgedWeapon(forgedDagger, masterwork);
			Approvals.Verify(masterworkSilverDagger.ToString());
		}
	}
}
