using Terraria.ID;
using VengenceMod.Projectiles;
using VengenceMod.Tiles;
using VengenceMod.Items.Meterials;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
    public class SpiritBringer : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 300;
            item.melee = true;
            item.width = 1200;
            item.height = 1200;
            item.useTime = 18;
            item.useAnimation = 18;
            item.useStyle = 1;
            item.knockBack = 9;
            item.value = 90000;
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = ProjectileType<SpiritBringerProjectile>();
            item.shootSpeed = 18f;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1508, 50); // Ectoplasm (uses tile_id from wiki)
            recipe.AddIngredient(3467, 20); // Luminite 
            recipe.AddIngredient(ModContent.ItemType<BlueDwarf>(), 10);
            recipe.AddIngredient(ModContent.ItemType<SpiritRaven>(), 1);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
