using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VengenceMod.Dusts
{
	public class VoidDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.color = new Color(188, 49, 131);
			dust.noGravity = true;
			dust.noLight = false;
			dust.frame = new Rectangle(0, 0, 12, 12);
			float light = 0.35f * dust.scale;
			Lighting.AddLight(dust.position, (2.55f * 0.5f * light), (2.55f * 0.5f * light), (2.55f * 0.5f * light));
		}

		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.scale -= 0.01f;
			int oldAlpha = dust.alpha;
			dust.alpha = (int)(dust.alpha * 1.2);

			if (dust.alpha == oldAlpha)
			{
				dust.alpha++;
			}
			if (dust.alpha >= 35)
			{
				dust.alpha = 35;
				dust.active = true;
			}

			return false;
		}
	}
}