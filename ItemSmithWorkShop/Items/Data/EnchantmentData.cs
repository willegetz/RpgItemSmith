using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Items.Data
{
	public class EnchantmentData
	{
		private static Dictionary<string, WeaponEnchantmentTemplate> weaponEnchantmentData;

		static EnchantmentData()
		{
			LoadWeaponEnchantmentData();
		}

		private static void LoadWeaponEnchantmentData()
		{
			weaponEnchantmentData = new Dictionary<string, WeaponEnchantmentTemplate>(StringComparer.OrdinalIgnoreCase)
								{
									{"Anarchic",
										 new WeaponEnchantmentTemplate{
											 enchantmentName = "Anarchic",
											 affix = "Pre",
											 costModifier = 2,
											 rangeIncrementModifier = 1,
											 weaponUse = "Melee, Ranged",
											 standardDamageBonus = "2d6 vs. Lawful Alignment",
											 doesCriticalDamage = false,
											 damageType = "Chaotic",
											 magicAura = "Moderate evocation [chaotic]",
											 minimumCasterLevel = 7,
											 requiredFeats = "Craft Magic Arms and Armor",
											 requiredSpells = "chaos hammer",
											 additionalRequirements = "Creator must be chaotic",
											 enchantmentNotes = "-1 temporary level to any wielder of Lawful Alignment.\n\tLevel loss cannot be overcome in any way while the\n\tweapon is wielded.",
										 }
									},
									{"Flaming Burst",
										new WeaponEnchantmentTemplate{
											enchantmentName = "Flaming Burst",
											affix = "Suf",
											costModifier = 2,
											rangeIncrementModifier = 1,
											weaponUse = "Melee, Ranged",
											standardDamageBonus = "1d6",
											doesCriticalDamage = true,
											damageType = "Fire",
											magicAura = "Strong evocation",
											minimumCasterLevel = 12,
											requiredFeats = "Craft Magic Arms and Armor",
											requiredSpells = "flame blade, flame strike, or fireball",
										}
									},
									{"Distance",
										new WeaponEnchantmentTemplate{
											enchantmentName = "Distance",
											affix = "Pre",
											costModifier = 1,
											weaponUse = "Ranged",
											rangeIncrementModifier = 2,
											magicAura = "Moderate divination",
											minimumCasterLevel = 6,
											requiredFeats = "Craft Magic Arms and Armor",
											requiredSpells = "clairaudience/clairvoyance",
											enchantmentNotes = "This property can only be placed on a ranged weapon.\n\tA weapon of distance has double the range\n\tincrement of other weapons of its kind",
										}
									
									},
									{"Keen",
										new WeaponEnchantmentTemplate{
											enchantmentName = "Keen",
											affix = "Pre",
											costModifier = 1,
											weaponUse = "Melee, Ranged",
											threatRangeModifier = 2,
											magicAura = "Moderate transmutation",
											minimumCasterLevel = 10,
											requiredFeats = "Craft Magic Arms and Armor",
											requiredSpells = "keen edge",
											enchantmentNotes = "Only piercing or slashing weapons can be keen. The keen\n\tbenefit does not stack with any other effect that expands\n\tthe threat range of a weapon.",
										}
									}
								};
		}

		public static WeaponEnchantmentTemplate RetrieveWeaponEnchantment(string enchantmentKey)
		{
			return weaponEnchantmentData[enchantmentKey];
		}
	}
}
