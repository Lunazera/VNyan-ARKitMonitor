# LZ's Blendshape Snapshot plugin for VNyan
Small tool to help when working with ARKit blendshapes. 

This displays all tracked 52 ARKit values in one window, and lets you pause to see the values at that time. You can set a threshold, and a selectable box at the bottom will list all blendshapes that were larger than that value. The list is formatted for use in other VNyan nodes (semi-colon separated list without spaces).

This plugin only runs when the plugin window is open! It should only be used as a monitor when testing and working on things in VNyan, it is otherwise a bit slow so don't keep it running otherwise.

## Installation
1. Download the latest zip file from [releases](https://github.com/Lunazera/VNyan-Blendshape-Snapshot/releases/)
2. Unzip the contents in your VNyan folder. This will put the `.dll` and `.vnobj` inside `Items/Assemblies` for you.
3. The plugin should be present when you load VNyan!

*Note: Remember to enable 3rd party plugins in VNyan under `Menu/Settings/Misc`*