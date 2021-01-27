using VengenceMod.Items.Meterials;
using VengenceMod.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class BlitzBlaster : ModItem
	{

		public override void SetDefaults() {
			item.damage = 40;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
			item.value = 20000;
			item.rare = ItemRarityID.Lime;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 20f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.OnyxBlaster, 1);
			recipe.AddIngredient(521, 4);
			recipe.AddIngredient(ModContent.ItemType<BlitzBar>(),10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
