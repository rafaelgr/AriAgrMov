<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html>
    <head runat="server">
        <meta charset="utf-8"/>
        <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
        <title>Ariagro Movil (c) Ariadna Software</title>
        <telerik:RadStyleSheetManager id="RadStyleSheetManager1" runat="server" />
        <!-- Bootstrap -->
        <link href="css/bootstrap.min.css" rel="stylesheet"/>
        <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
        <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
        <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
        <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
        <![endif]-->
    </head>
    <body style="padding-top:70px;">
        <form id="form1" runat="server">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js" />
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js" />
                </Scripts>
            </telerik:RadScriptManager>
            <script type="text/javascript">
                //Put your JavaScript code here.
            </script>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <div>
                <!-- Fixed navbar -->
                <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
                    <div class="container">
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <a class="navbar-brand" href="#">Ariagro Movil</a>
                        </div>
                        <div class="collapse navbar-collapse">
                            <ul class="nav navbar-nav">
                                <li class="active">
                                    <a href="Default.aspx">Inicio</a>
                                </li>
                                <li>
                                    <a href="Consulta.aspx">Consulta</a>
                                </li>
                                <li>
                                    <a href="Volcado.aspx">Volcado</a>
                                </li>
                            </ul>
                        </div><!--/.nav-collapse -->
                    </div>
                </div>
            </div> <!-- end of navbar -->

            <div class="container">
                <div class="jumbotron">
                    <h1>Ariagro Móvil</h1>
                    <p>
                        Utilice esta aplicación para el control de trazabilidad sobre dispositivos móviles.
                        Utilice las opciones del menú superior o los botones en las explicaciones de más abajo
                    </p>
                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <h2 class="text-primary">Consulta de palets</h2>
                        <p>
                            Utilice esta opción para leer las tarjetas asociadas a un palet y conocer la información del mismo.
                        </p>
                        <p>
                            <a class="btn btn-primary" href="Consulta.aspx" role="button">Ir a Consulta &raquo;</a>
                        </p>
                    </div>
                    <div class="col-md-6">
                        <h2 class="text-primary">Volcado de palets</h2>
                        <p>
                            Utilice esta opción para leer las tarjetas de identificación de los palets y volcarlos por las líneas de confección correspondientes.
                        </p>
                        <p>
                            <a class="btn btn-primary" href="Volcado.aspx" role="button">Ir a Volcado &raquo;</a>
                        </p>
                    </div>
                </div>
            </div>
            <hr />
            <footer>
                <div class="container text-center">
                    <address>
                        <strong>(c) Ariadna Sotware S.L.</strong><br>
                        http://www.ariadnasw.com<br>
                        <abbr title="Teléfono">Tel:</abbr> 902 888 878
                    </address>
                </div>
            </footer>
        </form>
        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="https://code.jquery.com/jquery.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="js/bootstrap.min.js"></script>
    </body>
</html>
