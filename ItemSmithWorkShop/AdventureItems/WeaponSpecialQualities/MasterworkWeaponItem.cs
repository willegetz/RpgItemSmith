using System;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;

namespace ItemSmithWorkShop.AdventureItems.WeaponSpecialQualities
{
	public class MasterworkWeaponItem : WeaponItemWeaver
	{
		readonly MaterialComponentOrder materialComponent;
		readonly WeaponOrder weaponOrder;

		public MasterworkWeaponItem(WeaponOrder weapon, MaterialComponentOrder component)
		{
			weaponOrder = weapon;
			materialComponent = component;
			AlternateAssignmentPath();
		}

		private void AlternateAssignmentPath()
		{
			weaponOrder.SetName(materialComponent.Name);
			weaponOrder.SetCost(materialComponent.CostModifier, materialComponent.MasterworkCost);
			weaponOrder.SetToHit(materialComponent.ToHit);
			weaponOrder.SetDescription(materialComponent.Description);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(string.Format("Name: '{0}'", weaponOrder.Name));
			sb.AppendLine(string.Format("Cost: '{0}'", weaponOrder.Cost));
			sb.AppendLine(string.Format("To Hit: '{0}'", weaponOrder.ToHit));
			sb.AppendLine(string.Format("Damage: '{0}'", weaponOrder.Damage));
			sb.AppendLine(string.Format("Weight: '{0}'", weaponOrder.Weight));
			sb.AppendLine(string.Format("Description:{0}{1}", Environment.NewLine, weaponOrder.Description));
			return sb.ToString();
		}
	}
}
