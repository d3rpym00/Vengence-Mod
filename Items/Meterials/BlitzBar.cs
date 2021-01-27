using Terraria.ID;
using Terraria.ModLoader;
using VengenceMod.Items.Placeable;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Meterials
{
	public class BlitzBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			ItemID.Sets.SortingPriorityMaterials[item.type] = 59;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 99;
			item.value = 750;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.rare = ItemRarityID.Lime;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<BlitzOre>(), 5);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
