using System;
using System.Linq;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites
{
	public class WeaponOrder
	{
		public string Name { get; private set; }
		public double Cost { get; private set; }
		public double Weight { get; private set; }
		public string Description { get; private set; }
		public string Damage { get; private set; }
		public int ThreatRange { get; private set; }
		public string Critical { get; private set; }
		public string Range { get; private set; }
		public string DamageType { get; private set; }
		public string Proficiency { get; private set; }
		public string Category { get; private set; }
		public double Hardness { get; private set; }
		public double HitPoints { get; private set; }

		public string ToHit { get; set; }

		public string Part { get; private set; }

		public WeaponOrder(WeaponData weaponData)
		{
			WeaponInformation(weaponData);
		}

		private void WeaponInformation(WeaponData data)
		{
			Name = data.WeaponName;
			Cost = data.BasePrice;
			Weight = data.WeaponWeight;
			Description = data.WeaponText;

			Damage = data.WeaponDamage;
			ThreatRange = data.WeaponThreatRange;
			Critical = data.WeaponCritical;
			Range = data.RangeIncrement;
			DamageType = data.WeaponDamageType;
			Proficiency = data.WeaponProficiencyRequirement;
			Category = data.WeaponCategory;
			Hardness = data.WeaponHardness;
			HitPoints = data.WeaponHitPoints;
			Part = data.WeaponPart;
			ToHit = "+0";
		}

		internal void SetName(string componentName)
		{
			Name = componentName + Name;
		}

		internal void SetCost(double componentCost, double masterworkCost)
		{
			Cost += masterworkCost;
		}

		public void SetToHit(string toHit)
		{
			ToHit = toHit;
		}

		internal void SetDescription(string description)
		{
			Description = string.Format("{0}{1}{2}", Description, Environment.NewLine, string.Format(description, Name));
		}
	}
}
