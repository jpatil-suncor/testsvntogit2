// Copyright © 2000 by Apple Computer, Inc., All Rights Reserved.
//
// You may incorporate this Apple sample code into your own code
// without restriction. This Apple sample code has been provided "AS IS"
// and the responsibility for its operation is yours. You may redistribute
// this code, but you are not permitted to redistribute it as
// "Apple sample code" after having made changes.
// ********************************
// application-specific functions *
// ********************************

// store variables to control where the popup will appear relative to the cursor position
// positive numbers are below and to the right of the cursor, negative numbers are above and to the left
//var xOffset = 30;
//var yOffset = -5;
var xOffset = -100;
var yOffset = 25;

function showPopup (targetObjectId, eventObj) {
//alert('here:targetObjectId['+targetObjectId+"]");
    if(eventObj) {
	// hide any currently-visible popups
	hideCurrentPopup();
	// stop event from bubbling up any farther
	eventObj.cancelBubble = true;
	// move popup div to current cursor position 
	// (add scrollTop to account for scrolling for IE)
	var newXCoordinate = (eventObj.pageX)?eventObj.pageX + xOffset:eventObj.x + xOffset + ((document.body.scrollLeft)?document.body.scrollLeft:0);
	var newYCoordinate = (eventObj.pageY)?eventObj.pageY + yOffset:eventObj.y + yOffset + ((document.body.scrollTop)?document.body.scrollTop:0);
//alert('here1:targetObjectId['+targetObjectId+"]");
	moveObject(targetObjectId, newXCoordinate, newYCoordinate);
//alert('here2:targetObjectId['+targetObjectId+"]");
	positionIFrame(targetObjectId, 'thehideframe');
//alert('here3:targetObjectId['+targetObjectId+"]");
	// and make it visible
	if( changeObjectVisibility(targetObjectId, 'visible') ) {
	    // if we successfully showed the popup
	    // store its Id on a globally-accessible object
//alert('here4:targetObjectId['+targetObjectId+"]");
	    window.currentlyVisiblePopup = targetObjectId;
//alert('here4a:targetObjectId['+targetObjectId+"]");
//alert(document.getElementById('thehideframe').style.display);
//	    document.getElementById('thehideframe').style.display = "visible"
//alert('here4b:targetObjectId['+targetObjectId+"]");
//	    if (targetObjectId=="stampingFeePopup")
//	    {
//	       document.getElementById('theframe').style.display = "none"
//	    }
//alert('here5:targetObjectId['+targetObjectId+"]");
	    return true;
	} else {
	    // we couldn't show the popup, boo hoo!
//alert('here6:targetObjectId['+targetObjectId+"]");
	    return false;
	}
    } else {
	// there was no event object, so we won't be able to position anything, so give up
//alert('here7:targetObjectId['+targetObjectId+"]");
	return false;
    }
} // showPopup

function hideCurrentPopup() {
//alert('here:hideCurrentPopup');
    // note: we've stored the currently-visible popup on the global object window.currentlyVisiblePopup
    if(window.currentlyVisiblePopup) {
	changeObjectVisibility(window.currentlyVisiblePopup, 'hidden');
    document.getElementById('thehideframe').style.display = "none"
	window.currentlyVisiblePopup = false;
    }
} // hideCurrentPopup

//////////////////////////////////////////////
// The following is used to hide select statements from the calendar dropdowns (divs)
//////////////////////////////////////////////
function positionIFrame(divid, frmid)
{
	var div = document.getElementById(divid);
	var frm = document.getElementById(frmid);
	frm.style.left = div.style.left;
	frm.style.top = div.style.top;
	frm.style.height = div.offsetHeight;
	frm.style.width = div.offsetWidth;
	frm.style.display = "block";	
}


// ***********************
// hacks and workarounds *
// ***********************

// initialize hacks whenever the page loads
window.onload = initializeHacks;

// setup an event handler to hide popups for generic clicks on the document
document.onclick = hideCurrentPopup;

function initializeHacks() {
    // this ugly little hack resizes a blank div to make sure you can click
    // anywhere in the window for Mac MSIE 5
    if ((navigator.appVersion.indexOf('MSIE 5') != -1) 
	&& (navigator.platform.indexOf('Mac') != -1)
	&& getStyleObject('blankDiv')) {
	window.onresize = explorerMacResizeFix;
    }
    resizeBlankDiv();
    // this next function creates a placeholder object for older browsers
    createFakeEventObj();
}

function createFakeEventObj() {
    // create a fake event object for older browsers to avoid errors in function call
    // when we need to pass the event object to functions
    if (!window.event) {
	window.event = false;
    }
} // createFakeEventObj

function resizeBlankDiv() {
    // resize blank placeholder div so IE 5 on mac will get all clicks in window
    if ((navigator.appVersion.indexOf('MSIE 5') != -1) 
	&& (navigator.platform.indexOf('Mac') != -1)
	&& getStyleObject('blankDiv')) {
	getStyleObject('blankDiv').width = document.body.clientWidth - 20;
	getStyleObject('blankDiv').height = document.body.clientHeight - 20;
    }
}

function explorerMacResizeFix () {
    location.reload(false);
}

