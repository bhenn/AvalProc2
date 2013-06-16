@ModelType AvalProc.Empresa

@Using (Ajax.BeginForm("Edit", "Empresa", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "updateSuccess"
        }, New With {.id = "updateEmpresaForm"}))
    
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Alterar Empresa</legend>

        @Html.HiddenFor(Function(model) model.Id)

        @Html.LabelFor(Function(model) model.Nome)
        @Html.EditorFor(Function(model) model.Nome)
        @Html.ValidationMessageFor(Function(model) model.Nome)

        @Html.LabelFor(Function(model) model.Cnpj)
        @Html.EditorFor(Function(model) model.Cnpj)
        @Html.ValidationMessageFor(Function(model) model.Cnpj)

        @Html.LabelFor(Function(model) model.Endereco)
        @Html.EditorFor(Function(model) model.Endereco)
        @Html.ValidationMessageFor(Function(model) model.Endereco)

    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
