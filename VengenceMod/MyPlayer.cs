using VengenceMod.Dusts;
using VengenceMod.Items;
using VengenceMod.NPCs.Boss;
using VengenceMod.NPCs;
using VengenceMod.NPCs.Boss.VoidWorm;
using VengenceMod.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod
{
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class MyPlayer : ModPlayer
	{
		public bool VoidFlames;
		public bool VoidFlamesI;

		public override void ResetEffects() {
			VoidFlames = false;
			VoidFlamesI = false;
		}
		public override void UpdateDead() {
			VoidFlames = false;

		}
	}
}