# InscryptionMoreSliderPuzzles

A mod for Inscryption that adds more slider puzzles to the GBC section of the game in the cabin.

This mod is mainly a proof of concept to show that replacing puzzles in the GBC section of the game works. 
Some things might not work as expected, such as certain sigils not displaying correctly or certain sigils 
not working in slider puzzles. This mod does not fix these things.

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

## Define Custom Puzzles

Your puzzles must be defined in the same folder with `MoreSliderPuzzles.dll`, or in a subfolder. The extension must be `.pdef`.

A `.pdef` file contains 4 lines, with each line containing 4 entries, separated by `|`. For each entry, you may leave it empty
(for an empty space), or an ID representing the card. The ID of the card can be prepended by `!`. If so, the tile is locked.
Each entry can be padded by whitespaces, and empty lines will be ignored.

The puzzles will appear in the order of their path, so puzzles with a lexicographically smaller name will appear first.

See the example puzzles for more details.
