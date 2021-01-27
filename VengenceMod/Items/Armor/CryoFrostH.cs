using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using VengenceMod.Tiles;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CryoFrostH : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("10% increased Ranged and Throwing damage.");
			DisplayName.SetDefault("Cryo Frost Helmet");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.LightRed;
			item.defense = 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<CryoFrostB>() && legs.type == ItemType<CryoFrostL>();
		}
		public override void UpdateEquip(Player player)
		{
			player.thrownDamage += 0.10f;
			player.rangedDamage += 0.10f;
		}


		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ArcticBar>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}