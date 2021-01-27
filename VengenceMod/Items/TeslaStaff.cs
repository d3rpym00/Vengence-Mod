using VengenceMod.Projectiles;
using VengenceMod.Items.Meterials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VengenceMod.Items
{
	public class TeslaStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults() {
			item.damage = 40;
			item.magic = true;
			item.mana = 5;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = ProjectileType<TeslaBullet>();
			item.shootSpeed = 15f;
		}
	}
}