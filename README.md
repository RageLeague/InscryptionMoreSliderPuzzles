# InscryptionMoreSliderPuzzles

A mod for Inscryption that adds more slider puzzles to the GBC section of the game in the cabin.

This mod is mainly a proof of concept to show that replacing puzzles in the GBC section of the game works. 
Some things might not work as expected, such as certain sigils not displaying correctly or certain sigils,
not working in slider puzzles. This mod does not fix these things, this mod plans to have a parch to fix
the Stat icons not showing up within sliderpuzzles however.

## Details

This mod changes the slider puzzle in the cabin in the GBC section of the game. That puzzle will be replaced 
by a list of puzzles, defined in the plugin folders. When you solve a puzzle, you will be rewarded as normal, 
but the cabinet will remain closed, and you can solve the next puzzle. If there are no more puzzles to solve,
because you've solved all puzzles defined, the cabinet will become open, making the puzzles inaccessible.

## Usage

In order to use this mod, you must have BepInEx installed. This mod does not depend on any other mods.

### Install from GitHub

You need to find the required files (`MoreSliderPuzzles.dll` and a folder containing the puzzles) and unpack them in the 
`BepInEx\plugins` folder.

### Installing with a Mod Manager
This is the recommended way to install BepInEx to the game.

1. Download and install [Thunderstore Mod Manager](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager) or [r2modman](https://Timberborn.thunderstore.io/package/ebkr/r2modman/).
2. Click the **Install with Mod Manager** button on the top of [BepInEx's](https://thunderstore.io/package/download/BepInEx/BepInExPack_Inscryption/5.4.1902/) page.
3. Run the game via the mod manager.

### Installing Manually
1. Install [BepInEx](https://thunderstore.io/package/download/BepInEx/BepInExPack_Inscryption/5.4.1902/) by pressing 'Manual Download' and extract the contents into a folder. **Do not extract into the game folder!**
2. Move the contents of the 'BepInExPack_Inscryption' folder into the game folder (where the game executable is).
3. Run the game. If everything was done correctly, you will see the BepInEx console appear on your desktop. Close the game after it finishes loading.
4. Install [MonoModLoader](https://inscryption.thunderstore.io/package/BepInEx/MonoMod_Loader_Inscryption/) and extract the contents into a folder.
5. Move the contents of the 'patchers' folder into 'BepInEx/patchers' (If any of the mentioned BepInEx folders don't exist, just create them).
6. Install [Inscryption API](https://inscryption.thunderstore.io/package/API_dev/API/) and extract the contents into a folder.
7. Move the contents of the 'plugins' folder into 'BepInEx/plugins' and the contents of the 'monomod' folder into the 'BepInEx/monomod' folder.
8. Run the game again. If everything runs correctly, a message will appear in the console telling you that the API was loaded.

### Installing on the Steam Deck:
1. Download [r2modman](https://Timberborn.thunderstore.io/package/ebkr/r2modman/) on the Steam Deck’s Desktop Mode and open it from its download using its `AppImage` file
2. Go to the setting of the profile you have for the mods and click `Browse Profile Folder`.
3. Copy the BepInEx folder then go to Steam, and browse Inscryption's local files; paste the folder there
4. Enter Gaming Mode and open Inscryption.  If everything was done correctly, you should see a console appear on your screen.

## Define Custom Puzzles

Your puzzles must be defined in the same folder with `MoreSliderPuzzles.dll`, or in any subfolder of the `Plugins` folder. The extension must be `.pdef`.
If the extension is prefixed with `_example` it wont be loaded in.

A `.pdef` file contains 4 lines, with each line containing 4 entries, separated by `|`. For each entry, you may leave it empty
(for an empty space), or an ID representing the card. The ID of the card can be prepended by `!`. If so, the tile is locked.
Each entry can be padded by whitespaces, and empty lines will be ignored.

An ID is defined as the in code name, it does not require the GUID to be present, If it is present an error will pop up telling you which ID failed to load.

The puzzles will be Randomized, if you wish to configure this there is a config available.

See the example puzzles for more details.

## Contributers:

* RageLeague - Made The Original Mod
* Creator - Porting
* WhistleWind - StatIcon Patch

Want to contribute? Open a PR at: https://github.com/SaxbyMod/InscryptionMoreSliderPuzzlesMiniUpdate