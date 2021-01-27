using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VengenceMod.Items.Meterials;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.NPCs.Hostile
{
    public class BigPinky : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Big Pinky");
            Main.npcFrameCount[npc.type] = 2;

        }
        public override void SetDefaults()
        {

            npc.aiStyle = 1; //Slime AI, i would like to know king slimes AI but this works just the same.
            npc.lifeMax = 50;
            npc.damage = 15;
            npc.defense = 0;
            npc.knockBackResist = 0;
            npc.width = 40;
            npc.height = 30;
            animationType = NPCID.GreenSlime;
            aiType = NPCID.GreenSlime; //AI type
            npc.lavaImmune = false;
            npc.noGravity = false;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.netAlways = true;
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemType<PinkGoo>(), 5);
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneOverworldHeight ? 0.10f : 0f;
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
class BigPinky : GlobalNPC
{
    public override void NPCLoot(NPC npc)
    {
        if (npc.type == NPCID.GreenSlime)
        {
            if (Main.rand.Next(5) == 0)
                Item.NewItem(npc.getRect(), ItemType<PinkGoo>(), 2);
        }
    }
}

