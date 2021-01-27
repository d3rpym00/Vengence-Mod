using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VengenceMod.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VengenceMod.Projectiles
{
	public class StellarStarspinProjectile : ModProjectile
	{
		private const float Radius = 100f;


		private bool spawnedAura;

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("StellarStarspin");
			ProjectileID.Sets.YoyosLifeTimeMultiplier[base.projectile.type] = -1f;
			ProjectileID.Sets.YoyosMaximumRange[base.projectile.type] = 450f;
			ProjectileID.Sets.YoyosTopSpeed[base.projectile.type] = 14f;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			base.projectile.aiStyle = 99;
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = -1;
			base.projectile.MaxUpdates = 2;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 10;
		}

		public override void AI()
		{
			if (base.projectile.owner == Main.myPlayer && !spawnedAura)
			{
				Projectile.NewProjectile(base.projectile.Center, Vector2.Zero, ModContent.ProjectileType<ZodiacRing>(), (int)((double)base.projectile.damage * 0.35), base.projectile.knockBack, base.projectile.owner, base.projectile.identity);
				spawnedAura = true;
			}
			int numDust = 125;
			float angleIncrement = (float)Math.PI * 2f / (float)numDust;
			Vector2 dustOffset = new Vector2(100f, 0f);
			dustOffset = dustOffset.RotatedByRandom(6.2831854820251465);
			for (int i = 0; i < numDust; i++)
			{
				dustOffset = dustOffset.RotatedBy(angleIncrement);
				int dustType = Utils.SelectRandom<int>(Main.rand, ModContent.DustType<CosmicPurpleDust>(), ModContent.DustType<CosmicPinkDust>());
				int dust = Dust.NewDust(base.projectile.Center, 1, 1, dustType);
				Main.dust[dust].position = base.projectile.Center + dustOffset;
				Main.dust[dust].fadeIn = 1f;
				Main.dust[dust].velocity *= 0.2f;
				Main.dust[dust].scale = 0.16f;
			}
			if ((base.projectile.position - Main.player[base.projectile.owner].position).Length() > 3200f)
			{
				base.projectile.Kill();
			}
		}
	}
}
