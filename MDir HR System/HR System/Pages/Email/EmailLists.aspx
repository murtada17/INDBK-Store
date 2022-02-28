﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="EmailLists.aspx.cs" Inherits="HR_Salaries.Pages.Email.EmailLists" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="row">
        <asp:HiddenField ID="hfEmpID" Value="0" runat="server" />
        <asp:HiddenField ID="hfListID" runat="server" Value="0" />
        <asp:HiddenField ID="hfEmailID" runat="server" Value="0" />
        <asp:Label ID="lblMessage" runat="server" CssClass="Error" Text=""></asp:Label>
    </div>
    <asp:Panel ID="pnlSearch" runat="server">
        <div class="row">
            <div class="columnleft" style="width: 99.61%" dir="rtl">
                <asp:GridView ID="gvEmailList" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AutoGenerateDeleteButton="False" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvEmailList_SelectedIndexChanging">
                    <EditRowStyle Wrap="false" />
                    <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                    <HeaderStyle BackColor="#6c757d" Font-Bold="True" ForeColor="White"></HeaderStyle>
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
        <div class="row">
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlData" runat="server" Visible="False">
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label2" runat="server" Text="عنوان البريد الألكتروني :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="txtltr" MaxLength="255"></asp:TextBox>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label4" runat="server" Text="تاريخ الأنشاء :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:TextBox ID="txtCreationDate" runat="server" MaxLength="15" CssClass="txtltr" AutoPostBack="True" OnTextChanged="txtCreationDate_TextChanged"></asp:TextBox>
                <asp:CalendarExtender ID="txtCreationDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtCreationDate" PopupPosition="BottomRight" Format="yyyy/MM/dd">
                </asp:CalendarExtender>
            </div>
        </div>

        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label7" runat="server" Text="اسم الموظف المسؤول(عربي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlNameUpdateAR" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNameUpdate_SelectedIndexChanged" CssClass="ddl">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label8" runat="server" Text="اسم الموظف المسؤول (أنكليزي) : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlNameUpdateEN" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNameUpdate_SelectedIndexChanged" CssClass="ddlltr">
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label5" runat="server" Text="اخرى :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:CheckBox ID="chbIsActive" runat="server" Checked="True" Text="فعــــــــــال" />
            </div>
            <div class="columnleft">
            </div>
            <div class="columnRight">
            </div>
        </div>
        <div class="row">

            <div class="columnleft">
                <asp:Label ID="Label1" runat="server" Text="ملاحظات : "></asp:Label>
            </div>
            <div class="columnRight" style="width: 680px;">
                <asp:TextBox ID="txtNotes" runat="server" CssClass="txtltr" MaxLength="255"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <asp:Button ID="btnSubmit" runat="server" Text="إضافة" CssClass="btn" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="إلغاء" CssClass="btnCancel" OnClick="btnCancel_Click" CausesValidation="False" UseSubmitBehavior="False" />
        </div>
        <div class="row"></div>

    </asp:Panel>
    <asp:Panel ID="pnlList" runat="server">
        <div class="row">
            <asp:GridView ID="gvEmails" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="grid" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" OnRowDeleting="gvEmails_RowDeleting">
                <EditRowStyle Wrap="false" />
                <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                <HeaderStyle BackColor="#6c757d" Font-Bold="True" ForeColor="White"></HeaderStyle>
                <PagerStyle HorizontalAlign="Left" BackColor="White" ForeColor="#000066"></PagerStyle>
                <RowStyle ForeColor="#000066"></RowStyle>
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White"></SelectedRowStyle>
                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
            </asp:GridView>
        </div>
        <div class="row"></div>
        <div class="row">
            <div class="columnleft">
                <asp:Label ID="Label9" runat="server" Text="اسم الموظف : "></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlMemberName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged" CssClass="ddl">
                </asp:DropDownList>
            </div>
            <div class="columnleft">
                <asp:Label ID="Label10" runat="server" Text="البريد الألكتروني للموظف :"></asp:Label>
            </div>
            <div class="columnRight">
                <asp:DropDownList ID="ddlEmail" runat="server" AutoPostBack="True" CssClass="ddlltr">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row"></div>

        <div class="row">
            <asp:Button ID="btnAdd" runat="server" Text="اضافة" CssClass="btn" OnClick="btnAdd_Click" />
            <asp:Button ID="btnCancelMemebers" runat="server" Text="إلغاء" CssClass="btnCancel" CausesValidation="False" UseSubmitBehavior="False" OnClick="btnCancelMemebers_Click" />
        </div>
    </asp:Panel>
</asp:Content>
