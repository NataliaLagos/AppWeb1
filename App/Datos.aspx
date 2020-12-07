<%@ Page Title="" Language="C#" MasterPageFile="~/App/Principal.Master" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="AppEmpleados.App.Formulario_web2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300;500&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="./estilos.css">
    <title> App Net </title>
</head>
<body>
    <header class="estiloHeader">
    </header>
	<h1 class="textoH1"> crud basico a una tabla html  </h1>
    <main class="estiloMain">
        <div class="contendeorApp"> 
        <div class="menuApp"> 
        <div class="contenedorBtnApp">
            <div>
                <asp:Button ID="btnListarTodo" runat="server" OnClick="btnListarTodo_Click" Text="Listar Empleados" class="btnApp" Visible="False" />  
            </div>
            <div>   
                 <div class ="contenedorText"> <asp:TextBox ID="inCodigoBuscar" runat="server" ></asp:TextBox> </div>
            </div>

            <div>   
                 <asp:Button ID="BtnBuscarCodigo" runat="server"  Text="Buscar Empleado" class="btnApp" OnClick="BtnBuscarCodigo_Click" />  
            </div>
            
            <div>   
                <asp:Label ID="LabelBuscar" runat="server" Font-Bold="True"></asp:Label>
            </div>
           
        </div>
        </div>
        <div class="contenedorDatos">
            <div class="contenedorGrid">       
            <asp:GridView CssClass="formatoGrid" ID="gvEmpleados" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowPaging="True" OnPageIndexChanging="gvEmpleados_PageIndexChanging" DataKeyNames="Codigo">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:ButtonField CommandName="Select" Text="Seleccionar" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
                </div>
        </div>
    </div>
    </main>
    <footer class="estiloFooter">
        <div class="contenedorGib">
            <div> 
                &nbsp;</div>
        </div>
    </footer>
</body>

</asp:Content>
