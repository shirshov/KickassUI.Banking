<img src="https://www.thewissen.io/wp-content/uploads/xamuijuly-1.png" width="300px" />

# Laconic KickassUI.Banking

Pixel perfect <sup>*</sup> rewrite of [KickassUI.Banking](https://github.com/sthewissen/KickassUI.Banking) 
using [Laconic](https://github.com/shirshov/laconic)

<img src="https://github.com/sthewissen/KickassUI.Banking/blob/master/combined.jpg" />

Laconic is added as a git submodule, do `git submodule init` after cloning this projects.

## Stats

**Line count** of files inside the KickassUI.Banking folder:    

Original (XAML files were reformatted to put each attribute on new line):

```
-------------------------------------------------------------------------------
Language                     files          blank        comment           code
-------------------------------------------------------------------------------
XAML                             5              6              5            860
C#                              10             25              3            155
MSBuild script                   1              3              0             23
-------------------------------------------------------------------------------
SUM:                            16             34              8           1038
-------------------------------------------------------------------------------
```

With Laconic:
```
-------------------------------------------------------------------------------
Language                     files          blank        comment           code
-------------------------------------------------------------------------------
C#                               6             27              1            419
MSBuild script                   1              3              0             17
-------------------------------------------------------------------------------
SUM:                             7             30              1            436
-------------------------------------------------------------------------------
```

**Character count**, calculated with  `-type f \( -name "*.xaml" -o -name "*.cs" \) -exec cat {} + | wc -m`

Original: 25,859

With Laconic: 16,848

## PancakeView
This rewrite shows how to use 3rd party controls in a Laconic app. 
Check the [PancakeView.cs](https://github.com/shirshov/KickassUI.Banking/blob/laconic/KickassUI.Banking/PancakeView.cs) file.

----
\*  Well, almost. A couple of FontAwesome icons were replaced with close equivalents.
