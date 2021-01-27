using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using VengenceMod.Tiles;
using Microsoft.Xna.Framework;
using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;

namespace VengenceMod.Items
{
	public class CosmicInfinity : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cosmic Infinity");
			Tooltip.SetDefault("Shoot with the fury of the cosmos");
		}

		public override void SetDefaults() {
			item.damage = 4486;
			item.ranged = true;
			item.useAnimation = 12;
			item.useTime = 4;
			item.width = 40;
			item.height = 20;
			item.useTime = 3;
			item.useAnimation = 3;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 20000;
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 100000f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ProjectileID.BulletHighVelocity;
			}
			return true;
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .85f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CosmicBar>(), 20);
			recipe.AddIngredient(ModContent.ItemType<MOTV>(), 1);
			recipe.AddIngredient(ModContent.ItemType<TeslaRifle>(), 1);
			recipe.AddIngredient(3456, 10);
			recipe.AddIngredient(3475, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
