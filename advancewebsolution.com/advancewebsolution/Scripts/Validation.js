// JScript File
function CheckEmail(ID)
		{
			var str = document.getElementById(ID).value
			var at="@"
			var dot="."
			var lat=str.indexOf(at)
			var lstr=str.length
			var ldot=str.indexOf(dot)
			if(str=="")
			{
			return 1;
			}
			if (str.indexOf(at)==-1){						
			return 2;
			}

			if (str.indexOf(at)==-1 || str.indexOf(at)==0 || str.indexOf(at)==lstr){				
			return 2;
			}

			if (str.indexOf(dot)==-1 || str.indexOf(dot)==0 || str.indexOf(dot)==lstr){						
				return 2;
			}

			if (str.indexOf(at,(lat+1))!=-1){					
				return 2;
			}

			if (str.substring(lat-1,lat)==dot || str.substring(lat+1,lat+2)==dot){				
				return 2;
			}

			if (str.indexOf(dot,(lat+2))==-1){					
				return 2;
			}
			
			if (str.indexOf(" ")!=-1){				
				return 2;
			}
 			return 0;
	}	
	
	function CheckEmail1(val)
		{
		
			var at="@"
			var dot="."
			var lat=val.indexOf(at)
			var lstr=val.length
			var ldot=val.indexOf(dot)
			if(val=="")
			{
			return 1;
			}
			if (val.indexOf(at)==-1){						
			return 2;
			}

			if (val.indexOf(at)==-1 || val.indexOf(at)==0 || val.indexOf(at)==lstr){				
			return 2;
			}

			if (val.indexOf(dot)==-1 || val.indexOf(dot)==0 || val.indexOf(dot)==lstr){						
				return 2;
			}

			if (val.indexOf(at,(lat+1))!=-1){					
				return 2;
			}

			if (val.substring(lat-1,lat)==dot || val.substring(lat+1,lat+2)==dot){				
				return 2;
			}

			if (val.indexOf(dot,(lat+2))==-1){					
				return 2;
			}
			
			if (val.indexOf(" ")!=-1){				
				return 2;
			}
 			return 0;
	}	
	
	function RequiredValue(ID)
	{
		var val = document.getElementById(ID).value
		if (val=="")
		{					
			return 1;
		}
		if (val=="?")
		{					
			return 1;
		}
		if (val=="0")
		{					
			return 1;
		}
 		return 0;	
	}
	function CompareValue(ID1,ID2)
	{
		if(document.getElementById(ID1).value == document.getElementById(ID2).value)
		{
			return 0;
		}
		return 1;
	}
	
	function CheckPassword(strng) 
	{		
		if (strng == "") 
		{
			return 1;
		}
		var illegalChars = /[\W_]/; // allow only letters and numbers
		if ((strng.length < 4) || (strng.length > 12)) 
		{
			return 2;
		}
		else if (illegalChars.test(strng)) 
		{
			return 3;
		}
		return 0;
    }    
    function RequiredInt(num)
    {
		if (num == "") 
		{
			return 1;
		}
		var OnlyNumbers = /^(\d)?\d*$/;		
		if(OnlyNumbers.test(num))
		{
			return 0;
		}			
		else
		{
			return 2;
		}
		return 0;
    }
    function RequiredYear(num)
    {
		if (num == "") 
		{
			return 1;
		}
		var OnlyNumbers = /^(\d)?\d*$/;	
		if (num.length != 4) 
		{
			return 3;
		}				
		else if(OnlyNumbers.test(num))
		{
			return 0;
		}
		else
		{
			return 2;
		}
		return 0;
    }
   function RequiredNum(num)
    {
		if (num == "") 
		{
			return 1;
		}
		var Numbers = /^(\d)?\d*(\.\d+)?$/;		
		if(Numbers.test(num))
		{
			
			return 0;
		}		
		else
		{
			return 2;
		}
		return 0;
    }
    
    function ValidZip(num)
    {
		if (num == "") 
		{
			return 1;
		}
		var OnlyNumbers = /^(\d)?\d*$/;		
		if(OnlyNumbers.test(num))
		{
			if ((num.length < 5) || (num.length > 6)) 
			{
				return 2;
			}
			return 0;
		}		
		else
		{
			return 2;
		}
		return 0;
    }
    
    function CheckCardID(strng) 
	{		
		if (strng == "") 
		{
			return 1;
		}
		var illegalChars = /[\W_]/; // allow only letters and numbers
		if ((strng.length < 3) || (strng.length > 4)) 
		{
			return 2;
		}
		else if (illegalChars.test(strng)) 
		{
			return 3;
		}
		return 0;
    }    
    
    function CheckCardNo(strng) 
	{		
		if (strng == "") 
		{
			return 1;
		}
		var illegalChars = /[\W_]/; // allow only letters and numbers
		if ((strng.length < 16) || (strng.length > 18)) 
		{
			return 2;
		}
		else if (illegalChars.test(strng)) 
		{
			return 3;
		}
		return 0;
    }    
    
    function CheckCreditCard1(cardNumber, cardType)
    {
		var isValid = false;
		var ccCheckRegExp = /[^\d ]/;
		isValid = !ccCheckRegExp.test(cardNumber);
		if (isValid)
		{
			var cardNumbersOnly = cardNumber.replace(/ /g,"");
			var cardNumberLength = cardNumbersOnly.length;
			var lengthIsValid = false;
			var prefixIsValid = false;
			var prefixRegExp;
			switch(cardType)
			{
				case "MasterCard":
					lengthIsValid = (cardNumberLength == 16);
					prefixRegExp = /^5[1-5]/;
					break;
				case "Visa":
					lengthIsValid = (cardNumberLength == 16 || cardNumberLength == 13);
					prefixRegExp = /^4/;
					break;
				case "Discover":
					lengthIsValid = (cardNumberLength == 15);
					prefixRegExp = /^3(4|7)/;
					break;
				default:
					prefixRegExp = /^$/;
					alert("Card type not found");
			}
			prefixIsValid = prefixRegExp.test(cardNumbersOnly);
			isValid = prefixIsValid && lengthIsValid;
		}
		if (isValid)
		{
			var numberProduct;
			var numberProductDigitIndex;
			var checkSumTotal = 0;
			for (digitCounter = cardNumberLength - 1; digitCounter >= 0; digitCounter--)
			{
				checkSumTotal += parseInt (cardNumbersOnly.charAt(digitCounter));
				digitCounter--;
				numberProduct = String((cardNumbersOnly.charAt(digitCounter) * 2));
				for (var productDigitCounter = 0; productDigitCounter < numberProduct.length; productDigitCounter++)
				{
					checkSumTotal += 
					parseInt(numberProduct.charAt(productDigitCounter));
				}
			}
			isValid = (checkSumTotal % 10 == 0);
		}
		return isValid;
}

