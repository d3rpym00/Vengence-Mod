﻿using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;
using System;
using VengenceMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items.ZodiacYoyos
{
	public class StellarStarspin : ModItem
	{
		public override void SetStaticDefaults() {

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 2.5f;
			item.damage = 1150;
			item.rare = ItemRarityID.Purple;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(platinum: 90);
			item.shoot = ProjectileType<StellarStarspinProjectile>();
		}

		// Make sure that your item can even receive these prefixes (check the vanilla wiki on prefixes)
		// These are the ones that reduce damage of a meee weapon
		private static readonly int[] unwantedPrefixes = new int[] { PrefixID.Terrible, PrefixID.Dull, PrefixID.Shameful, PrefixID.Annoying, PrefixID.Broken, PrefixID.Damaged, PrefixID.Shoddy};

		public override bool AllowPrefix(int pre) {
			// return false to make the game reroll the prefix

			// DON'T DO THIS BY ITSELF:
			// return false;
			// This will get the game stuck because it will try to reroll every time. Instead, make it have a chance to return true

			if (Array.IndexOf(unwantedPrefixes, pre) > -1) {
				// IndexOf returns a positive index of the element you search for. If not found, it's less than 0. Here check the opposite
				// Rolled a prefix we don't want, reroll
				return false;
			}
			// Don't reroll
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<Aries>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Taurus>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Gemini>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Cancer>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Leo>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Virgo>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Libra>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Scorpio>(), 1);
			recipe.AddIngredient(ModContent.ItemType<Sagittarius>(), 1);
			recipe.AddIngredient(ModContent.ItemType<CosmicBar>(), 25);
			recipe.AddIngredient(ModContent.ItemType<BlueDwarf>(), 25);
			recipe.AddTile(TileType<CelestialCrucible>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
