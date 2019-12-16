<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewMessage.aspx.cs" Inherits="HospitalOnlineSystemGroup12.NewMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><span class="auto-style2">New Message</span><br />
    </h2>
    <p>
        To:
    <asp:DropDownList ID="RecipientsDropDownList" runat="server">
    </asp:DropDownList>
    </p>
    <p>
        <asp:TextBox ID="MessageTextBox" runat="server" Height="227px" TextMode="MultiLine" Width="824px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="SendButton" runat="server" Height="57px" OnClick="SendButton_Click" Text="SEND" Width="181px" />
    </p>
</asp:Content>
