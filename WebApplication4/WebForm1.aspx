<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Button1 {
            width: 105px;
        }
        body {
            margin: 0;
            font-family: Courier, sans-serif;
        }
        .container {
            width: 90%;
            margin-left: 3%;
        }
        table
{
    width: 80%;
    border: 3px solid #aab3a4;
}

th, td {
    border: 1px solid #d5e2cd;
    padding: 8px; 
    text-align: left; 
}

header {
    background-color: #d5e2cd;
    color: #000000;
    padding: 10px 0;
}

header h1 {
    margin: 0;
    font-size: 24px;
}

nav ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
}

nav ul li {
    display: inline;
    margin-right: 20px;
}

nav ul li a {
    color: #000000;
    text-decoration: none;
}

footer {
    background-color: #d5e2cd;
    color: black;
    text-align: center;
    padding: 10px 0;
    position: fixed; 
    bottom: 0; 
    width: 100%; 
}

.contenido{
    margin: 10% 0 0 22%;
}

    </style>
</head>
<body>
    <header>
    <div class="container">
        <h1>Banco ABC</h1>
        <nav>
            <ul>
                <li><a href="#">Inicio</a></li>
                <li><a href="#">Ingresar</a></li>
            </ul>
        </nav>
    </div>
    </header>
    <div class="contenido">
    <form id="form1" runat="server">
    <div>
        Ingrese su usuario cuenta:
        <asp:TextBox ID="TextBox1" runat="server" Height="22px" Width="228px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Ingrese" OnClick="Button1_Click" />
    </div><br>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
    <Columns>
        <asp:BoundField DataField="nro_cuenta" HeaderText="Nro. Cuenta" />
        <asp:BoundField DataField="monto_cuenta" HeaderText="Monto" />
        <asp:BoundField DataField="tipo_cuenta" HeaderText="Tipo" />
        <asp:BoundField DataField="tasainteres_cuenta" HeaderText="Tasa de Interés" />
        <asp:BoundField DataField="estado_cuenta" HeaderText="Estado" />
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button ID="Button3" runat="server" Text="Eliminar" OnClick="Button3_Click" CommandArgument='<%# Eval("nro_cuenta") %>' />
                 <asp:Button ID="Button2" runat="server" Text="Editar" OnClick="Button2_Click" CommandArgument='<%# Eval("nro_cuenta") %>' />
                 <asp:Button ID="Button4" runat="server" Text="Insertar" OnClick="Button4_Click" CommandArgument='<%# Eval("nro_cuenta") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <SelectedRowStyle BackColor="#FFD700" Font-Bold="True" ForeColor="Black" />
    </asp:GridView>

    </form>
    </div>
    <footer>
    <div class="container">
        <p>&copy; 2024 Banco ABC. Todos los derechos reservados.</p>
    </div>
    </footer>

</body>
</html>
