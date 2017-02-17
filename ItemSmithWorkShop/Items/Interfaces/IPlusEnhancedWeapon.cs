using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Items.Interfaces
{
	public interface IPlusEnhancedWeapon : IForgedWeapon
	{
		double PlusEnhancement { get; }
		double MinimumCasterLevel { get; }
		string MagicAura { get; }
		string GeneratesLight { get; }
		string RequiredFeats { get; }
		double CreationTime { get; }
		double RawMaterialCost { get; }
		double CreationXpCost { get; }
		double BaseEnhancementCost { get; }
		double BaseItemCost { get; }
	}
}
