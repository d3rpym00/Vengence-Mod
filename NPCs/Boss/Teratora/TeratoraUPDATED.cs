using Terraria;
using Terraria.ID;
using Mictosoft.Xna.Framework;
using Terraria.Modloader;
using System;
using VengenceMod.Items.Meterials;

namespace VengenceMod.NPCs.Boss.Teratora
{
    [AutoloadBossHead]
    public class Teratora : ModNPC
    {

    }

    public override void SetDefaults()
    {
        npc.Boss = true;
    }

    public override void ScaleExpertStats()
    {
        npc.lifeMax += (int)(npc.lifeMax * 0.579f * bossLifeScale);
        npc.damage += (int)(npc.damage * 0.6f);
    }

    public override void AI()
    {

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