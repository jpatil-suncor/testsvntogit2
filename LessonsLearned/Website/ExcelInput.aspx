<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExcelInput.aspx.cs" Inherits="Website.ExcelInput" %>
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
              
     <script language="javascript" src="/LL/JavaScripts/imgSwap.js" type="text/javascript"></script>

  
	<!-- HEADER -->
	<table class="tableOuter" align="center">
	<tr><td>
    <a href="Default.aspx"><img src="images/hdr_excel.jpg" alt="Lessons Learned Home Page"></a>
	</td></tr>
	<!-- WELCOME LABEL -->
	<tr><td>
     <asp:Label ID="lblWelcome" runat="server" CssClass="fieldLabel" Font-Bold="True" Font-Size="85%" ></asp:Label>            		
	</td></tr>
   </table>  
          
    
    <asp:Label ID="Label2" runat="server" CssClass="fieldLabel" Font-Bold="False" Font-Size="85%"  Width="174px" style="z-index: 101; position: absolute; left: 25px; top: 133px; " >Tips for Uploading file:</asp:Label>
    <asp:Label ID="Label3" runat="server" CssClass="fieldLabel" Font-Bold="False" Font-Size="85%"  Width="661px" style="z-index: 101; position: absolute; left: 50px; top: 153px; " > - File Name Can be anything, worksheet name must be named "Upload" no spaces</asp:Label>
    <asp:Label ID="Label4" runat="server" CssClass="fieldLabel" Font-Bold="False" Font-Size="85%"  Width="863px" style="z-index: 101; position: absolute; left: 49px; top: 174px; " > - Column names must be these with no spaces: Item, Originator, Lesson Learned Title, Lesson Learned Statement, Additional Background, Recommendations, References, Category, Priority, Impact, Frequency, Phases, Processes, SBU, BU, Project</asp:Label>
    

    
    <asp:Label ID="Label9" runat="server" CssClass="fieldLabel" Font-Bold="False" Font-Size="85%"  Width="174px" style="z-index: 101; position: absolute; left: 25px; top: 250px; " >Select Excel File:</asp:Label>
    <asp:FileUpload ID="ExcelFile" runat=server Width="450px" style="z-index: 101;  left: 215px; position: absolute; top: 250px; " />
    <asp:button id="btnInput" runat=server text="Input" style="z-index: 101;  left: 25px; position: absolute; top: 275px; " OnClick="btnInput_Click" />
    
    <asp:CheckBox ID="cbGrid" CssClass="fieldLabel" Font-Bold="False" Font-Size="85%" Text="Check here to view Import results in Grid" style="z-index: 101;  left: 101px; position: absolute; top: 276px; " runat="server" Width="259px" />
    
     <asp:Label ID="lblMsg" Text="" runat="server" style="z-index: 101;  left: 25px; position: absolute; top: 300px; " Height="93px" Width="644px"></asp:Label>
    	<TABLE id="Table4" style="FONT-SIZE: 100%; Z-INDEX: 123; LEFT: 2px; POSITION: absolute; TOP: 400px" cellSpacing="1" cellPadding="1" border="0">
		
				<TR>
					<TD style="FONT-SIZE: 70%; HEIGHT: 1px" align="left" width="100%" colSpan="2" rowSpan="1">
					   
					</TD>
				</TR>
				
				<TR>
					<TD colSpan="2">
					   <asp:datagrid id=dgExcel runat="server" Font-Size="100%" Width="100%" Height="20px" AutoGenerateColumns="False" AllowSorting="True">
							<ALTERNATINGITEMSTYLE CssClass="GridAlternatingItem"></ALTERNATINGITEMSTYLE>
							<ITEMSTYLE CssClass="GridItem"></ITEMSTYLE>
							<HEADERSTYLE CssClass="GridHeader" Font-Bold="True" BackColor="Red" ForeColor="White" HorizontalAlign="Center"></HEADERSTYLE>
							<COLUMNS>
							    <asp:BoundColumn HeaderText="Item" SortExpression="Item" DataField="Item"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Originator" SortExpression="Originator" DataField="Originator"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Lesson Learned Title" SortExpression="Lesson Learned Title" DataField="Lesson Learned Title"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Lesson Learned Statement" SortExpression="Lesson Learned Statement" DataField="Lesson Learned Statement"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Additional Background" SortExpression="Additional Background" DataField="Additional Background" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Recommendations" Sortexpression="Recommendations" DataField="Recommendations" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Category" Sortexpression="Category" DataField="Category" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Priority" Sortexpression="Priority" DataField="Priority" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Impact" Sortexpression="Impact" DataField="Impact" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Frequency" Sortexpression="Frequency" DataField="Frequency" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Phases" Sortexpression="Phases" DataField="Phases" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="SBU" Sortexpression="SBU" DataField="SBU" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="BU" Sortexpression="BU" DataField="BU" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Project" Sortexpression="Project" DataField="Project" ></asp:BoundColumn>
								<asp:BoundColumn HeaderText="References" Sortexpression="References" DataField="References" ></asp:BoundColumn>
						    </COLUMNS>
					   </asp:datagrid>
					</TD>
				</TR>
				<tr>
				    <td>
				        <asp:Label ID="lblSearch" runat="server" CssClass="fieldLabel" Visible="False" Font-Bold="True" Font-Size="85%" Width="827px"></asp:Label>
				    </td>
				</tr>
			</TABLE>
    </form>
</body>
</html>