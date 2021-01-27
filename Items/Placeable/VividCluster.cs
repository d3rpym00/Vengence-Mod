using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Placeable
{
	public class VividCluster : ModItem
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
			item.rare = ItemRarityID.Yellow;
			item.maxStack = 999;
			item.consumable = true;
			item.createTile = TileType<Tiles.VividCluster>();
			item.width = 12;
			item.height = 12;
			item.value = 3000;
		}
	}
}
