<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" Inherits="Visitourvan" Title="Fritzy's pet care pros : Visit our van" Codebehind="Visitourvan.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Suggestion.ascx" TagName="Suggestion" TagPrefix="Sg" %>
<%@ Register Src="~/Controls/TestZip.ascx" TagName="Zipcode1" TagPrefix="Z1" %>
<%@ Register Src="~/Controls/JoinFritzyClub.ascx" TagName="Join" TagPrefix="Jo" %>
<%@ Register Src="~/Controls/Appointment.ascx" TagName="Appointment" TagPrefix="AP" %>
<%@ Register Src="~/Controls/giftcard.ascx" TagName="Gift" TagPrefix="GF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    &nbsp;
    <script type="text/javascript" language="javascript">


        //*****parameters to set*****
        //into this array insert the paths of your pics.
        var def_imges = new Array(0);
        var def_divid = "slideshow"; //the id of the div container that will hold the slideshow
        var def_picwid = 666; //set this to the width of your widest pic
        var def_pichei = 378; //... and this to the height of your highest pic
        var def_backgr = "#eeeeee"; //set this to the background color you want to use for the slide-area
        //(for example the body-background-color) if your pics are of different size
        var def_sdur = 3; //time to show a pic between fades in seconds
        var def_fdur = 1; //duration of the complete fade in seconds
        var def_steps = 20; //steps to fade from on pic to the next
        var def_startwhen = "y"; //start automatically at pageload? set it to "y" for on and to "n" for off
        var def_shuffle = "y"; //start with random image? set it to "y" for on and to "n" for off
        var def_showcontr = "y"; //do you want to show controls? set it to "y" for on and to "n" for off
        //into this array insert the paths of your control-buttons or the text to display e.g. back,start,stop,fwrd.
        var def_contr = new Array('bwd.png', 'start.png', 'stop.png', 'fwd.png');
        var def_imges1 = new Array('pics/2.jpg', 'pics/3.jpg', 'pics/4.jpg');
        //****************************************************************

        //daisychain onload-events
        //function daisychain(sl){if(window.onload) {var ld=window.onload;window.onload=function(){ld();sl();};}else{window.onload=function(){sl();};}}
        var xmlHttp;
        function showCD(str) {

            xmlHttp = GetXmlHttpObject();
            if (xmlHttp == null) {
                alert("Browser does not support HTTP Request");
                return;
            }
            var url = "X2.aspx";
            url = url + "?q=" + str;
            url = url + "&sid=" + Math.random();
            xmlHttp.open("GET", url, false);
            xmlHttp.send(null);
            var str = xmlHttp.responseText;
            var str1 = str.split("#");

            for (var k = 0 ; k < str1.length ; k++) {
                def_imges[k] = str1[k];
            }
        }

        function stateChanged() {

            if (xmlHttp.readyState == 4 || xmlHttp.readyState == "complete") {
                var str = xmlHttp.responseText;
                var str1 = str.split("#");

                for (var k = 0 ; k < str1.length ; k++) {
                    def_imges[k] = str1[k];
                }

            }
            else {
                alert(xmlHttp.readyState);
            }

        }

        function GetXmlHttpObject() {
            var xmlHttp = null;
            try {
                // Firefox, Opera 8.0+, Safari 
                xmlHttp = new XMLHttpRequest();
            }
            catch (e) {
                // Internet Explorer 
                try {
                    xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
                }
                catch (e) {
                    xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
            }
            return xmlHttp;
        }





        function daisychain(sl) {
            if (window.onload) {
                var ld = window.onload; window.onload = function () {
                    ld();
                    sl();
                };
            }
            else {
                window.onload = function () {
                    sl();
                };
            }
        }
        function pausecomp(millis) {
            var date = new Date();
            var curDate = null;

            do { curDate = new Date(); }
            while (curDate - date < millis);
        }
        function be_slideshow(be_slideid, be_imges, be_divid, be_picwid, be_pichei, be_backgr, be_sdur, be_fdur, be_steps, be_startwhen, be_shuffle, be_showcontr, be_contr) {
            showCD("asd");

            //declarations and defaults
            var slideid = (be_slideid) ? be_slideid : "0";
            var imges = (be_imges) ? be_imges : def_imges;
            var divid = (be_divid) ? be_divid : def_divid;
            var picwid = (be_picwid) ? be_picwid : def_picwid;
            var pichei = (be_pichei) ? be_pichei : def_pichei;
            var backgr = (be_backgr) ? be_backgr : def_backgr;
            var sdur = (be_sdur) ? be_sdur : def_sdur;
            var fdur = (be_fdur) ? be_fdur : def_fdur;
            var steps = (be_steps) ? be_steps : def_steps;
            var startwhen = (be_startwhen) ? be_startwhen : def_startwhen;
            startwhen = (startwhen.toLowerCase() == "y") ? 1 : 0;
            var shuffle = (be_shuffle) ? be_shuffle : def_shuffle;
            shuffle = (shuffle.toLowerCase() == "y") ? 1 : 0;
            var showcontr = (be_showcontr) ? be_showcontr : def_showcontr;
            showcontr = (showcontr.toLowerCase() == "y") ? 1 : 0;
            var contr = (be_contr) ? be_contr : def_contr;
            var ftim = fdur * 1000 / steps;
            var stim = sdur * 1000;
            var emax = imges.length;
            var self = this;
            var stopit = 1;
            var startim = 1;
            var u = 0;
            var parr = new Array();
            var ptofade, pnext, factor, mytimeout;
            //check if there are at least 3 pictures, elswhere double the array
            if (imges.length <= 2) { imges = imges.concat(imges); }
            //shuffle images if set
            if (shuffle) { var i; for (i = 0; i <= Math.floor(Math.random() * imges.length) ; i++) { imges.push(imges.shift()); } }

            //push images into array and get things going
            this.b_myfade = function () {
                var a, idakt, paktidakt, ie5exep;
                for (a = 1; a <= emax; a++) {
                    idakt = "img_" + slideid + "_" + a; paktidakt = document.getElementById(idakt);
                    ie5exep = new Array(paktidakt); parr = parr.concat(ie5exep);
                }
                if (startwhen) {
                    stopit = 0;
                    mytimeout = setTimeout(function () { self.b_slide(); }, stim);
                }
            }

            //prepare current and next and trigger slide
            this.b_slide = function () {
                clearTimeout(mytimeout);
                u = 0;
                ptofade = parr[startim - 1];
                if (startim < emax) { pnext = parr[startim]; }
                else { pnext = parr[0]; }
                pnext.style.zIndex = 1;
                pnext.style.visibility = "visible";
                pnext.style.filter = "Alpha(Opacity=100)";
                pnext.style.MozOpacity = 1;
                pnext.style.opacity = 1;
                ptofade.style.zIndex = 2;
                ptofade.style.visibility = "visible";
                ptofade.style.filter = "Alpha(Opacity=100)";
                ptofade.style.MozOpacity = 1;
                ptofade.style.opacity = 1;
                factor = 100 / steps;
                if (stopit == "0") {
                    this.b_slidenow();
                }
            }

            //one step forward
            this.b_forw = function () {
                stopit = 1;
                clearTimeout(mytimeout);
                ptofade = parr[startim - 1];
                if (startim < emax) { pnext = parr[startim]; startim = startim + 1; }
                else { pnext = parr[0]; startim = 1; }
                ptofade.style.visibility = "hidden";
                ptofade.style.zIndex = 1;
                pnext.style.visibility = "visible";
                pnext.style.zIndex = 2;
                self.b_slide();
            }

            //one step back
            this.b_back = function () {
                stopit = 1;
                clearTimeout(mytimeout);
                if (u == 0) { //between two slides
                    ptofade = parr[startim - 1];
                    if (startim < emax) { pnext = parr[startim]; }
                    else { pnext = parr[0]; }
                    pnext.style.visibility = "hidden";
                    ptofade.style.zIndex = 1;
                    ptofade.style.visibility = "visible";
                    if (startim >= 2) { startim = startim - 1; }
                    else { startim = emax; }
                    self.b_slide();
                }
                else { //whilst sliding
                    self.b_slide();
                }
            }

            //slide as said, then give back
            this.b_slidenow = function () {
                var check1, maxalpha, curralpha;
                check1 = ptofade.style.MozOpacity;
                maxalpha = (100 - factor * u) / 100 * 105;
                if (check1 <= maxalpha / 100) { u = u + 1; }
                curralpha = 100 - factor * u;
                ptofade.style.filter = "Alpha(Opacity=" + curralpha + ")";
                ptofade.style.MozOpacity = curralpha / 100;
                ptofade.style.opacity = curralpha / 100;
                if (u < steps) { //slide not finished
                    if (stopit == "0") { mytimeout = setTimeout(function () { self.b_slidenow(); }, ftim); }
                    else { this.b_slide(); }
                }
                else { //slide finished
                    if (startim < emax) {
                        ptofade.style.visibility = "hidden";
                        ptofade.style.zIndex = 1;
                        pnext.style.zIndex = 2;
                        startim = startim + 1; u = 0;
                        mytimeout = setTimeout(function () { self.b_slide(); }, stim);
                    }
                    else {
                        ptofade.style.visibility = "hidden";
                        ptofade.style.zIndex = 1;
                        pnext.style.zIndex = 2;
                        startim = 1; u = 0;
                        mytimeout = setTimeout(function () { self.b_slide(); }, stim);
                    }
                }
            }

            //manual start
            this.b_start = function () {
                if (stopit == 1) {
                    stopit = 0;
                    mytimeout = setTimeout(function () { self.b_slide(); }, stim);
                }
            }

            //manual stop
            this.b_stop = function () {
                clearTimeout(mytimeout);
                stopit = 1;
                this.b_slide();
            }

            //insert css and images
            this.b_insert = function () {
                var b, thestylid, thez, thevis, slidehei;
                slidehei = (showcontr) ? (pichei + 25) : (pichei); //add space for the controls
                var myhtml = "<div style='width:" + picwid + "px;height:" + slidehei + "px;'>";
                myhtml += "<div style='position:absolute;width:" + picwid + "px;height:" + pichei + "px;'>";
                for (b = 1; b <= emax; b++) {
                    thez = 1; thevis = 'hidden';
                    if (b <= 1) { thez = 2; thevis = 'visible'; }
                    myhtml += "<div id='img_" + slideid + "_" + b + "' style='font-size:0;line-height:" + pichei + "px;margin:0;padding:0;text-align:center;visibility:" + thevis + ";z-index:" + thez + ";position:absolute;left:0;top:0;width:" + picwid + "px;height:" + pichei + "px;background-color:" + backgr + ";'>";
                    myhtml += "<img src='" + imges[(b - 1)] + "' style='vertical-align:middle;border:0;' alt=''/></div>";
                }
                myhtml += "</div>";
                //show controls
                if (showcontr) {
                    for (b = 1; b <= 4; b++) {
                        var check = contr[b - 1].substring(contr[b - 1].length - 3).toLowerCase(); //check for buttons
                        contr[b - 1] = (check == "jpg" || check == "gif" || check == "png") ? ("<img src='" + contr[b - 1] + "' style='border:none;' alt=''/>") : (contr[b - 1]);
                    }
                    myhtml += "<div style='display:block;width:" + picwid + "px;padding-top:" + (pichei + 3) + "px;text-align:right;'>";
                    myhtml += "<a href='javascript:be_" + slideid + ".b_back();' style='text-decoration:none; display:none;'>" + contr[0] + "</a>&nbsp;";
                    myhtml += "<a href='javascript:be_" + slideid + ".b_start();' style='text-decoration:none; display:none;'>" + contr[1] + "</a>&nbsp;";
                    myhtml += "<a href='javascript:be_" + slideid + ".b_stop();' style='text-decoration:none; display:none;'>" + contr[2] + "</a>&nbsp;";
                    myhtml += "<a href='javascript:be_" + slideid + ".b_forw();' style='text-decoration:none; display:none;'>" + contr[3] + "</a>";
                }
                myhtml += "</div>";
                document.getElementById(divid).innerHTML = myhtml;
                self.b_myfade();
            }

            //call autostart-function
            daisychain(this.b_insert);

        }

        var be_0 = new be_slideshow();

    </script><!--[if IE]><link href="ie.css" rel="stylesheet" type="text/css" /><![endif]-->
    <asp:HiddenField ID="v1" runat="server" Value="1" />
    <div id="mainPlaceholder">
        <!-- main place holder start here -->
        <div class="wrappercontainer">
            <div id="wrapper">
                <!--wrapper start here -->
                <div id="mainInnerContent">
                    <!-- Main Content Starts Here -->
                    <div id="innerLeftPannel">
                        <!-- inner left pannel start here -->
                        <div class="title">
                            <asp:Image ID="vantitle" ImageUrl="~/Images/vanTitle.jpg" runat="server" Style=""
                                AlternateText="" />
                        </div>
                        <div class="vanleftInner">
                           
                            <div class="vanInner">
                                <div id="slideshow" style="width:100%; background: none;">
                                    <img src="pics/2.jpg" />
                                </div>
                                <div id="livesearch" runat="server">
                                    <asp:Label ID="lblShow" runat="server" Text=" "></asp:Label>
                                </div>
                            </div>
                            <div style="clear: both; height: 50px;">
                            </div>
                            <div class="title">
                                <asp:Image ID="vanImgShadow" ImageUrl="~/Images/vanImgShadow.jpg" runat="server"
                                    AlternateText="" />
                            </div>
                            <div class="leftInner">
                                <div class="vanTitle">
                                    <asp:Image ID="fullsalonheader" ImageUrl="~/Images/fullsalonHeader.jpg" runat="server"
                                        AlternateText="" />
                                </div>
                                <div class="innerContent">
                                    <p>
                                        <asp:Literal ID="litContent" runat="server"></asp:Literal>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- inner left pannel end here -->
                    <div id="innerRightPannel">
                        <!-- innere right pannel start here -->
                        <div class="img1">
                            <Z1:Zipcode1 ID="ctlZipcode" runat="server" />
                            <div>
                                <asp:ImageButton ID="imgbtnMakePayment" runat="server" ImageUrl="~/Images/makepayment.gif" Width="236px" Height="100px" OnClick="imgbtnMakePayment_Click" Visible="false" Style="margin-left: 7px" />
                            </div>
                            <Jo:Join ID="asd" runat="server" />
                            <AP:Appointment ID="Ap" runat="server" />
                            <GF:Gift ID="GF" runat="server" />

                            <div class="img">
                                <a href="ComingSoon.aspx"  onclick="javascript:$find('SuggestionBox').show();return false;"  title="GROOMERS BLOG"  >
                                    <img src="images/btn_groomers_blog.jpg" border="0" alt="Groomers Blog" class="groomersBlogImg" /></a>
                            </div>
                            <div class="img">
                                <a href="ComingSoon.aspx"  onclick="javascript:$find('SuggestionBox').show();return false;"  title="PET LOVERS BLOG"  >
                                    <img src="images/btn_pet_lovers_blog.jpg" width="234" height="78" border="0" alt="Pet Lovers Blog" /></a>
                            </div>
                            <Sg:Suggestion ID="ctlSuggestion" runat="server" />
                        </div>
                    </div>
                    <!-- inner right pannel end here -->
                </div>
                <!-- main content end here -->
                <div style="clear: both;">
                </div>
                <div id="mainBottomImg">
                </div>

                <!-- wrapper end here -->
            </div>
        </div>
    </div>
</asp:Content>

