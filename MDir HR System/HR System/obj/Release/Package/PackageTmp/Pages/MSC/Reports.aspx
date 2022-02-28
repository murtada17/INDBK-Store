<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="HR_Salaries.Pages.MSC.Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <asp:Label ID="lblMessage" runat="server" Style="font-size: x-large;"></asp:Label>
    <div class="content">
        <div class="container">
            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
                        <asp:Panel ID="Panel1" runat="server">

                            <asp:Panel ID="PalChose" runat="server">
                                <div class="row">
                                    <div class="col-6 col-md-12">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="سحب التقرير"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>

                        </asp:Panel>
                        <div dir="ltr">
                            <asp:Panel ID="Panel2" runat="server" Visible="true">
                                <div class="row">

                                    <div class="col-6 col-md-3">
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server" Text="المادة" ForeColor="Red"></asp:Label>
                                    </div>
                                    <div class="col-6 col-md-3">
                                        <asp:DropDownList ID="groupid" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
                                    </div>
                                    <div class="col-6 col-md-3">
                                    </div>
                                    <div class="col-6 col-md-3">
                                    </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-6 col-md-3">
                                            <asp:Label CssClass="lbl" Width="100%" ID="Label12" runat="server" Text="الشهر" ForeColor="Red"></asp:Label>
                                        </div>
                                        <div class="col-6 col-md-3">
                                            <asp:DropDownList ID="month_DDL" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
                                        </div>
                                        <div class="col-6 col-md-3">
                                            <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server" Text="السنة" ForeColor="Red"></asp:Label>
                                        </div>
                                        <div class="col-6 col-md-3">
                                            <asp:TextBox CssClass="txt" Width="100%" ID="year_txt" runat="server" MaxLength="8" Text="" required TabIndex="1"></asp:TextBox>

                                        </div>


                                    </div>
                            </asp:Panel>
                        </div>
                        <!-- OnClick -->
                        <br />
                                <div class="col-6 col-md-12" style="text-align:center">
                                    <asp:CheckBox ID="Save" runat="server" Text="حفظ التقرير" />
                                     </div>
                        <div class="col-6 col-md-12">
                            <asp:Button Style="font-size: unset;" ID="btnSend" runat="server" Text="تنفيذ" Width="100%" CssClass="btn btn-success" OnClick="btnSend_Click" />
                        </div>
                        <div class="col-6 col-md-3">
                            <asp:Label ID="AddUpdate" runat="server" Text="Label111" Visible="false"></asp:Label>
                        </div>
                        <div class="col-md-10">
                            <asp:GridView ID="gvDepartment" runat="server" CssClass="grid" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True">
                                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>

                                <HeaderStyle BackColor="#5f6b89" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>

                                <RowStyle ForeColor="#000066"></RowStyle>

                                <SelectedRowStyle BackColor="#92AED1" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

                                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>




</asp:Content>
