<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="CifPage.aspx.cs" Inherits="HR_Salaries.Pages.PathCif.CifPage" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      
    <asp:Label ID="lblMessage" runat="server" style=" font-size:x-large;" ></asp:Label>
    <div class="content">
        <div class="container">
            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
                        <asp:Panel ID="Panel1" runat="server">


                        <asp:Panel ID="PalChose" runat="server">
                            <div class="row">
                                <div class="col-6 col-md-12" >
                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server"  Text="CIF r" ></asp:Label>             
                                    </div>
                               </div>
                            </asp:Panel>

                          </asp:Panel>
                        <div dir="ltr">
                         <asp:Panel ID="Panel2" runat="server" Visible="true">


                             <!-- Start Chose for Add or Update-->

                            <div class="row">
    <div class="col-6 col-md-5">
        <asp:Button style="font-size: unset;" ID="Button1" runat="server" Text="أضافة" width="100%" CssClass="btn btn-success"  />
    </div>
    <div class="col-6 col-md-1">
        
    </div>
    <div class="col-6 col-md-1">
        
    </div>    
    <div class="col-6 col-md-5">
        <asp:Button style="font-size: unset;" ID="Button2" runat="server" Text="تعديل" width="100%" CssClass="btn btn-success" />
    </div>
    
</div>

                             <!-- End -->
                         
                             


                             <!-- Start -->
<div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server"  Text="COMP_CODE" ForeColor="Red" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="COMP_CODE" runat="server" MaxLength="8" Text="" TabIndex="1" TextMode="Number" required></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server"  Text="BRANCH_CODE" ForeColor="Red" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="BRANCH_CODE" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false" required></asp:DropDownList> 
    </div>    
