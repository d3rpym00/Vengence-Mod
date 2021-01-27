using Terraria.ID;
using VengenceMod.Dusts;
using VengenceMod.Projectiles;
using Terraria.ModLoader;
using VengenceMod.Items.Meterials;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class GreatGallent : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Who cant handle EVEN MORE light like this?." +
                "Fires bouncing 3 light spheres that explode in minutes." + " A proud thanks for Gold GoldFish for help with this sprite!");
		}

		public override void SetDefaults() 
		{
			item.damage = 200;
			item.melee = true;
			item.width = 1000;
			item.height = 1000;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Purple;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shootSpeed = 20f;
			item.shoot = ProjectileType<GreatGallentBeamBlu>();
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Gallent>(), 1);
			recipe.AddIngredient(ModContent.ItemType<VoidCells>(), 10);
			recipe.AddIngredient(1570, 1);
			recipe.AddIngredient(1570, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}