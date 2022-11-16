using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace YC_powers
{
    internal class Config : ModConfig
    {
        public static Config Instance;

        public override ConfigScope Mode => ConfigScope.ClientSide;

        public override void OnLoaded()
        {
            Instance = this;
        }

        [DefaultValue(true)]
        [Label("Reduce incoming damage")]
        public bool ReduceDamage;

        [DefaultValue(true)]
        [Label("Taking damage increases player power")]
        public bool ConvertDamage;

        [DefaultValue(true)]
        [Label("Fishing rods auto spam blobs")]
        public bool FishingSpamming;

        [DefaultValue(true)]
        [Label("Fishing rods auto collect")]
        public bool FishingCollect;

        [DefaultValue(true)]
        public bool ShortRespawnTimer;
    }
}
