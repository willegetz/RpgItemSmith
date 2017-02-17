using System;
using System.Linq;

namespace ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites
{
	public class WeaponItem : WeaponItemWeaver
	{
		private string name;
		private double cost;
		private double weight;
		private readonly string description;
		private string damage;
		private readonly int threatRange;
		private readonly string critical;
		private readonly string range;
		private readonly string damageType;
		private readonly string proficiency;
		private readonly string category;
		private double hardness;
		private double hitPoints;

		public WeaponItem(WeaponOrder weapon)
		{
			name = weapon.Name;
			cost = weapon.Cost;
			weight = weapon.Weight;
			description = weapon.Description;
			damage = weapon.Damage;
			threatRange = weapon.ThreatRange;
			critical = weapon.Critical;
			range = weapon.Range;
			damageType = weapon.DamageType;
			proficiency = weapon.Proficiency;
			category = weapon.Category;
			hardness = weapon.Hardness;
			hitPoints = weapon.HitPoints;
		}

		public string Category
		{
			get
			{
				return category;
			}
		}

		public string Proficiency
		{
			get
			{
				return proficiency;
			}
		}

		public string Range
		{
			get
			{
				return range;
			}
		}

		public override string GetName()
		{
			return name;
		}

		public override double GetCost()
		{
			return cost;
		}

		public override bool IsMasterwork()
		{
			return false;
		}

		public override double GetWeight()
		{
			return weight;
		}

		public override string GetDescription()
		{
			return description;
		}

		public override string GetDamage()
		{
			return damage;
		}

		public override string GetThreat()
		{
			return string.Format("{0}-20", threatRange);
		}

		public override string GetCriticalMultiplier()
		{
			return critical;
		}

		public override string GetDamageType()
		{
			return damageType;
		}

		public override double GetHardness()
		{
			return hardness;
		}

		public override double GetHitPoints()
		{
			return hitPoints;
		}

		internal void SetName(string sizeKey)
		{
			name = string.Format("{0} [{1}]", name, sizeKey);
		}

		internal void SetCost(double sizeMultiplier)
		{
			cost = (cost * sizeMultiplier);
		}

		internal void SetHardness(double sizeMultiplier)
		{
			hardness = (hardness * sizeMultiplier);
		}

		internal void SetWeight(double sizeMultiplier)
		{
			weight = (weight * sizeMultiplier);
		}

		internal void SetHitPoints(double sizeMultiplier)
		{
			hitPoints = (hitPoints * sizeMultiplier);
		}

		internal void SetDamage(string newDamage)
		{
			damage = newDamage;
		}
	}
}