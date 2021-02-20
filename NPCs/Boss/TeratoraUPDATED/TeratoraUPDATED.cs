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
        int moveType = 0;
        int moveCounter = 0;
        int shootDelay = 0;
        int shootDelay2 = 0;
        int shootCooldown = 2 * 60;
        int shootCooldown2 = 2 * 45;
        Vector2 targetPos;
        public bool killBoss = false;
        public float tVel = 0f;
        public float vel = 0f;
        public float vMax = 10f;
        public float vAccel = 0.2f;
        public float vMag = 0f;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            tVel = 0f;
            vel = 0f;
            vMax = 10f;
            vAccel = 0.2f;
            vMag = 0f;
            killBoss = false;
            moveType = 0;
            moveCounter = 0;
            shootCooldown = 2 * 60;
            shootCooldown2 = 2 * 45;
            shootDelay = 0;
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
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active) 
            {
                npc.TargetClosest();
            }
            
            bool dead = Main.player[npc.target].dead;

            if (dead)
            {
                Death(npc);
                return; 
            }
            
            CheckMoveType();            
            if (moveType == 0)
            {
                Track2(npc);
            }
            else if (moveType == 1)
            {
                Dash(npc);
            }
            else if (moveType == 2)
            {
                Track(npc);
            }
        }

        private void CheckMoveType()
        {
            moveCounter++;
            if (moveCounter > 9 * 60 + 2)
            {
                moveCounter = 0;
                moveType++;
            }

            if (moveType == 3)
            {
                moveType = 0;
            }
        }

        private void Track(NPC npc)
        {
            npc.position = Main.player[npc.target].Center + new Vector2(-50, -300);
            npc.rotation = 0;
            Shoot(npc);
        }

        private void Track2(NPC npc)
        {
            npc.position = Main.player[npc.target].Center + new Vector2(-350, -50);
			// npc.rotation = (float)Math
            Shoot2(npc);
        }

        private void Dash(NPC npc)
        {
            float dist = Vector2.Distance(targetPos, npc.Center);
            tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
                vMag = tVel;
            }

            if (vMag > tVel)
            {
                vMag = tVel;
            }

            if (vMag > vMax)
            {
                vMag = vMax;
            }

            if (dist != 0)
            {
                npc.velocity = npc.DirectionTo(targetPos) * vMag;
            }
        }

        private void Death(NPC npc)
        {
            npc.velocity.Y = -10f;
            
            if (npc.timeLeft > 30)
            {
                npc.timeLeft = 30;
            }
        }

        private void Shoot(NPC npc)
        {
            shootDelay++;
            if (shootDelay > shootCooldown)
            {
                shootDelay = Main.rand.Next(0, 60);
                if (Main.netMode != 1)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, ModContent.ProjectileType<TeslaBeam2>(), (int)(npc.damage / 2), 3, Main.myPlayer);
                }
            }
        }

        private void Shoot2(NPC npc)
        {
            
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