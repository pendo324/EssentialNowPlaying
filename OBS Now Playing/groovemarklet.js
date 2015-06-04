(function (a, b, c) { function d(a) { return "[object Function]" == o.call(a) } function e(a) { return "string" == typeof a } function f() { } function g(a) { return !a || "loaded" == a || "complete" == a || "uninitialized" == a } function h() { var a = p.shift(); q = 1, a ? a.t ? m(function () { ("c" == a.t ? B.injectCss : B.injectJs)(a.s, 0, a.a, a.x, a.e, 1) }, 0) : (a(), h()) : q = 0 } function i(a, c, d, e, f, i, j) { function k(b) { if (!o && g(l.readyState) && (u.r = o = 1, !q && h(), l.onload = l.onreadystatechange = null, b)) { "img" != a && m(function () { t.removeChild(l) }, 50); for (var d in y[c]) y[c].hasOwnProperty(d) && y[c][d].onload() } } var j = j || B.errorTimeout, l = b.createElement(a), o = 0, r = 0, u = { t: d, s: c, e: f, a: i, x: j }; 1 === y[c] && (r = 1, y[c] = []), "object" == a ? l.data = c : (l.src = c, l.type = a), l.width = l.height = "0", l.onerror = l.onload = l.onreadystatechange = function () { k.call(this, r) }, p.splice(e, 0, u), "img" != a && (r || 2 === y[c] ? (t.insertBefore(l, s ? null : n), m(k, j)) : y[c].push(l)) } function j(a, b, c, d, f) { return q = 0, b = b || "j", e(a) ? i("c" == b ? v : u, a, b, this.i++, c, d, f) : (p.splice(this.i++, 0, a), 1 == p.length && h()), this } function k() { var a = B; return a.loader = { load: j, i: 0 }, a } var l = b.documentElement, m = a.setTimeout, n = b.getElementsByTagName("script")[0], o = {}.toString, p = [], q = 0, r = "MozAppearance" in l.style, s = r && !!b.createRange().compareNode, t = s ? l : n.parentNode, l = a.opera && "[object Opera]" == o.call(a.opera), l = !!b.attachEvent && !l, u = r ? "object" : l ? "script" : "img", v = l ? "script" : u, w = Array.isArray || function (a) { return "[object Array]" == o.call(a) }, x = [], y = {}, z = { timeout: function (a, b) { return b.length && (a.timeout = b[0]), a } }, A, B; B = function (a) { function b(a) { var a = a.split("!"), b = x.length, c = a.pop(), d = a.length, c = { url: c, origUrl: c, prefixes: a }, e, f, g; for (f = 0; f < d; f++) g = a[f].split("="), (e = z[g.shift()]) && (c = e(c, g)); for (f = 0; f < b; f++) c = x[f](c); return c } function g(a, e, f, g, h) { var i = b(a), j = i.autoCallback; i.url.split(".").pop().split("?").shift(), i.bypass || (e && (e = d(e) ? e : e[a] || e[g] || e[a.split("/").pop().split("?")[0]]), i.instead ? i.instead(a, e, f, g, h) : (y[i.url] ? i.noexec = !0 : y[i.url] = 1, f.load(i.url, i.forceCSS || !i.forceJS && "css" == i.url.split(".").pop().split("?").shift() ? "c" : c, i.noexec, i.attrs, i.timeout), (d(e) || d(j)) && f.load(function () { k(), e && e(i.origUrl, h, g), j && j(i.origUrl, h, g), y[i.url] = 2 }))) } function h(a, b) { function c(a, c) { if (a) { if (e(a)) c || (j = function () { var a = [].slice.call(arguments); k.apply(this, a), l() }), g(a, j, b, 0, h); else if (Object(a) === a) for (n in m = function () { var b = 0, c; for (c in a) a.hasOwnProperty(c) && b++; return b }(), a) a.hasOwnProperty(n) && (!c && !--m && (d(j) ? j = function () { var a = [].slice.call(arguments); k.apply(this, a), l() } : j[n] = function (a) { return function () { var b = [].slice.call(arguments); a && a.apply(this, b), l() } }(k[n])), g(a[n], j, b, n, h)) } else !c && l() } var h = !!a.test, i = a.load || a.both, j = a.callback || f, k = j, l = a.complete || f, m, n; c(h ? a.yep : a.nope, !!i), i && c(i) } var i, j, l = this.yepnope.loader; if (e(a)) g(a, 0, l, 0); else if (w(a)) for (i = 0; i < a.length; i++) j = a[i], e(j) ? g(j, 0, l, 0) : w(j) ? B(j) : Object(j) === j && h(j, l); else Object(a) === a && h(a, l) }, B.addPrefix = function (a, b) { z[a] = b }, B.addFilter = function (a) { x.push(a) }, B.errorTimeout = 1e4, null == b.readyState && b.addEventListener && (b.readyState = "loading", b.addEventListener("DOMContentLoaded", A = function () { b.removeEventListener("DOMContentLoaded", A, 0), b.readyState = "complete" }, 0)), a.yepnope = k(), a.yepnope.executeStack = h, a.yepnope.injectJs = function (a, c, d, e, i, j) { var k = b.createElement("script"), l, o, e = e || B.errorTimeout; k.src = a; for (o in d) k.setAttribute(o, d[o]); c = j ? h : c || f, k.onreadystatechange = k.onload = function () { !l && g(k.readyState) && (l = 1, c(), k.onload = k.onreadystatechange = null) }, m(function () { l || (l = 1, c(1)) }, e), i ? k.onload() : n.parentNode.insertBefore(k, n) }, a.yepnope.injectCss = function (a, c, d, e, g, i) { var e = b.createElement("link"), j, c = i ? h : c || f; e.href = a, e.rel = "stylesheet", e.type = "text/css"; for (j in d) e.setAttribute(j, d[j]); g || (n.parentNode.insertBefore(e, n), m(c, 0)) } })(this, document);

