using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace VengenceMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class MysticHelmet : ModItem
	{

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

	
		/* Here are the individual weapon class bonuses.
		player.meleeDamage -= 0.2f;
		player.thrownDamage -= 0.2f;
		player.rangedDamage -= 0.2f;
		player.magicDamage -= 0.2f;
		player.minionDamage -= 0.2f;
		*/
	

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MysticBar>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}