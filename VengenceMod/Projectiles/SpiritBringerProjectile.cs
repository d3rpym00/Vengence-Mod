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
    }
}

// https://www.youtube.com/watch?v=R7korB9hcp8 <-- tutorial for creating a projectile