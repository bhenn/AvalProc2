<div class="navbar">
    <div class="navbar-inner">
        <ul class="nav">
            <li>@Html.ActionLink("Home","Index","Home")</li>
            <li>@Html.ActionLink("Sobre","About","Home")</li>
        </ul>
        <div style="width: auto; text-align:right">
            @If Request.IsAuthenticated Then
                @Html.ActionLink(" Logout ", "logout", "Usuario")
            Else
                @Html.ActionLink(" Registrar ", "create", "Usuario")
                @Html.ActionLink("Login", "Login", "Usuario")
            End If
        </div>
    </div>
</div>