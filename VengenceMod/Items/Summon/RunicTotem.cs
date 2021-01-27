using VengenceMod.NPCs.Boss.TimeWeaver;
using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.Summon
{
	//imported from my tAPI mod because I'm lazy
	public class RunicTotem : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Runic Totem");
			Tooltip.SetDefault("Summons Time Weaver.");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13; // This helps sort inventory know this is a boss summoning item.
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 28;
			item.maxStack = 1;
			item.rare = ItemRarityID.Red;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = ItemUseStyleID.HoldingUp;
			item.UseSound = SoundID.Item44;
			item.consumable = false;
		}

		// We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
		public override bool CanUseItem(Player player) {
			// "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
			return NPC.downedAncientCultist && player.ZoneOverworldHeight && !NPC.AnyNPCs(NPCType<NPCs.Boss.TimeWeaver.TimeWeaverHead>());
		}

		public override bool UseItem(Player player) {
			NPC.SpawnOnPlayer(player.whoAmI, NPCType<NPCs.Boss.TimeWeaver.TimeWeaverHead>());
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<VividBar>(), 5);
			recipe.AddIngredient(ModContent.ItemType<VoidBar>(), 5);
			recipe.AddIngredient(ModContent.ItemType<RunicShard>(), 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}