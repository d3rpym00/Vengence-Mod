using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VengenceMod.Projectiles
{
    public class GalaxiusProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Galaxius Beam");
			//aiType = 495;
        }

        public override void SetDefaults()
        {
			projectile.aiStyle = 27;
			projectile.width = 62;
			projectile.height = 62;
            projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = false;
			projectile.penetrate = 3;
			projectile.extraUpdates = 1;
			projectile.timeLeft = 165;
        }     
		
		private const float maxTicks = 60f;
        private const int alphaReducation = 25;

		public override void AI()
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.15f, 0.15f, 0.5f);
			
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 43, projectile.velocity.X * -0.75f, projectile.velocity.Y * 0f, 100, default(Color), 0.5f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 1f;
			
			dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, projectile.velocity.X * -0.75f, projectile.velocity.Y * 0f, 100, default(Color), 0.75f);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].scale = 1f;
        }
    }
}