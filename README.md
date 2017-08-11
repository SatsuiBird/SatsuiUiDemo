
<p align="center">
  <img src="http://github.messatsu-dojo.com/previews/satsuiui.gif" alt="SatsuiUi preview"/>
</p>

# What is SatsuiUi ? #

SatsuiUi is a library containing a skin system and several controls i created for my own WPF projects.  
You can change the theme on the fly.  
It's easy, fast to use and free.

# How to install it ? #

The Nuget package is available here : [https://www.nuget.org/packages/Messatsu.SatsuiUi/](https://www.nuget.org/packages/Messatsu.SatsuiUi/ "Messatsu.SatsuiUi")

    PM> Install-Package Messatsu.SatsuiUi

# How to use it ? #

When the Nuget package is installed, instantiate a SkinManager object which take your application resources as parameter :

    SkinManager manager = new SkinManager(Application.Current.Resources);

Then select a default skin and a color :

    manager.SetCurrentSkin(manager.Skins[0], 1);

In your XAML code, add a reference to SatsuiUi.Controls

	xmlns:ctrls="clr-namespace:SatsuiUi.Controls;assembly=SatsuiUi"

For now, there is 2 differents skins and 2 differents colors for each one : 
 
- (0) **Crystal** :
  - (1) Light
  - (2) Dark
- (1) **Classic** :
  - (1) White 
  - (2) Black

# Which controls are managed by SatsuiUi ? #

- SatsuiWindow *(improved window)*
- Button
- HintTextBox *(improved TextBox)*
- HintComboBox *(improved ComboBox)*
- CheckBox
- ProgressBar
- Slider
- ListBox
- ListView
- ContentControl
- HintGroupBox *(improved GroupBox)*
- ColorPicker
- ImagePicker 
- SoundPicker
- FontPicker
- KeyPicker
- ContributorsList

# Some controls are missing ! #

You can add your owns controls to a skin using the **AddResource** function :

	// Add a custom template to the Crystal skin 
    manager.addResource(manager.Skins[0], "/YourProject;component/Path/YourTemplateResource.xaml");
	
	// Add colors definitions for the Light color of the Crystal skin
	manager.AddResource(manager.Skins[0], 1, "/YourProject;component/Path/YourFirstColorsResource.xaml");

	// Add colors definitions for the Dark color of the Crystal skin
	manager.AddResource(manager.Skins[0], 1, "/YourProject;component/Path/YourSecondColorsResource.xaml");

There is an example in the DemoMVVM project, feel free to ask me if you got any problem.

# Eh, im not english ! #

All customs controls are designed to support translation.  
For example, you can change default texts of a ImagePicker control :

    <ctrls:ImagePicker 
		NoFileText="No file selected"
		ValidText="Let's go !"
		RemoveText="Remove this !"
		BrowseText="Let's pick some cool images"
		DialogTitle="Im a beautiful window !"/>

They are also compatible with SatsuiLocalization, see links below.

# My others projects #

**SatsuiLocalization**  
Easy localization of .NET applications  
[https://github.com/SatsuiBird/SatsuiLocalizationDemo](https://github.com/SatsuiBird/SatsuiLocalizationDemo "SatsuiLocalizationDemo")

**SatsuiMemory**  
Read and edit applications memory easily  
[https://github.com/SatsuiBird/SatsuiMemoryDemo](https://github.com/SatsuiBird/SatsuiMemoryDemo "SatsuiMemoryDemo")

**SatsuiOverlay**  
Create customizable HTTP widgets  
[https://github.com/SatsuiBird/SatsuiOverlayDemo](https://github.com/SatsuiBird/SatsuiOverlayDemo "SatsuiOverlayDemo")
