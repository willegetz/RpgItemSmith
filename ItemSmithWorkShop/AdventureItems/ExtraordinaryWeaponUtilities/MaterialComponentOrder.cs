using System;
using System.Linq;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities
{
	public class MaterialComponentOrder
	{
		public string Name { get; private set; }
		public double CostModifier { get; private set; }
		public int MasterworkCost { get; private set; }
		public double WeightModifier { get; private set; }
		public string ToHit { get; private set; }
		public int DamageModifier { get; private set; }
		public string Description { get; private set; }
		public bool IsMasterwork { get; private set; }
		public double AdditionalCostModifier { get; private set; }

		public MaterialComponentOrder(MaterialComponentData component)
		{
			ComponentInformation(component);
		}

		private void ComponentInformation(MaterialComponentData component)
		{
			Name = component.Name;
			CostModifier = component.ComponentCostModifier;
			MasterworkCost = component.MasterworkCostModifier;
			WeightModifier = component.ComponentWeightModifier;
			ToHit = component.ToHitBonus;
			DamageModifier = component.ComponentDamageModifier;
			Description = component.ComponentDescription;
			IsMasterwork = component.IsMasterwork;
			AdditionalCostModifier = component.AdditionalCostModifier;
		}
	}
}
