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
To use the WebApps, you'll need to bookmark the nowplaying.js script that's also on this repo. I've uploaded nowplaying.min.js to my own server at http://topkek.us/nowplaying.min.js. This is what your bookmark should end up looking like:

javascript:(function(){document.body.appendChild(document.createElement("script")).src="//cdn.rawgit.com/pendo324/OBS-Now-Playing/7832b96455d1ed5fe7b60e004b74c011d9db5cda/OBS%20Now%20Playing/nowplaying.min.js"})()

Once you load the .js script you will notice a shield in the address bar (on Chrome at least). Just click it and allow the loading of unsafe scripts.

Unfortunately, due to the nature of how SSL binding works with .NET, I was unable to get an SSL certificate for this application, meaning this will send data using HTTP, not HTTPS. All the script does is sends data to a localhost server, so I would deem it safe. In the future I may add HTTPS support, it would be trivial on the javascript side tbh.

### Compiling
To compile using Visual Studio on Windows you are going to need to get a few References

These can be found using Nuget:
* Costura.Fody
* Fody
* Newtonsoft.Json

You will also need access to iTunes.exe to import iTunesLib. Not sure how this works with Mono, but I'd like to hear it.
