using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MysticHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("10% increased magic damage."
			+ "\nImproved night vision");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.defense = 20;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<MysticBreastplate>() && legs.type == ItemType<MysticLeggings>();
		}
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.10f;
			Lighting.brightness += 1.50f;
		}


		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MysticBar>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}