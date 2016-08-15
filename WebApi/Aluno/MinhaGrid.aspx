<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MinhaGrid.aspx.cs" Inherits="Aluno.MinhaGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:GridView runat="server" ID="gridDisciplinas" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="IdDisc" HeaderText="Id" />
                <asp:BoundField DataField="DescricaoDisc" HeaderText="Disciplina" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
