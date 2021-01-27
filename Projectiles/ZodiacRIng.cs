using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace VengenceMod.Projectiles
{
	public class ZodiacRing : ModProjectile
	{
		private int radius = 100;

		public override string Texture => "VengenceMod/Projectiles/ZodiacRing";

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Zodiac Ring");
		}

		public override void SetDefaults()
		{
			base.projectile.melee = true;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
			base.projectile.width = 200;
			base.projectile.height = 200;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
			base.projectile.alpha = 255;
			base.projectile.ignoreWater = true;
			base.projectile.timeLeft = 300;
		}

		public override void AI()
		{
			Projectile parent = Main.projectile[0];
			bool active = false;
			for (int i = 0; i < Main.projectile.Length; i++)
			{
				Projectile p = Main.projectile[i];
				if ((float)p.identity == base.projectile.ai[0] && p.active && p.type == ModContent.ProjectileType<StellarStarspinProjectile>())
				{
					parent = p;
					active = true;
				}
			}
			if (active)
			{
				base.projectile.Center = parent.Center;
				base.projectile.timeLeft = 2;
			}
			else
			{
				base.projectile.Kill();
			}
			if (!parent.active)
			{
				base.projectile.Kill();
			}
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			float num = Vector2.Distance(base.projectile.Center, targetHitbox.TopLeft());
			float dist2 = Vector2.Distance(base.projectile.Center, targetHitbox.TopRight());
			float dist3 = Vector2.Distance(base.projectile.Center, targetHitbox.BottomLeft());
			float dist4 = Vector2.Distance(base.projectile.Center, targetHitbox.BottomRight());
			float minDist = num;
			if (dist2 < minDist)
			{
				minDist = dist2;
			}
			if (dist3 < minDist)
			{
				minDist = dist3;
			}
			if (dist4 < minDist)
			{
				minDist = dist4;
			}
			return minDist <= (float)radius;
		}
	}
}

