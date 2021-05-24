<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Input.aspx.cs" Inherits="Website.Input" %>
<%@ Register Assembly="Fluent.MultiLineTextBoxValidator" Namespace="Fluent" TagPrefix="cc3" %>
<%@ Register TagPrefix="cc1" Namespace="PetroCanada.CorpExec.WebControls" Assembly="PetroCanada.CorpExec.WebControls" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Lessons Learned</title>
    <link rel="stylesheet" type="text/css" href="LLStyles.css" />
        <meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
</head>
<body >
 <form id="form1" runat="server">    
    <script language="javascript" src="/LL/JavaScripts/llscript.js" type="text/javascript"></script>
    <script language="javascript" src="/LL/JavaScripts/utility.js" type="text/javascript"></script>
    <script language="javascript" src="/LL/JavaScripts/popup.js" type="text/javascript"></script>
    <script language="javascript" src="/LL/JavaScripts/dFilter.js" type="text/javascript"> </script>
    <script language="javascript" src="/LL/JavaScripts/imgSwap.js" type="text/javascript"></script>
    
<script type="text/javascript">
function ValidatorOnLoad() {
//  alert("hola");
}
</script>

<!--OUTER CONTAINER TABLE -->
<table cellpadding="0" cellspacing="0" border="0" width="100%" style="height: 100%">
<tr><td valign="top">

	<!-- HEADER -->
	<table class="tableOuter"  align="center">
	<tr><td>
	<!--<asp:Image ID="imgHeader" runat="server" ImageUrl="images/hdr_lessLearn.jpg" /> --> 
    <a href="Default.aspx"><img src="images/hdr_input.jpg" alt="Lessons Learned Home Page" /></a>   
  </td></tr>
  
 	<!-- WELCOME LABEL -->
	<tr><td>
     <asp:Label ID="lblWelcome" runat="server" CssClass="fieldLabel" Font-Size="85%" ></asp:Label>          		
	</td></tr> 
	</table> 
    
 </td></tr>
 <tr>
 <td valign="top">   
    <table width="100%" cellspacing="0" style="z-index: 101;  left: 25px; width: 100%; position: absolute; top: 145px;">
	    <tr>
	        <td class="CellEdit"> 
		        <table cellspacing="0" style="width: 774px">
		        <tr>
		            <td colspan="2" class="ButtonRow">
					    <asp:button id="btnBack" runat="server" text="<< Back" causesvalidation="false" />
					    <asp:button id="btnNext" runat="server" text="Next >>" causesvalidation="false" />
					    &nbsp;&nbsp;&nbsp;
					    <asp:button id="btnCancel" runat="server" text="Cancel" causesvalidation="false" />
						<asp:button id="btnSave" runat="server" text="Save" causesvalidation="false" enabled="false" ToolTip="After saving you will have the option to Print or Save File As." />&nbsp;&nbsp;
				    </td>
				    <td>
				        <asp:button id="exceltemplate" runat="server" text="Import Excel Template" causesvalidation="False" enabled="true" Visible="false" OnClick="exceltemplate_Click" Width="139px" />
				    </td>				
		        </tr>
                <tr>
                    <td class="ButtonRow" colspan="2" />                
                </tr>
                </table>
           </td>
        </tr>
        <!-- <tr>
		        <td colspan="2" style="height: 26px">
                    <cc1:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="ErrorMessage" Height="1px" />
                </td>
		    </tr>
		 -->
    </table>  
 		
	<asp:panel id="panel1" Visible="true" runat="server"  >
		    
	          <!-- LEFT COLUMN -->
             <asp:Label ID="Label25" runat="server" CssClass="fieldLabel" Font-Bold="false" Font-Size="75%"  Width="645px" style="z-index: 999;  left: 25px; position: absolute;  top: 170px;" Text="<%$ Resources:mandatorystatement %>"/>
             
	          
	         <asp:Label ID="Label9" runat="server" CssClass="fieldLabel"  Font-Bold="True"    Width="165px" style="z-index: 101; position: absolute; left: 25px; top: 200px;" Text="<%$ Resources:FirstName %>" />:
             <asp:TextBox ID="txtFirstName" runat="server"  Height="20px" TabIndex="10" ToolTip="" Width="145px" style="z-index: 101;  left: 150px; position: absolute; top: 200px; "></asp:TextBox>
             <asp:Label ID="Label1" runat="server" CssClass="fieldLabel" Font-Bold="True"   Width="165px" style="z-index: 101;  left: 25px; position: absolute; top: 225px;" Text="<%$ Resources:LastName %>" >:</asp:Label>
             <asp:TextBox ID="txtLastName" runat="server"   Height="20px" TabIndex="20" ToolTip="" Width="145px" style="z-index: 101;  left: 150px; position: absolute; top: 225px; "></asp:TextBox>
             <asp:Label ID="Label2" runat="server" CssClass="fieldLabel" Font-Bold="True"   Width="165px" style="z-index: 101;  left: 25px; position: absolute;  top: 250px;" Text="<%$ Resources:PhoneNumber %>">:</asp:Label>
             <asp:TextBox ID="txtPhone" onKeyDown="javascript:return dFilter (event.keyCode, this, '(###) ###-####');"  style="z-index: 101;  left: 150px; position: absolute; top: 250px; " runat="server"   Height="20px" TabIndex="30" ToolTip="" Width="145px"></asp:TextBox>
             <asp:Label ID="Label3" runat="server" CssClass="fieldLabel" Font-Bold="False"   Width="165px" style="z-index: 101;  left: 25px; position: absolute; top: 275px;" Text="<%$ Resources:Location %>">:</asp:Label>
             <asp:TextBox ID="txtLocation" runat="server"   Height="20px" TabIndex="40" ToolTip="" Width="145px" style="z-index: 101;  left: 150px; position: absolute; top: 275px; "></asp:TextBox>
             <asp:Label ID="Label11" runat="server" CssClass="fieldLabel" Font-Bold="True"   Width="165px" style="z-index: 101;  left: 25px; position: absolute;  top: 300px;" Text="<%$ Resources:SBU %>">:</asp:Label>
             <asp:DropDownList ID="ddlSBU" runat="server" TabIndex="50" Width="150px" style="z-index: 101;  left: 150px; position: absolute; top: 300px; " DataSource="<%# dvSBU %>" DataTextField="NAME" DataValueField="LL_SBU_ID"></asp:DropDownList>
             
	         <asp:Label ID="Label12" runat="server" CssClass="fieldLabel" Font-Bold="True"   Width="165px" style="z-index: 101;  left: 25px; position: absolute; top: 325px;" Text="<%$ Resources:BusinessUnit %>">:</asp:Label>
             <asp:DropDownList ID="ddlBU" runat="server" TabIndex="50" Width="275px"  AutoPostBack="true" style="z-index: 101;  left: 150px; position: absolute; top: 325px; " DataSource="<%# dvBU %>" DataTextField="NAME" DataValueField="LL_BU_ID" OnSelectedIndexChanged="ddlBU_SelectedIndexChanged"></asp:DropDownList>
	         <asp:Label ID="Label28" runat="server" CssClass="fieldLabel" Font-Bold="True"   Width="165px" style="z-index: 101;  left: 25px; position: absolute; top: 350px; " Text="<%$ Resources:ProjectName %>">:</asp:Label>
             <asp:DropDownList ID="ddlProject" runat="server" TabIndex="50" Width="225px" style="z-index: 101;  left: 150px; position: absolute; top: 350px; " DataSource="<%# dvProject %>" DataTextField="NAME" DataValueField="LL_PROJECT_ID"></asp:DropDownList>
             <asp:Label ID="Label29" runat="server" CssClass="fieldLabel" Font-Bold="False"   Width="35px" style="z-index: 101; text-align: right; left: 25px; position: absolute; top: 375px;" Text="<%$ Resources:Other %>" >:</asp:Label>
             <asp:TextBox ID="txtOther" runat="server"   Height="20px" TabIndex="60" ToolTip="" Width="150px" style="z-index: 101; left: 150px;  position: absolute; top: 375px; " ></asp:TextBox>
            
             <asp:Label ID="Label30" runat="server" CssClass="fieldLabel" Font-Bold="True"   Width="165px" style="z-index: 101;  left: 25px; position: absolute; top: 400px;" Text="<%$ Resources:LessonTitle %>" >:</asp:Label>
             <asp:Image ID="imgTitle" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 135px; position: absolute;  top: 400px; "  />
             <asp:TextBox ID="txtTitle" MaxLength="0" TextMode="MultiLine" CssClass="fieldLabel" Font-Bold="false" runat="server"   Height="60px" TabIndex="70" ToolTip="" Width="350px" style="z-index: 101;  left: 150px; position: absolute; top: 400px; " ></asp:TextBox>
        &nbsp;<cc3:MultiLineTextBoxValidator ID="MultiLineTextBoxValidator4" 
                        ControlToValidate="txtTitle" 
                        OutputControl="txtTitleOutput" 
                        runat="server" 
                        EnableClientSideRestriction="True"
                        MaxLength="100" 
                        ShowJavascriptAlert="false"
                        ErrorMessage="You have exceed the maximum length of 100, for Title"
                        ShowCharacterCount="True">
             </cc3:MultiLineTextBoxValidator>     
            
             <asp:TextBox ID="txtTitleOutput" width="35px" runat="server" style="z-index: 101;  left: 150px; position: absolute; top: 465px; " /> 
             <asp:Label ID="Label4" runat="server" CssClass="fieldLabel" Font-Bold="false"  Width="365px" style="z-index: 101;  left: 188px; position: absolute;  top: 465px;" Text="<%$ Resources:titlecharacters %>" ></asp:Label>
             
             <asp:Label ID="Label31" runat="server" CssClass="fieldLabel" Font-Bold="True"   Width="165px" style="z-index: 101;  left: 25px; position: absolute;  top: 490px;" Text="<%$ Resources:Statement %>">: </asp:Label>
             <asp:Image ID="imgStatement" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 135px; position: absolute;  top: 490px; " />
             <asp:TextBox ID="txtStatement" MaxLength="300" TextMode="MultiLine" CssClass="fieldLabel" Font-Bold="false" runat="server"   Height="75px" TabIndex="80" ToolTip="" Width="350px" style="z-index: 101;  left: 150px; position: absolute;  top: 490px; " ></asp:TextBox>
            
             <cc3:MultiLineTextBoxValidator ID="MultiLineTextBoxValidator3" 
                        ControlToValidate="txtStatement" 
                        OutputControl="txtStateOutput" 
                        runat="server" 
                        EnableClientSideRestriction="True"
                        MaxLength="300" 
                        ShowJavascriptAlert="false"
                        ErrorMessage="You have exceed the maximum length of 1000, for Additional Background"
                        ShowCharacterCount="True">
             </cc3:MultiLineTextBoxValidator>     
             <asp:TextBox ID="txtStateOutput" width="35px" runat="server" style="z-index: 101;  left: 150px;  position: absolute; top: 570px; " /> 
             <asp:Label ID="Label16" runat="server" CssClass="fieldLabel" Font-Bold="false"  Width="365px" style="z-index: 101;  left: 188px; position: absolute; top: 570px;" Text="<%$ Resources:statementcharacters %>"  > characters remaining for statement</asp:Label>
             
             
             <asp:Label ID="Label32" runat="server" CssClass="fieldLabel" Font-Bold="false"   Height="35px" Width="165px" style="z-index: 101;  left: 25px; position: absolute; top: 595px;" Text="<%$ Resources:Additional %>" ></asp:Label>
             <asp:Image ID="imgBackground" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 135px; position: absolute; top: 595px; " />
             <asp:Label ID="Label18" runat="server" CssClass="fieldLabel" Font-Bold="false"   Height="35px" Width="165px" style="z-index: 101;  left: 25px; position: absolute;  top: 610px;" Text="<%$ Resources:background %>" >:</asp:Label>
             <asp:TextBox ID="txtBackground" MaxLength="500" TextMode="MultiLine" CssClass="fieldLabel" Font-Bold="false" runat="server"   Height="75px" TabIndex="90" ToolTip="" Width="350px" style="z-index: 101;  left: 150px; position: absolute; top: 595px; " ></asp:TextBox>
             <cc3:MultiLineTextBoxValidator ID="MultiLineTextBoxValidator2" 
                        ControlToValidate="txtBackground" 
                        OutputControl="txtBackOutput" 
                        runat="server" 
                        EnableClientSideRestriction="True"
                        MaxLength="1000" 
                        ShowJavascriptAlert="false"
                        ErrorMessage="You have exceed the maximum length of 1000, for Additional Background"
                        ShowCharacterCount="True">
             </cc3:MultiLineTextBoxValidator>     
             <asp:TextBox ID="txtBackOutput" width="35px" runat="server" style="z-index: 101;  left: 150px; position: absolute; top: 675px; " /> 
             <asp:Label ID="Label14" runat="server" CssClass="fieldLabel" Font-Bold="false"   Width="365px" style="z-index: 101;  left: 188px; position: absolute; top: 675px; " Text="<%$ Resources:additionalstatement %>" >characters remaining for additional background</asp:Label>
             
             <!-- RIGHT COLUMN -->
             <asp:Label ID="Label5" runat="server" CssClass="fieldLabel" Font-Bold="False"   Width="125px" style="z-index: 101;  left: 510Px; position: absolute; top: 200px;" Text="<%$ Resources:type %>" >:</asp:Label>
             <asp:Image ID="imgType" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 630px;  position: absolute; top: 200px; " />               
             <asp:DropDownList ID="ddlType" runat="server" TabIndex="110" Width="125px" style="z-index: 1;  left: 645px; position: absolute; top: 200px; " DataSource="<%# dvType %>" DataTextField="NAME" DataValueField="LL_OCCURRENCE_TYPE_ID"></asp:DropDownList>
             <asp:Label ID="Label22" runat="server" CssClass="fieldLabel" Font-Bold="False"   Width="35px" style="z-index: 101;  left: 800px; position: absolute;  top: 200px; " Text="<%$ Resources:other %>" >:</asp:Label>
             <asp:TextBox ID="txtTypeOther" runat="server"   Height="20px" TabIndex="60" ToolTip="" Width="135px" style="z-index: 101;  left: 835px; position: absolute; top: 200px; " ></asp:TextBox>
             
             <asp:Label ID="Label6" runat="server" CssClass="fieldLabel" Font-Bold="False"   Width="125px" style="z-index: 101;  left: 510px; position: absolute; top: 225px;" Text="<%$ Resources:priority %>">:</asp:Label> 
             <asp:Image ID="imgImpact" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 630px;  position: absolute; top: 225px; " />               
             <asp:DropDownList ID="ddlImpact" runat="server" TabIndex="120" Width="125px" style="z-index: 1;  left: 645px; position: absolute;  top: 225px; " DataSource="<%# dvImpact %>" DataTextField="NAME" DataValueField="LL_OCCURRENCE_IMPACT_ID" Font-Underline="False" ></asp:DropDownList>
             <asp:Label ID="Label19" runat="server" CssClass="fieldLabel" Font-Bold="False"   Width="36px" style="z-index: 101;  left: 775px; position: absolute; text-align: right; top: 225px;" Text="<%$ Resources:impact %>">:</asp:Label> 
             <asp:Image ID="imgFinImpact" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 820px;  position: absolute; top: 225px; " />               
             <asp:DropDownList ID="ddlFinancialImpact" runat="server" TabIndex="120" Width="100px" style="z-index: 1;  left: 835px; position: absolute;  top: 225px; " DataSource="<%# dvFinancialImpact %>" DataTextField="NAME" DataValueField="LL_FINANCIAL_IMPACT_ID" Font-Underline="False" ></asp:DropDownList>
             
             <asp:Label ID="Label7" runat="server" CssClass="fieldLabel" Font-Bold="False"   Width="125px" style="z-index: 101;  left: 510px;  position: absolute;  top: 250px;" Text="<%$ Resources:frequency %>">:</asp:Label>
             <asp:Image ID="imgFrequency" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 630px;  position: absolute; top: 250px; " />               
             <asp:DropDownList ID="ddlFrequency" runat="server" TabIndex="130" Width="145px" style="z-index: 1;  left: 645px; position: absolute;  top: 250px; " DataSource="<%# dvFrequency %>" DataTextField="NAME" DataValueField="LL_OCCURRENCE_FREQUENCY_ID"></asp:DropDownList>
            
             <asp:Label ID="Label8" runat="server" CssClass="fieldLabel" Font-Bold="True"   Width="165px" style="z-index: 101;  left: 508px;  position: absolute; top: 275px;" Text="<%$ Resources:recommendations %>">:</asp:Label>
             <asp:Image ID="imgRecommendations" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 631px;  position: absolute; top: 275px; " />               
             <asp:TextBox ID="txtRecommendations"  TextMode="MultiLine" CssClass="fieldLabel" Font-Bold="false" runat="server"   Height="75px" TabIndex="95" ToolTip="" Width="337px" style="z-index: 101;  left: 645px;  position: absolute; top: 275px; "></asp:TextBox>
             <cc3:MultiLineTextBoxValidator ID="MultiLineTextBoxValidator1" 
                        ControlToValidate="txtRecommendations" 
                        OutputControl="txtRecomOutput" 
                        runat="server" 
                        EnableClientSideRestriction="True"
                        MaxLength="500" 
                        ShowJavascriptAlert="false"
                        ErrorMessage="You have exceed the maximum length of 500, for Recommendations"
                        ShowCharacterCount="True">
             </cc3:MultiLineTextBoxValidator>     
             <asp:TextBox ID="txtRecomOutput" width="35px" runat="server" style="z-index: 101;  left: 645px;  position: absolute; top: 355px; "/>
             <asp:Label ID="Label13" runat="server" CssClass="fieldLabel" style="z-index: 101;  left: 683px;  position: absolute; top: 355px; " Font-Bold="false"   Width="300px" Text="<%$ Resources:recommendationsstatement %>"/>
            
             <asp:Label ID="Label23" runat="server" CssClass="fieldLabel" Font-Bold="false"   Width="165px" style="z-index: 101;  left: 510px;  position: absolute; top: 380px;" Text="<%$ Resources:Reference %>">:</asp:Label>
             <asp:Image ID="imgReference" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 630px;  position: absolute; top: 380px; " />               
             <asp:TextBox ID="txtReference"  TextMode="MultiLine" runat="server" CssClass="fieldLabel" Font-Bold="false"   Height="75px" TabIndex="95" ToolTip="" Width="335px" style="z-index: 101;  left: 645px;  position: absolute; top: 380px; "></asp:TextBox>
             <cc3:MultiLineTextBoxValidator ID="MultiLineTextBoxValidator5" 
                        ControlToValidate="txtReference" 
                        OutputControl="txtRefOutput" 
                        runat="server" 
                        EnableClientSideRestriction="True"
                        MaxLength="500" 
                        ShowJavascriptAlert="false"
                        ErrorMessage="You have exceed the maximum length of 500, for Recommendations"
                        ShowCharacterCount="True">
             </cc3:MultiLineTextBoxValidator>     
            <asp:TextBox ID="txtRefOutput" width="35px" runat="server" style="z-index: 101;  left: 645px;  position: absolute; top: 460px; "/>
            <asp:Label ID="Label24" runat="server" CssClass="fieldLabel" style="z-index: 101;  left: 683px;  position: absolute; top: 460px; " Font-Bold="false" Width="300px" Text="<%$ Resources:referencesstatement %>"/>
              
            <asp:Label ID="Label10" runat="server" CssClass="fieldLabel" style="z-index: 101;  left: 25px;  position: absolute; top: 700px; " Font-Bold="false" Font-Size="85%" Width="500px" Text="<%$ Resources:fileattachments %>">:</asp:Label>
            <asp:Image ID="imgFileUpload" runat="server" ImageUrl="~/Images/info.gif" style="z-index: 101;  left: 148px;  position: absolute; top: 700px; " />               
	        <asp:Label ID="Label20" runat="server" CssClass="fieldLabel" style="z-index: 101;  left: 25px;  position: absolute; top: 775px; " Font-Bold="False" Font-Size="85%" Width="20px" Height="21px">1)</asp:Label>
            <asp:TextBox ID="txtFile1" width="450px" Enabled="false" runat="server" style="z-index: 101;  left: 45px;  position: absolute; top: 775px; "/>            	        
            <asp:button id="btnFile1" runat="server" text="del" causesvalidation="False" style="z-index: 101;  left: 500px;  position: absolute; top: 775px; " OnClick="btnFile1_Click" />
            
            <asp:Label ID="Label21" runat="server" CssClass="fieldLabel" style="z-index: 101;  left: 25px;  position: absolute; top: 800px; " Font-Bold="False" Font-Size="85%" Width="20px" Height="21px">2)</asp:Label>
	        <asp:TextBox ID="txtFile2" width="450px" Enabled="false" runat="server" style="z-index: 101;  left: 45px;  position: absolute; top: 800px; "/>            	        
	        <asp:button id="btnFile2" runat="server" text="del" causesvalidation="False" style="z-index: 101;  left: 500px;  position: absolute; top: 800px; " OnClick="btnFile2_Click" />	       
	        
	        <asp:button id="btnUpload" runat="server" text="Upload" causesvalidation="False" style="z-index: 101;  left: 25px;  position: absolute; top: 750px; " OnClick="btnUpload_Click" />	       
	        <asp:FileUpload ID="FileUpload3"  EnableViewState="true" runat="server" Width="450px" style="z-index: 101;  left: 25px; position: absolute; top: 725px; " />
	        
	        
	        <asp:FileUpload ID="FileUpload4" Visible="false"  EnableViewState="true" runat="server" Width="500px"/>
              
            <cc1:ValidationSummary ID="ValidationSummary11" runat="server" CssClass="ErrorMessage" Height="74px" style="z-index: 101;  left: 510px;  position: absolute; top: 500px; ">
                    </cc1:ValidationSummary> 
              
	</asp:panel>
	<asp:Panel id="panel2" Visible="false" runat="server" >
	    
	        <asp:Label ID="Label17" runat="server" CssClass="fieldLabel" style="z-index: 101;  left: 25px;  position: absolute; top: 200px; " Font-Bold="false"   Width="670px" Text="<%$ Resources:helpProcesses %>" />
    	    <asp:datagrid id="dgSubjectMatter" runat="server" Height="25px" AutoGenerateColumns="False" AllowSorting="True" Width="200px" style="z-index: 101;  left: 25px; position: absolute; top: 225px; " >
			    <ALTERNATINGITEMSTYLE CssClass="GridAlternatingItem"></ALTERNATINGITEMSTYLE>
			    <ITEMSTYLE CssClass="GridItem"></ITEMSTYLE>
			    <HEADERSTYLE CssClass="GridHeader" Font-Bold="True" BackColor="Red" ForeColor="White" HorizontalAlign="Center"></HEADERSTYLE>
			    <COLUMNS>
			        <asp:BoundColumn Visible="false" HeaderText="Subject Matter ID" SortExpression="" DataField="ll_subject_matter_id"></asp:BoundColumn>
			        <asp:TemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15px">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelection" Runat="server" />
                    </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn Visible="true" HeaderText="<%$ Resources:processAffected %>" HeaderStyle-Width="15px" SortExpression="NAME" DataField="NAME"></asp:BoundColumn>
			    </COLUMNS>
            </asp:datagrid>	
            
            <asp:datagrid id="dgStages" runat="server"  Height="25px" AutoGenerateColumns="False" AllowSorting="True" Width="200px" style="z-index: 101;  left: 250px; position: absolute; top: 225px; " >
				<ALTERNATINGITEMSTYLE CssClass="GridAlternatingItem"></ALTERNATINGITEMSTYLE>
				<ITEMSTYLE CssClass="GridItem"></ITEMSTYLE>
				<HEADERSTYLE CssClass="GridHeader" Font-Bold="True" BackColor="Red" ForeColor="White" HorizontalAlign="Center"></HEADERSTYLE>
				<COLUMNS>
					<asp:BoundColumn Visible="false" HeaderText="Project Stage ID" SortExpression="" DataField="ll_project_stage_id"></asp:BoundColumn>
				    <asp:TemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15px">
                           <ItemTemplate>
                                <asp:CheckBox ID="chkSelection" Runat="server" />
                            </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn Visible="true" HeaderText="<%$ Resources:projectPhase %>" HeaderStyle-Width="15px" SortExpression="NAME" DataField="NAME"></asp:BoundColumn>
					</COLUMNS>
	            </asp:datagrid>	 
	          
            <asp:datagrid id="dgCategory" runat="server" Font-Size="100%"  Height="25px" AutoGenerateColumns="False" AllowSorting="True" Width="200px" style="z-index: 101;  left: 500px; position: absolute; top: 225px; ">
				<ALTERNATINGITEMSTYLE CssClass="GridAlternatingItem"></ALTERNATINGITEMSTYLE>
				<ITEMSTYLE CssClass="GridItem"></ITEMSTYLE>
				<HEADERSTYLE CssClass="GridHeader" Font-Bold="True" BackColor="Red" ForeColor="White" HorizontalAlign="Center"></HEADERSTYLE>
				<COLUMNS>
				    <asp:BoundColumn Visible="false" HeaderText="Category ID" SortExpression="" DataField="ll_category_id"></asp:BoundColumn>
				    <asp:TemplateColumn HeaderText="" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15px">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelection" Runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn Visible="true" HeaderText="<%$ Resources:category %>" HeaderStyle-Width="15px" SortExpression="NAME" DataField="NAME"></asp:BoundColumn>
				</COLUMNS>
            </asp:datagrid>      
	      
	</asp:Panel>
	
