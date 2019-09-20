<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSuppliers.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSuppliers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Suppliers</h1>

    <asp:ListView ID="SuppliersListView" runat="server"
        DataSourceID="SuppliersDataSource"
        InsertItemPosition="FirstItem"
        ItemType="WestWindSystem.Entities.Supplier">
        <LayoutTemplate>
            <table class="table table-hover table-condensed">
                <thead>
                    <tr>
                        <th>Supplier ID</th>
                        <th>Company Name</th>
                        <th>Contact</th>
                        <th>Address</th>
                        <th>Phone / Fax</th>
                    </tr>
                </thead>
                <tbody>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>

        <%-- This insert item template is for inserting records in a gridview setting. BindItem is semantic, bind => item --%>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:LinkButton ID="AddSupplier" runat="server" CssClass="btn btn-success glyphicon glyphicon-plus" CommandName="Insert">Add</asp:LinkButton></td>
                <td>
                    <asp:TextBox ID="CompanyName" runat="server" Text="<%# BindItem.CompanyName %>"
                        placeholder="Enter company name: ">
                    </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Contact" runat="server" Text="<%# BindItem.ContactName%>" placeholder="Contact name"></asp:TextBox>
                    <asp:TextBox ID="JobTitle" runat="server" Text="<%# BindItem.ContactTitle%>" placeholder="Job title"></asp:TextBox>
                    <asp:TextBox ID="Email" runat="server" Text="<%# BindItem.Email%>" placeholder="Email"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:TextBox ID="Phone" runat="server" Text="<%# BindItem.Phone%>" TextMode="Phone" placeholder="Phone #"></asp:TextBox>
                    <asp:TextBox ID="Fax" runat="server" Text="<%# BindItem.Fax%>" placeholder="Fax #"></asp:TextBox></td>
            </tr>
        </InsertItemTemplate>

        <%-- Displaying the fields --%>
        <ItemTemplate>
            <tr>
                <%-- ok, this is displaying the fields in the column. Address has multiple columns specified,
                    which is leading to more information being taken from the db--%>
                <td><%# Item.SupplierID %></td>
                <td><%# Item.CompanyName %></td>
                <td>
                    <b><%# Item.ContactName %></b>
                    &ndash;
                    <i><%# Item.ContactTitle %></i>
                    <br />
                    <%# Item.Email %>
                </td>
                <td><%# Item.Address.Address1 %>
                    <br />
                    <%# Item.Address.City %>
                    <%# Item.Address.Region %>
                    &nbsp;&nbsp;
                    <%# Item.Address.PostalCode %>
                    <br />
                    <%# Item.Address.Country %>
                </td>
                <td>
                    <%# Item.Phone %>
                    <br />
                    <%# Item.Fax %>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

    <asp:ObjectDataSource ID="SuppliersDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController" DataObjectTypeName="WestWindSystem.Entities.Supplier" InsertMethod="AddSupplier"></asp:ObjectDataSource>

</asp:Content>