function CheckCreditCard(ccno) {
	ccsum=0;
	cclen=ccno.length;
	if (cclen<13)
	{
		return 2;		
	}
	else
	{
		for (i=1; i<cclen; i++)
		{
			ccdig=parseInt(ccno.charAt(cclen-(i+1)));
			if (i%2==1)
			{
				ccdig*=2;
				if (ccdig.toString().length==2)
				{
					ccdig=(parseInt(ccdig.toString().charAt(0))+parseInt(ccdig.toString().charAt(1)));
				} 
			}
			ccsum+=ccdig;
		}
		ccsum+=parseInt(ccno.charAt(cclen-1));
		if (ccsum%10==0)
		{
			if (ccno.match(/^4/) )
				{				
				if (cclen==13 || cclen==16) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^50|^56|^57|^58|^6/) )
				{				
				if (cclen>=13 || cclen<=19) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^51|^52|^53|^54|^55/) )
				{				
				if (cclen==16) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^413733|^413734|^413735|^413736|^413737|^4462|^453978|^453979|^454313|^454313|^454432|^454433|^454434|^454435|^454742|^456725|^456726|^456727|^456728|^456729|^45673|^456740|^456741|^456742|^456743|^456744|^456745|^46583|^46584|^46585|^46586|^46587|^484409|^484410|^49096|^49097|^492181|^492182|^498824/) )
				{				
				if (cclen==16) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^450875|^484406|^484407|^484408|^484411|^484412|^484413|^484414|^484415|^484416|^484417|^484418|^484419|^48442|^48443|^48444|^484450|^484451|^484452|^484453|^484454|^484455|^49173|^49174|^49175|^491880/) )
				{				
				if (cclen==16) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^405501|^405502|^405503|^405504|^405550|^405551|^405552|^405553|^405554|^415928|^424604|^424604|^427533|^4288|^443085|^4484|^4485|^4486|^4715|^4716|^4804/) )
				{				
				if (cclen==16) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^490300|^490301|^49031|^49032|^490330|^490331|^490332|^490333|^490334|^49034|^49035|^49036|^49037|^49038|^49039|^49040|^490419|^490451|^490459|^490467|^490475|^490476|^490477|^490478|^4905|^491103|^491104|^491105|^491106|^491107|^491108|^491109|^49111|^49112|^49113|^49114|^49115|^49116|^491170|^491171|^491172|^491173|^491183|^491184|^491185|^491186|^491187|^491188|^491189|^49119|^4928|^4987/) )
				{				
				if (cclen==16) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^6011/) )
				{
				if (cclen==16) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^63345|^63346|^63347|^63348|^63349|^6767/) )
				{
				if (cclen==16 || cclen==18 || cclen==19) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^490302|^490303|^490304|^490305|^490306|^490307|^490308|^490309|^490335|^490336|^490337|^490338|^490339|^491101|^491102|^491174|^491175|^491176|^491177|^491178|^491179|^491180|^491181|^491182|^4936|^564182|^63330|^63331|^63332|^63333|^63334|^6759/) )
				{
				if (cclen==16 || cclen==18 || cclen==19) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^34|^37/) )
				{				
				if (cclen==13 || cclen==15) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^3528|^3529|^353|^354|^355|^356|^357|^358/) )
				{
				if (cclen==15 || cclen==16) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^300|^301|^302|^303|^304|^305|^36|^380|^381|^382|^383|^384|^385|^386|^387|^388/) )
				{				
				if (cclen==14) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^389/) )
				{
				if (cclen==14) {return 0;}
				 else {return 1;}
				}

			if (ccno.match(/^2014|^2149/) )
				{
				if (cclen==15) {return 0;}
				 else {return 1;}
				}	
		} 	
		else
		{
			return 1;
		}	
	}	
}

