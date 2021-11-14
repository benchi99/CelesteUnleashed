using Celeste;
using Celeste.Mod;
using System;

namespace CelesteUnleashed
{
    public class UnleashedModule : EverestModule
    {
        public static UnleashedModule Instance;
        private readonly static Random Random = new Random();

        private readonly static string[] JUMP_SFX =
        {
            "event:/benchi99/jump1",
            "event:/benchi99/jump2",
            "event:/benchi99/jump3"
        };

        private readonly static string[] DASH_SFX =
        {
            "event:/benchi99/dash1",
            "event:/benchi99/dash2"
        };

        public UnleashedModule()
        {
            Instance = this;
        }

        public override void Load()
        {
            On.Celeste.Player.Jump += OnPlayerJump;
            On.Celeste.Player.DashBegin += OnDashBegin;
        }

        public override void Unload()
        {
            On.Celeste.Player.Jump -= OnPlayerJump;
            On.Celeste.Player.DashBegin -= OnDashBegin;
        }

        private void OnPlayerJump(On.Celeste.Player.orig_Jump orig, Celeste.Player self, bool particles, bool playSfx)
        {
            Audio.Play(GetRandomAudioID(JUMP_SFX));
            orig(self, particles, false);
        }

        private void OnDashBegin(On.Celeste.Player.orig_DashBegin orig, Player self)
        {
            Audio.Play(GetRandomAudioID(DASH_SFX));
            orig(self);
        }

        private static string GetRandomAudioID(string[] audioIDs)
        {
            return audioIDs[Random.Next(0, audioIDs.Length)];
        }
    }
}
