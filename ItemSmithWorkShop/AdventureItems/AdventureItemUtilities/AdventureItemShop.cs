using System;
using System.Linq;

namespace ItemSmithWorkShop.AdventureItems.AdventureItemUtilities
{
	public abstract class AdventureItemShop
	{
		public AdventureItem OrderItem(string itemName)
		{
			var adventureItem = CreateItem(itemName);

			return adventureItem;
		}

		protected abstract AdventureItem CreateItem(string itemName);
	}
}
