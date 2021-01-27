using VengenceMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Projectiles
{
	public class SpiritBringerProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Bringer Fire");
        }

        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 15;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.aiStyle = -1;
            projectile.tileCollide = true;
        }

        public override void AI()
        {
            float velXMult = 0.25f;
            projectile.velocity.X += velXMult;

            float velYMult = 0.25f;
            projectile.velocity.Y += velYMult;
        }
    }
}
