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
			dust.rotation += dust.velocity.X * 0.1f;
			dust.scale -= 0.01f;
			if(dust.scale < 0.5f) 
			{
				dust.active = false;
			}
			return false;
		}
	}
}