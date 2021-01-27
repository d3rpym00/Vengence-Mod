using VengenceMod.Items.Meterials;
using Terraria;
using VengenceMod.Tiles;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace VengenceMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CryoFrostL : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Cryo Frost Leggings");
			Tooltip.SetDefault("5% increased movement speed");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.LightRed;
			item.defense = 15;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1f;
			player.maxRunSpeed *= 1f;
		}


		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ArcticBar>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}