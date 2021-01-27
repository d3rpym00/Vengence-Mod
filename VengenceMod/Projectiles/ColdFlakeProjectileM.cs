using VengenceMod.Items;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Projectiles
{
	public class ColdFlakeProjectileM : ModProjectile
	{

		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.hide = true;
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
		}
	}
}
