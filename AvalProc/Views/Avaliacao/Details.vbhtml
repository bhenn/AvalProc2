@ModelType AvalProc.Avaliacao

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Avaliacao</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Descricao)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Descricao)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Empresa.Nome)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Empresa.Nome)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
