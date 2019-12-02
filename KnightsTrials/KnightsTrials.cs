using System;
using System.Reflection;
using GlobalEnums;
using Modding;

namespace KnightsTrials
{
    public class KnightsTrials : Mod
    {

        internal static KnightsTrials Instance;

        public override string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        
        public override void Initialize()
        {
            Instance = this;

            Log("Initializing");

            On.GameManager.BeginSceneTransition += EditTransition;
            Log("Initialized");
        }

        private static void EditTransition(On.GameManager.orig_BeginSceneTransition orig, GameManager self, GameManager.SceneLoadInfo info)
        {
            if (info.SceneName == "Room_Final_Boss_Core")
            {
                info.SceneName = "Room_Final_Boss_Atrium";
            }
            orig(self, info);
        }

    }

}
