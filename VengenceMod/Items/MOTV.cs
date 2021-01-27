using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;

namespace VengenceMod.Items
{
	public class MOTV : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("M.O.T.V");
			Tooltip.SetDefault("Transforms musket balls into void bullets");
		}

		public override void SetDefaults()
		{
			item.damage = 95;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 20000;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 100f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<BlitzBlaster>(), 1);
			recipe.AddIngredient(ModContent.ItemType<VoidBar>(), 20);
			recipe.AddIngredient(ModContent.ItemType<VoidCells>(), 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet)
			{
				type = ModContent.ProjectileType<VoidBullet>();
			}
			return true;
		}
	}
}
