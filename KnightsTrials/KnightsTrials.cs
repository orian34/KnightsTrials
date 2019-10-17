using System;
using System.Reflection;
using GlobalEnums;
using Modding;

namespace KnightsTrials
{
    /// <summary>
    /// The main mod class
    /// </summary>
    /// <remarks>This configuration has settings that are save specific</remarks>
    public class KnightsTrials : Mod
    {

        /// <summary>
        /// Represents this Mod's instance.
        /// </summary>
        internal static KnightsTrials Instance;

        /// <summary>
        /// Fetches the Mod Version From AssemblyInfo.AssemblyVersion
        /// </summary>
        /// <returns>Mod's Version</returns>
        public override string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        
        /// <summary>
        /// Called after the class has been constructed.
        /// </summary>
        public override void Initialize()
        {
            //Assign the Instance to the instantiated mod.
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
