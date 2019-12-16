<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddAppointment.aspx.cs" Inherits="HospitalOnlineSystemGroup12.AddAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        margin-left: 1720px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style1">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
<p>
    <asp:Label ID="DepartmentNameLabel" runat="server" Text="Department: "></asp:Label>
    <asp:DropDownList ID="DepartmentDropDownList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="Department" DataValueField="Department" OnSelectedIndexChanged="DepartmentDropDownList_SelectedIndexChanged">
        <asp:ListItem>Cardiology</asp:ListItem>
        <asp:ListItem>Intensive Care Unit</asp:ListItem>
        <asp:ListItem>Oncology</asp:ListItem>
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [Department] FROM [DoctorsTable]"></asp:SqlDataSource>
</p>
<p>
    <asp:Label ID="DoctorNameLabel" runat="server" Text="Doctor: "></asp:Label>
    <asp:DropDownList ID="DoctorDropDownList" runat="server" DataSourceID="SqlDataSource3" DataTextField="LastName" DataValueField="DoctorID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [LastName], [DoctorID] FROM [DoctorsTable] WHERE ([Department] = @Department)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DepartmentDropDownList" Name="Department" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</p>
    <p>
        <asp:Label ID="SelectDateLabel" runat="server" Text="Select Date Bellow"></asp:Label>
</p>
<p>
    <asp:Calendar ID="SelectDateCalendar" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" OnSelectionChanged="SelectDateCalendar_SelectionChanged" Width="350px">
        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#999999" />
        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
        <TodayDayStyle BackColor="#CCCCCC" />
    </asp:Calendar>
</p>
<p>
    <asp:Label ID="SelectTimeLabel" runat="server" Text="Time: "></asp:Label>
&nbsp;
    <asp:Label ID="HoursLabel" runat="server" Text="Hours: "></asp:Label>
    <asp:DropDownList ID="HourDropDownList" runat="server">
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;
    <asp:Label ID="MinuteLabel" runat="server" Text="Min: "></asp:Label>
    <asp:DropDownList ID="MinDropDownList" runat="server">
        <asp:ListItem>0</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    <asp:Button ID="CreateAppointmentButton" runat="server" OnClick="CreateAppointmentButton_Click" Text="Create Appointment" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="DisplayMesageLabel" runat="server" Text="Label" Visible="False"></asp:Label>
</p>
<p>
</p>
<p>
</p>
</asp:Content>
