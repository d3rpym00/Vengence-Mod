using VengenceMod.Items;
using VengenceMod.NPCs;
using VengenceMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod
{
	public class MyWorld : ModWorld
	{
		public static bool downedMegaPinky;
		public static bool downedVoidScourge;
		public static bool downedTeratora;
		public static bool downedTimeWeaver;
		public static int VengenceTiles;


		public override void Initialize()
		{
			downedMegaPinky = false;
			downedVoidScourge = false;
			downedTeratora = false;
			downedTimeWeaver = false;
		}
		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedMegaPinky)
			{
				downed.Add("MegaPinky");
			}

			if (downedVoidScourge)
			{
				downed.Add("VoidScourge");
			}

			if (downedTeratora)
			{
				downed.Add("Teratora");
			}

			if (downedTimeWeaver)
			{
				downed.Add("TimeWeaver");
			}

			return new TagCompound
			{
				["downed"] = downed,
			};
		}
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedMegaPinky = downed.Contains("MegaPinky");
			downedVoidScourge = downed.Contains("VoidScourge");
			downedTeratora = downed.Contains("Teratora");
			downedTimeWeaver = downed.Contains("TimeWeaver");
		}

		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedMegaPinky = flags[0];
				downedVoidScourge = flags[1];
				downedTeratora = flags[2];
				downedTimeWeaver = flags[3];
			}
			else
			{
				mod.Logger.WarnFormat("VengenceMod: Unknown loadVersion: {0}", loadVersion);
			}
		}
		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedMegaPinky;
			flags[1] = downedVoidScourge;
			flags[2] = downedTeratora;
			flags[3] = downedTimeWeaver;

			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedMegaPinky = flags[0];
			downedVoidScourge = flags[1];
			downedTeratora = flags[2];
			downedTimeWeaver = flags[3];
		}
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1)
			{
				// Next, we insert our step directly after the original "Shinies" step. 
				// ExampleModOres is a method seen below.
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Vengence Mod Ores", VengenceModOres));



			}
		}
		private void VengenceModOres(GenerationProgress progress)
		{
			// progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
			progress.Message = "Vengence Mod Ores";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
			{
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
																						// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileType<MysticOre>());
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileType<BlitzOre>());
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileType<ArcticOre>());
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileType<CrystallariumShard>());
				// Alternately, we could check the tile already present in the coordinate we are interested. Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
				// Tile tile = Framing.GetTileSafely(x, y);
				// if (tile.active() && tile.type == TileID.SnowBlock)
				// {
				// 	WorldGen.TileRunner(.....);
				// }
			}
		}
	}
}