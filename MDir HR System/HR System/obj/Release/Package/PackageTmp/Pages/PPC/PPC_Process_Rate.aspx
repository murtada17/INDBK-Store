<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="PPC_Process_Rate.aspx.cs" Inherits="HR_Salaries.Pages.PPC.PPC_Process_Rate" %>
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
                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server"  Text="العمولة" ></asp:Label>             
                                    </div>
                               </div>
                            </asp:Panel>

                          </asp:Panel>
                        <div dir="rtl">
                       

<asp:Panel ID="RowsData" runat="server" Visible="true">

    
    
    
    <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label7" runat="server"  Text="النسبة (0.001 مثال)" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Process_Commission_Value_percentage" runat="server" Text="" required TabIndex="1" Enabled="true"></asp:TextBox>
    </div>
     
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label8" runat="server"  Text="المبلغ الثابت" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Process_Commission_Value_fixed" runat="server" Text="" required TabIndex="1" Enabled="true"></asp:TextBox>
    </div>    
          

 </div>

     <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server"  Text="أقل مبلغ مقطوع" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:TextBox CssClass="txt" Width="100%" ID="Process_Min_Commission" runat="server" Text="" required TabIndex="1" Enabled="true"></asp:TextBox>
    </div>
     
    <div class="col-6 col-md-3">
    </div>
    <div class="col-6 col-md-3">
    </div>    
          

 </div>

      <div class="row">
    <div class="col-6 col-md-3">
        <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server"  Text="تفعيل النسبة" ForeColor="Red"></asp:Label>
    </div>
    <div class="col-6 col-md-3">
        <asp:CheckBox ID="CB_1" runat="server" OnCheckedChanged="CB_1_CheckedChanged"  AutoPostBack="true"/>
    </div>
     
    <div class="col-6 col-md-3">
    </div>
    <div class="col-6 col-md-3">
    </div>    
          

 </div>
          <div class="row">
    <div class="col-6 col-md-3">
              <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server" Text="تفعيل المبلغ الثابت"></asp:Label>

    </div>
    <div class="col-6 col-md-3">
                <asp:CheckBox ID="CB_2" runat="server" OnCheckedChanged="CB_2_CheckedChanged" AutoPostBack="true"/>

    </div>
     
    <div class="col-6 col-md-3">
        
    </div>
    <div class="col-6 col-md-3">
       
    </div>    
          

 </div>


                             <!-- End -->       
                       </asp:Panel>


                                </div>
                        <!-- OnClick -->
                        <br />


                            <div class="col-6 col-md-12">
                                <asp:Button style="font-size: unset;" ID="btnSend" runat="server" Text="تنفيذ" width="100%" CssClass="btn btn-success" OnClick="btnSend_Click" Visible="true" />
                            </div>    
                         <br />
                         
                        <div class="col-6 col-md-12">
                                <asp:Button style="font-size: unset;" ID="btnCancel" runat="server" Text="ألغـــاء" width="100%" CssClass="btn btn-danger" OnClick="btnCancel_Click" Visible="true" />
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
