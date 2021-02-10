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
        int shootDelay = 0;
        int shootCooldown = 2 * 60;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            npc.boss = true;
            npc.width = 78;
            npc.height = 78;
            npc.damage = 40;
            npc.defense = 10;
            npc.lifeMax = 39800;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.scale = 1.5f;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Teratora");
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax += (int)(npc.lifeMax * 0.579f * bossLifeScale);
            npc.damage += (int)(npc.damage * 0.6f);
        }

        public override void AI()
        {
            UpdateValues();
            Track(npc);
        }

        private void UpdateValues()
        {
            theta += (float)Math.PI / 90;
            if (theta > (float)Math.PI * 2)
            {
                theta -= (float)Math.PI * 2;
            }

            if (moveType == 0)
            {
                npc.rotation = 0;
            }

            else
            {
                npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) - 1.57f;
            }
        }

        private void Track(NPC npc)
        {
            npc.position = Main.player[npc.target].Center + new Vector2(-50, -300);
            Shoot(npc);
        }

        private void Shoot(NPC npc)
        {
            shootDelay++;
            if (shootDelay > shootCooldown)
            {
                shootDelay = Main.rand.Next(0, 60);
                if (Main.netMode != 1)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<TripleTeslaBeam>(), (int)(npc.damage / 2), 3, Main.myPlayer);
                }
            }
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<TeslaBar>(), 10);
            if (Main.rand.Next(6) == 0)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<TeslaRifle>(), 1);
            }

            if (Main.rand.Next(6) == 0)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<TeslaStaff>(), 1);
            }
        }
    }
}