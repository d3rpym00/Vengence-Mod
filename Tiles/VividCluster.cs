using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using VengenceMod.Items.Placeable;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Tiles
{
	public class VividCluster : ModTile
	{
		public override void SetDefaults()
		{
			TileID.Sets.Ore[Type] = true;
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 410; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileMergeDirt[Type] = true;
			Main.tileSolid[Type] = true;
			Main.tileBlockLight[Type] = true;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Vivid Cluster");
			AddMapEntry(new Color(185, 191, 251), name);

			dustType = 84;
			drop = ItemType<Items.Placeable.VividCluster>();
			soundType = SoundID.Tink;
			soundStyle = 1;
			mineResist = 9f;
			minPick = 200;
		}
	}
}