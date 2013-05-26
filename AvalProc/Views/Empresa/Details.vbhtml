@ModelType AvalProc.Empresa

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Empresa</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Nome)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Nome)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Cnpj)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Cnpj)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Endereco)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Endereco)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
