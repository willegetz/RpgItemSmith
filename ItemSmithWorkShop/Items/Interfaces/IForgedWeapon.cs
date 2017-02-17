using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Items.Interfaces
{
	public interface IForgedWeapon : IWeapon
	{
		double AdditionalEnchantmentCost { get; }
		string ToHitModifier { get; }
		double DamageBonus { get; }
		string ComponentName { get; }
	}
}
