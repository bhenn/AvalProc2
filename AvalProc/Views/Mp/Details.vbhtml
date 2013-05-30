@ModelType AvalProc.Mp

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Mp</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Nome)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Nome)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Descricao)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Descricao)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Pa.Nome)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Pa.Nome)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
