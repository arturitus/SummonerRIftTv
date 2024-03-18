# Summoner Rift Tv 

[![.NET 8.0](https://img.shields.io/badge/NET-8.0-brightgreen.svg)](https://github.com/dotnet/core/blob/main/release-notes/8.0/README.md)
[![Avalonia](https://img.shields.io/badge/Avalonia-11.0.10-brightgreen.svg)](https://avaloniaui.net)

Summoner Rift Tv is a desktop app for spectating League of Legends matches without the need for the League of Legends client.

![image](https://github.com/arturitus/SummonerRIftTv/assets/68915153/57460b8f-ccd0-451c-bd91-a55e652f4b0e)

## Build status 
[![.NET](https://github.com/arturitus/SummonerRIftTv/actions/workflows/dotnet.yml/badge.svg)](https://github.com/arturitus/SummonerRIftTv/actions/workflows/dotnet.yml)
[![Netlify Status](https://api.netlify.com/api/v1/badges/dce4adb2-4213-4eae-bb88-0c978dff9f4a/deploy-status)](https://app.netlify.com/sites/summonerrifttv/deploys)

## How to use

1. **[Download Summoner Rift Tv](https://github.com/arturitus/SummonerRIftTv/releases/latest)** from the releases page and install.
2. Start Summoner Rift Tv.
3. Search a Summoner by their `name` + `#tag`.
4. Hit spectate button. League of Legends will launch with the game.

[Note 1:](#how-to-use/) `Tag` doesn't need to be specified, if the player has the default tag, which is region-dependent. For example, `#EUW` or `#NA1`.

[Note 2:](#how-to-use/) Make sure the League of Legends folder path is correctly set in Summoner Rift Tv `Options` tab. The default path is `C:/Riot Games/League of Legends`.

## Credits

This project wouldn't have been possible without the help, contributions, and resources from the following individuals and communities:

- [Netlify](https://www.netlify.com): Enables serverless hosting of the proxy for the Riot API.
  
    [![Netlify](https://www.netlify.com/img/deploy/button.svg)](https://www.netlify.com)

- [Material.Avalonia](https://github.com/AvaloniaCommunity/Material.Avalonia): Provides community support and resources for Material Design in Avalonia applications.
  
  [![Material.Avalonia](https://raw.githubusercontent.com/AvaloniaCommunity/Material.Avalonia/master/wiki/FavIcon.svg)](https://github.com/AvaloniaCommunity/Material.Avalonia)
  [![Material.Avalonia](https://img.shields.io/badge/Material.Avalonia-Community%20Support-red?logo=github)](https://github.com/AvaloniaCommunity/Material.Avalonia)

- [Avalonia](https://github.com/AvaloniaUI/Avalonia): A cross-platform XAML-based UI framework providing a flexible and powerful desktop application development platform.
  
  [![Avalonia](https://avaloniaui.net/img/logo/avalonia-white-purple.svg)](https://avaloniaui.net)
  [![Avalonia](https://img.shields.io/badge/Avalonia-UI%20Framework-blueviolet?logo=github)](https://github.com/AvaloniaUI/Avalonia)

- [Community Dragon](https://raw.communitydragon.org): Provides resources and assets for League of Legends community projects.
  
    [![Community Dragon](https://raw.communitydragon.org/.theme/logo.png)](https://raw.communitydragon.org)
    [![CommunityDragon](https://img.shields.io/badge/CommunityDragon-blue?logo=github)](https://github.com/CommunityDragon)

## Technical stuff

- Summoner Rift Tv has been tested only on Windows 10, although Avalonia is known for being cross-platform.
- Summoner Rift Tv has been specifically compiled for win-x64, leveraging Avalonia's compatibility with Ahead-of-Time (AoT) compilation offered by .NET 8. This choice not only reduces application size but also enhances startup times. 
    
- [![Virus Total](https://img.shields.io/badge/VirusTotal-Scan-blue?logo=virustotal)](https://www.virustotal.com/gui/file/8db9bcf730f9d5d816b1e1da69274e6788c08e91d326cb8973a30df087803da5/detection)
- [![Virus Total AoT](https://img.shields.io/badge/VirusTotal-AoT_Scan-blue?logo=virustotal)](https://www.virustotal.com/gui/file/bd0ef835d6e65b987d08173072a06446577eec28f656a362dee99125464e2247/detection)
    For some reason this compiled exe gets flagged.


## TODO
- Display the the `gameName` instead of the `summonerName`.
- Display each player solo queue rank.
- Display team average rank.
