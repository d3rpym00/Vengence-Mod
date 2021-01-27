using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VengenceMod.Dusts;

namespace VengenceMod.Projectiles
{
	public class TeslaBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tesla Bullet");
		}
	

		public override void SetDefaults()
		{
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 1;
			projectile.penetrate = 10;
			projectile.timeLeft = 300;
			projectile.friendly = true;
			projectile.magic = true;
			aiType = ProjectileID.Bullet;
		}

		public override Color? GetAlpha(Color lightColor) => new Color(127, 255, 212);

		public override void AI()

		{
			if (projectile.localAI[0] == 0f)
			{
				Main.PlaySound(SoundID.Item20, projectile.position);
				projectile.localAI[0] = 1f;
			}
			int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 66, 1f, 1f, 100, new Color(127, 255, 212), 1.5f);
			Main.dust[dust].velocity *= 0.1f;
			if (projectile.velocity == Vector2.Zero)
			{
				Main.dust[dust].velocity.Y -= 1f;
				Main.dust[dust].scale = 1.2f;
			}
			else
			{
				Main.dust[dust].velocity += projectile.velocity * 0.2f;
			}
			Main.dust[dust].position.X = projectile.Center.X + 4f + (float)Main.rand.Next(-2, 3);
			Main.dust[dust].position.Y = projectile.Center.Y + (float)Main.rand.Next(-2, 3);
			Main.dust[dust].noGravity = true;

		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}
	}
}