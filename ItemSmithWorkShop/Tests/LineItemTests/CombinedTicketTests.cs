using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using System.Collections.Generic;
using ItemSmithWorkShop.AdventureItems.Interfaces;
using System.Text;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.Tests.LineItemTests
{
	[TestClass]
	public class CombinedTicketTests
	{
		[TestMethod]
		public void TestCombinedTicket()
		{
			var sb = new StringBuilder();
			List<ILineItems> orderTicket = new List<ILineItems>();
			orderTicket.Add(ItemTicket.GetWeaponTicket("Short Sword"));
			orderTicket.Add(ItemTicket.GetMaterialIngot("Cold Iron"));
			orderTicket.Add(ItemTicket.GetSpecialAbilityTicket("Icy Burst"));

			foreach (var item in orderTicket)
			{
				sb.AppendLine(item.ToString() + Environment.NewLine);
			}

			Approvals.Verify(sb.ToString());
		}
	}
}
