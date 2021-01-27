using Terraria.ID;
using VengenceMod.Dusts;
using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class Gallent : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("Gallent"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Who cant handle light like this?." +
                "Fires bouncing light Beams that explode in minutes");
		}

		public override void SetDefaults() 
		{
			item.damage = 75;
			item.melee = true;
			item.width = 1000;
			item.height = 1000;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileType<GallentBeam>();
			item.shootSpeed = 16f;
			
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ArcticBar>(), 20);
			recipe.AddIngredient(ModContent.ItemType<MysticBar>(), 10);
			recipe.AddIngredient(ModContent.ItemType<BlitzBar>(), 15);
			recipe.AddIngredient(548, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}