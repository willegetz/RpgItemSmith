using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using ItemSmithWorkShop.AdventureItems.WeaponSpecialQualities;
using ItemSmithWorkShop.WeaponUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;

namespace ItemSmithWorkShop.Tests.WeaponTests
{
	[TestClass]
	public class ProofOfConceptTest
	{
		[TestMethod]
		public void TestWeaponOrder()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			Approvals.Verify(DisplayUtilities.BasicDisplay(weapon));
		}

		// Display Utilities does not work with this test.
		[TestMethod]
		public void TestMasterworkOrder()
		{
			WeaponOrder weapon = WeaponItemSmith.OrderBlah("Dagger");
			MasterworkWeaponItem masterworkWeapon = WeaponItemSmith.OrderBlah(weapon, "Masterwork");
			Approvals.Verify(masterworkWeapon.ToString());
		}
	}
}
