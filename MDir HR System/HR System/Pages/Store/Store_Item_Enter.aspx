﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Store_Item_Enter.aspx.cs" Inherits="HR_Salaries.Pages.Store.Store_Item_Enter" %>

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
                                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="الادخال المخزني"></asp:Label>
                                    </div>
                                </div>
                            </asp:Panel>

                        </asp:Panel>
                        <div dir="rtl">






                            <asp:Panel ID="add_update_panel" runat="server" Visible="true">


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

                                </asp:Panel>


                                <!-- Start Search Panel -->


                        </div>
                        <!-- OnClick -->
                        <br />


                         <asp:Panel ID="PanelSearch" runat="server" Visible="false">
                                 <div class="row">

                                        <div class="col-6 col-md-6">
                                            <asp:TextBox ID="txtUpdate" class="form-control" runat="server" placeholder="أسم المادة"></asp:TextBox>
                                        </div>
                                        <div class="col-6 col-md-6" style="text-align: right;">
                                            <asp:Button Style="font-size: unset;" ID="btnSerchUpdate" class="btn btn-primary" runat="server" Text="بحث" OnClick="btnSerchUpdate_Click" />
                                        
                                        </div>

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





                        <asp:Panel ID="Panel_Add_Update" runat="server" Visible="false">

                            <div class="row">
                                 <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server" Text="أسم المادة" ></asp:Label>
                                </div>
                                        <div class="col-6 col-md-6">
                                             <asp:DropDownList ID="item_name" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                               </div>

                            <div class="row">

                                 <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server" Text="رقم المادة" ></asp:Label>
                                </div>

                                <div class="col-6 col-md-6">
                                            <asp:TextBox ID="item_number" class="form-control" runat="server" placeholder="" Enabled="false"></asp:TextBox>
                                        </div>
                                        
                                    </div>


                            <div class="row">
                                 <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server" Text="الكمية" ></asp:Label>
                                </div>
                                        <div class="col-6 col-md-6">
                                            <asp:TextBox ID="quantity" class="form-control" runat="server" placeholder=""></asp:TextBox>
                                        </div>
                               </div>

                            <div class="row">

                                 <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server" Text="سعر المفرد" ></asp:Label>
                                </div>

                                <div class="col-6 col-md-6">
                                            <asp:TextBox ID="unit_price" class="form-control" runat="server" placeholder=""></asp:TextBox>
                                        </div>
                                        
                                    </div>




                             <div class="row">
                                 <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label7" runat="server" Text="السعر الكلي" ></asp:Label>
                                </div>
                                        <div class="col-6 col-md-6">
                                            <asp:TextBox ID="total_rice" class="form-control" runat="server" placeholder="" Enabled="false"></asp:TextBox>
                                        </div>
                               </div>

                            <div class="row">

                                 <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label8" runat="server" Text="تاريخ الشراء" ></asp:Label>
                                </div>

                                <div class="col-6 col-md-3">
                                    <asp:TextBox CssClass="txt" Width="100%" ID="purchas_date" runat="server" Text=""  TabIndex="1"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="purchas_date"
                                    Format="yyyy-MM-dd">
                                    </cc1:CalendarExtender>
                                </div>
                                        
                           </div>



                            

                           



                            </asp:Panel>













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