</div>
 
                          
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server"  Text="CIF_NO" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="CIF_NO" runat="server"  Text="" TextMode="Number" TabIndex="1" required></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label6" runat="server"  Text="SHORT_NAME_ENG" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="SHORT_NAME_ENG" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label7" runat="server"  Text="LONG_NAME_ENG" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="LONG_NAME_ENG" runat="server"  Text=""  TabIndex="1" required ></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label8" runat="server"  Text="SHORT_NAME_ARAB" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="SHORT_NAME_ARAB" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label9" runat="server"  Text="LONG_NAME_ARAB" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="LONG_NAME_ARAB" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label10" runat="server"  Text="Region_code" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="Region_code" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label11" runat="server"  Text="ECO_SECTOR" ForeColor="Red" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        
        <asp:DropDownList ID="ECO_SECTOR" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false" required></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label13" runat="server"  Text="SUB_ECO_SECTOR" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">



        <asp:DropDownList ID="SUB_ECO_SECTOR" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 

            </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label14" runat="server"  Text="COUNTRY" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="COUNTRY" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label15" runat="server"  Text="NATION_CODE" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">

        <asp:DropDownList ID="NATION_CODE" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 

    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label16" runat="server"  Text="RESIDENT" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="RESIDENT" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 

    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label17" runat="server"  Text="TYPE" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="TYPE" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label18" runat="server"  Text="CIF_TYPE" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="CIF_TYPE" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label19" runat="server"  Text="id_no" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="id_no" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label20" runat="server"  Text="Division" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
         <asp:DropDownList ID="Division" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label21" runat="server"  Text="Dept" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="Dept" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 

    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label22" runat="server"  Text="language" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="language" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 

    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label23" runat="server"  Text="additional_reference" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="additional_reference" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label24" runat="server"  Text="first_name_eng" ForeColor="Red" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="first_name_eng" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label25" runat="server"  Text="sec_name_eng" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="sec_name_eng" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label26" runat="server"  Text="third_name_eng" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="third_name_eng" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label27" runat="server"  Text="last_name_eng" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="last_name_eng" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label28" runat="server"  Text="first_name_ar" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="first_name_ar" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label29" runat="server"  Text="sec_name_ar" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="sec_name_ar" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label30" runat="server"  Text="third_name_ar" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="third_name_ar" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label31" runat="server"  Text="last_name_ar" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="last_name_ar" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label32" runat="server"  Text="sexe" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
         <asp:DropDownList ID="sexe" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label33" runat="server"  Text="birth_date" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="birth_date" runat="server"  Text=""  TabIndex="1" required></asp:TextBox> 
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="birth_date"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label34" runat="server"  Text="place_of_birth" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="place_of_birth" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label35" runat="server"  Text="ADD_STRING1" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="ADD_STRING1" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label36" runat="server"  Text="MARITAL_STATUS" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="MARITAL_STATUS" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label37" runat="server"  Text="civil_code" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="civil_code" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label38" runat="server"  Text="id_type" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="id_type" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 

    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label39" runat="server"  Text="PRIORITY_CODE" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="PRIORITY_CODE" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 

    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label40" runat="server"  Text="mother_first_name" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="mother_first_name" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label41" runat="server"  Text="mother_last_name" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="mother_last_name" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label42" runat="server"  Text="Relation_code" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="Relation_code" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label43" runat="server"  Text="Legal_Status" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="Legal_Status" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label44" runat="server"  Text="CIF_PROFILE" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="CIF_PROFILE" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label45" runat="server"  Text="OCCUP_POSITION" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="OCCUP_POSITION" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label46" runat="server"  Text="EDUC_LEVEL" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="EDUC_LEVEL" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label47" runat="server"  Text="RELIGION" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="RELIGION" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label48" runat="server"  Text="MAIL_STMT" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="MAIL_STMT" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label49" runat="server"  Text="PERIOD" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="PERIOD" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label50" runat="server"  Text="MODE_COMM" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="MODE_COMM" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label51" runat="server"  Text="DESCRIPTION" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="DESCRIPTION" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label52" runat="server"  Text="DATE_CREATED" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="DATE_CREATED" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="DATE_CREATED"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label53" runat="server"  Text="CREATED_BY" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="CREATED_BY" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label54" runat="server"  Text="MODIFIED_BY" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="MODIFIED_BY" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label55" runat="server"  Text="DATE_MODIFIED" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="DATE_MODIFIED" runat="server"  Text=""  TabIndex="1"></asp:TextBox>  
        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="DATE_MODIFIED"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label56" runat="server"  Text="APPROVED_BY" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="APPROVED_BY" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label57" runat="server"  Text="DATE_APPROVED" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="DATE_APPROVED" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>  
        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="DATE_APPROVED"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label58" runat="server"  Text="DELETED_BY" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="DELETED_BY" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label59" runat="server"  Text="DATE_DELETED" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="DATE_DELETED" runat="server"  Text=""  TabIndex="1"></asp:TextBox>  
        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="DATE_DELETED"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label60" runat="server"  Text="STATUS" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
         <asp:DropDownList ID="STATUS" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList> 
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label61" runat="server"  Text="ADDRESS1_ENG" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="ADDRESS1_ENG" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label62" runat="server"  Text="ADDRESS2_ENG" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="ADDRESS2_ENG" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label63" runat="server"  Text="ADDRESS3_ENG" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="ADDRESS3_ENG" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label64" runat="server"  Text="ADDRESS4_ENG" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="ADDRESS4_ENG" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label65" runat="server"  Text="ADDRESS1_ARAB" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="ADDRESS1_ARAB" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label66" runat="server"  Text="ADDRESS2_ARAB" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="ADDRESS2_ARAB" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label67" runat="server"  Text="ADDRESS3_ARAB" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="ADDRESS3_ARAB" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label68" runat="server"  Text="ADDRESS4_ARAB" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="ADDRESS4_ARAB" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label69" runat="server"  Text="STREET_DETAILS_ENG" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="STREET_DETAILS_ENG" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label70" runat="server"  Text="TEL" ForeColor="Red"></asp:Label> 
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="TEL" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label71" runat="server"  Text="HOME_TEL" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="HOME_TEL" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label72" runat="server"  Text="WORK_TEL" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="WORK_TEL" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label73" runat="server"  Text="OTHER_TEL" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="OTHER_TEL" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label74" runat="server"  Text="MOBILE" ForeColor="Red" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="MOBILE" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label75" runat="server"  Text="FAX" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="FAX" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label76" runat="server"  Text="EMAIL" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="EMAIL" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label77" runat="server"  Text="PO_BOX" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="PO_BOX" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label78" runat="server"  Text="PASSPORT_NO" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="PASSPORT_NO" runat="server"  Text=""  TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label79" runat="server"  Text="PASSPORT_ISSUE_PLACE" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="PASSPORT_ISSUE_PLACE" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    </div>    </div>
 
                             
                             
   <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label80" runat="server"  Text="PASSPORT_ISSUE_DATE" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="PASSPORT_ISSUE_DATE" runat="server"  Text=""  TabIndex="1"></asp:TextBox>

         <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="PASSPORT_ISSUE_DATE"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>

    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label81" runat="server"  Text="PASSPORT_EXPIRY_DATE" ></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="PASSPORT_EXPIRY_DATE" runat="server"  Text=""  TabIndex="1"></asp:TextBox>    
        <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="PASSPORT_EXPIRY_DATE"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>

     </div>    

   </div>
 

   <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label82" runat="server"  Text="Old_Account" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Old_Account" runat="server"  Text=""  TabIndex="1" required></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
       
    </div>
    <div class="col-6 col-md-3">
            

     </div>    

   </div>

   <div class="row">
    <div class="col-6 col-md-3">

        
         <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server"  Text="Picter" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
       <asp:FileUpload ID="FilePic" runat="server" />
    </div>
    <div class="col-6 col-md-3">
        
       <asp:Label CssClass="lbl" Width="100%" ID="Label12" runat="server"  Text="Signter" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
            <asp:FileUpload ID="FileSic" runat="server" />

     </div>    

   </div>


                             <!-- End -->

                           
                       </asp:Panel>
                                </div>
                        <!-- OnClick -->
                        <br />
                            <div class="col-6 col-md-12">
                                <asp:Button style="font-size: unset;" ID="btnSend" runat="server" Text="تنفيذ" width="100%" CssClass="btn btn-success" OnClick="btnSend_Click" />
                            </div>    
                            <div class="col-6 col-md-3">
                                <asp:Label ID="AddUpdate" runat="server" Text="Label111" Visible="false"></asp:Label>
                            </div>
                            </div>
                            
                         </div>
                     </div>
                 </div>
             </div>
        
    

  
</asp:Content>
