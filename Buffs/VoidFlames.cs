using VengenceMod.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace VengenceMod.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class VoidFlames : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Void Flames");
			Description.SetDefault("Losing life");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<MyPlayer>().VoidFlames = true;
		}
	}
}
