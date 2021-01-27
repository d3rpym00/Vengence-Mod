using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using VengenceMod.Items.Placeable;
using Microsoft.Xna.Framework;
using VengenceMod.Projectiles;

namespace VengenceMod.Items
{
    public class RunicKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Runic Knives");
        }
        public override void SetDefaults()
        {
            item.damage = 500;
            item.thrown = true;
            item.noMelee = true;
            item.width = 32;
            item.height = 32;
            item.useTime = 5;
            item.useAnimation = 5;
            item.consumable = true;
            item.maxStack = 999;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 4;
            item.value = Item.sellPrice(gold: 75);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item39;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<RunicKnivesProjectile>();
            item.shootSpeed = 12f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 2 + Main.rand.Next(4);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
