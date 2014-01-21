<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PolarConverter.WF._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
        <div class="infobox">
            <p>
                <b>PolarConverter converts your .xml, .hrm and .gpx files from your Polar&reg; watch
                    to
                    .tcx files that can easily be imported into fitness apps such as Endomondo or Strava.</b>
            </p>
            <p>
                In order to get your .hrm and .gpx files you need to have a Polar&reg; watch that
                is compatible with Polar Pro Trainer&trade;. Export your files from the watch to
                your computer with Polar Pro Trainer&trade;, and use those files to convert with
                PolarConverter. You'll usually find your .hrm and .gpx files under C:\Users\{user}\AppData\Local\VirtualStore\Program
                Files (x86)\Polar\Polar ProTrainer\{polar user}. Xml files can be downloaded from
                your account at <a href="https://www.polarpersonaltrainer.com/" target="_blank">https://www.polarpersonaltrainer.com/.</a>
            </p>
            <p>
                Visit Polar's homepage to see a list of Polar Pro Trainer&trade; compatible Polar&reg;
                products:<br />
                <a href="http://www.polar.fi/en/support/Polar_Products_Compatible_with_Polar_ProTrainer_5?product_id=446&category=faqs"
                   target="_blank">Polar Pro Trainer&trade; compatible watches.</a>
            </p>
            <p>
                Connect to your Dropbox account and place your .hrm and .gpx in the Apps/PolarConverter
                folder in your Dropbox folder.
            </p>
            <p>
                Any questions or comments?<br />
                <a href="mailto:polarconverter@gmail.com">Contact me</a><br />
            </p>
            <a rel="nofollow" href="http://www.facebook.com/share.php?u=http://www.facebook.com/sharer/sharer.php?u=http://polarconverter.azurewebsites.net/&t=Convert%20your%20Polar%20files%20with%20PolarConverter"
               class="fb_share_button" onclick="return fbs_click()" target="_blank" style="text-decoration: none;">
                Share</a><br/>
            <br/>
        </div>
</asp:Content>
