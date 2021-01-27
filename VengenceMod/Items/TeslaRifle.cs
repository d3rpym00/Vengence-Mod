using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;

namespace VengenceMod.Items
{
	public class TeslaRifle : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tesla Rifle");
			Tooltip.SetDefault("Transforms musket balls into high velocity bullets");
		}

		public override void SetDefaults() {
			item.damage = 20;
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
			item.rare = ItemRarityID.Lime;
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
	}
}
