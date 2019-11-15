<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderShipping.aspx.cs" Inherits="WebApp.Sales.OrderShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Order Shipping</h1>
    
    <div class ="row">
        <div class="col-md-12">
            <p>
                <asp:Literal ID="SupplierInfo" runat="server"></asp:Literal>
            </p>
            <asp:ListView ID="CurrentOrders" runat="server" DataSourceID="SupplierOrderDataSource">
                
            </asp:ListView>
            <asp:ObjectDataSource ID="SupplierOrderDataSource" runat="server"></asp:ObjectDataSource>
        </div>
    </div>

</asp:Content>
