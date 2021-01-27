using Terraria.ID;
using VengenceMod.Items.Placeable;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Meterials
{
	public class VoidBar : ModItem
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
			item.rare = ItemRarityID.Cyan;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<VoidCells>(), 2);
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
