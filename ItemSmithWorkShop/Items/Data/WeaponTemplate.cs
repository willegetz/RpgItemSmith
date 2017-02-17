using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.Data
{
	public class WeaponTemplate : IWeapon
	{
		public string proficiency;
		public string Proficiency
		{
			get { return proficiency; }
			private set { proficiency = value; }
		}

		public string weaponUse;
		public string WeaponUse
		{
			get { return weaponUse; }
			private set { weaponUse = value; }
		}

		public string weaponCategory;
		public string WeaponCategory
		{
			get { return weaponCategory; }
			private set { weaponCategory = value; }
		}

		public string weaponSubCategory;
		public string WeaponSubCategory
		{
			get { return weaponSubCategory; }
			private set { weaponSubCategory = value; }
		}

		public string weaponSize;
		public string WeaponSize
		{
			get { return weaponSize; }
			private set { weaponSize = value; }
		}

		public string weaponName;
		public string WeaponName
		{
			get { return weaponName; }
			private set { weaponName = value; }
		}

		public double weaponCost;
		public double WeaponCost
		{
			get { return weaponCost; }
			private set { weaponCost = value; }
		}

		public string damage;
		public string Damage
		{
			get { return damage; }
			private set { damage = value; }
		}

		public double threatRangeLowerBound;
		public double ThreatRangeLowerBound
		{
			get { return threatRangeLowerBound; }
			private set { threatRangeLowerBound = value; }
		}

		private string threatRange;
		public string ThreatRange
		{
			get { return threatRange; }
			private set { threatRange = value; }
		}

		public string criticalDamage;
		public string CriticalDamage
		{
			get { return criticalDamage; }
			private set { criticalDamage = value; }
		}

		public double rangeIncrement;
		public double RangeIncrement
		{
			get { return rangeIncrement; }
			private set { rangeIncrement = value; }
		}

		public double maxRange;
		public double MaxRange
		{
			get { return maxRange; }
			private set { maxRange = value; }
		}

		public double weight;
		public double Weight
		{
			get { return weight; }
			private set { weight = value; }
		}

		public string damageType;
		public string DamageType
		{
			get { return damageType; }
			private set { damageType = value; }
		}

		public string specialInfo;
		public string SpecialInfo
		{
			get { return specialInfo; }
			private set { specialInfo = value; }
		}

		public string givenName;
		public string GivenName
		{
			get { return givenName; }
			private set { givenName = value; }
		}

		public bool isMasterwork;
		public bool IsMasterwork
		{
			get { return isMasterwork; }
			private set { isMasterwork = value; }
		}

		public double hardness;
		public double Hardness
		{
			get { return hardness; }
			private set { hardness = value; }
		}

		public double hitPoints;
		public double HitPoints
		{
			get { return hitPoints; }
			private set { hitPoints = value; }
		}

		public bool IsMagical { get { return false; } }

		public bool isBow;
		public bool IsBow 
		{
			get { return isBow; }
			private set { isBow = value; } 
		}

		public WeaponTemplate()
		{
			Proficiency = proficiency;
			WeaponUse = weaponUse;
			WeaponCategory = weaponCategory;
			WeaponSubCategory = weaponSubCategory;
			WeaponSize = weaponSize;
			WeaponName = weaponName;
			WeaponCost = weaponCost;
			Damage = damage;
			ThreatRangeLowerBound = threatRangeLowerBound;
			CriticalDamage = criticalDamage;
			RangeIncrement = rangeIncrement;
			MaxRange = maxRange;
			DamageType = damageType;
			Weight = weight;
			Hardness = hardness;
			HitPoints = hitPoints;
			SpecialInfo = specialInfo;
			GivenName = givenName;
			IsMasterwork = isMasterwork;
			IsBow = isBow;
		}
	}
}
