<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="HospitalOnlineSystemGroup12.Meagan_s_Work.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>My Messages</h1>
    <p>
        <asp:GridView ID="MessagesGridView" runat="server" AutoGenerateSelectButton="True" Width="1098px">
        </asp:GridView>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
