using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace CupheadCreeperMod
{
    [BepInPlugin("petergunbo21.cuphead.creepermod", "Cuphead Creeper Mod", "0.1.0")]
    public class Plugin : BaseUnityPlugin
    {
        private ConfigEntry<KeyCode> menuKey;
        private ConfigEntry<KeyCode> buildKey;
        private ConfigEntry<KeyCode> cycleBlockKey;
        private ConfigEntry<KeyCode> creeperKey;

        private bool menuVisible;
        private bool buildMode;
        private int selectedBlock;
        private float nextCreeperTime;
        private const float CreeperCooldownSeconds = 15f;

        private readonly string[] blockNames = { "Wood", "Stone", "Brick" };

        private void Awake()
        {
            menuKey = Config.Bind("Controls", "MenuKey", KeyCode.F6, "Show or hide the mod menu.");
            buildKey = Config.Bind("Controls", "BuildModeKey", KeyCode.F7, "Toggle build mode.");
            cycleBlockKey = Config.Bind("Controls", "CycleBlockKey", KeyCode.B, "Cycle the selected block type.");
            creeperKey = Config.Bind("Controls", "CreeperKey", KeyCode.G, "Request a Creeper companion.");

            Logger.LogInfo("Cuphead Creeper Mod starter loaded. Gameplay features still need integration.");
        }

        private void Update()
        {
            if (Input.GetKeyDown(menuKey.Value))
                menuVisible = !menuVisible;

            if (Input.GetKeyDown(buildKey.Value))
            {
                buildMode = !buildMode;
                Logger.LogInfo("Build mode " + (buildMode ? "enabled" : "disabled") +
                    ". Solid block placement is not integrated yet.");
            }

            if (Input.GetKeyDown(cycleBlockKey.Value))
            {
                selectedBlock = (selectedBlock + 1) % blockNames.Length;
                Logger.LogInfo("Selected block: " + blockNames[selectedBlock]);
            }

            if (Input.GetKeyDown(creeperKey.Value))
                TryRequestCreeper();
        }

        private void TryRequestCreeper()
        {
            if (Time.time < nextCreeperTime)
            {
                float remaining = nextCreeperTime - Time.time;
                Logger.LogInfo("Creeper cooldown: " + Mathf.CeilToInt(remaining) + " seconds remaining.");
                return;
            }

            nextCreeperTime = Time.time + CreeperCooldownSeconds;
            Logger.LogInfo("Creeper summon requested. Companion spawning and boss targeting are not integrated yet.");
        }

        private void OnGUI()
        {
            if (!menuVisible)
                return;

            GUI.Box(new Rect(20, 20, 300, 190), "Cuphead Creeper Mod (Starter)");
            GUI.Label(new Rect(35, 52, 270, 22), "Build mode: " + (buildMode ? "ON" : "OFF"));
            GUI.Label(new Rect(35, 76, 270, 22), "Block: " + blockNames[selectedBlock]);
            GUI.Label(new Rect(35, 100, 270, 22), "Creeper cooldown: " + GetCooldownText());
            GUI.Label(new Rect(35, 124, 270, 38), "Gameplay hooks are not connected yet.");
            if (GUI.Button(new Rect(35, 160, 120, 30), "Toggle Build"))
                buildMode = !buildMode;
            if (GUI.Button(new Rect(165, 160, 120, 30), "Close"))
                menuVisible = false;
        }

        private string GetCooldownText()
        {
            float remaining = Mathf.Max(0f, nextCreeperTime - Time.time);
            return remaining <= 0f ? "Ready" : Mathf.CeilToInt(remaining) + "s";
        }
    }
}
