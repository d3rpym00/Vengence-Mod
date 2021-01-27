using VengenceMod.Tiles;
using Terraria;
using VengenceMod.Items.Meterials;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace VengenceMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Wings)]
	public class VoidSpiritWings : ModItem
	{

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = ItemRarityID.Cyan;
			item.accessory = true;
		}
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 150;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 9f;
			acceleration *= 2.5f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<VoidCells>(), 14);
			recipe.AddIngredient(ModContent.ItemType<VoidBar>(), 20);
			recipe.AddIngredient(575, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}