using Microsoft.Xna.Framework.Audio;
using Terraria.ModLoader;

namespace VengenceMod.Sounds
{
	public class WeaverDeathSound : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan, SoundType type)
		{
			soundInstance = sound.CreateInstance();
            type = SoundType.Music;
			return soundInstance;

		}
	}
}
