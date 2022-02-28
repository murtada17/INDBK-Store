<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Disappearance.aspx.cs" Inherits="HR_Salaries.Pages.MSC.Disappearance" %>
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
                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server"  Text="تنفيذ الاندثار" ></asp:Label>             
                                    </div>
                               </div>
                            </asp:Panel>

                          </asp:Panel>
                        <div dir="ltr">
                         <asp:Panel ID="Panel2" runat="server" Visible="true">

                              <div class="row">
                       
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label12" runat="server"  Text="الشهر" ForeColor="Red"></asp:Label>
                            </div>
                                   <div class="col-6 col-md-3">
                                <asp:DropDownList ID="month_DDL" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server"  Text="السنة" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="year_txt" runat="server" MaxLength="8" Text="" required TabIndex="1"></asp:TextBox>
                            
                            </div>

                           
                            </div>
                           
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
