using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VengenceMod.NPCs.Boss.Teratora
{
    public class TeslaSpiralShot : ModNPC
    {
        float _theta = -1;
        float _dist = 0;
        float _distRate = 1;
        Vector2 _origin;
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tesla Sprial");
        }
        public override void SetDefaults()
        {
            bitherial = true;
            _distRate = 1;
            _dist = 20;
            _theta = -1;
            npc.width = 44;
            npc.height = 44;
            npc.damage = 60;
            npc.defense = 12;
            npc.lifeMax = 4500;
            npc.value = 0f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.buffImmune[24] = true;
            npc.dontTakeDamage = true;
            npc.scale = 1.5f;
        }
        
        public override void OnHitPlayer(Player target, int dmgDealt, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 300, true);
        }
        
        public override void AI()
        {
            if (_theta == -1)
            {
                _theta = npc.ai[1] * 6.28f / 8;
                _origin = npc.position;
            }
            _theta += 3.14f / 120;
            _dist += _distRate;
            _distRate += .05f;
            float divisions = 6.28f / 8;
            Vector2 targetPos;
            targetPos.X = _origin.X + _dist * (float)Math.Cos(_theta) - npc.width / 2;
            targetPos.Y = _origin.Y + _dist * (float)Math.Sin(_theta);
            npc.position = targetPos;
            if(_dist > 1200)
            {
                npc.active = false;
                npc.life = 0;
            }
            npc.rotation = (float)Math.Atan2((double)npc.velocity.Y, (double)npc.velocity.X) + 1.57f / 2;
        }

        public override Color? GetAlpha(Color drawColor)
        {
            int b = 125;
            int b2 = 225;
            int b3 = 255;
            if (drawColor.R != (byte)b)
            {
                drawColor.R = (byte)b;
            }
            if (drawColor.G < (byte)b2)
            {
                drawColor.G = (byte)b2;
            }
            if (drawColor.B < (byte)b3)
            {
                drawColor.B = (byte)b3;
            }
            return drawColor;
        }
    }
}