(function () {
    "use strict";
    var interval;
    var site;
    var site_supported = false;
    var identifier;

    function grooveshark() {
        var song = $("#now-playing-metadata").text(),
            title = "Grooveshark - " + song;
        return {
            song: song,
            title: title
        };
    }

    function pandora() {
        var song = $(".info .playerBarSong").text() + " - " + $(".info .playerBarArtist").text(),
            title = "Pandora - " + song;
        return {
            song: song,
            title: title
        };
    }

    function plug() {
        var song = $("#now-playing-bar .bar-value").text(),
            title = "Plug.dj - " + song;
        return {
            song: song,
            title: title
        };
    }

    function zaycev() {
        var song = $("#zp_current_song .ontheair_artist").text() + $("#zp_current_song .ontheair_song").text(),
            title = "Zaycev - " + song;
        return {
            song: song,
            title: title
        };
    }

    function eighttracks() {
        var song = $("#now_playing .title_artist .t").text() + " - " + $("#now_playing .title_artist .a").text(),
            title = "8tracks - " + song;
        if ($("#now_playing .title_artist .t").text() === "") {
            return false;
        }
        return {
            song: song,
            title: title
        };
    }

    function googleplay() {
        var song = $("#player-artist").text() + " - " + $("#player-song-title").text(),
            title = song + " - My Library - Google Play";
        if (song.length < 4) { // " - " is of length 3
            return false;
        }
        return {
            song: song,
            title: title
        };
    }

    function rdio() {
        var song = $(".song_title").text() + " - " + $(".text_metadata .artist_title").text(),
            title = "Rdio - " + song;
        return {
            song: song,
            title: title
        };
    }

    function soundcloud() {
        var song = $('.playbackSoundBadge__title>span[aria-hidden]').text(),
            title = "Soundcloud - " + song;
        return {
            song: song,
            title: title
        };
    }

    function youtify() {
        var song = $(".info .title").text(),
            title = "Youtify - " + song;
        return {
            song: song,
            title: title
        };
    }

    function deezer() {
        var songTitle = $('span.player-track-link:nth-child(1)').text();
        var artist = $('span.player-track-link:nth-child(3)').text();
        var song = songTitle + " - " + artist;
        var title = "Deezer - " + song;

        return {
            song: song,
            title: title
        };
    }

    function youtube() {
        var songTitle = $('#eow-title').text();
        var title = "YouTube - " + songTitle;
        var song = songTitle; //unfortunately there is no good way to
                              //determine an 'artists' or songName here
        return {
            song: song,
            title: title
        };
    }

    var redirects = {
        "grooveshark": grooveshark,
        "plug": plug,
        "pandora": pandora,
        "zaycev": zaycev,
        "8tracks": eighttracks,
        "rdio": rdio,
        "soundcloud": soundcloud,
        "youtify": youtify,
        "play.google": googleplay,
        "deezer": deezer,
        "youtube": youtube
    };

    function check_song() {
        var song = identifier();
        set_song(song);
        sendLocalPOST(identifier, song);
    }

    function set_song(song) {
        if (song) {
            $('title').text(song.title);
            $('.SMGCurrentPlayingSong').text(song.song);
        } else {
            $('.SMGCurrentPlayingSong').text("No song playing");
        }
    }

    function start() {
        if (site_supported) {
            check_song();
            interval = setInterval(check_song, 2000);
        }
    }

    function stop() {
        if (interval) {
            clearInterval(interval);
            set_song();
        }
    }

    function website_name() {
        var e = window.location.host;
        return e;
    }

    function not_supported() {
        console.log("not supported :(((");
        site_supported = false;
        $('.SMGSite').text(website_name())
            .attr('title', 'For more info, click me!')
            .attr('href', '')
            .css('color', 'red')
            .parent().append('<a href="https://github.com/pendo324/OBS-Now-Playing">, not supported.</a>');
    }

    function supported() {
        console.log("supported as fuck :)))");
        site_supported = true;
        $('.SMGSite').text(website_name())
            .css('color', 'green');
    }

    function check_for_support() {
        var website = website_name();
        var redirect;

        $('.SMGSite').text(website);
        for (redirect in redirects) {
            if (website.indexOf(redirect) !== -1) {
                identifier = redirects[redirect];
                supported();
            }
        }
        if (!site_supported) {
            not_supported();
        }
        console.log("check_for_support: " + site_supported);
    }

    function add_to_document(testResult, key) {
        $ = window.jQuery;
        // I've made it so that it's completely impossible to update SMG
        // at any later point. This is heaven from a developer's perspective
        var html = "<div class='SMGContainer'><style>.SMGContainer *{margin: 0;padding: 0;}.SMGContainer button{background:-webkit-gradient(linear,left top,left bottom,color-stop(0.05,#f6b33d),color-stop(1,#d29105));background:-moz-linear-gradient(center top,#f6b33d 5%,#d29105 100%);filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#f6b33d', endColorstr='#d29105');background-color:#f6b33d;-webkit-border-top-left-radius:0;-moz-border-radius-topleft:0;border-top-left-radius:0;-webkit-border-top-right-radius:0;-moz-border-radius-topright:0;border-top-right-radius:0;-webkit-border-bottom-right-radius:0;-moz-border-radius-bottomright:0;border-bottom-right-radius:0;-webkit-border-bottom-left-radius:0;-moz-border-radius-bottomleft:0;border-bottom-left-radius:0;text-indent:0;border:1px solid #eda933;display:inline-block;color:#222;font-family:Arial;font-size:15px;font-weight:700;font-style:normal;height:24px;line-height:24px;width:56px;text-decoration:none;text-align:center;text-shadow:1px 1px 0 #cd8a15}.SMGContainer button:hover{background:-webkit-gradient(linear,left top,left bottom,color-stop(0.05,#d29105),color-stop(1,#f6b33d));background:-moz-linear-gradient(center top,#d29105 5%,#f6b33d 100%);filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#d29105', endColorstr='#f6b33d');background-color:#d29105}.SMGContainer button:active{position:relative;top:1px}.SMGContainer{background-color: rgb(240, 240, 255);box-shadow: 0 0 3px black;border: 1px solid rgb(60, 60, 60);color: #444;position: fixed;bottom: 30px;right: 30px;width: 300px;height: 200px;z-index:50000}.SMGContainer h1{line-height: 16px;font-family: helvetica;font-size: 15px;}.SMGInformation{margin: 10px;}.SMGControls{margin: 10px;}.SMGCurrentPlayingSong{font-weight: bold;}.SMGLogo{display: inline-block;width: 16px;height: 16px;background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAABCElEQVR42qVTgQ2CQAz83wA30AnEDZ4NYAJ1AnUCZAJlAt1AN9AN1AlkBDbANlzfh5RIYpMLfqnX3vWx5s+wA/mYkBLmOL8IV8LzF8GUcCI4FN+RdyDlc0aoNQIuuBEqwlrpxiQHNFmgrkPwwDMJO/QiQhMDEk+wArtnhgcxfIjwe4JallmwL0LgMNo56NYMmB7mMyGIlLEbyLkHZ4tGb2zFEzQYaT+CQCRzvrLQJgbOMImsMsN0F2VrqqYCzOJ0EhBUMLmGhJJwFEbRteMkRjQ9UyVY5kY2ZnsvctNeIu2PHFvTrtvXWIU9h4zSfO8E+7SEL50G2sfkMGIa5GqsjUk7V3zoaxwdH/3tQ5EfsW3gAAAAAElFTkSuQmCC);}.SMGSite{font-weight: bold;}.SMGSite + a, .SMGSite + a:active, .SMGSite + a:visited{color: red;text-decoration: none;}</style><div class='SMGInformation'><h1><span class='SMGLogo'></span> Groovemarklet, yay!</h1><br/><span class='SMGCurrentPlayingSong'>No song playing</span><p>You're on: <span class='SMGSite'></span></p></div><hr/><div class='SMGControls'><p class='SMGRunning'>Running</p><button class='SMGStart'>Stop</button><br/><br/><p>Hide and show me with <b>ctrl-m<b></p></div></div>";
        $('body').append(html);
        SMGInit();
    }

    function inject_libraries() {
        if (document.getElementsByClassName("SMGContainer").length < 1) { // Only add a groovemarklet when there are none running
            yepnope({
                test: !!window.jQuery, // Converts the existence of jQuery to a boolean true or false
                nope: "https://cdn.jsdelivr.net/jquery/2.0.3/jquery-2.0.3.min.js",
                complete: add_to_document
            });
            yepnope.injectJs("https://cdn.jsdelivr.net/keymaster.js/1.6.1/keymaster.min.js", function () {
                key("ctrl+m", function () {
                    $(".SMGContainer").fadeToggle(); // Binds the hide me to ctrl-m
                });
            });
        }
    }

    function SMGInit() {
        $('.SMGContainer').hide().fadeIn(200);

        check_for_support();
        $('.SMGStart').click(function () {
            if ($(this).text() === "Start") {
                $(".SMGRunning").text("Running.");
                $(this).text("Stop");
                start();
            } else if ($(this).text() === "Stop") {
                $(".SMGRunning").text("Not running.");
                $(this).text("Start");
                stop();
            }
        });
        start();
    }

    function sendLocalPOST(player, song) {
        var url = "http://localhost:13337/";
        var params = "player=" + player + "&song=" + song;
        var xhr = new XMLHttpRequest();
        xhr.open("POST", url, true);

        xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");

        xhr.send(params);
    }

    inject_libraries();
}());