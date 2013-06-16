@ModelType AvalProc.Processo

@Using (Ajax.BeginForm("Create", "Avaliador", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "createSuccess"
        }, New With {.id = "updateProcessoForm"}))
    
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Novo Processo</legend>

            @Html.LabelFor(Function(model) model.Descricao)
            @Html.EditorFor(Function(model) model.Descricao)
            @Html.ValidationMessageFor(Function(model) model.Descricao)

            @Html.LabelFor(Function(model) model.SubCategoriaId, "SubCategoria")
            @Html.DropDownListFor(Function(model) model.SubCategoriaId , ViewBag.SubCategoriaId)
            @Html.ValidationMessageFor(Function(model) model.SubCategoriaId)
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
