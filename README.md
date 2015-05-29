# OBS Now Playing
A now playing tool intended to be used with OBS.

So bascially its just something that I made to replace SMG. I'll be adding functionality for soem more major media players in the coming weeks. If anyone actually sees this and wants to request a player, just make an issue. 

Planned players to support:
* Spotify (done)
* iTunes (done)
* winamp (done)
* VLC (done)
* MPC-HC (done)
* YouTube in Chrome or Firefox (depending on how hard it is)

### Compiling
To compile using Visual Studio on Windows you are going to need to get a few References

These can be found using Nuget:
* Costura.Fody
* Fody
* Newtonsoft.Json

You will also need access to iTunes.exe to import iTunesLib. Not sure how this works with Mono, but I'd like to hear it.
