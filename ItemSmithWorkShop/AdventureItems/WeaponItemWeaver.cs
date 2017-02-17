using System;
using System.Linq;

namespace ItemSmithWorkShop.AdventureItems
{
	public abstract class WeaponItemWeaver
	{
		public virtual string GetName()
		{
			return string.Empty;
		}

		public virtual double GetCost()
		{
			return 0;
		}

		public virtual bool IsMasterwork()
		{
			return false;
		}

		public virtual string GetDescription()
		{
			return string.Empty;
		}

		public virtual double GetWeight()
		{
			return 0;
		}

		public virtual int GetDamageModifier()
		{
			return 0;
		}

		public virtual double GetAdditionalMagicCostModifier()
		{
			return 0;
		}

		public virtual string GetToHit()
		{
			return string.Empty;
		}

		public virtual string GetDamage()
		{
			return string.Empty;
		}

		public virtual string GetThreat()
		{
			return string.Empty;
		}

		public virtual string GetDamageType()
		{
			return string.Empty;
		}

		public virtual string GetCriticalMultiplier()
		{
			return string.Empty;
		}

		public virtual string GetEnchantmentCriticalDamage()
		{
			return string.Empty;
		}

		public virtual double GetHardness()
		{
			return 0;
		}

		public virtual double GetHitPoints()
		{
			return 0;
		}

		public virtual int GetCasterLevelRequired()
		{
			return 0;
		}

		public virtual string GetCreationRequirements()
		{
			return string.Empty;
		}

		public virtual int GetEnhancementBonus()
		{
			return 0;
		}

		public virtual int GetEnhancementBonusForCost()
		{
			return 0;
		}

		public virtual double GetModifiedHardness()
		{
			return 0;
		}

		public virtual double GetMinimumCasterLevel()
		{
			return 0;
		}

		public virtual double GetDaysToCreate()
		{
			return 0;
		}

		public virtual double GetCreationXpCost()
		{
			return 0;
		}

		public virtual double GetCreationRawMaterialCost()
		{
			return 0;
		}

		public virtual double GetWeaponCost()
		{
			return 0;
		}

		public virtual double GetModifiedHitPoints()
		{
			return 0;
		}
	}
}
