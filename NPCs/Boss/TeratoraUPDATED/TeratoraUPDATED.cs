using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System;
using VengenceMod.Items.Meterials;
using VengenceMod.Items;

namespace VengenceMod.NPCs.Boss.TeratoraUPDATED
{
    [AutoloadBossHead]
    public class TeratoraUPDATED : ModNPC
    {
        float theta = 0;
        int moveType = 0;
        
        public override void SetDefaults()
        {
            npc.boss = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax += (int)(npc.lifeMax * 0.579f * bossLifeScale);
            npc.damage += (int)(npc.damage * 0.6f);
        }

        public override void AI()
        {
            UpdateValues();
            Teleport(npc);
        }

        private void UpdateValues()
        {
            theta += (float)Math.PI / 90;
            if (theta > (float)Math.PI * 2)
                theta -= (float)Math.PI * 2;
            if (moveType == 0)
                npc.rotation = 0;
            else
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
        }

        private void Teleport(NPC npc)
        {
            npc.position.X = Main.player[npc.target].position.X;
            npc.position.Y = Main.player[npc.target].position.Y + 100;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TeslaBar>(), 10);
            if (Main.rand.Next(6) == 0)
                Item.NewItem(npc.getRect(), ModContent.ItemType<TeslaRifle>(), 1);
            if (Main.rand.Next(6) == 0)
                Item.NewItem(npc.getRect(), ModContent.ItemType<TeslaStaff>(), 1);
        }
    }
}