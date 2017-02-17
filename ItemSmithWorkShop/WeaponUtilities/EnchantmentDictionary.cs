using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.AdventureItemUtilities;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class EnchantmentDictionary : AdventureItem
	{
		private static Dictionary<string, EnchantmentData> weaponEnchantments;

		static EnchantmentDictionary()
		{
			LoadWeaponEnchantments();
		}

		public static EnchantmentData GetEnchantmentData(string enchantment)
		{
			return weaponEnchantments[enchantment];
		}

		private static void LoadWeaponEnchantments()
		{
			weaponEnchantments = new Dictionary<string, EnchantmentData>(StringComparer.OrdinalIgnoreCase)
			{
				{
					"Flaming", new EnchantmentData
					{
						EnchantmentName = "Flaming", EnchantmentDamage = " +1D6", MinimumCasterLevel = 10, EnhancementBonus = 1,
						DamageType = "Fire", CreationRequirements = "\tRequired Spells: flame blade, flame strike, or fireball",
						EnchantmentDescription = string.Format("Flaming: Upon command, a flaming weapon is sheathed in fire.{0}\tThe fire does not harm the wielder. The effect{0}\tremains until another command is given.", Environment.NewLine)
					}
				},
				{
					"Icy Burst", new EnchantmentData
					{
						EnchantmentName = "Icy Burst", EnchantmentDamage = " +1D6", EnchantmentCriticalDamage = " +1d10", MinimumCasterLevel = 10, EnhancementBonus = 2,
						DamageType = "Cold", CreationRequirements = "\tRequired Spells: chill metal or ice storm",
						EnchantmentDescription = string.Format("Icy Burst: An icy burst weapon functions as a frost weapon that also{0}\texplodes with frost upon striking a successful critical hit.{0}\tThe frost does not harm the wielder. In addition to the extra{0}\tdamage from the frost ability, an icy burst weapon deals an{0}\textra 1d10 points of cold damage on a successful critical hit.{0}\tIf the weapon’s critical multiplier is ×3, add an extra 2d10{0}\tpoints of cold damage instead, and if the multiplier is ×4,{0}\tadd an extra 3d10 points. Bows, crossbows, and slings so{0}\tcrafted bestow the cold energy upon their ammunition.{0}\tEven if the frost ability is not active, the weapon still{0}\tdeals its extra cold damage on a successful critical hit.", Environment.NewLine)
					}
				},
				{
					"Vorpal", new EnchantmentData 
					{
						EnchantmentName = "Vorpal", MinimumCasterLevel = 18, EnhancementBonus = 5, CreationRequirements = "\tRequired Spells: circle of death, keen edge",
						EnchantmentDescription = string.Format("Vorpal: This potent and feared ability allows the weapon to sever the heads{0}\tof those it strikes. Upon a roll of natural 20 (followed by a successful{0}\troll to confirm the critical hit), the weapon severs the opponent's{0}\thead (if it has one) from its body. Some creatures, such as many{0}\taberrations and all oozes, have no heads. Others, such as golems{0}\tand undead creatures other than vampires, are not affected by the{0}\tloss of their heads. Most other creatures, however, die when their{0}\theads are cut off.{0}\tA vorpal weapon must be a slashing weapon.", Environment.NewLine)
					}
				},
			};
		}
	}
}
