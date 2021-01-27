using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class MysticDark : ModItem
	{
		public override void SetStaticDefaults() {
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults() {
			item.damage = 20;
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
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<MysticDarkProjectile>();
			item.shootSpeed = 15f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(173, 4);
			recipe.AddIngredient(521, 10);
			recipe.AddIngredient(527, 1);
			recipe.AddIngredient(ModContent.ItemType<MysticBar>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}