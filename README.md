# OBS Now Playing
A now playing tool intended to be used with OBS.

So bascially its just something that I made to replace SMG. I'll be adding functionality for soem more major media players in the coming weeks. If anyone actually sees this and wants to request a player, just make an issue. 

Currently supported:
  - Desktop (Windows [tested], *NIX [untested]):
    * Spotify
    * iTunes
    * winamp
    * VLC
    * MPC-HC
  - WebApps:
    * Spotify web player (play.spotify.com)
    * YouTube
    * Pandora
    * Google Play (play.google.com)

Planned players to support:
* Nothing at the moment, just stability fixes

### Usage
To use the WebApps, you'll need install the companion extension from the webstore. Here's a link to it: https://chrome.google.com/webstore/detail/now-playing-companion/aocghdlnkcebaipehcejjpeiijpdjldo.

Then, on any supported site, press that new icon in the top right of your browser then press the button inside that, and then on the bottom right of the page, there will be a new text box, press "Start" to link it up with the desktop application and you're done!

### Compiling
To compile using Visual Studio on Windows you are going to need to get a few References

These can be found using Nuget:
* Costura.Fody
* Fody
* Newtonsoft.Json

You will also need access to iTunes.exe to import iTunesLib. Not sure how this works with Mono, but I'd like to hear it.
