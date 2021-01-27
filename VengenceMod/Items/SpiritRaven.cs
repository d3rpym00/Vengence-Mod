using Terraria.ID;
using VengenceMod.Projectiles;
using VengenceMod.Tiles;
using VengenceMod.Items.Meterials;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class SpiritRaven : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 150;
			item.melee = true;
			item.width = 1000;
			item.height = 1000;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Cyan;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileType<SpiritRavenProjectile>();
			item.shootSpeed = 16f;
			
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<VoidCells>(), 20);
			recipe.AddIngredient(ModContent.ItemType<VoidBar>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}