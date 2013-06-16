@ModelType AvalProc.Pa

@Using (Ajax.BeginForm("Edit", "Pa", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "updateSuccess"
        }, New With {.id = "updatePAForm"}))
    
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Alterar Atributo de Processo</legend>

        @Html.HiddenFor(Function(model) model.Id)

            @Html.LabelFor(Function(model) model.Nome)
            @Html.EditorFor(Function(model) model.Nome)
            @Html.ValidationMessageFor(Function(model) model.Nome)

            @Html.LabelFor(Function(model) model.Descricao)
            @Html.EditorFor(Function(model) model.Descricao)
            @Html.ValidationMessageFor(Function(model) model.Descricao)

    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
