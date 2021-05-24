<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenericError.aspx.cs" Inherits="Website.GenericError" %>
<%@ Register TagPrefix="cc1" Namespace="PetroCanada.CorpExec.WebControls" Assembly="PetroCanada.CorpExec.WebControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Lessons Learned</title>
    <link rel="stylesheet" type="text/css" href="LLStyles.css">
        <meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
</head>		
<body>
   <form id="Form1" method="post" runat="server">
    
      <div id="_headerImage2" class="headerImage">
     <table id="Table1" style="z-index: 101; left: 8px; width: 100%; position: absolute;
        top: 7px; height: 69px" cellspacing="1" cellpadding="0" width="571" border="0"
        background=".\Images\banner4.gif">
        <tr>
            <td width="5%">
                &nbsp;
            </td>
            <td width="95%">
                <h2 align="center" class="BannerTitle" title="The Letters of Credit System">
                    Lessons Learned <asp:Label ID="lblTitle" runat="server" CssClass="Banner Title"></asp:Label></h2>
            </td>
        </tr>
     </table>
     </div>  
        
     <table id="Table2" style="z-index: 101; left: 8px; width: 100%; position: absolute;
        top: 75px; height: 1px" cellspacing="0" cellpadding="0" width="571" border="0"
        background=".\Images\header_menu_bar.gif">
        <tr>
          <td>
              <asp:Label ID="lblWelcome" runat="server" CssClass="fieldLabel" Font-Bold="True" Font-Size="85%" Width="304px"></asp:Label>
          </td>
          <td style="height: 24px; width: 96%;">
                <table id="Table3" align="center" class="navigationMenuList" border="0" cellpadding="2" cellspacing="0" style="left: -127px; top: 0px">
				 <tr>
				    <td style="height: 23px" align="center" ><a id="A3" class="navigationLink" href="Default.aspx" title="" runat="server">Home</a></td>
					<td style="height: 23px" align="center" ><a id="A1" class="navigationLink" href="Input.aspx" title="" runat="server">Input</a></td>
					<td style="height: 23px" align="center" ><a id="A2" class="navigationLink" href="Search.aspx" title="" runat="server">Search</a></td>
				</tr>   
			    </table>
            </td>
        </tr>
    </table>
    
    
     <asp:Label ID="Label9" runat="server" CssClass="fieldLabel" Font-Bold="False" Font-Size="85%"  Width="338px" style="z-index: 101; position: absolute; left: 25px; top: 150px; " >We're sorry.  An error has occured.</asp:Label>
     <asp:Label ID="Label1" runat="server" CssClass="fieldLabel" Font-Bold="False" Font-Size="85%"  Width="750px" style="z-index: 101; position: absolute; left: 25px; top: 175px; " >A notification has been sent to Tehnical Support. We will attempt to correct the problem within 24 hours. If the problem has not been corrected please Contact us.
     </asp:Label>
     
    </form>
</body>
</html>
