using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VengenceMod.Projectiles
{
	public class RunicKnivesProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Runic Knife");
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 10;
			projectile.aiStyle = 1;
			projectile.penetrate = 7;
			projectile.timeLeft = 180;
			projectile.friendly = true;
			projectile.thrown = true;
			aiType = ProjectileID.ThrowingKnife;
		}
	}
}