using System;
using Terraria.ModLoader;
using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
    public class MorganitePickaxe : ModItem
    {

        public override void SetDefaults() {
            item.damage = 6;
            item.melee = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 10;
            item.useAnimation = 10;
            item.pick = 45;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 6;
            item.value = 40;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RefinedMorganite>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}