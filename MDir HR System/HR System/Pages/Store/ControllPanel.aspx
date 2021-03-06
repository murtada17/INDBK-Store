<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="ControllPanel.aspx.cs" Inherits="HR_Salaries.Pages.CBS.ControllPanel" %>

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
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="معلومات الزبائن"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>

                        </asp:Panel>
                        <div dir="rtl">




                            <asp:Panel ID="Panel4" runat="server" Visible="true">

                                 <div class="row">
                                        <div class="col-6 col-md-1">
                                            <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server"  Text="الشهر" ForeColor="Red"></asp:Label>
                                        </div>

                                        <div class="col-6 col-md-3">
                                            <asp:DropDownList ID="month_DDL" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
                                        </div>

                                       <div class="col-6 col-md-1">
                                           <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server"  Text="السنة" ForeColor="Red"></asp:Label>
                                        </div>

                                        <div class="col-6 col-md-3">
                                            <asp:DropDownList ID="years_DDL" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
                                        </div>


                                      <div class="col-6 col-md-1">

                                        </div>

                                        <div class="col-6 col-md-3">
                                            <asp:Button Style="font-size: unset;" ID="getValue" runat="server" Text="تنفيذ" Width="100%" CssClass="btn btn-success" OnClick="getValue_Click"  />
                                        </div>

                                </asp:Panel>



                            <asp:Panel ID="add_update_panel" runat="server" Visible="false">


                                <!-- Start Chose for Add or Update-->

                                <div class="row">
                                    <div class="col-6 col-md-5">
                                        <asp:Button Style="font-size: unset;" ID="ButAdd" runat="server" Text="أضافة" Width="100%" CssClass="btn btn-success" OnClick="ButAdd_OnClick" />
                                    </div>
                                    <div class="col-6 col-md-1">
                                    </div>
                                    <div class="col-6 col-md-1">
                                    </div>
                                    <div class="col-6 col-md-5">
                                        <asp:Button Style="font-size: unset;" ID="ButUpdate" runat="server" Text="تعديل" Width="100%" CssClass="btn btn-success" OnClick="ButUpdate_OnClick" />
                                    </div>

                                </div>

                                <!-- End -->




                                <!-- Start Search Panel -->

                                <asp:Panel ID="PalUpdate" runat="server" Visible="false">

                                    <div class="row">

                                        <div class="col-6 col-md-6">
                                            <asp:TextBox ID="txtUpdate" class="form-control" runat="server" placeholder="رقم الزبون - Contract-Code"></asp:TextBox>
                                        </div>
                                        <div class="col-6 col-md-6" style="text-align: right;">
                                            <asp:Button Style="font-size: unset;" ID="btnSerchUpdate" class="btn btn-primary" runat="server" Text="بحث" OnClick="btnSerchUpdate_Click" />
                                        </div>
                                        <!-- <div class="col-6 col-md-3"> <asp:Label ID="Label18" runat="server" Text="البحث و التعديل عن المواد"></asp:Label> </div> -->
                                        <div class="col-6 col-md-3"></div>
                                    </div>


                                    <div class="row" style="padding: 0px 0px 0px 0px;">
                                        <!--OnSelectedIndexChanged="GVUpdate_PageIndexChanging"-->
                                        <div class="col-md-12">
                                            <asp:GridView ID="GVUpdate" runat="server" BackColor="White" BorderColor="#CCCCCC"
                                                BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                                CssClass="table table-striped table-bordered table-condensed"
                                                AutoGenerateColumns="False" AutoGenerateDeleteButton="False"
                                                AutoGenerateSelectButton="True" AllowSorting="True" OnSelectedIndexChanged="GVUpdate_SelectedIndexChanged">
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

                                    </div>



                                </asp:Panel>





                                <asp:Panel ID="RowsData" runat="server" Visible="false">

                                    <div class="row">
                                        <div class="col-6 col-md-3">
                                            <asp:Label CssClass="lbl" Width="100%" ID="Label12" runat="server" Text="ContractCode" ForeColor="Red"></asp:Label>
                                        </div>
                                        <div class="col-6 col-md-3">
                                            <asp:TextBox CssClass="txt" Width="100%" ID="Coll_ContractCode" runat="server" Text="" required TabIndex="1"></asp:TextBox>
                                        </div>
                                        <div class="col-6 col-md-3">
                                            <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server" Text="CollateralCode" ForeColor="Red"></asp:Label>
                                        </div>
                                        <div class="col-6 col-md-3">
                                            <asp:TextBox CssClass="txt" Width="100%" ID="Coll_CollateralCode" runat="server" Text="" required TabIndex="1"></asp:TextBox>
                                        </div>
                                    </div>


                                </asp:Panel>








                                <!-- End -->


                            </asp:Panel>
                        </div>
                        <!-- OnClick -->
                        <br />

                        <asp:Panel ID="Panel3" runat="server" Visible="false">
                            <div class="col-6 col-md-12">
                                <asp:Button Style="font-size: unset;" ID="btnSend" runat="server" Text="تنفيذ" Width="100%" CssClass="btn btn-success" OnClick="btnSend_Click"  />
                            </div>
                            <br />

                            <div class="col-6 col-md-12">
                                <asp:Button Style="font-size: unset;" ID="btnCancel" runat="server" Text="ألغـــاء" Width="100%" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                            </div>

                        </asp:Panel>

                        <div class="col-6 col-md-3">
                            <asp:Label ID="AddUpdate" runat="server" Text="Label111" Visible="false"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>




</asp:Content>
