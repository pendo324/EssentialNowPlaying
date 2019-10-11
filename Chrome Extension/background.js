var port = null;
var message = null;
var connected = false;

function connect() {
    // connect to local program com.a.chrome_interface
    port = chrome.runtime.connectNative('com.flyinglawnmower.obsnp');
    port.onMessage.addListener(onNativeMessage);
    port.onDisconnect.addListener(onDisconnected);
    connected = true;
}

connect();

function onNativeMessage(msg) {
    console.log("Message received from Native Interface.")
    console.log(msg);
}

function onDisconnected() {
    connected = false;
    console.log("Disconnected.");
}

function sendNativeMessage(msg) {
    message = msg;
    port.postMessage(message);
}

// wait for shit from the worker
chrome.runtime.onMessage.addListener(function(data, sender, sendResponse) {
    if (connected === false) {
        connect();
    }
    sendNativeMessage(data);
});
