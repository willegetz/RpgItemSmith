using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Items.Interfaces
{
	public interface IMaterialComponent
	{
		string ComponentName { get; }
		double WeaponCostModifier { get; }
		bool IsMasterwork { get; }
		string ToHitBonus { get; }
		double DamageBonus { get; }
		string ComponentInfo { get; }

		double ApplyCostModifier(IWeapon weapon);
		string AppendSpecialInfo(IWeapon weapon);
		string ApplyToHitModifier();
		double ApplyDamageModifier(IWeapon weaopn);

		// These methods do not belong in all classes implementing IMaterialComponent
		//		Cold Iron has an additional enchantment cost
		//		Mithral applies a special weight modifier
		//		Masterwork needs to know if the object is already masterwork.
		bool VerifyMasterwork(IWeapon weapon);
		double ApplyWeightModifer(IWeapon weapon);
		double GetAdditionalEnchantmentCost();

	}
}
