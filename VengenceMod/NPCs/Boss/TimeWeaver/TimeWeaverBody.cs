using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VengenceMod.NPCs.Boss.TimeWeaver
{
	public class TimeWeaverBody : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Time Weaver");
		}

		public override void SetDefaults()
		{
			npc.width = 70;
			npc.height = 64;
			npc.damage = 160;
			npc.defense = 75;
			npc.lifeMax = 1;
			npc.knockBackResist = 0.0f;
			npc.behindTiles = true;
			npc.noTileCollide = true;
			npc.netAlways = true;
			npc.noGravity = true;
			npc.dontCountMe = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.npcSlots = 1f;
			npc.boss = true;
			npc.aiStyle = -1;
			npc.alpha = 200;
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
			music = MusicID.Boss3;
			npc.dontCountMe = true;
		}
		bool exposed;
		//int timer;
		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write(exposed);
		}
		public override void ReceiveExtraAI(BinaryReader reader)
		{
			exposed = reader.ReadBoolean();
		}
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
			=> false;
			
			int attackTimer;

		public override bool PreAI()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				npc.localAI[1] += 1;
				if (npc.localAI[1] == Main.rand.Next(100, 500))
				{
					if (!exposed)
					{
						exposed = true;
						npc.netUpdate = true;
					}
				}
				if (npc.localAI[1] >= 651)
				{
					npc.localAI[1] = 0f;
				}
				npc.localAI[2] += 1;
				if (npc.localAI[2] == Main.rand.Next(200, 600))
				{
					if (exposed)
					{
						exposed = false;
						npc.netUpdate = true;
					}
				}
				if (npc.localAI[2] >= 601)
				{
					npc.localAI[2] = 0f;
				}
			}
			if (exposed)
			{
				npc.defense = 8;
				npc.dontTakeDamage = false;
			}
			else
			{
				npc.defense = 9999;
				npc.dontTakeDamage = true;
			}
			Player player = Main.player[npc.target];
			bool expertMode = Main.expertMode;
			Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0f, 0.075f, 0.25f);
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				npc.ai[3]++;
				if (npc.ai[3] >= (float)Main.rand.Next(1400, 7500))
				{
					Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 9);
					npc.ai[3] = 0f;
					npc.TargetClosest(true);
					if (Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height))
					{
						float num941 = 1f; //speed
						Vector2 vector104 = new Vector2(npc.position.X + (float)npc.width * 0.125f, npc.position.Y + (float)(npc.height / 8));
						float num942 = player.position.X + (float)player.width * 0.125f - vector104.X + (float)Main.rand.Next(-20, 21);
						float num943 = player.position.Y + (float)player.height * 0.125f - vector104.Y + (float)Main.rand.Next(-20, 21);
						float num944 = (float)Math.Sqrt((double)(num942 * num942 + num943 * num943));
						num944 = num941 / num944;
						num942 *= num944;
						num943 *= num944;
						num942 += (float)Main.rand.Next(-10, 11) * 0.01f;
						num943 += (float)Main.rand.Next(-10, 11) * 0.01f;
						int num945 = expertMode ? 13 : 25;
						vector104.X += num942 * 4f;
						vector104.Y += num943 * 2.5f;
						npc.netUpdate = true;
					}
				}
			}
			if (!Main.npc[(int)npc.ai[1]].active)
			{
				npc.life = 0;
				npc.HitEffect(0, 10.0);
				npc.active = false;
			}
			if (Main.npc[(int)npc.ai[1]].alpha < 128)
			{
				if (npc.alpha != 0)
				{
					for (int num934 = 0; num934 < 2; num934++)
					{
						int num935 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 226, 0f, 0f, 100, default, 2f);
						Main.dust[num935].noGravity = true;
						Main.dust[num935].noLight = true;
					}
				}
				npc.alpha -= 42;
				if (npc.alpha < 0)
				{
					npc.alpha = 0;
				}
			}
			if (npc.ai[2] > 0)
			{
				npc.realLife = (int)npc.ai[2];
			}

			if (npc.target < 0 || npc.target == byte.MaxValue || Main.player[npc.target].dead)
			{
				npc.TargetClosest(true);
			}

			if (Main.player[npc.target].dead && npc.timeLeft > 300)
			{
				npc.timeLeft = 300;
			}

			if (npc.ai[1] < (double)Main.npc.Length)
			{
				Vector2 npcCenter = new Vector2(npc.position.X + (float)npc.width * 0.0125f, npc.position.Y + (float)npc.height * 0.0125f);

				float dirX = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 100) - npcCenter.X;
				float dirY = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 100) - npcCenter.Y;

				npc.rotation = (float)Math.Atan2(dirY, dirX) + 1.57f;

				float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);

				float dist = (length - (float)npc.width/2) / length;
				float posX = dirX * dist;
				float posY = dirY * dist;

				npc.velocity = Vector2.Zero;
				npc.position.X = npc.position.X + posX;
				npc.position.Y = npc.position.Y + posY;
			}
			attackTimer++;
			
			if(attackTimer >= 1200 && attackTimer <= 1600 || Main.npc[(int)npc.ai[1]].life <= Main.npc[(int)npc.ai[1]].lifeMax*.3f) {
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction.X *= 5f;
				direction.Y *= 5f;
				int damage = Main.expertMode ? 18 : 25;
				for (int i = 0; i < 2; i++)
                {
					if(Main.rand.Next(1000) == 0) {
						Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 12);
					int num947 =Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, 440, damage, 0, Main.myPlayer, 0, 0);
						Main.projectile[num947].timeLeft = 240;
						Main.projectile[num947].ranged = false;
						Main.projectile[num947].hostile = true;
						Main.projectile[num947].friendly = false;
					}
				}
			}
			
			if(attackTimer == 2000) attackTimer = 0;
			
			return true;
		}

		public override bool CheckActive() => false;

		public override bool PreNPCLoot() => false;

		public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{

			var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
							 drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
			return false;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
		{
			if (exposed)
			{
				Color color1 = Lighting.GetColor((int)(npc.position.X + npc.width * 0.5) / 16, (int)((npc.position.Y + npc.height * 0.5) / 16.0));
				Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width * 0.5f, npc.height * 0.5f);
				int r1 = color1.R;
				drawOrigin.Y += 34f;
				drawOrigin.Y += 8f;
				--drawOrigin.X;
				Vector2 position1 = npc.Bottom - Main.screenPosition;
				Texture2D texture2D2 = Main.glowMaskTexture[239];
				float num11 = (float)(Main.GlobalTime % 1.0 / 1.0);
				float num12 = num11;
				if (num12 > 0.5)
					num12 = 1f - num11;
				if (num12 < 0.0)
					num12 = 0.0f;
				float num13 = (float)((num11 + 0.5) % 1.0);
				float num14 = num13;
				if (num14 > 0.5)
					num14 = 1f - num13;
				if (num14 < 0.0)
					num14 = 0.0f;
				Rectangle r2 = texture2D2.Frame(1, 1, 0, 0);
				drawOrigin = r2.Size() / 2f;
				Vector2 position3 = position1 + new Vector2(0.0f, -20f);
				Color color3 = new Color(84, 207, 255) * 1.6f;
				Main.spriteBatch.Draw(texture2D2, position3, new Microsoft.Xna.Framework.Rectangle?(r2), color3, npc.rotation, drawOrigin, npc.scale * 0.5f, SpriteEffects.None ^ SpriteEffects.FlipHorizontally, 0.0f);
				float num15 = 1f + num11 * 0.75f;
				Main.spriteBatch.Draw(texture2D2, position3, new Microsoft.Xna.Framework.Rectangle?(r2), color3 * num12, npc.rotation, drawOrigin, npc.scale * 0.5f * num15, SpriteEffects.None ^ SpriteEffects.FlipHorizontally, 0.0f);
				float num16 = 1f + num13 * 0.75f;
				Main.spriteBatch.Draw(texture2D2, position3, new Microsoft.Xna.Framework.Rectangle?(r2), color3 * num14, npc.rotation, drawOrigin, npc.scale * 0.5f * num16, SpriteEffects.None ^ SpriteEffects.FlipHorizontally, 0.0f);
				Texture2D texture2D3 = Main.extraTexture[89];
				Rectangle r3 = texture2D3.Frame(1, 1, 0, 0);
				drawOrigin = r3.Size() / 2f;
				Vector2 scale = new Vector2(0.75f, 1f + num16) * 1.5f;
				float num17 = 1f + num13 * 0.75f;

			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 226, hitDirection, -1f, 0, default(Color), 1f);
			}
			if (npc.life <= 0)
			{
				Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 4);
				 Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/TimeWeaverGore/TimeWeaverGore3"), 1f);
				for (int num623 = 0; num623 < 20; num623++)
				{
					int dust1 = Dust.NewDust(npc.Center, npc.width, npc.height, 226);

					Main.dust[dust1].velocity *= -1f;
					Main.dust[dust1].noGravity = true;
					Main.dust[dust1].scale *= .8f;
					Vector2 vector2_1 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
					vector2_1.Normalize();
					Vector2 vector2_2 = vector2_1 * (Main.rand.Next(50, 100) * 0.04f);
					Main.dust[dust1].velocity = vector2_2;
					vector2_2.Normalize();
					Vector2 vector2_3 = vector2_2 * 104f;
					Main.dust[dust1].position = (npc.Center) - vector2_3;
				}
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction.X *= 12;
				direction.Y *= -12f;

				int amountOfProjectiles = Main.rand.Next(1, 2);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float A = Main.rand.Next(-150, 150) * 0.01f;
					float B = Main.rand.Next(-80, 0) * 0.0f;
				}
			}
		}
		public override void ModifyHitByProjectile(Terraria.Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (projectile.penetrate <= -1)
			{
				damage /= 3;
			}
			else if (projectile.penetrate >= 3)
			{
				damage /= 3;
			}
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.65f);
		}
	}
}