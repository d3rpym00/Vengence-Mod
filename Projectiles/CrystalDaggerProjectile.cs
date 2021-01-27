using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VengenceMod.Projectiles
{
	public class CrystalDaggerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystallized Dagger");
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.penetrate = 1;
			projectile.timeLeft = 180;
			projectile.friendly = true;
			projectile.thrown = true;
			aiType = ProjectileID.ThrowingKnife;
		}
	}
}