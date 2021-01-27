using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VengenceMod.NPCs.Boss.TimeWeaver
{
	public class LightBallLaser : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sphere of light");
		}

		public override void SetDefaults()
		{
			projectile.hostile = true;
			projectile.height = 16;
			projectile.width = 16;
			projectile.friendly = false;
			projectile.aiStyle = -1;
			projectile.timeLeft = 900;
			projectile.penetrate = -1;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
				projectile.Kill();


			if (projectile.velocity.X != oldVelocity.X)
				projectile.velocity.X = oldVelocity.X * .5f;

			if (projectile.velocity.Y != oldVelocity.Y)
				projectile.velocity.Y = oldVelocity.Y * -1.3f;

			Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 10);
			return false;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 120);
		}
		float counter = -1440;

		public override void AI()
		{
			projectile.velocity *= 0.97f;
			counter++;
			if (counter == 0) {
				counter = -1440;
			}
			for (int i = 0; i < 6; i++) {
				if (projectile.velocity.X != 0) {
					float x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
					float y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;

					int num = Dust.NewDust(projectile.Center + new Vector2(0, (float)Math.Cos(counter / 8.2f) * 9.2f).RotatedBy(projectile.rotation), 6, 6, 180, 0f, 0f, 0, default(Color), 1f);
					Main.dust[num].velocity *= .1f;
					Main.dust[num].scale *= .7f;
					Main.dust[num].noGravity = true;
				}

			}
		}
		
		public override void Kill(int timeLeft) {
			
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3) {
				projectile.tileCollide = false;
				// Set to transparent. This projectile technically lives as  transparent for about 3 frames
				projectile.alpha = 255;
				// change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
				projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				
				projectile.width = 154;
				projectile.height = 154;
				projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			}
			// Play explosion sound
			Main.PlaySound(SoundID.Item14, projectile.position);
			// Smoke Dust spawn
			for (int i = 0; i < 50; i++) {
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 180, 0f, 0f, 100, default(Color), 0.55f);
				Main.dust[dustIndex].velocity *= 0f;
				Main.dust[dustIndex].scale = 1.25f;
				Main.dust[dustIndex].noGravity = true;
			}
		}

	}
	
	public class LightLaser : ModProjectile 
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sphere of light");
			aiType = 616;
		}

		public override void SetDefaults()
		{
			projectile.hostile = true;
			projectile.height = 8;
			projectile.width = 8;
			projectile.friendly = false;
			projectile.aiStyle = 1;
			projectile.timeLeft = 150;
			projectile.penetrate = -1;
		}
		
		public override void AI()
		{
			int num = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 0, 0, 180, 0f, 0f, 0, default(Color), 1f);
			Main.dust[num].velocity *= 0f;
			Main.dust[num].scale *= 1.25f;
			Main.dust[num].noGravity = true;
			
			for(int i = 0; i < 200; i++)
            {
            Player target = Main.player[i];
            if(target.statLife > 0)
            {
            float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
            float shootToY = target.position.Y - projectile.Center.Y;
            float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

            if(distance < 800f && target.active)
            {
               distance = 3.45f / distance;
   
               shootToX *= distance * 3;
               shootToY *= distance * 3;

               projectile.velocity.X = shootToX;
               projectile.velocity.Y = shootToY;
            }
            }
            }
		}
		
	}
}