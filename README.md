# Essential Now Playing
A now playing tool intended to be used with OBS.

So bascially its just something that I made to replace SMG. If anyone actually sees this and wants to request a player, just make an issue on the github page. 

Currently supported:
  - Desktop (Windows [tested], *NIX [untested]):
    * Spotify
    * iTunes
    * winamp
    * VLC
    * MPC-HC
    * foobar2000
  - WebApps:
    * Spotify web player (play.spotify.com)
    * YouTube
    * Pandora
    * Google Play (play.google.com)

Planned players to support:
* Nothing at the moment, just stability fixes

### Usage
This application is completely portable. All that is required is that the two ```.exe```'s are in the same directory. Everything else is automagically setup when you run the application. If you move it and want to keep your settings, also move settings.json.

To use the WebApps, you'll need install the companion extension from the webstore. Here's a link to it: https://chrome.google.com/webstore/detail/now-playing-companion/aocghdlnkcebaipehcejjpeiijpdjldo.

Then, on any supported site, press that new icon in the top right of your browser then press the button inside that, and then on the bottom right of the page, there will be a new text box, press "Start" to link it up with the desktop application and you're done!

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
