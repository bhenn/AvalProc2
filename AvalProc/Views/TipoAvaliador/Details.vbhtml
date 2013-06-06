@ModelType AvalProc.TipoAvaliador

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>TipoAvaliador</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Descricao)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Descricao)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
