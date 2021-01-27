using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VengenceMod.Projectiles
{
    public class VividStarProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vivid Star");
			//aiType = 495;
        }

        public override void SetDefaults()
        {
			projectile.aiStyle = 5;
			projectile.width = 20;
			projectile.height = 20;
            projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.penetrate = 5;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 135;
        }     
		
		private const float maxTicks = 60f;
        private const int alphaReducation = 25;
		
		public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.1f, 0.05f, 0.6f);
			
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 59, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 100, default(Color), 0.75f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 1f;
			
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 54, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 0.75f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 0.50f;
        }
    }
}