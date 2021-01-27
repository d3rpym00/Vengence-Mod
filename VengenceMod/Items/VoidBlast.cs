using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class VoidBlast : ModItem
	{
		public override void SetDefaults() {
			item.damage = 55;
			item.magic = true;
			item.mana = 12;
			item.width = 40;
			item.height = 40;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = ProjectileType<VoidBullet>();
			item.shootSpeed = 50f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(127, 1);
			recipe.AddIngredient(ModContent.ItemType<VoidBar>(), 10);
			recipe.AddIngredient(ModContent.ItemType<VoidCells>(), 5);
			recipe.AddIngredient(ModContent.ItemType<MysticBar>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}