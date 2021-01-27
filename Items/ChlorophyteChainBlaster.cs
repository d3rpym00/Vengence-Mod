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
	public class ChlorophyteChainBlaster : ModItem
	{

		public override void SetDefaults() {
			item.damage = 90;
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
			item.rare = ItemRarityID.Yellow;
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
				type = ProjectileID.ChlorophyteBullet;
			}
			return true;

			Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
			speedX = perturbedSpeed.X;
			speedY = perturbedSpeed.Y;
			return true;
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .30f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1006, 20);
			recipe.AddIngredient(1929, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}
