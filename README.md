
<p align="center">
  <img src="http://github.messatsu-dojo.com/previews/satsuiui.gif" alt="SatsuiUi preview"/>
</p>

# What is SatsuiUi ? #

SatsuiUi is a library containing a skin system and several controls i created for my own WPF projects. It's easy, fast to use and free.

# How to install it ? #

You can install the Nuget package with the command : **Install-Package Messatsu.SatsuiUi**

# How to use it ? #

When the Nuget package is installed, instanciate a SkinManager object wich take your application resources as parameter :

    SkinManager manager = new SkinManager(Application.Current.Resources);

Then select a default skin and a color :

    manager.SetCurrentSkin(manager.Skins[0], 1);

For now, there is 2 diffrents skins and 2 differents colors for each one : 
 
Crystal (0) : Light (1) / Dark (2)  
Classic (1) : White (1) / Black (2)

# Some controls are missing ! #

You can add your owns controls to a skin using the function AddResource :

```C#
	// Add a custom template to the Crystal skin 
    manager.addResource(manager.Skins[0], "/YourProject;component/Path/YourTemplateResource.xaml");
	
	// Add colors definitions for the Light color of the Crystal skin
	manager.AddResource(manager.Skins[0], 1, "/YourProject;component/Path/YourFirstColorsResource.xaml");

	// Add colors definitions for the Dark color of the Crystal skin
	manager.AddResource(manager.Skins[0], 1, "/YourProject;component/Path/YourSecondColorsResource.xaml");
```

There is an example in the demo, feel free to ask if you got any problem.

# My others projects #

**SatsuiLocalization**  
Easy localization of .NET applications  
[https://github.com/SatsuiBird/SatsuiLocalizationDemo](https://github.com/SatsuiBird/SatsuiLocalizationDemo "SatsuiLocalizationDemo")

**SatsuiMemory**  
Read and edit easily applications memory  
[https://github.com/SatsuiBird/SatsuiMemoryDemo](https://github.com/SatsuiBird/SatsuiMemoryDemo "SatsuiMemoryDemo")

**SatsuiOverlay**  
Create customizable HTTP widgets  
[https://github.com/SatsuiBird/SatsuiOverlayDemo](https://github.com/SatsuiBird/SatsuiOverlayDemo "SatsuiOverlayDemo")
