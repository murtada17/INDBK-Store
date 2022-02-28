<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="CreatePages.aspx.cs" Inherits="HR_Salaries.Pages.CBS.CreatePages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Label ID="lblMessage" runat="server" Style="font-size: x-large;"></asp:Label>

                            <asp:Panel ID="PalChose" runat="server">
                                <div class="row">
                                    <div class="col-6 col-md-12">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="Page Creater "></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="Panel1" runat="server">
                                    <div class="row">
                                            <div class="col-6 col-md-3">
                                                <asp:Label CssClass="lbl" Width="100%" ID="Label80" runat="server" Text="Table name"></asp:Label>
                                            </div>
                                            <div class="col-6 col-md-3">
                                                <asp:TextBox CssClass="txt" Width="100%" ID="table_name" runat="server" Text=""  TabIndex="1"></asp:TextBox>
                                            </div>
                                            <div class="col-6 col-md-3">
                                                <asp:Label CssClass="lbl" Width="100%" ID="Label81" runat="server" Text="date_year"></asp:Label>
                                            </div>
                                            <div class="col-6 col-md-3">
                                                <asp:TextBox CssClass="txt" Width="100%" ID="date_year" runat="server" Text=""  TabIndex="1"></asp:TextBox>
                                            </div>    
                                    </div>
                           </asp:Panel>




                        <asp:Panel ID="Panel3" runat="server" Visible="true">
                            <div class="col-6 col-md-3">
                                <asp:Button Style="font-size: unset;" ID="btnSend" runat="server" Text="تنفيذ" Width="100%" CssClass="btn btn-success" OnClick="btnSend_Click"  />
                            </div>
                            <br />

                            <div class="col-6 col-md-3">
                                <asp:Button Style="font-size: unset;" ID="btnCancel" runat="server" Text="ألغـــاء" Width="100%" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                            </div>

                        </asp:Panel>




</asp:Content>
