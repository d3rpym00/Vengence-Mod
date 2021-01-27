using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace VengenceMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MysticLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("\n5% increased movement speed");
			
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.defense = 20;
		}
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 1.1f;
			player.maxRunSpeed *= 1.1f;
		}


		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MysticBar>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}