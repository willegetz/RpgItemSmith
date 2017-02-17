using System;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.Interfaces;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class WeaponData : ILineItems
	{
		public string WeaponName { get; set; }
		public string WeaponPart { get; set; }
		public string WeaponCategory { get; set; }
		public string WeaponProficiencyRequirement { get; set; }
		public string WeaponDamage { get; set; }
		public int WeaponThreatRange { get; set; }
		public string WeaponCritical { get; set; }
		public string WeaponDamageType { get; set; }
		public double WeaponHardness { get; set; }
		public double WeaponHitPoints { get; set; }
		public double BasePrice { get; set; }
		public double WeaponWeight { get; set; }
		public string WeaponText { get; set; }

		public string RangeIncrement { get; set; }

		public override string ToString()
		{
			return string.Format("Name: '{1}'{0}Base Price: '{2} gp'{0}Weight: '{3} pound(s)'{0}Damage: '{4} [{5}-20/{6}]' {7}{0}Range Increment: '{8} feet'{0}Hardness: '{9}'{0}Hit Points: '{10}'{0}{11}",
				Environment.NewLine,
				WeaponName,
				BasePrice,
				WeaponWeight,
				WeaponDamage,
				WeaponThreatRange,
				WeaponCritical,
				WeaponDamageType,
				RangeIncrement,
				WeaponHardness,
				WeaponHitPoints,
				WeaponText);
		}
	}
}