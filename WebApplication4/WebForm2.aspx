<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Button1 {
            height: 39px;
            width: 199px;
        }

        body{
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
    margin: 10% 0 0 35%;
    font-size: 20px;
}

.contenedor TextBox
{
    margin-bottom: 1%;
    font-size: 15px;
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
    <form id="form2" runat="server">
    <div>
    
        INGRESE LOS DATOS:</div>
&nbsp;<p>
           Nro. de cuenta:<asp:TextBox ID="Text1" runat="server" /><br />
Monto de cuenta:<asp:TextBox ID="Text2" runat="server" /><br />
Tipo de cuenta:<asp:TextBox ID="Text3" runat="server" /><br />
Tasa de interés:<asp:TextBox ID="Text4" runat="server" /><br />
Estado de cuenta:<asp:TextBox ID="Text5" runat="server" /><br />
Id usuario:<asp:TextBox ID="Text6" runat="server" /><br />
<asp:Button ID="Button1" runat="server" Text="GUARDAR" OnClick="Button1_Click" />

    </form>
</div>

    <footer>
    <div class="container">
        <p>&copy; 2024 Banco ABC. Todos los derechos reservados.</p>
    </div>
</footer>
        
</body>
</html>
