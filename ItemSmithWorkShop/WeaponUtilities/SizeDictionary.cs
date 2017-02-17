using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class SizeDictionary
	{
		const string fine = "Fine";
		const string diminutive = "Diminutive";
		const string tiny = "Tiny";
		const string small = "Small";
		const string medium = "Medium";
		const string large = "Large";
		const string huge = "Huge";
		const string gargantuan = "Gargantuan";
		const string colossal = "Colossal";

		const string d0 = "No Meaningful Damage";
		const string d1 = "1";
		private const string d2 = "1d2";
		private const string d3 = "1d3";
		private const string d4 = "1d4";
		private const string d6 = "1d6";
		private const string d2d4 = "2d4";
		private const string d8 = "1d8";
		private const string d10 = "1d10";
		private const string d12 = "1d12";
		private const string d2d6 = "2d6";
		private const string d3d6 = "3d6";
		private const string d4d6 = "4d6";
		private const string d6d6 = "6d6";
		private const string d2d8 = "2d8";
		private const string d3d8 = "3d8";
		private const string d4d8 = "4d8";
		private const string d6d8 = "6d8";
		private const string d8d6 = "8d6";

		private static Dictionary<string, double> sizeModifier;

		public Dictionary<string, string> damage1D2 { get; private set; }
		public Dictionary<string, string> damage1D3;
		public Dictionary<string, string> damage1D4;
		public Dictionary<string, string> damage1D6;
		public Dictionary<string, string> damage2D4;
		public Dictionary<string, string> damage1D8;
		public Dictionary<string, string> damage1D10;
		public Dictionary<string, string> damage1D12;
		public Dictionary<string, string> damage2D6;

		public SizeDictionary()
		{
			LoadDamageDictionaries();
		}

		private void LoadDamageDictionaries()
		{
			damage1D2 = new Dictionary<string, string>
			{
				{ fine, d0 }, { diminutive, d0 }, { tiny, d0 },
				{ small, d1 }, { medium, d2 }, { large, d3 }, { huge, d4 }, { gargantuan, d6 }, { colossal, d8 },
			};
			damage1D3 = new Dictionary<string, string>
			{
				{ fine, d0 }, { diminutive, d0 }, { tiny, d1 },
				{ small, d2 }, { medium, d3 }, { large, d4 }, { huge, d6 }, { gargantuan, d8 }, { colossal, d2d6 },
			};
			damage1D4 = new Dictionary<string, string>
			{
				{ fine, d0 }, { diminutive, d1 }, { tiny, d2 },
				{ small, d3 }, { medium, d4 }, { large, d6 }, { huge, d8 }, { gargantuan, d2d6 }, { colossal, d3d6 },
			};
			damage1D6 = new Dictionary<string, string>
			{
				{ fine, d1 }, { diminutive, d2 }, { tiny, d3 },
				{ small, d4 }, { medium, d6 }, { large, d8 }, { huge, d2d6 }, { gargantuan, d3d6 }, { colossal, d4d6 },
			};
			damage2D4 = new Dictionary<string, string>
			{
				{ fine, d2 }, { diminutive, d3 }, { tiny, d4 },
				{ small, d6 }, { medium, d2d4 }, { large, d2d6 }, { huge, d3d6 }, { gargantuan, d4d6 }, { colossal, d6d6 },
			};
			damage1D8 = new Dictionary<string, string>
			{
				{ fine, d2 }, { diminutive, d3 }, { tiny, d4 },
				{ small, d6 }, { medium, d8 }, { large, d2d6 }, { huge, d3d6 }, { gargantuan, d4d6 }, { colossal, d6d6 },
			};
			damage1D10 = new Dictionary<string, string>
			{
				{ fine, d3 }, { diminutive, d4 }, { tiny, d6 },
				{ small, d8 }, { medium, d10 }, { large, d2d8 }, { huge, d3d8 }, { gargantuan, d4d8 }, { colossal, d6d8 },
			};
			damage1D12 = new Dictionary<string, string>
			{
				{ fine, d4 }, { diminutive, d6 }, { tiny, d8 },
				{ small, d10 }, { medium, d12 }, { large, d3d6 }, { huge, d4d6 }, { gargantuan, d6d6 }, { colossal, d8d6 },
			};
			damage2D6 = new Dictionary<string, string>
			{
				{ fine, d4 }, { diminutive, d6 }, { tiny, d8 },
				{ small, d10 }, { medium, d2d6 }, { large, d3d6 }, { huge, d4d6 }, { gargantuan, d6d6 }, { colossal, d8d6 },
			};
		}
	}
}
