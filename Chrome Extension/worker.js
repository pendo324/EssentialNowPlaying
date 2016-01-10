"use strict";
var player;
var interval;
var players;
var supported;
var website;

var $ = window.jQuery;

supported = false;

players = {
    "mixcloud": mixcloud,
    "pandora": pandora,
    "play.google.com": play,
    "play.spotify.com": spotify,
    "soundcloud": soundcloud,
    "tunein": tunein,
    "youtube": youtube
};

function mixcloud() {
    var artist, song, songTitle;
    var wp = "Mixcloud";

    if ($(document).find('a[ng-bind="player.currentCloudcast.title"]').text() === undefined || $(document).find('a[ng-bind="player.currentCloudcast.title"]').text() === null) {
        songTitle = 'Paused';
    } else {
        artist = $(document).find('a[ng-bind="player.currentCloudcast.owner"]').text();
        song = $(document).find('a[ng-bind="player.currentCloudcast.title"]').text();
        songTitle = artist + ' - ' + song;
    }

    return {
        song: songTitle,
        webPlayer: wp
    };
}

function pandora() {
    var artist, song, songTitle;
    var wp = "Pandora";

    if ($(document).find('.playerBarSong').text() === undefined || $(document).find('.playerBarSong').text() === null) {
        songTitle = 'Paused';
    } else {
        artist = $(document).find('.playerBarArtist').text();
        song = $(document).find('.playerBarSong').text();
        songTitle = artist + ' - ' + song;
    }

    return {
        song: songTitle,
        webPlayer: wp
    };
}

function play() {
    var artist, song, songTitle;
    var wp = "Google Play";

    if ($(document).find('#player-artist').text() === undefined || $(document).find('#player-artist').text() === null) {
        songTitle = 'Paused';
    } else {
        artist = $(document).find('#player-artist').text();
        song = $(document).find('#player-song-title').text();
        songTitle = artist + " - " + song;
    }

    return {
        song: songTitle,
        webPlayer: wp
    };
}

function spotify() {
    var artist, song, songTitle;
    var wp = "Spotify";
    var split = $('title').text().split(' - ');

    if (split.length == 3) {
        artist = split[1]
        song = split[0];
        songTitle = artist + ' - ' + song;
    } else {
        songTitle = "Paused";
    }

    return {
        song: songTitle,
        webPlayer: wp
    };
}

function soundcloud() {
    var songTitle;
    var wp = "Soundcloud";
    if ($(document).find('.playbackSoundBadge__title').attr('title') === undefined || $(document).find('.playbackSoundBadge__title').attr('title') === null) {
        songTitle = 'Paused';
    } else {
        songTitle = $(document).find('.playbackSoundBadge__title').attr('title');
    }

    return {
        song: songTitle,
        webPlayer: wp
    };
}

// Can't grab artist from tunein, it is placed together
function tunein() {
    var songTitle;
    var wp = "tunein";
    if ($(document).find('#tuner > div > div > div.display > div.line1._navigateNowPlaying').text() === undefined || $(document).find('#tuner > div > div > div.display > div.line1._navigateNowPlaying').text() === null) {
        songTitle = 'Paused';
    } else {
        songTitle = $(document).find('#tuner > div > div > div.display > div.line1._navigateNowPlaying').text();
    }

    return {
        song: songTitle,
        webPlayer: wp
    };
}

//unfortunately there is no good way to determine an 'artist'
function youtube() {
    var songTitle;
    var wp = "YouTube";

    if ($(document).find('#eow-title').text() === undefined || $(document).find('#eow-title').text() === null) {
        songTitle = 'Paused';
    } else {
        songTitle = $(document).find('#eow-title').text().trim();
    }

    return {
        song: songTitle,
        webPlayer: wp
    };
}

// sets the song variable, send it to localhost and makes the 
// appropriate changes to the html object(s)
// TODO: add the html shit
function setSong() {
    var song = player();
    if (song.song != '') {
        $('.NowPlayingBody').text(song.song);
        sendToBackground(song.webPlayer, song.song);
    } else {
        $('.NowPlayingBody').text("No song playing");
    }
}

function init() {
    if ($('.NowPlayingContainer').length > 0) {
        return;
    }
    addHTML();
    var s = checkSupport();
    if (s) {
        setSong();
        $('.NowPlayingSupported').text(website + ' is supported!').css('color', 'green');
        $('.NowPlayingButton').click(function() {
            if ($('.NowPlayingButton').text() == 'Start') {
                $('.NowPlayingButton').text('Stop');
                start();
            } else if ($('.NowPlayingButton').text() == 'Stop') {
                $('.NowPlayingButton').text('Start');
                stop();
            }
        });
    } else {
        $('.NowPlayingSupported').text(website).append(' <a href="https://github.com/pendo324/OBS-Now-Playing">is not supported.</a>').css('color', 'red');
    }
}

function start() {
    setSong();
    interval = setInterval(setSong, 2000);
}

function stop() {
    if (interval != null) {
        clearInterval(interval);
    }
}

function checkSupport() {
    website = window.location.host;

    for (var p in players) {
        if (website.indexOf(p) > -1) { //website.includes(p), works in Chrome/Opera and Firefox 40
            player = players[p];
            supported = true;
        }
    }
    return supported;
}

function addHTML() {
    var html = "<div id='npiframe-container style='visibility:hidden'><iframe name='npiframe'></iframe></div><div class=NowPlayingContainer><style>.NowPlayingContainer{background-color:#343434;border:2px solid #3c3c3c;color:#f5f5f5;position:fixed;bottom:50px;right:30px;width:300px;min-height:100px;z-index:10000;}.NowPlayingHeader{margin:10px;line-height:18px;font-family:arial;font-size:16px}.NowPlayingBody{margin-top:15px;margin-left:10px;line-height:16px;font-family:arial;font-size:14px}.NowPlayingSupported{margin-left:65px;margin-top:-20px;line-height:16px;font-family:arial;font-size:14px}.NowPlayingSupported a:link{color:#09F}.NowPlayingSupported a:visited{color: #CC0099;}.NowPlayingButton{margin-left:10px;line-height:16px;font-family:arial;font-size:14px}</style><div><div class=NowPlayingHeader>OBS Now Playing</div><button class=NowPlayingButton>Start</button><div class=NowPlayingSupported></div><div class=NowPlayingBody>No song playing.</div></div></div>";
    $('body').append(html);
}

function sendToBackground(player, song) {
    var data = {
        'player': player,
        'song': song
    };

    chrome.runtime.sendMessage(data);
}

init();
