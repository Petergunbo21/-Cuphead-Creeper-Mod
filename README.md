# Cuphead Creeper Mod

A starter project for a Cuphead mod with buildable blocks, a bow-and-arrow weapon, and a Creeper companion.

## Important status

This is a **source scaffold, not a finished playable mod**. The menu, configurable hotkeys, build-mode state, block-type cycling, and Creeper cooldown logic are starter code. Actual solid blocks, the custom weapon/projectiles, and a boss-targeting Creeper still require Cuphead/Blender API integration, assets, and in-game testing.

## Planned controls

- **F6** — show/hide the mod menu
- **F7** — toggle build mode
- **B** — cycle block type
- **G** — request a Creeper summon (15-second cooldown)
- **Normal shoot button** — intended to fire arrows once the custom weapon is integrated

The starter currently logs build and Creeper actions instead of spawning gameplay objects. It does not yet replace Cuphead's weapon.

## Modding requirements

Cuphead mods commonly use BepInEx 5 and the Blender Cuphead modding API. Building the plugin requires a compatible Cuphead installation/game assemblies and the correct BepInEx/Unity references.

- Blender API docs: https://boofii.github.io/blender-docs/
- Blender API source: https://github.com/Boofii/Blender
- Cuphead modding template: https://github.com/UserNotFoundXEption/CupheadModdingTemplate

The project has not been compiled or tested in GameHub. GameHub on Android may not support the same PC mod-loader setup, so first confirm whether your GameHub Cuphead installation can load BepInEx plugins.

## Files

- `Plugin.cs` — starter plugin, settings, keyboard controls, simple on-screen menu, and cooldown state.
- `FEATURE_STATUS.md` — implementation checklist and what remains.

Back up your game files before testing mods. Do not install unknown DLLs from untrusted sources.
