@ModelType AvalProc.Usuario

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Usuario</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Email)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Email)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Senha)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Senha)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.SenhaSalt)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.SenhaSalt)
    </div>
</fieldset>
@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
