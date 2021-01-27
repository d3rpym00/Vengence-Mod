using Terraria.ID;
using VengenceMod.Items.Meterials;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Placeable
{
	public class VoidCrucible : ModItem
	{

		public override void SetDefaults() {
			item.width = 28;
			item.height = 14;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.VoidCrucible>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AdamantiteForge);
			recipe.AddIngredient(ModContent.ItemType<VoidCells>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}