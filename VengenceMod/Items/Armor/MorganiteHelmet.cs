using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace VengenceMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MorganiteHelmet : ModItem
	{
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<MorganiteBreastPlate>() && legs.type == ItemType<MorganiteGreaves>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RefinedMorganite>(), 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}