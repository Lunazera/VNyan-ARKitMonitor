# LZ's ARKit Monitor tool for VNyan
Small tool to help when working with ARKit blendshapes. 

![image of plugin window](https://github.com/Lunazera/VNyan-ARKitMonitor/blob/master/example.png)

Displays all tracked 52 ARKit values in one window, and lets you pause to see the values at that time. You can set a threshold, and a selectable box at the bottom will list all blendshapes that were larger than that value. The list is formatted for use in other VNyan nodes (semi-colon separated list without spaces). 

![image of plugin window](https://github.com/Lunazera/VNyan-ARKitMonitor/blob/master/ARKitMonitorwindow.png)

This plugin only runs when the plugin window is open, but if you want it to run when hidden, click the left toggle. You'll find the output of largest blendshapes in a text parameter named `LZMonitor_blendshapes`

## Installation
1. Download the latest zip file from [releases](https://github.com/Lunazera/VNyan-ARKitMonitor/releases/)
2. Unzip the contents in your VNyan folder. This will put the `.dll` and `.vnobj` inside `Items/Assemblies` for you.
3. The plugin should be present when you load VNyan!

## Example gif
![image of plugin window](https://github.com/Lunazera/VNyan-ARKitMonitor/blob/master/ARKitMonitorExample.gif)

*Note: Remember to enable 3rd party plugins in VNyan under `Menu/Settings/Misc`*
