using VengenceMod.Items.Meterials;
using Terraria;
using VengenceMod.Tiles;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace VengenceMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CosmicGuardianL : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cosmic Guardian Leggings");
			Tooltip.SetDefault("40% increased movement speed"
			+ "\n+50 max life");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Purple;
			item.defense = 50;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1f;
			player.maxRunSpeed *= 1f;
		}


		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CosmicBar>(), 20);
			recipe.AddTile(TileType<CelestialCrucible>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}