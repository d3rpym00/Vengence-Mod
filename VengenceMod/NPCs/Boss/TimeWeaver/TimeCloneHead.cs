using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VengenceMod.NPCs.Boss.TimeWeaver
{
	[AutoloadBossHead]
	public class TimeCloneHead : ModNPC
	{
		public bool halfLife = false;
		public bool fifthofLife = false;
		int timer = 20;
		public bool flies = true;
		public bool directional = false;
		public float speed = 12f;
		public float turnSpeed = 0.24f;
		public bool tail = false;
		public int minLength = 46;
		public int midLength = 48;
		public int maxLength = 49;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Time Weaver's Clone");
		}

		public override void SetDefaults()
		{
			npc.dontTakeDamage = true;
			npc.damage = 0;
			npc.npcSlots = 20f;
			npc.width = 70; //324
			npc.height = 64; //216
			npc.defense = 0;
			npc.lifeMax = 900000; //250000 //new
			Main.npcFrameCount[npc.type] = 1; //new //new
			animationType = 10; //new
			npc.knockBackResist = 0f;
			npc.boss = true;
			npc.value = 40000;
			npc.alpha = 255;
			npc.behindTiles = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.netAlways = true;
			music = MusicID.Boss3;
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
		}
		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) {
			return false;
		}
		
		int attackTimer;
		bool charge;
		int shootCD = 0;
		
		public override void AI()
		{
			npc.TargetClosest(true);
			npc.velocity = npc.velocity*(1f);
			Player player = Main.player[npc.target];
			
			for (int i = 0; i < Main.maxNPCs; i++)
            {if (Main.npc[i].type == mod.NPCType("TimeWeaverHead") && !Main.npc[i].active) npc.active = false;}
			
			timer++;
			if ((timer == 100 || timer == 400) && npc.life > npc.lifeMax * .2f)
			{
				Main.PlaySound(SoundID.Item, (int)npc.position.X, (int)npc.position.Y, 91);
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction.X *= 2.5f;
				direction.Y *= 2.5f;

				int amountOfProjectiles = 1;
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
					float A = (float)Main.rand.Next(-200, 200) * 0.05f;
					float B = (float)Main.rand.Next(-200, 200) * 0.05f;
					int damage = Main.expertMode ? 18 : 25;
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("LightBallLaser"), damage, 0, Main.myPlayer, 0, 0);
				}
			}
			if (timer == 600)
			{
				if (npc.life <= 5000 && npc.life > npc.lifeMax * .2f && npc.life < npc.lifeMax * .7f)
				{
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction.X *= 2.5f;
				direction.Y *= 2.5f;
				int damage = Main.expertMode ? 18 : 25;
					for (int i = 0; i < 2; i++)
					{
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("LightBallLaser"), damage, 0, Main.myPlayer, 0, 0);
					}
				}
			}
			if (timer == 700)timer = 0;
			attackTimer++;
			if (npc.life <= npc.lifeMax * .5f && halfLife == false)
			{
				//CombatText.NewText(new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height), new Color(255, 155, 0, 100),"Instability Detected");
				halfLife = true;
			}
			if (npc.life <= npc.lifeMax * .2f && fifthofLife == false) 
			{
				fifthofLife = true;
			}
			
			if (npc.life <= npc.lifeMax)
			{
				npc.aiStyle = 6; //new
				aiType = -1;
				
				
				if (attackTimer >= 400 && attackTimer <= 800)
				{
					charge = true;
				}
				else if (attackTimer >= 800)
				{
					charge = false;
					//attackTimer = 0;
				}
				if (attackTimer == 2000) attackTimer = 0;
				
				Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0f, 0.075f, 0.25f);
				if (npc.ai[3] > 0f)
					npc.realLife = (int)npc.ai[3];

				npc.velocity.Length();
				if (npc.alpha != 0)
				{
					for (int num934 = 0; num934 < 2; num934++)
					{
						int num935 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 226, 0f, 0f, 100, Color.Purple, 2f);
						Main.dust[num935].noGravity = true;
						Main.dust[num935].noLight = true;
					}
				}
				npc.alpha -= 12;
				if (npc.alpha < 0)
					npc.alpha = 0;

				if (Main.netMode != NetmodeID.MultiplayerClient)
				{
					if (!tail && npc.ai[0] == 0f)
					{

						int after = npc.whoAmI;
						for (int num36 = 0; num36 < maxLength; num36++)
						{
							int before;
							if (num36 >= 0 && num36 < minLength)
								before = NPC.NewNPC((int)npc.position.X + (npc.width / 1), (int)npc.position.Y + (npc.height / 1), mod.NPCType("TimeCloneBody"), npc.whoAmI);
							else if (num36 >= minLength && num36 < midLength)
								before = NPC.NewNPC((int)npc.position.X + (npc.width / 1), (int)npc.position.Y + (npc.height / 1), mod.NPCType("TimeCloneBody2"), npc.whoAmI);
							else
								before = NPC.NewNPC((int)npc.position.X + (npc.width / 1), (int)npc.position.Y + (npc.height / 1), mod.NPCType("TimeCloneTail"), npc.whoAmI);

							Main.npc[before].realLife = npc.whoAmI;
							Main.npc[before].ai[2] = npc.whoAmI;
							Main.npc[before].ai[1] = after;
							Main.npc[after].ai[0] = before;
							npc.netUpdate = true;
							after = before;
						}
						tail = true;
					}
					if (!npc.active && Main.netMode == NetmodeID.Server)
						NetMessage.SendData(MessageID.StrikeNPC, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
				}

				int num180 = (int)(npc.position.X / 16f) - 1;
				int num181 = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
				int num182 = (int)(npc.position.Y / 16f) - 1;
				int num183 = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
				if (num180 < 0)
					num180 = 0;

				if (num181 > Main.maxTilesX)
					num181 = Main.maxTilesX;

				if (num182 < 0)
					num182 = 0;

				if (num183 > Main.maxTilesY)
					num183 = Main.maxTilesY;

				bool flag94 = flies;
				npc.localAI[1] = 0f;
				if (directional)
				{
					if (npc.velocity.X < 0f)
						npc.spriteDirection = 1;

					else if (npc.velocity.X > 0f)
						npc.spriteDirection = -1;
				}
				if (player.dead)
				{

					npc.TargetClosest(false);
					flag94 = false;
					npc.velocity.Y = npc.velocity.Y + 10f;
					if ((double)npc.position.Y > Main.worldSurface * 16.0)
						npc.velocity.Y = npc.velocity.Y + 10f;

					if ((double)npc.position.Y > Main.rockLayer * 16.0)
					{
						for (int num957 = 0; num957 < 200; num957++)
						{
							if (Main.npc[num957].aiStyle == npc.aiStyle)
								Main.npc[num957].active = false;
						}
					}
				}
				Vector2 value = npc.Center + (npc.rotation - 1.57079637f).ToRotationVector2() * 8f;
				Vector2 value2 = npc.rotation.ToRotationVector2() * 16f;
				Dust dust = Main.dust[Dust.NewDust(value + value2, 0, 0, 226, npc.velocity.X, npc.velocity.Y, 100, Color.Transparent, 0.5f + Main.rand.NextFloat() * 1.5f)];
				dust.noGravity = true;
				dust.noLight = true;
				dust.position -= new Vector2(2f); //4
				dust.fadeIn = 1f;
				dust.scale *= .6f;
				dust.velocity = Vector2.Zero;
				dust = Main.dust[Dust.NewDust(value - value2, 0, 0, 226, npc.velocity.X, npc.velocity.Y, 100, Color.Transparent, 0.5f + Main.rand.NextFloat() * 1.5f)];
				dust.noGravity = true;
				dust.noLight = true;
				dust.position -= new Vector2(2f); //4
				dust.fadeIn = 1f;
				dust.velocity = Vector2.Zero;
				float num188 = speed;
				float num189 = turnSpeed;
				Vector2 vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float num191 = player.position.X + (float)(player.width / 2);
				float num192 = player.position.Y + (float)(player.height / 2);
				int num42 = -1;
				int num43 = (int)(player.Center.X / 16f);
				int num44 = (int)(player.Center.Y / 16f);
				for (int num45 = num43 - 2; num45 <= num43 + 2; num45++)
				{
					for (int num46 = num44; num46 <= num44 + 15; num46++)
					{
						if (WorldGen.SolidTile2(num45, num46))
						{
							num42 = num46;
							break;
						}
					}
					if (num42 > 0)
						break;
				}
				if (num42 > 0)
				{
					npc.defense = 15;
					num42 *= 16;
					float num47 = (float)(num42 - 560); //was 800
					if (player.position.Y > num47 && !charge)
					{
						num192 = num47;
						if (Math.Abs(npc.Center.X - player.Center.X) < 170f) //was 500
						{
							if (npc.velocity.X > 0f)
								num191 = player.Center.X + 170f; //was 600
							else
								num191 = player.Center.X - 170f; //was 600
						}
					}
					else if (charge && player.position.Y < num47)
					{
						num192 = num47;
						if (Math.Abs(npc.Center.X - player.Center.X) < 450f) //was 500
						{
							if (npc.velocity.X > 0f)
								num191 = player.Center.X + 450f; //was 600
							else
								num191 = player.Center.X - 450f; //was 600
						}
					}
				}
				else
				{
					npc.defense = 0;
					num188 = Main.expertMode ? 12.5f : 10f; //added 2.5
					num189 = Main.expertMode ? 0.25f : 0.2f; //added 0.05
				}
				float num48 = num188 * 1.23f;
				float num49 = num188 * 0.7f;
				float num50 = npc.velocity.Length();
				if (num50 > 0f)
				{
					if (num50 > num48)
					{
						npc.velocity.Normalize();
						npc.velocity *= num48;
					}
					else if (num50 < num49)
					{
						npc.velocity.Normalize();
						npc.velocity *= num49;
					}
				}
				if (num42 > 0)
				{
					for (int num51 = 0; num51 < 200; num51++)
					{
						if (Main.npc[num51].active && Main.npc[num51].type == npc.type && num51 != npc.whoAmI)
						{
							Vector2 vector3 = Main.npc[num51].Center - npc.Center;
							if (vector3.Length() < 200f)
							{
								vector3.Normalize();
								vector3 *= 1000f;
								num191 -= vector3.X;
								num192 -= vector3.Y;
							}
						}
					}
				}
				else
				{
					for (int num52 = 0; num52 < 200; num52++)
					{
						if (Main.npc[num52].active && Main.npc[num52].type == npc.type && num52 != npc.whoAmI)
						{
							Vector2 vector4 = Main.npc[num52].Center - npc.Center;
							if (vector4.Length() < 60f)
							{
								vector4.Normalize();
								vector4 *= 200f;
								num191 -= vector4.X;
								num192 -= vector4.Y;
							}
						}
					}
				}
				num191 = (float)((int)(num191 / 16f) * 16);
				num192 = (float)((int)(num192 / 16f) * 16);
				vector18.X = (float)((int)(vector18.X / 16f) * 16);
				vector18.Y = (float)((int)(vector18.Y / 16f) * 16);
				num191 -= vector18.X;
				num192 -= vector18.Y;
				float num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
				if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
				{
					try
					{
						vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
						num191 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector18.X;
						num192 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector18.Y;
					}
					catch
					{
					}
					npc.rotation = (float)Math.Atan2(num192, num191) + 1.57f;
					num193 = (float)Math.Sqrt(num191 * num191 + num192 * num192);
					int num194 = npc.width;
					num193 = (num193 - num194) / num193;
					num191 *= num193;
					num192 *= num193;
					npc.velocity = Vector2.Zero;
					npc.position.X = npc.position.X + num191;
					npc.position.Y = npc.position.Y + num192;
					if (directional)
					{
						if (num191 < 0f)
							npc.spriteDirection = 1;

						if (num191 > 0f)
							npc.spriteDirection = -1;
					}
				}
				else
				{
					num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
					float num196 = System.Math.Abs(num191);
					float num197 = System.Math.Abs(num192);
					float num198 = num188 / num193;
					num191 *= num198;
					num192 *= num198;
					bool flag21 = false;
					if (!flag21)
					{
						if ((npc.velocity.X > 0f && num191 > 0f) || (npc.velocity.X < 0f && num191 < 0f) || (npc.velocity.Y > 0f && num192 > 0f) || (npc.velocity.Y < 0f && num192 < 0f))
						{
							if (npc.velocity.X < num191)
								npc.velocity.X = npc.velocity.X + num189;
							else
							{
								if (npc.velocity.X > num191)
									npc.velocity.X = npc.velocity.X - num189;
							}

							if (npc.velocity.Y < num192)
								npc.velocity.Y = npc.velocity.Y + num189;
							else
							{
								if (npc.velocity.Y > num192)
								{
									npc.velocity.Y = npc.velocity.Y - num189;
								}
							}

							if ((double)System.Math.Abs(num192) < (double)num188 * 0.2 && ((npc.velocity.X > 0f && num191 < 0f) || (npc.velocity.X < 0f && num191 > 0f)))
							{
								if (npc.velocity.Y > 0f)
									npc.velocity.Y = npc.velocity.Y + num189 * 2f;
								else
									npc.velocity.Y = npc.velocity.Y - num189 * 2f;
							}
							if ((double)System.Math.Abs(num191) < (double)num188 * 0.2 && ((npc.velocity.Y > 0f && num192 < 0f) || (npc.velocity.Y < 0f && num192 > 0f)))
							{
								if (npc.velocity.X > 0f)
									npc.velocity.X = npc.velocity.X + num189 * 2f; //changed from 2
								else
									npc.velocity.X = npc.velocity.X - num189 * 2f; //changed from 2
							}
						}
						else
						{
							if (num196 > num197)
							{
								if (npc.velocity.X < num191)
									npc.velocity.X = npc.velocity.X + num189 * 1.1f; //changed from 1.1
								else if (npc.velocity.X > num191)
									npc.velocity.X = npc.velocity.X - num189 * 1.1f; //changed from 1.1

								if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.5)
								{
									if (npc.velocity.Y > 0f)
										npc.velocity.Y = npc.velocity.Y + num189;
									else
										npc.velocity.Y = npc.velocity.Y - num189;
								}
							}
							else
							{
								if (npc.velocity.Y < num192)
									npc.velocity.Y = npc.velocity.Y + num189 * 1.1f;
								else if (npc.velocity.Y > num192)
									npc.velocity.Y = npc.velocity.Y - num189 * 1.1f;
								if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.5)
								{
									if (npc.velocity.X > 0f)
										npc.velocity.X = npc.velocity.X + num189;
									else
										npc.velocity.X = npc.velocity.X - num189;
								}
							}
						}
					}
				}
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 226, hitDirection, -1f, 0, Color.Purple, 1f);
			}
			if (npc.life <= 0)
			{
				npc.active = false;
			}
		}
		
	}
}