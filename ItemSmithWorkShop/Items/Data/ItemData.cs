using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Items.Data
{
	public class ItemData
	{
		private static Dictionary<string, WeaponTemplate> weaponData;

		static ItemData()
		{
			LoadWeaponData();
		}

		private static void LoadWeaponData()
		{
			weaponData = new Dictionary<string, WeaponTemplate>(StringComparer.OrdinalIgnoreCase)
			             	{
			             		{ "Dagger",
			             			new WeaponTemplate {
			             					weaponName = "Dagger",
			             					proficiency = "Simple",
			             					weaponUse = "Melee",
			             					weaponCategory = "Light",
			             					weaponSubCategory = "Thrown",
			             					weaponSize = "Medium",
			             					weaponCost = 2,
											damage = "1d4",
											threatRangeLowerBound = 19,
											criticalDamage = "x2",
											rangeIncrement = 10,
											maxRange = 0,
											damageType = "Piercing or Slashing",
											weight = 1,
											hardness = 10,
											hitPoints = 2,
											specialInfo = "+2 bonus on Sleight of Hand checks made to conceal a\n\tdagger on your body"
														}
			             		},
								// Add Crossbow
								{ "Heavy Crossbow",
									new WeaponTemplate {
										weaponName = "Heavy Crossbow",
										proficiency = "Simple",
										weaponUse = "Ranged",
										weaponCategory = "Light",
										weaponSize = "Medium",
										weaponCost = 50,
										damage = "1d10",
										threatRangeLowerBound = 19,
										criticalDamage = "x2",
										rangeIncrement = 120,
										maxRange = 0,
										damageType = "Piercing",
										weight = 8,
										hardness = 5,
										hitPoints = 5,
										specialInfo = "Loading a heavy crossbow is a full round that provokes attacks of opportunity",
										isBow = true
														}
								},
								{ "Short Sword",
									new WeaponTemplate{
											 weaponName = "Short Sword",
											 proficiency = "Martial",
											 weaponUse = "Melee",
											 weaponCategory = "One-Handed",
											 weaponSubCategory = string.Empty,
											 weaponSize = "Medium",
											 weaponCost = 10,
											 damage = "1d6",
											 threatRangeLowerBound = 19,
											 criticalDamage = "x2",
											 rangeIncrement = 0,
											 maxRange = 0,
											 damageType = "Piercing",
											 weight = 2,
											 hardness = 10,
											 hitPoints = 5,
											 specialInfo = "This sword is popular as on off-hand weapon"
														}
								
								}			
							};
		}



		public static WeaponTemplate RetrieveWeaponTemplate(string weaponKey)
		{
			return weaponData[weaponKey];
		}
	}
}
