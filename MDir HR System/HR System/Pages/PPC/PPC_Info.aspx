<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="PPC_Info.aspx.cs" Inherits="HR_Salaries.Pages.PPC.PPC_Info" %>
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
                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server"  Text="معلومات الزبائن" ></asp:Label>             
                                    </div>
                               </div>
                            </asp:Panel>

                          </asp:Panel>
                        <div dir="rtl">
                         <asp:Panel ID="Panel2" runat="server" Visible="true">


                             <!-- Start Chose for Add or Update-->

                            <div class="row">
    <div class="col-6 col-md-5">
        <asp:Button style="font-size: unset;" ID="ButAdd" runat="server" Text="أضافة" width="100%" CssClass="btn btn-success" OnClick="ButAdd_OnClick"  />
    </div>
    <div class="col-6 col-md-1">
        
    </div>
    <div class="col-6 col-md-1">
        
    </div>    
    <div class="col-6 col-md-5">
        <asp:Button style="font-size: unset;" ID="ButUpdate" runat="server" Text="تعديل" width="100%" CssClass="btn btn-success" OnClick="ButUpdate_OnClick" />
    </div>
    
</div>

                             <!-- End -->
                         
                             


                             <!-- Start Search Panel -->

                              <asp:Panel ID="PalUpdate" runat="server" Visible="false">

                              <div class="row">
                              
                              <div class="col-6 col-md-6" ><asp:TextBox ID="txtUpdate" class="form-control" runat="server" placeholder="رقم الحساب"></asp:TextBox></div>
                              <div class="col-6 col-md-6" style="text-align: right;"><asp:Button style="font-size: unset;" ID="btnSerchUpdate" class="btn btn-primary" runat="server" Text="بحث" OnClick="btnSerchUpdate_Click"  /> </div>
                             <!-- <div class="col-6 col-md-3"> <asp:Label ID="Label18" runat="server" Text="البحث و التعديل عن المواد"></asp:Label> </div> -->
                              <div class="col-6 col-md-3"> </div>
                         </div>


                                                        <div class="row" style="padding: 0px 0px 0px 0px;">
                            <div class="col-md-1">  
                                    </div>
                                                            <!--OnSelectedIndexChanged="GVUpdate_PageIndexChanging"-->
                     <div class="col-md-12">  
                     <asp:GridView ID="GVUpdate" runat="server" BackColor="White" BorderColor="#CCCCCC"
                     BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                     CssClass="table table-striped table-bordered table-condensed"
                     AutoGenerateColumns="False" AutoGenerateDeleteButton="False"
                     AutoGenerateSelectButton="True"  AllowSorting="True" OnSelectedIndexChanged="GVUpdate_SelectedIndexChanged">
                    <EditRowStyle Wrap="false" />
                    <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                    <HeaderStyle BackColor="#5f6b89" Font-Bold="True" ForeColor="White"></HeaderStyle>
                    <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>
                    <RowStyle ForeColor="#000066"></RowStyle>
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                    <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                    <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                    <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                    <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                </asp:GridView>
         </div>
                               <div class="col-md-1">  
                                    </div>
   </div>



                            </asp:Panel>





<asp:Panel ID="RowsData" runat="server" Visible="false">

 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label12" runat="server"  Text="الفرع" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="Branch_No" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server"  Text="المخول -أ-" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="User_code_A" runat="server"  Text="" required TabIndex="1" Enabled="false"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server"  Text="المحول -ب-" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="User_code_B" runat="server"  Text="" required TabIndex="1" Enabled="false"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server"  Text="تاريخ فتح الحساب" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Account_opening_date" runat="server"  Text="" required TabIndex="1" Enabled="true"></asp:TextBox>  
         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Account_opening_date"
         Format="yyyy-MM-dd">
         </cc1:CalendarExtender>
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server"  Text="اسم صاحب الحساب" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Account_name" runat="server"  Text="" required TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label6" runat="server"  Text="رقم الحساب" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Account_number" runat="server"  Text="" required TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label7" runat="server"  Text="IBAN" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="IBAN" runat="server"  Text="0" required TabIndex="1" Enabled="false"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label8" runat="server"  Text="نوع الحساب" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="Account_Type" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label9" runat="server"  Text="العملة" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="Account_currency" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label10" runat="server"  Text="العنوان" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Account_holder_address" runat="server"  Text="" required TabIndex="1"></asp:TextBox>    </div>    </div>
 <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label11" runat="server"  Text="رقم الموبايل" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Account_holder_mobile" runat="server"  Text="" required TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label13" runat="server"  Text="الصنف" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:DropDownList ID="Account_Class" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="Account_Class_SelectedIndexChanged" ></asp:DropDownList>
    </div>    </div>


    <asp:Panel ID="IndOrCom" runat="server" Visible="false">   
    <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label14" runat="server"  Text="اسم صاحب الشركة" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Name_manager" runat="server"  Text="" required TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label15" runat="server"  Text="عنوان صاحب الشركة" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Address_manager" runat="server"  Text="" required TabIndex="1"></asp:TextBox>    </div>    </div>
    <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label16" runat="server"  Text="المهنة" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="profession_manager" runat="server"  Text="" required TabIndex="1"></asp:TextBox>
    </div>
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label17" runat="server"  Text="موبايل صاحب الشركة" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Mobile_manager" runat="server"  Text="" required TabIndex="1"></asp:TextBox>    </div>    </div>
        </asp:Panel>


    </asp:Panel>








                             <!-- End -->

                           
                       </asp:Panel>
                                </div>
                        <!-- OnClick -->
                        <br />


                            <div class="col-6 col-md-12">
                                <asp:Button style="font-size: unset;" ID="btnSend" runat="server" Text="تنفيذ" width="100%" CssClass="btn btn-success" OnClick="btnSend_Click" Visible="false" />
                            </div>    
                         <br />
                         
                        <div class="col-6 col-md-12">
                                <asp:Button style="font-size: unset;" ID="btnCancel" runat="server" Text="ألغـــاء" width="100%" CssClass="btn btn-danger" OnClick="btnCancel_Click" Visible="false" />
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
