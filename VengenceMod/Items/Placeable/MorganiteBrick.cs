using VengenceMod.Tiles.Brick;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using VengenceMod.Items.Meterials;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Placeable
{
	public class MorganiteBrick : ModItem
	{
		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = TileType<Tiles.Brick.MorganiteBrick>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RefinedMorganite>(), 30);
			recipe.SetResult(this, 10);
			recipe.AddRecipe();
		}
	}
}
