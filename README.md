# Essential Now Playing
A now playing tool intended to be used with OBS.

So bascially its just something that I made to replace SMG. If anyone actually sees this and wants to request a player, just make an issue on the github page. 

## NOTICE
There is a new, rewritten version available here: https://github.com/pendo324/universal-np. I intend to add features to it much more regularly. It has most of the same features, and I really need people to test it pls.

Currently supported:
  - Desktop (Windows [tested], *NIX [untested]):
    * Spotify
    * iTunes
    * winamp
    * VLC
    * MPC-HC
    * foobar2000
    * MediaMonkey
  - WebApps:
    * Mixcloud
    * Spotify web player (play.spotify.com)
    * Soundcloud
    * Tunein
    * YouTube
    * Pandora
    * Google Play (play.google.com)
    * Deezer

Planned players to support:
* Nothing at the moment, just stability fixes

### Usage
This application is completely portable. All that is required is that the two ```.exe```'s are in the same directory. Everything else is automagically setup when you run the application. If you move it and want to keep your settings, also move settings.json.

To use the WebApps, you'll need install the companion extension from the webstore. Here's a link to it: https://chrome.google.com/webstore/detail/now-playing-companion/aocghdlnkcebaipehcejjpeiijpdjldo.

To use the WebApps you need to do the following:

1. Open Essential Now Playing.
2. Select the Player and set the file path.
3. Head to any supported web player.
4. Click on the Now Playing Companion Extension and "Use on this page".
(You should see the NativeMessagingInterface background process start up in Task Manager)
5. On the web pop-up click "Start".
6. Go back to Essential Now Playing app and hit "Start!".

Be sure that the desktop application is running before activating the Chrome extension.

#### Note: WebApps will not function if ```NativeMessagingInterface.exe``` is not in the same directory as ```Essential Now Playing.exe```.
Please ensure that they are in the same directory before creating an issue.

### Compiling
To compile using Visual Studio on Windows you are going to need to get a few References

These can be found using Nuget:
* Costura.Fody
* Fody
* Newtonsoft.Json

You will also need access to iTunes.exe to import iTunesLib. Not sure how this works with Mono, but I'd like to hear it.

#### Licence
Copyright (c) 2016 Flying Lawnmower Development

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
