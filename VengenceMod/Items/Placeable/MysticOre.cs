using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Placeable
{
	public class MysticOre : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[item.type] = 59;
		}

		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.maxStack = 999;
			item.rare = ItemRarityID.Pink;
			item.consumable = true;
			item.createTile = TileType<Tiles.MysticOre>();
			item.width = 12;
			item.height = 12;
			item.value = 3000;
		}
	}
}
