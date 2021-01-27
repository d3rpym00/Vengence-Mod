using Terraria.ID;
using VengenceMod.Items.Meterials;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Placeable
{
	public class CelestialCrucible : ModItem
	{

		public override void SetDefaults() {
			item.width = 47;
			item.height = 34;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.createTile = TileType<Tiles.CelestialCrucible>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<VoidCrucible>(), 1);
			recipe.AddIngredient(ModContent.ItemType<BlueDwarf>(), 10);
			recipe.AddIngredient(ModContent.ItemType<ChaosBar>(), 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}