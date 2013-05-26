@ModelType AvalProc.Avaliador

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Avaliador</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Nome)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Nome)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Cpf)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Cpf)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
