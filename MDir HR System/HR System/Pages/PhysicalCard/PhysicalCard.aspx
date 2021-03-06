<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="PhysicalCard.aspx.cs" Inherits="HR_Salaries.Pages.PhysicalCard.PhysicalCard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
    <asp:Label ID="lblMessage" runat="server"  ></asp:Label>
    <div class="content">
        <div class="container">
            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
                        <asp:Panel ID="Panel1" runat="server">


                        <asp:Panel ID="PalChose" runat="server">
                            <div class="row">
                                <div class="col-6 col-md-3" >
                                    <asp:Button ID="ButAdd" runat="server" Text="أضافة" OnClick="ButAdd_OnClick"/>
                                    </div>
                                <div class="col-6 col-md-3" >
                                    <asp:Button ID="ButUpdate" runat="server" Text="تعديل" OnClick="ButUpdate_OnClick"/>
                                    </div>
                                </div>
                            </asp:Panel>



                            <asp:Panel ID="PalUpdate" runat="server" Visible="false">

                                <div class="row">
                              <div class="col-6 col-md-3" ><asp:TextBox ID="txtUpdate" class="form-control" runat="server" ></asp:TextBox></div>
                              <div class="col-6 col-md-3" style="text-align: right;"><asp:Button style="font-size: unset;" ID="btnSerchUpdate" class="btn btn-primary" runat="server" Text="بحث" OnClick="btnSerchUpdate_Click" /> </div>
                              <div class="col-6 col-md-3"> <asp:Label ID="Label9" runat="server" Text="البحث عن طريق رقم البطاقة"></asp:Label> </div>
                              <div class="col-6 col-md-3"> </div>
                         </div>








     <div class="row" style="padding: 0px 0px 0px 0px;">
                            <div class="col-md-1">  
                                    </div>

                  <div class="col-md-10">  
                     <asp:GridView ID="GVUpdate" runat="server" BackColor="White" BorderColor="#CCCCCC"
                     BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                     CssClass="table table-striped table-bordered table-condensed"
                     AutoGenerateColumns="False" AutoGenerateDeleteButton="False"
                     AutoGenerateSelectButton="True" OnSelectedIndexChanged="GVUpdate_PageIndexChanging" AllowSorting="True">
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




                 
                        

                          </asp:Panel>
                        <div dir="ltr">
                         <asp:Panel ID="Panel2" runat="server" Visible="false">
  



<!-- Account_Number -->
                         <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" runat="server" Text="Full Name"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="txtfull_name" runat="server"  ></asp:TextBox>
                            </div>
                            
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server" Text="CardNumber"></asp:Label>
                            </div>

                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="txtCardNumber" runat="server" TextMode="Number" Text="" ></asp:TextBox>
                            </div>

                        </div>




                             <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" runat="server" Text="Account Number"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="txtAccount_Number" runat="server"  ></asp:TextBox>
                            </div>
                            
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server" Text="Amount"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="txtAmount" runat="server" TextMode="Number" Text="" ></asp:TextBox>
                            </div>
                        </div>


                             <div class="row">
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" runat="server" Text="Phone Number"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="txtphone_number" runat="server"  ></asp:TextBox>
                            </div>
                            
                            <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server" Text="E-mail"></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:TextBox CssClass="txt" Width="100%" ID="txtEmail" runat="server" Text="" ></asp:TextBox>
                            </div>
                        </div>


                             <div class="row">
                                
                                <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server" Text="Carrncy"></asp:Label>
                                </div>
                                 <div class="col-6 col-md-3">
                                    <asp:DropDownList ID="ddlCCY" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%"></asp:DropDownList>
                                </div>
                                <div class="col-6 col-md-3">
                                </div>
                                <div class="col-6 col-md-3">
                                </div>
                            </div>






                    <div class="row">
                                <div class="col-6 col-md-3">
                                    <asp:Label CssClass="lbl" Width="100%" ID="Label97" runat="server" Text="is send?"></asp:Label>
                                </div>
                                <div class="col-6 col-md-3">
                                    <asp:CheckBox ID="isSend" runat="server" />
                                </div>
                                <div class="col-6 col-md-3">
                                <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server" Text="is Active?"></asp:Label>

                                </div>
                                <div class="col-6 col-md-3">
                                <asp:CheckBox ID="isActive" runat="server" />
                                <asp:Label ID="SequenceNumber" runat="server" Text="Label" Visible="false"></asp:Label>
                                <asp:Label ID="txtDSlipNu" runat="server" Text="Label" Visible="false"></asp:Label>


                                    
                                </div>
                    </div>


                    <div class="row">
                                <div class="col-6 col-md-3">
                                <asp:DropDownList CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" ID="ddlTraType" runat="server" Visible="False"></asp:DropDownList>
                                </div>
                    </div>




                                </div>



                            <div class="col-6 col-md-3">
                                <asp:Button style="font-size: unset;" ID="btnSend" runat="server" Text="التالي" width="100%" CssClass="btn btn-success" OnClick="btnSend_Click" />
                                <asp:Button style="font-size: unset;" ID="Button1" runat="server" Text="تجريبي" width="100%" CssClass="btn btn-success" OnClick="Button1_Click" Visible="false" />
                                <asp:Button style="font-size: unset;" ID="btn_export" runat="server" Text="تصدير" width="100%" CssClass="btn btn-success" OnClick="btn_export_Click" Visible="False" />

                            </div>    
                            <div class="col-6 col-md-3">
                                <asp:Label ID="lblempid" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-6 col-md-3">
                                <asp:Label ID="AddUpdate" runat="server" Text="Label"></asp:Label><asp:Label ID="CONTRACTREFERENCE" runat="server" Text=""></asp:Label>
                                <asp:Label ID="lbl_id" runat="server" Text=""></asp:Label>
                            </div>

                        </asp:Panel>

                            </div>
                             </asp:Panel>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
    

    </div>


</asp:Content>

