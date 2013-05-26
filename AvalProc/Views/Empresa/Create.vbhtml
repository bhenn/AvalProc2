@ModelType AvalProc.Empresa

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Empresa</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Nome)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Nome)
            @Html.ValidationMessageFor(Function(model) model.Nome)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Cnpj)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Cnpj)
            @Html.ValidationMessageFor(Function(model) model.Cnpj)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Endereco)
        </div>
        <div class="editor-field">
            @Html.TextAreaFor(Function(model) model.Endereco)
            @Html.ValidationMessageFor(Function(model) model.Endereco)
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
