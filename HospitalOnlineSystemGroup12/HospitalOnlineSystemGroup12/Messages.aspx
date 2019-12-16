<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="HospitalOnlineSystemGroup12.Meagan_s_Work.Messages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 43px;
        }
        .auto-style4 {
            font-weight: normal;
            color: #006600;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="auto-style2">My Messages</h2>
    <h3 class="auto-style4">
        <strong>Inbox</strong></h3>
    <p class="auto-style4">
        <asp:Label ID="EmptyInboxLabel" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="InboxGridView" runat="server" Width="1100px" AutoGenerateColumns="False" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="From" HeaderText="From" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="MessagePreview" HeaderText="Message Preview" />
                <asp:BoundField DataField="Read" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <h3 class="auto-style2">
        Sent</h3>
    <p class="auto-style2">
        <asp:Label ID="EmptySentLabel" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="SentGridView" runat="server" Width="1100px" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="To" HeaderText="To" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="MessagePreview" HeaderText="Message Preview" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
    </p>
    <br />
    <asp:Button ID="ViewMessageButton" runat="server" ForeColor="#006600" Height="50px" OnClick="ViewMessageButton_Click" Text="VIEW" Width="150px" />
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="DeleteMessageButton" runat="server" ForeColor="#006600" Height="50px" Text="DELETE" Width="150px" OnClick="DeleteMessageButton_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="NewMessageButton" runat="server" Height="50px" Text="NEW DRAFT" Width="150px" ForeColor="#006600" OnClick="NewMessageButton_Click" />
    <br />
    <br />
    <asp:Label ID="InstructionsLabel" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="ViewMessageTextBox" runat="server" Height="216px" ReadOnly="True" TextMode="MultiLine" Width="819px"></asp:TextBox>
    </asp:Content>
