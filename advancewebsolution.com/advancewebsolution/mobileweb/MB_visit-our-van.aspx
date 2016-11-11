﻿<%@ Page Language="C#" MasterPageFile="Inner_Page_MB_MasterPage.master" AutoEventWireup="true" Inherits="Mobile_MB_visit_our_van" Title="Mobile Grooming Services" Codebehind="MB_visit-our-van.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="contentinnersection">
        <div class="innerpageheading">
            <h1>
                Fritzy Fresh Van</h1>
        </div>
    </div>
    <div class="homebanner1">

        <script type="text/javascript">

            // Flexible Image Slideshow- By JavaScriptKit.com (http://www.javascriptkit.com)
            // For this and over 400+ free scripts, visit JavaScript Kit- http://www.javascriptkit.com/
            // This notice must stay intact for use

            var ultimateshow = new Array()

            //ultimateshow[x]=["path to image", "OPTIONAL link for image", "OPTIONAL link target"]

            ultimateshow[0] = ['../mobileweb/pic/1.png', '', '']
            ultimateshow[1] = ['../mobileweb/pic/2.png', '', '_new']
            ultimateshow[2] = ['../mobileweb/pic/3.png', '', '']
            ultimateshow[3] = ['../mobileweb/pic/4.png', '', '']

            //configure the below 3 variables to set the dimension/background color of the slideshow

            var slidewidth = "320" //set to width of LARGEST image in your slideshow
            var slideheight = "142" //set to height of LARGEST iamge in your slideshow
            var slidecycles = "3" //number of cycles before slideshow stops (ie: "2" or "continous")
            var randomorder = "no" //randomize the order in which images are displayed? "yes" or "no"
            var preloadimages = "yes" //preload images? "yes" or "no"
            var slidebgcolor = ''

            //configure the below variable to determine the delay between image rotations (in miliseconds)
            var slidedelay = 3000

            ////Do not edit pass this line////////////////

            var ie = document.all
            var dom = document.getElementById
            var curcycle = 0

            if (preloadimages == "yes") {
                for (i = 0; i < ultimateshow.length; i++) {
                    var cacheimage = new Image()
                    cacheimage.src = ultimateshow[i][0]
                }
            }

            var currentslide = 0

            function randomize(targetarray) {
                ultimateshowCopy = new Array()
                var the_one
                var z = 0
                while (z < targetarray.length) {
                    the_one = Math.floor(Math.random() * targetarray.length)
                    if (targetarray[the_one] != "_selected!") {
                        ultimateshowCopy[z] = targetarray[the_one]
                        targetarray[the_one] = "_selected!"
                        z++
                    }
                }
            }

            if (randomorder == "yes")
                randomize(ultimateshow)
            else
                ultimateshowCopy = ultimateshow

            function rotateimages() {
                curcycle = (currentslide == 0) ? curcycle + 1 : curcycle
                ultcontainer = '<center>'
                if (ultimateshowCopy[currentslide][1] != "")
                    ultcontainer += '<a href="' + ultimateshowCopy[currentslide][1] + '" target="' + ultimateshowCopy[currentslide][2] + '">'
                ultcontainer += '<img src="' + ultimateshowCopy[currentslide][0] + '" border="0" height="142" width="320">'
                if (ultimateshowCopy[currentslide][1] != "")
                    ultcontainer += '</a>'
                ultcontainer += '</center>'
                if (ie || dom)
                    crossrotateobj.innerHTML = ultcontainer
                if (currentslide == ultimateshow.length - 1) currentslide = 0
                else currentslide++
                if (curcycle == parseInt(slidecycles) && currentslide == 0)
                    return
                setTimeout("rotateimages()", slidedelay)
            }

            if (ie || dom)
                document.write('<div id="slidedom" style="width:' + slidewidth + ';height:' + slideheight + '; background-color:' + slidebgcolor + '"></div>')

            function start_slider() {
                crossrotateobj = dom ? document.getElementById("slidedom") : document.all.slidedom
                rotateimages()
            }

            if (ie || dom)
                window.onload = start_slider

        </script>

    </div>
    <div class="contentinnersection">
        <div class="innercontent">
            <h2>
                <span class="heading">Full Salon on Wheels</span></h2>
            <p>
                The Fritzy Fresh Van is well stocked with state-of-the-art tools, supplies and equipment.
                It is fully self-contained with its own water and power supply. The utility area
                in the rear houses tanks for fresh and used water, plumbing, power distribution
                and storage. The center section is the “Salon”. On the left is the warm water hydrotub
                complete with all of the supplies and accessories to perform the bath portion of
                the Fritzy Fresh Spa Treatment. Directly in the center is the grooming station with
                a hydraulic table, drying blower, ClipperVac and all of the supplies and accessories
                to make your pet Fritzy Fresh!</p>
        </div>
    </div>
</asp:Content>
