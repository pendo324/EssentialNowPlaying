var port = null;
var message = null;

function connect() {
    // connect to local program com.a.chrome_interface
    port = chrome.runtime.connectNative('com.flyinglawnmower.obsnp');
    port.onMessage.addListener(onNativeMessage);
    port.onDisconnect.addListener(onDisconnected);
}

connect();

function onNativeMessage(msg) {
    console.log("Message received from Native Interface.")
    console.log(msg);
}

function onDisconnected() {
    console.log("Disconnected.");
}

function sendNativeMessage(msg) {
    message = msg;
    port.postMessage(message);
}

// wait for shit from the worker
chrome.runtime.onMessage.addListener(function(data, sender, sendResponse) {
    sendNativeMessage(data);
});
