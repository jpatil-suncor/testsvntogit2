function formatCurrency(num) {
num = num.toString().replace(/\$|\,/g,'');
if(isNaN(num) || num=='')
  return "";   //num = "0";
sign = (num == (num = Math.abs(num)));
num = Math.floor(num*100+0.50000000001);
cents = num%100;
num = Math.floor(num/100).toString();
if(cents<10)
cents = "0" + cents;
for (var i = 0; i < Math.floor((num.length-(1+i))/3); i++)
num = num.substring(0,num.length-(4*i+3))+','+
num.substring(num.length-(4*i+3));
return (((sign)?'':'-') + '$' + num + '.' + cents);
}

function EditKeyDown() {
//alert("hello");
var e = window.event;
var key = e.keyCode;
var id = e.srcElement.id;
var val = document.all(id).value;

if(window.event) // IE
  {
//      alert("EditKeyDown:id[" + id + "]key[" + key + "]val[" + val + "]");
    if(isNaN(val) || val=='')
    {
    }
    else
    {
      if (key==66)  // 'B'
      {
         document.all(id).value=val*1000000000;
         event.keyCode = 9;  // tab out
      }
      if (key==77)  // 'm'
      {
         document.all(id).value=val*1000000;
         event.keyCode = 9;  // tab out
      }
      if (key==75)  // 'k'
      {
         document.all(id).value=val*1000;
         event.keyCode = 9;  // tab out
      }
    }
  }
}

function AllowTabCharacter() {
   if (event != null) {
      if (event.srcElement) {
         if (event.srcElement.value) {
            if (event.keyCode == 9) {  // tab character
               if (document.selection != null) {
                  document.selection.createRange().text = '\t';
                  event.returnValue = false;
               }
               else {
                  event.srcElement.value += '\t';
                  return false;
               }
            }
          }
      }
   }
}

function NotesKeyDown() {
//alert("NotesKeyDown");
var e = window.event;
var key = e.keyCode;
var id = e.srcElement.id;
var val = document.all(id).value;

if(window.event) // IE
  {
//    alert("EditKeyDown:id[" + id + "]key[" + key + "]val[" + val + "]");
    //  return AllowTabCharacter()
    return true;
  }
//  return AllowTabCharacter();
}

/////////////////////////////////////////
// Use this to display a TEXTBOX in focus
/////////////////////////////////////////
function showFocus(ctrlName)
{
//alert("showFocus");
	var ctrl = document.all(ctrlName);
	ctrl.focus();
	
	var myIndex = ctrlName.indexOf("txt");
	
	if (myIndex >= 0)
		ctrl.select();
		
//	ctrl.style.backgroundColor = "#FFFFC0";
}

//////////////////////////////////////////////
// Use this to display a TEXTBOX not in focus 
//////////////////////////////////////////////
function showBlur(ctrlName)
{
//alert("showBlur");
//	var ctrl = document.all(ctrlName);
//	ctrl.style.backgroundColor = "white";
}




