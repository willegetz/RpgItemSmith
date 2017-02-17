using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemSmithWorkShop.Tests.LineItemTests
{
	[TestClass]
	public class MaterialIngotTests
	{
		[TestMethod]
		public void TestGetMithralIngot()
		{
			var ingot = ItemTicket.GetMaterialIngot("Mithral");
			Approvals.Verify(ingot.ToString());
		}
	}
}