</td></tr>	
<tr><td style="height: 173px">

	<!-- Navigation table -->
 <asp:panel id="panelNav" Visible="true" runat="server" HorizontalAlign="Center" width="100%" style="z-index: 101; position:absolute; top: 850px; " >
    <table class="tableNav" cellpadding="0" cellspacing="0" >
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
</asp:panel>


</td> </tr>
</table>
	
	
</form>

<iframe id="thehideframe" src="" class="frmcls" style="display: none;"></iframe>
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 51px; width: 880px; top: 554px;" class="popup" id="title">
        <asp:Localize  runat="server" Text="<%$ Resources:helpTitle %>" />
    </div>
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 41px; width: 870px; top: 530px;" class="popup" id="statement">
        <asp:Localize ID="Localize1"  runat="server" Text="<%$ Resources:helpStatement %>" />
    </div>
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 72px; width: 861px; top: 418px; height: 180px;" class="popup" id="background">
       <asp:Localize ID="Localize2"  runat="server" Text="<%$ Resources:helpBackground %>" />
    </div>
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 45px; width: 373px; top: 390px;" class="popup" id="recommendation">
      <asp:Localize ID="Localize3"  runat="server" Text="<%$ Resources:helpRecommendation %>" />
    </div>
    
     <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 43px; width: 373px; top: 392px;" class="popup" id="reference">
         <asp:Localize ID="Localize4"  runat="server" Text="<%$ Resources:helpReference %>" />
    </div>
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 39px; width: 438px; top: 454px;" class="popup" id="help">
        Please place your mouse over the 'i' icons for more information on that item.
    </div>
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 39px; width: 438px; top: 454px;" class="popup" id="fileupload">
       <asp:Localize ID="Localize5"  runat="server" Text="<%$ Resources:helpFileAttachement %>" />
    </div>
    
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 39px; width: 438px; top: 454px;" class="popup" id="type">
        <asp:Localize ID="Localize6"  runat="server" Text="<%$ Resources:helpType %>" />
    </div>
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 39px; width: 438px; top: 454px;" class="popup" id="impact">
       <asp:Localize ID="Localize7"  runat="server" Text="<%$ Resources:helpImpact %>" />
    </div>
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 39px; width: 438px; top: 454px;" class="popup" id="frequency">
        <asp:Localize ID="Localize8"  runat="server" Text="<%$ Resources:helpFrequency %>" />
    </div>
    <div onclick='event.cancelBubble = true;' style="z-index: 999; left: 53px; width: 223px; top: 365px;" class="popup" id="Kimpact">
        <asp:Localize ID="Localize9"  runat="server" Text="<%$ Resources:helpImpact %>" />
    </div>
    
       
   
</body>
</html>