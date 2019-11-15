<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderShipping.aspx.cs" Inherits="WebApp.Sales.OrderShipping" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Order Shipping</h1>
    
    <div class ="row">
        <div class="col-md-12">
            <p>
                <asp:Literal ID="SupplierInfo" runat="server"></asp:Literal>
            </p>
            <asp:ListView ID="CurrentOrders" runat="server" DataSourceID="SupplierOrderDataSource">
                <ItemTemplate>

                </ItemTemplate>
            </asp:ListView>
            <asp:ObjectDataSource ID="SupplierOrderDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadOrders" TypeName="WestWindSystem.BLL.OrderProcessingController">
                <SelectParameters>
                    <asp:Parameter DefaultValue="2" Name="supplierId" Type="Int32"></asp:Parameter>
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </div>

</asp:Content>
