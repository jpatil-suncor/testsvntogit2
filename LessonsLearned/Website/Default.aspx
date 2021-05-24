<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Website._Default" %>
<%@ Register TagPrefix="cc1" Namespace="PetroCanada.CorpExec.WebControls" Assembly="PetroCanada.CorpExec.WebControls" %>
<%@ Register Assembly="Fluent.MultiLineTextBoxValidator" Namespace="Fluent" TagPrefix="cc3" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Lessons Learned</title>
    <link rel="stylesheet" type="text/css" href="LLStyles.css" />
    <meta name="vs_defaultClientScript" content="JavaScript" />
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5" />
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0" />
    <meta name="ProgId" content="VisualStudio.HTML" />
    <meta name="Originator" content="Microsoft Visual Studio.NET 7.0" />
   
    <script type="text/javascript" language="javascript">
        var bookmarkurl="http://corpweb-test/ll/Default.aspx"
		var bookmarktitle="Lessons Learned"

		function addbookmark()
		{
		  if (document.all)
		     window.external.AddFavorite(bookmarkurl,bookmarktitle)
		}
    </script>
    
    <script language="javascript" src="/LL/JavaScripts/popup.js"   type="text/javascript"></script>
    <script language="javascript" src="/LL/JavaScripts/utility.js" type="text/javascript"></script> 
    <script language="javascript" src="/LL/JavaScripts/imgSwap.js" type="text/javascript"></script>
    
</head>
<body>
   <form id="Form1" method="post" runat="server">
  
     

  	<!-- HEADER -->
	<table class="tableOuter" align="center">
	   <tr>
	        <td>
	            <a href="Default.aspx"> <asp:Image ID="imgHeader" runat="server" ImageUrl="images/hdr_lessLearn.jpg" AlternateText="Lessons Learned Home Page" /> </a>
                <!-- <a href="Default.aspx"><img src="images/hdr_lessLearn.jpg" alt="Lessons Learned Home Page"></a> -->
	        </td>
	   </tr>
	    <!-- WELCOME LABEL -->
	    <tr>
	        <td>
                <asp:Label ID="lblWelcome" runat="server" CssClass="fieldLabel" Font-Bold="True" Font-Size="85%" ></asp:Label>            		
	        </td>
	    </tr>
	    <tr>
	        <td>
	            <!-- BODY TEXT -->
	            <table class="tableContent" cellspacing="0" cellpadding="0" border="0">  
	            <tr>
	                <td colspan="3">
	                    <img src="images/spacer.gif" height="100px" width="1px" alt="" />
	                </td>
	            </tr>    
                <tr>
		            <td width="25px">&nbsp;</td>
                    <td>Thank you for supporting the Lessons Learned (LL) Process! Capturing, sharing and applying our experiences is an important responsibility for everyone in Petro-Canada.              </td>
				    <td width="25px">&nbsp;</td>
                </tr>
                <tr>
		            <td>&nbsp;</td>
                    <td>This one-stop site has been developed to manage all of your Lessons Learned requirements including the following:         </td>
			        <td>&nbsp;</td>
                </tr>
		        <tr>
		            <td colspan="3">&nbsp;</td>
		        </tr>
                <tr>
		            <td>&nbsp;</td>
                    <td colspan="2">
                        <!-- <ul> -->
                        <img src="images/bullet.gif" alt="" />detailed information on the Lessons Learned process <br />
                        <img src="images/bullet.gif" alt="" />the ability to input your specific individual lessons learned information quickly on-line<br />
                        <img src="images/bullet.gif" alt="" />meeting guidelines and templates to capture and input group lessons learned workshops<br />
                        <img src="images/bullet.gif" alt="" />the ability to search the extensive database of processed lessons learned<br />
                        <!-- </ul> -->
                    </td>			 
                </tr> 
		        <tr>
		            <td colspan="3">&nbsp;</td>
		        </tr>
		        <tr>
		            <td>&nbsp;</td>
		            <td class="txtsm">Add Lessons Learned to your <a href="javascript:addbookmark()">bookmarks</a></td><td>&nbsp;</td></tr>       
            </table>	
	</td></tr>	
	<tr><td align="center">
    <img src="images/3Rs.jpg" alt="Cheaper, Better, Faster" />
				<!-- <asp:Image ID="img3Rs" runat="server" ImageUrl="images/3Rs.jpg" />	-->
	</td></tr>
	<tr><td>
	</td></tr>
	</table>
	<!-- Navigation table -->
 <div class="centerIt">
    
     <table class="tableNav" cellpadding="0" cellspacing="0">
        <tr>
            <td>
            <a href="Input.aspx" id="A1" title="Input" onmouseover="document.low2.src='images/buttNavOn_02.gif'" onmouseout="document.low2.src='images/buttNavOff_02.gif'">
            <img src="images/buttNavOff_02.gif" name="low2" alt="Input"/></a></td>
            
            <!-- 
             <a href="Input.aspx" id="A1" title="Input" onMouseOver="imgOn('low2')" onMouseOut="imgOff('low2')">
            <img src="images/buttNavOff_02.gif" name="low2" alt="Input"/></a></td>
             -->
            <td>
                <a href="Search.aspx" id="A2" onmouseover="document.low3.src='images/buttNavOn_03.gif'" onmouseout="document.low3.src='images/buttNavOff_03.gif'">
                 <img src="images/buttNavOff_03.gif" name="low3" alt="Search"/>
                </a>
            </td>

            <td><a href="Man.aspx" onmouseover="document.low4.src='images/buttNavOn_04.gif'" onmouseout="document.low4.src='images/buttNavOff_04.gif'" > 
            <img src="images/buttNavOff_04.gif" name="low4" alt="Manuals and Guides"/></a></td>
        </tr>
        <tr>
            <td><a href="Workshop.aspx" onmouseover="document.low5.src='images/buttNavOn_05.gif'" onmouseout="document.low5.src='images/buttNavOff_05.gif'" >
            <img src="images/buttNavOff_05.gif" name="low5" alt="Workshop"/></a></td>

            <td><a href="mailto:ospll@petro-canada.ca?subject=Lessons Learned Question" onmouseover="document.low6.src='images/buttNavOn_06.gif'" onmouseout="document.low6.src='images/buttNavOff_06.gif'" >
            <img src="images/buttNavOff_06.gif" name="low6" alt="Contact"/></a></td>
            
            <td><a href="Learn.aspx" onmouseover="document.low7.src='images/buttNavOn_07.gif'" onmouseout="document.low7.src='images/buttNavOff_07.gif'">
            <img src="images/buttNavOff_07.gif" name="low7" alt="Learn More"/></a></td>
         </tr>                          

    </table>
</div>
</form>  
</body>
</html>


