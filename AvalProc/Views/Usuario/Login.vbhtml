@ModelType avalproc.Usuario  


@Code
    ViewData("Title") = "Login"
End Code

<h2>Login</h2>

@Using Html.BeginForm()
    @<fieldset>
        <legend>Usuário</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Email)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Email)

            @Html.ValidationMessageFor(Function(model) model.Email)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Senha)
        </div>
        <div class="editor-field">
            @Html.PasswordFor(Function(model) model.Senha)
            @Html.ValidationMessageFor(Function(model) model.Senha)
        </div>
        
        <p>
            <input type="submit" value="Login" />
        </p>
     </fieldset>
    
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section


