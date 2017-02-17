using System;
using System.Linq;

namespace ItemSmithWorkShop.AdventureItems.AdventureItemUtilities
{
	public abstract class AdventureItem
	{
		protected string name = "Unknown Item";
		protected double cost;
		protected double weight;
		protected string description = "I don't know what item this is.";

		public virtual string GetItem()
		{
			return string.Format("{0}:\t'{1} gp{4}Weight: '{2} pound(s)'{4}\t{3}", name, cost, weight, description, Environment.NewLine);
		}
	}
}
