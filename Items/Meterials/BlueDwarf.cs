using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Meterials
{
	public class BlueDwarf : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Blue Dwarf Star");
			Tooltip.SetDefault("A piece of a blue dwarf fallen from the cosmos.");
			// ticksperframe, frameCount
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		// TODO -- Velocity Y smaller, post NewItem?
		public override void SetDefaults() {
			item.width = 24;
			item.height = 24;
			item.maxStack = 999;
			item.value = 1000;
			item.rare = ItemRarityID.Purple;
		}

		// The following 2 methods are purely to show off these 2 hooks. Don't use them in your own code.
		public override void GrabRange(Player player, ref int grabRange) {
			grabRange *= 3;
		}

		public override bool GrabStyle(Player player) {
			Vector2 vectorItemToPlayer = player.Center - item.Center;
			Vector2 movement = -vectorItemToPlayer.SafeNormalize(default(Vector2)) * 0.1f;
			item.velocity = item.velocity + movement;
			item.velocity = Collision.TileCollision(item.position, item.velocity, item.width, item.height);
			return true;
		}

		public override void PostUpdate() {
			Lighting.AddLight(item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
		}
	}
}