﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="HospitalOnlineSystemGroup12.Meagan_s_Work.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>My Messages</h1>
    <h2>
        Inbox</h2>
    <p>
        <asp:GridView ID="InboxGridView" runat="server" AutoGenerateDeleteButton="True" Width="1100px" AutoGenerateColumns="False">
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="View" />
                <asp:BoundField DataField="From" HeaderText="From" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="MessagePreview" HeaderText="Message Preview" />
                <asp:BoundField DataField="Read" />
            </Columns>
        </asp:GridView>
    </p>
    <h2>
        Sent</h2>
    <p>
        <asp:GridView ID="SentGridView" runat="server" AutoGenerateDeleteButton="True" Width="1100px" AutoGenerateColumns="False">
            <Columns>
                <asp:ButtonField ButtonType="Button" Text="View" />
                <asp:BoundField DataField="To" HeaderText="To" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="MessagePreview" HeaderText="Message Preview" />
            </Columns>
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <h2>
        New Message</h2>
    <p class="auto-style1">
        To:
    </p>
    <asp:DropDownList ID="RecipientsDropDownList" runat="server" OnSelectedIndexChanged="RecipientsDropDownList_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="MessageLabel" runat="server" Text="Text:"></asp:Label>
    <br />
    <asp:ListBox ID="MessageListBox" runat="server" Height="271px" Width="1158px"></asp:ListBox>
    <br />
    <br />
    <asp:Button ID="SendButton" runat="server" Height="61px" OnClick="SendButton_Click" Text="SEND" Width="146px" />
</asp:Content>
