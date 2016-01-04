// var app = chrome.runtime.getBackgroundPage();

function doWork() {
    chrome.tabs.executeScript({
        file: 'jquery.js'
    }, function() {
        chrome.tabs.executeScript({
            file: 'worker.js'
        });
    });
}

document.getElementById('start').addEventListener('click', doWork);

console.log($(document));
