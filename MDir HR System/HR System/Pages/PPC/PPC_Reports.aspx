<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MDirMaster.Master" AutoEventWireup="true" CodeBehind="PPC_Reports.aspx.cs" Inherits="HR_Salaries.Pages.PPC.PPC_Reports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="CrystalDecisions.Web" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
      
    <asp:Label ID="lblMessage" runat="server" style=" font-size:x-large;" ></asp:Label>
    <div class="content">
        <div class="container">
            <div class="col-lg-13">
                <div class="sub-content">
                    <div class="list-group">
                      
                        <div dir="rtl">


                             <!-- Start Chose for Add or Update-->



                             <!-- End -->
                  
                            
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
         <div class="col-md-12">  
         </div>
       </div>

          <div class="row">
                                <div class="col-6 col-md-12" >
                        <asp:Label CssClass="lbl" Width="100%" ID="Label2" runat="server"  Text="الاستعـــلام عن الحركات" ></asp:Label>             
                                    </div>
                               </div>
        
         <div class="row">
              <div class="col-6 col-md-3" >
                 <asp:DropDownList ID="proccess_type" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
             </div>
             <div class="col-6 col-md-2" >
                 <asp:TextBox ID="FromDate" class="form-control" runat="server" placeholder="من تاريخ"></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="FromDate"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
             </div>

             <br /><br />
             <div class="col-6 col-md-2" >
                 <asp:TextBox ID="ToDate" class="form-control" runat="server" placeholder="الى تاريخ"></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="ToDate"
                                    Format="yyyy-MM-dd">
                                </cc1:CalendarExtender>
             </div>


              <div class="col-6 col-md-3" >
                 <asp:DropDownList ID="DLL_user" runat="server" CssClass="btn btn-secondary dropdown-toggle dropdown-toggle-split" Width="100%" TabIndex="1" AutoPostBack="false"></asp:DropDownList>
             </div>


             
             <div class="col-6 col-md-6" style="text-align: right;"><asp:Button style="font-size: unset;" ID="GetTransactions" class="btn btn-primary" runat="server" Width="200px" Text="الحركات" OnClick="GetTransactions_Click" /> 
                 <br />
                 <br />
             </div>
                  
          </div>


        
        <div class="row">
         <div class="col-md-12">  
             <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
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
