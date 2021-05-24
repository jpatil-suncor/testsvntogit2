<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Man.aspx.cs" Inherits="Website.Man" %>
<%@ Register TagPrefix="cc1" Namespace="PetroCanada.CorpExec.WebControls" Assembly="PetroCanada.CorpExec.WebControls" %>
<%@ Register Assembly="Fluent.MultiLineTextBoxValidator" Namespace="Fluent" TagPrefix="cc3" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Lessons Learned</title>
    <link rel="stylesheet" type="text/css" href="LLStyles.css">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="ProgId" content="VisualStudio.HTML">
    <meta name="Originator" content="Microsoft Visual Studio.NET 7.0">
   
</head>
<body>
   <form id="Form1" method="post" runat="server">
  

     <script language="javascript" src="/LL/JavaScripts/imgSwap.js" type="text/javascript"></script>

  
	<!-- HEADER -->
	<table class="tableOuter" align="center">
	    <tr><td>
        <a href="Default.aspx"><img src="images/hdr_man.jpg" alt="Lessons Learned Home Page"></a>
	    </td></tr>
	    <!-- WELCOME LABEL -->
	    <tr><td>
         <asp:Label ID="lblWelcome" runat="server" CssClass="fieldLabel" Font-Bold="True" Font-Size="85%" ></asp:Label>            		
	    </td></tr>
	    <tr>
	    <td>
	    <!-- BODY TEXT -->
	
	<table class="tableMan" cellspacing="0" cellpadding="0" border="0">  
	<tr><td colspan="3"><img src="images/spacer.gif" height="100px" width="1px">
	
	</td></tr>    
        <tr>
		     <td width="25px">&nbsp;</td>
                 <td>
                Following are the Lessons Learned manuals and guides. 
                </td>
			<td width="25px">&nbsp;</td>
        </tr>
        <tr><td colspan="3">&nbsp;</td></tr>
         <tr>
		 <td>&nbsp;</td>
             <td colspan="2">
                 <ul>
                     <img src="images/bullet.gif"><a href="http://pcaportal.pcacorp.net/pls/portal/portal.show_doc_link?p_nav=Y&amp;p_docbase=FortHills&amp;p_docid=09001f988012be39">Lessons Learned Quick Reference Guide.pdf </a><br/>
                     <img src="images/bullet.gif"><a href="http://pcaportal.pcacorp.net/pls/portal/portal.show_doc_link?p_nav=Y&amp;p_docbase=FortHills&amp;p_docid=09001f988012be3a">Lessons Learned Process Map.pdf </a><br/>
                     <img src="images/bullet.gif"><a href="http://pcaportal.pcacorp.net/pls/portal/portal.show_doc_link?p_nav=Y&amp;p_docbase=FortHills&amp;p_docid=09001f988012be3b">Lessons Learned User Manual.pdf </a><br/>                     
                     <img src="images/bullet.gif"><a href="http://pcaportal.pcacorp.net/pls/portal/portal.show_doc_link?p_nav=Y&amp;p_docbase=FortHills&amp;p_docid=09001f988012c17f">Lessons Learned New User Orientation.ppt  </a><br/> 
                 </ul>
             </td>			 
         </tr> 
    </table>
    <br/><br/>
	</td></tr>
 	
	<tr><td>
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
		</td></tr>		
    </table>
</form>  
</body>
</html>


