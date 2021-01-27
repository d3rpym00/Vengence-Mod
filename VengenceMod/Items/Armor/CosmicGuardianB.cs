using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using VengenceMod.Tiles;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class CosmicGuardianB : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Cosmic Guardian Breastplate");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Purple;
			item.defense = 70;
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CosmicBar>(), 30);
			recipe.AddTile(TileType<CelestialCrucible>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}