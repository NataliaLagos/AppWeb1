<%@ Page Title="" Language="C#" MasterPageFile="~/App/Principal.Master" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="AppEmpleados.App.Formulario_web11" %>
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
    <h1 class="textoH1"> nuetro equipo de trabajo  </h1>
    <main class="estiloMain">
        <div class="contenedorCards">
                 <!-- inicio  cards-->
                 <div class="cards">
                    <div>
                        <img class="picProgramador" src="pic/programador.jpg" alt="">
                    </div>
                    <div>         
                    <p class="textoResaltado"> Nombre </p>
                    <p class="textoNormal"> Andea Natalia Lagos Leon </p>
                    <p class="textoResaltado"> Correo </p>
                    <p class="textoNormal"> anlagos9@misena.edu.co </p>
                    </div>
                </div>
                <!-- final cards-->
        </div>
    </main>
    <footer class="estiloFooter">
        <div class="contenedorGib">
            <div> 
                &nbsp;</div>
        </div>
    </footer>
</body>

</html>

</asp:Content>
