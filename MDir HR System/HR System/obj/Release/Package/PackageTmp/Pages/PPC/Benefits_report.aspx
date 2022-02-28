﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="Benefits_report.aspx.cs" Inherits="HR_Salaries.Pages.PPC.Benefits_report" %>
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
                        <asp:Label CssClass="lbl" Width="100%" ID="Label4" runat="server"  Text="الاستعـــلام" ></asp:Label>             
                                    </div>
                               </div>
                            </asp:Panel>

                          </asp:Panel>
                        <div dir="rtl">
                         <asp:Panel ID="Panel2" runat="server" Visible="true">
                             </asp:Panel>

                             <!-- Start Chose for Add or Update-->



                             <!-- End -->
                         
  





                             <!-- Start -->

    <asp:Panel ID="PalReversedSearch" runat="server" Visible="true">  <!-- Search Panle -->
        <div class="row">
             <div class="col-6 col-md-6" >
             </div>
             <br />
             <div class="col-6 col-md-6" style="text-align: right;"> 
                 <br />
             </div>
                  
          </div>



         <div class="row">
             <div class="col-6 col-md-3" >
                 <asp:TextBox ID="FromDate" class="form-control" runat="server" placeholder="من تاريخ"></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="FromDate"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
             </div>
             <div class="col-6 col-md-3" >
                 <asp:TextBox ID="ToDate" class="form-control" runat="server" placeholder="الى تاريخ"></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="ToDate"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
             </div>
             
             <div class="col-6 col-md-6" style="text-align: right;"><asp:Button style="font-size: unset;" ID="GetTransactions" class="btn btn-primary" runat="server" Width="200px" Text="الحركات" OnClick="GetTransactions_Click" /> 
                 <br /> <br /> <br />
             </div>
                  
          </div>


        <div class="row">
         <div class="col-md-12">  
                     <asp:GridView ID="GVReversedSearch" runat="server" BackColor="White" BorderColor="#CCCCCC"
                     BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                     AutoGenerateColumns="False" AutoGenerateDeleteButton="False"
                     AutoGenerateSelectButton="True"  AllowSorting="True" OnSelectedIndexChanged="GVReversedSearch_SelectedIndexChanged">
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


        <br />
        <br />

        <div class="row">

            <div class="col-6 col-md-3" >
             <asp:Label CssClass="lbl" Width="100%" ID="Label1" runat="server"  Text="" ></asp:Label>     
                </div>

            <div class="col-6 col-md-3" >
             <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server"  Text="" ></asp:Label>     
                </div>


             <div class="col-6 col-md-3" >
             <asp:Label CssClass="lbl" Width="100%" ID="Label6" runat="server"  Text="" ></asp:Label>     
                </div>

            </div>



        <div class="row">

            <div class="col-6 col-md-3" >
             <asp:Label CssClass="lbl" Width="100%" ID="Label3" runat="server"  Text="" ></asp:Label>     
                </div>

        <div class="col-6 col-md-3" >
             <asp:Label CssClass="lbl" Width="100%" ID="from_" runat="server"  Text="" ></asp:Label>     
                </div>

             <div class="col-6 col-md-3" >
             <asp:Label CssClass="lbl" Width="100%" ID="Label5" runat="server"  Text="" ></asp:Label>     
                </div>

            <div class="col-6 col-md-3" >
             <asp:Label CssClass="lbl" Width="100%" ID="to_" runat="server"  Text="" ></asp:Label>     
                </div>

            </div>


    </asp:Panel>






                                </div>
                        <!-- OnClick -->
                        <br />

                   


                         
                         
                      
                            <div class="col-6 col-md-3">
                                <asp:Label ID="AddUpdate" runat="server" Text="Label111" Visible="false"></asp:Label>
                            </div>
                            </div>
                            
                         </div>
                     </div>
                 </div>
             </div>
        
    

  
</asp:Content>
