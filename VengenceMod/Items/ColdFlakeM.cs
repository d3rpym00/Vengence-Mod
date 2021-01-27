using Microsoft.Xna.Framework;
using Terraria;
using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class ColdFlakeM : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cold Flake");
		}
		public override void SetDefaults()
		{
			item.shootSpeed = 15f;
			item.damage = 40;
			item.knockBack = 5f;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 30;
			item.height = 30;
			item.rare = ItemRarityID.LightRed;

			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.melee = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 75);
			item.shoot = ProjectileType<ColdFlakeProjectileM>();

		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ArcticBar>(), 10);
			recipe.AddIngredient(664, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
