using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using VengenceMod.Tiles;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CosmicGuardianMelee : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("50% increased Melee damage." + "\n+100 max life");
			DisplayName.SetDefault("Cosmic Guardian Mask");
		}
		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = ItemRarityID.Purple;
			item.defense = 80;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<CosmicGuardianB>() && legs.type == ItemType<CosmicGuardianL>();
		}
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.50f;
			player.statLifeMax2 += 100;
		}


		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<CosmicBar>(), 20);
			recipe.AddTile(TileType<CelestialCrucible>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}