using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VengenceMod.Items.Meterials;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.NPCs.Boss.MegaPinky
{
    [AutoloadBossHead]
    public class MegaPinky : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Pinky");
            Main.npcFrameCount[npc.type] = 6;

        }
        public override void SetDefaults()
        {

            npc.aiStyle = 1; // Slime AI, i would like to know king slimes AI but this works just the same.
            npc.lifeMax = 3500;
            npc.damage = 15;
            npc.defense = 0;
            npc.knockBackResist = 0;
            npc.width = 162;
            npc.height = 126;
            animationType = NPCID.KingSlime;
            aiType = NPCID.KingSlime; //AI type
            npc.npcSlots = 1f;
            npc.boss = true;
            npc.lavaImmune = false;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.netAlways = true;
            music = MusicID.Boss1;
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.LesserHealingPotion;
            Item.NewItem(npc.getRect(), ItemType<PinkGoo>(), 30);

        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax += (int)(npc.lifeMax * 0.579f * bossLifeScale);
            npc.damage += (int)(npc.damage * 0.6f);
        }
        public override void AI()
        {
            npc.ai[0]++;
            Player player = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
            npc.netUpdate = true;

        }
    }
}
class MegaPinky : GlobalNPC
{
    public override void NPCLoot(NPC npc)
    {
        if (npc.type == NPCID.Pinky)
        {
            if (Main.rand.Next(5) == 0)
                Item.NewItem(npc.getRect(), ModContent.ItemType<PinkGoo>(), 1);
        }
    }
}

