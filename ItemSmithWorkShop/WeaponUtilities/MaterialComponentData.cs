using System;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.Interfaces;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class MaterialComponentData : ILineItems
	{
		public string Name { get; set; }
		public double ComponentCostModifier { get; set; }
		public int MasterworkCostModifier { get; set; }
		public double ComponentWeightModifier { get; set; }
		public string ToHitBonus { get; set; }
		public int ComponentDamageModifier { get; set; }
		public string ComponentDescription { get; set; }
		public bool IsMasterwork { get; set; }
		public double AdditionalCostModifier { get; set; }

		public override string ToString()
		{
			return string.Format("Name: {1}{0}Cost Modifier: '{2} gold pieces'{0}\tAdditional Cost: '{3}'{0}Weight Multiplier: '{4}'{0}Is Masterwork: '{5}'{0}Masterwork Cost: '{6}'{0}To Hit Bonus: '{7}'{0}Damage Modifier: '{8}'{0}Description:{0}\t{9}",
				Environment.NewLine,
				Name,
				ComponentCostModifier,
				AdditionalCostModifier,
				ComponentWeightModifier,
				IsMasterwork,
				MasterworkCostModifier,
				ToHitBonus,
				ComponentDamageModifier,
				ComponentDescription);
		}
	}
}
