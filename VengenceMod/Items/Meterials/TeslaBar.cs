using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Meterials
{
	public class TeslaBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[item.type] = 59;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 750;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.rare = ItemRarityID.LightRed;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = false;
		}
	}
}
