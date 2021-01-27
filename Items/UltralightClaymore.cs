using Terraria.ID;
using Terraria;
using VengenceMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using VengenceMod.Tiles;
using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class UltralightClaymore : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 450;
			item.melee = true;
			item.width = 1000;
			item.height = 1000;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileType<UltralightProjectile>();
			item.shootSpeed = 16f;
			
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(502, 10);
			recipe.AddIngredient(1570, 1);
			recipe.AddIngredient(3457, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 3 + Main.rand.Next(0); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(45)); // 30 degree spread.
																												// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .1f);
				perturbedSpeed = (perturbedSpeed * scale);
				Projectile.NewProjectile(position.X, position.Y, (perturbedSpeed.X + (Main.rand.Next(-3, 4))), (perturbedSpeed.Y + (Main.rand.Next(-3, 4))), type, damage, knockBack, player.whoAmI);
			}
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}

			return true;
		}
	}
}