//validating Phone number


// Declaring required variables
var digits = "0123456789";
// non-digit characters which are allowed in phone numbers
var phoneNumberDelimiters = "()- ";
// characters which are allowed in international phone numbers
// (a leading + is OK)
var validWorldPhoneChars = phoneNumberDelimiters + "+";
// Minimum no of digits in an international phone no.
var minDigitsInIPhoneNumber = 10;

function isInteger(s)
{   var i;
    for (i = 0; i < s.length; i++)
    {   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

function stripCharsInBag(s, bag)
{   var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++)
    {   
        // Check that current character isn't whitespace.
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function checkInternationalPhone(strPhone)
{
	s=stripCharsInBag(strPhone,validWorldPhoneChars);
	return (isInteger(s) && s.length >= minDigitsInIPhoneNumber);
}
	
function ValidatePhoneNumber(phone)
{
	if (phone == "")
	{
		return 1;
	}
	if (checkInternationalPhone(phone)==false)
	{
		return 2;
	}
	return 0;
}
function validateInteger(str){
       if(str == "")
      {
        return 1;
      }
      else if(isNaN(parseInt(str)))
      {
         return 1;
      }
      else
      {  
         return 0;
      }
   }
//Date validation



function IsValidDate(ID) 
{
	var dateStr = document.getElementById(ID).value;	
	var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{2}|\d{4})$/;

	// To require a 4 digit year entry, use this line instead:
	// var datePat = /^(\d{1,2})(\/|-)(\d{1,2})\2(\d{4})$/;

	var matchArray = dateStr.match(datePat); // is the format ok?
	if (matchArray == null) 
	{
		alert("Date is not in a valid format.")
		return 1;
	}
	month = matchArray[1]; // parse date into variables
	day = matchArray[3];
	year = matchArray[4];
	if (month < 1 || month > 12) 
	{ // check month range
		alert("Month must be between 1 and 12.");		
		return 2;
	}
	if (day < 1 || day > 31) 
	{
		alert("Day must be between 1 and 31.");
		return 3;
	}
	if ((month==4 || month==6 || month==9 || month==11) && day==31) 
	{
		alert("Month "+month+" doesn't have 31 days!")
		return 4
	}
	if (month == 2) 
	{ // check for february 29th
		var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
		if (day>29 || (day==29 && !isleap)) 
		{
			alert("February " + year + " doesn't have " + day + " days!");
			return 5;
		}
	}	
}
	
// Validate phone number


var zChar = new Array(' ', '(', ')', '-', '.');
var maxphonelength = 13;
var phonevalue1;
var phonevalue2;
var cursorposition;

function ParseForNumber1(object){
phonevalue1 = ParseChar(object.value, zChar);
}
function ParseForNumber2(object){
phonevalue2 = ParseChar(object.value, zChar);
}

function backspacerUP(object,e) { 
if(e)
{ 
e = e 
}
 else 
 {
e = window.event 
} 
if(e.which){ 
var keycode = e.which 
} else {
var keycode = e.keyCode 
}

ParseForNumber1(object)

if(keycode >= 48){
ValidatePhone(object)
}
}

function backspacerDOWN(object,e) { 
if(e){ 
e = e 
} else {
e = window.event 
} 
if(e.which){ 
var keycode = e.which 
} else {
var keycode = e.keyCode 
}
ParseForNumber2(object)
} 

function GetCursorPosition(){

var t1 = phonevalue1;
var t2 = phonevalue2;
var bool = false
for (i=0; i<t1.length; i++)
{
if (t1.substring(i,1) != t2.substring(i,1)) {
if(!bool) {
cursorposition=i
bool=true
}
}
}
}
	
function ValidatePhone(object)
	{
		var p = phonevalue1
		p = p.replace(/[^\d]*/gi,"")
		if (p.length < 3)
	 {
		object.value=p
	} else if(p.length==3){
		pp=p;
		d4=p.indexOf('(')
		d5=p.indexOf(')')
		if(d4==-1)
		{
		pp="("+pp;
		}
		if(d5==-1)
		{
			pp=pp+")";
		}
		object.value = pp;
		}
		 else if(p.length>3 && p.length < 7)
		 {
			p ="(" + p; 
			l30=p.length;
			p30=p.substring(0,4);
			p30=p30+")"
			p31=p.substring(4,l30);
			pp=p30+p31;
			object.value = pp; 
		}	
		 else if(p.length >= 7){
			p ="(" + p; 
			l30=p.length;
			p30=p.substring(0,4);
			p30=p30+")"
			p31=p.substring(4,l30);
			pp=p30+p31;
			l40 = pp.length;
			p40 = pp.substring(0,8);
			p40 = p40 + "-"
			p41 = pp.substring(8,l40);
			ppp = p40 + p41;
			object.value = ppp.substring(0, maxphonelength);
		}
	GetCursorPosition()
		if(cursorposition >= 0){
			if (cursorposition == 0) {
				cursorposition = 2
			}
			 else if (cursorposition <= 2) 
			 {
				cursorposition = cursorposition + 1
			}
			 else if (cursorposition <= 5) 
			 {
				cursorposition = cursorposition + 2
			}
			 else if (cursorposition == 6) 
			 {
				cursorposition = cursorposition + 2
	}
	 else if (cursorposition == 7) 
	 {
		cursorposition = cursorposition + 4
		e1=object.value.indexOf(')')
		e2=object.value.indexOf('-')
		if (e1>-1 && e2>-1){
		if (e2-e1 == 4)
		 {
			cursorposition = cursorposition - 1
		}
		}
		}
		 else if (cursorposition < 11) 
		 {
			cursorposition = cursorposition + 3
		}
		 else if (cursorposition == 11) 
		 {
			cursorposition = cursorposition + 1
		}
		 else if (cursorposition >= 12) 
		 {
			cursorposition = cursorposition
		}
		var txtRange = object.createTextRange();
		txtRange.moveStart( "character", cursorposition);
		txtRange.moveEnd( "character", cursorposition - object.value.length);
		txtRange.select();
	    }
	    }
		function ParseChar(sStr, sChar)
		{
			if (sChar.length == null) 
			{
				zChar = new Array(sChar);
			}
				else zChar = sChar;
			for (i=0; i<zChar.length; i++)
			{
				sNewStr = "";
				var iStart = 0;
				var iEnd = sStr.indexOf(sChar[i]);
				while (iEnd != -1)
			{
				sNewStr += sStr.substring(iStart, iEnd);
				iStart = iEnd + 1;
				iEnd = sStr.indexOf(sChar[i], iStart);
			}
				sNewStr += sStr.substring(sStr.lastIndexOf(sChar[i]) + 1, sStr.length);
				sStr = sNewStr;
			}
		return sNewStr;
		}
		
function mOvr(src)
{
	if (!src.contains(event.fromElement))
	{ 
		src.style.cursor = 'hand';
	}
}
function mOut(src) 
{
	if (!src.contains(event.toElement))
	{ 
		src.style.cursor = 'default';
	}
}


function IsNonNegDecimal(element)
{
    var nonnegdecimalRE = "^[0-9][0-9]*(\\.[0-9]*)?$";
    if(element.value.match(nonnegdecimalRE) != null)
    {
        return 1;
    }
    return 0;
}
// JScript File

function IsNumeric(sText)
{
   var ValidChars = "0123456789.";
   var IsNumber=true;
   var Char;

 
   for (i = 0; i < sText.length && IsNumber == true; i++) 
      { 
      Char = sText.charAt(i); 
      if (ValidChars.indexOf(Char) == -1) 
         {
         IsNumber = false;
         }
      }
   return IsNumber;
}

