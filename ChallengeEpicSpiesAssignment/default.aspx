<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="ChallengeEpicSpiesAssignment._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <asp:Image ID="spyImage" runat="server" Height="190px" ImageUrl="~/Images/epic-spies-logo.jpg" />
                <br />
            </p>
            <h2>Spy New Assignment Form</h2>
            <p>
                <asp:Label ID="codeNameLabel" runat="server" Text="Spy Code Name:"></asp:Label>
&nbsp;<asp:TextBox ID="spyCodeNameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="assignmentNameLabel" runat="server" Text="New Assignment Name:"></asp:Label>
&nbsp;
                <asp:TextBox ID="assignmentNameTextBox" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="prevAssignCalLabel" runat="server" Text="End Date of Previous Assignment"></asp:Label>
                <asp:Calendar ID="previousCalendar" runat="server"></asp:Calendar>
            </p>
            <p>
                <asp:Label ID="newAssignCalLabel" runat="server" Text="Start Date of New Assignment"></asp:Label>
                <asp:Calendar ID="startCalendar" runat="server"></asp:Calendar>
            </p>
            <p>
                <asp:Label ID="endAssignCalLabel" runat="server" Text="Projected End Date of New Assignment"></asp:Label>
                <asp:Calendar ID="endCalendar" runat="server"></asp:Calendar>
            </p>
            <p>
                <asp:Button ID="AssignButton" runat="server" Text="Assign Spy" OnClick="AssignButton_Click" />
            </p>
            <p>
                <asp:Label ID="resultLabel" runat="server"></asp:Label>
            </p>
            <p>
                &nbsp;</p>
        </div>
    </form>
</body>
</html>
