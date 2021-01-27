using VengenceMod.NPCs.Boss.Teratora;
using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Summon
{
	//imported from my tAPI mod because I'm lazy
	public class TeslaCapusle : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Tesla Capusle");
			Tooltip.SetDefault("Summons a very powerful being."
			+ "Summons Teratora");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 28;
			item.maxStack = 20;
			item.rare = ItemRarityID.Lime;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = false;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		public override bool CanUseItem(Player player) {
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return NPC.downedPlantBoss && player.ZoneOverworldHeight && !NPC.AnyNPCs(NPCType<NPCs.Boss.Teratora.Teratora>());
		}

		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.Boss.Teratora.Teratora>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod); 
			recipe.AddIngredient(1006, 10);
			recipe.AddIngredient(ModContent.ItemType<BlitzBar>(), 30);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}