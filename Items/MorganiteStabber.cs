using VengenceMod.Items.Meterials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class MorganiteStabber : ModItem
	{
		public override void SetDefaults() {
			item.damage = 18; // The damage your item deals
			item.melee = true; // Whether your item is part of the melee class
			item.width = 40; // The item texture's width
			item.height = 40; // The item texture's height
			item.useTime = 10; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 10; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
			item.knockBack = 6; // The force of knockback of the weapon. Maximum is 20
			item.value = Item.buyPrice(silver: 50); // The value of the weapon in copper coins
			item.rare = ItemRarityID.Green; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
			item.UseSound = SoundID.Item1; // The sound when the weapon is being used
			item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button
			item.crit = 6; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance

			//The useStyle of the item. 
			//Use useStyle 1 for normal swinging or for throwing
			//use useStyle 2 for an item that drinks such as a potion,
			//use useStyle 3 to make the sword act like a shortsword
			//use useStyle 4 for use like a life crystal,
			//and use useStyle 5 for staffs or guns
			item.useStyle = ItemUseStyleID.Stabbing; // 1 is the useStyle
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RefinedMorganite>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
