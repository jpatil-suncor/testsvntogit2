
// JavaScript Document

if (document.images) {
low2on = new Image(); // Active images
low2on.src = "images/buttNavOn_02.gif";

low2off = new Image(); // Inactive images
low2off.src = "images/buttNavOff_02.gif";
}

if (document.images) {
low3on = new Image(); // Active images
low3on.src = "images/buttNavOn_03.gif";

low3off = new Image(); // Inactive images
low3off.src = "images/buttNavOff_03.gif";
}

if (document.images) {
low4on = new Image(); // Active images
low4on.src = "images/buttNavOn_04.gif";

low4off = new Image(); // Inactive images
low4off.src = "images/buttNavOff_04.gif";
}

if (document.images) {
low5on = new Image(); // Active images
low5on.src = "images/buttNavOn_05.gif";

low5off = new Image(); // Inactive images
low5off.src = "images/buttNavOff_05.gif";
}

if (document.images) {
low6on = new Image(); // Active images
low6on.src = "images/buttNavOn_06.gif";

low6off = new Image(); // Inactive images
low6off.src = "images/buttNavOff_06.gif";
}

if (document.images) {
low7on = new Image(); // Active images
low7on.src = "images/buttNavOn_07.gif";

low7off = new Image(); // Inactive images
low7off.src = "images/buttNavOff_07.gif";
}
function imgOn(imgName) {
if (document.images) {
document[imgName].src = eval(imgName + "on.src");
}
}

function imgOff(imgName) {
if (document.images) {
document[imgName].src = eval(imgName + "off.src");
}
}