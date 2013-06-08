<div class="navbar-inner">
    <div class="container">
        <ul class="nav">
            <li>@Html.ActionLink("Home", "Index", "Home")</li>
            <li>@Html.ActionLink("Sobre", "About", "Home")</li>

            @If Request.IsAuthenticated Then
                @<li class="dropdown pull-right">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"> @Request.LogonUserIdentity.Name  <b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            @Html.ActionLink(" Logout ", "logout", "Usuario")
                            @Html.ActionLink(" Registrar ", "create", "Usuario")
                        </li>
                    </ul>
                </li>
                
            Else
                @<li class="dropdown pull-right">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">Usuário<b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        <li>
                            @Html.ActionLink("Login", "Login", "Usuario")
                        </li>
                    </ul>
                </li>
            End If
        </ul>
    </div>
</div>
