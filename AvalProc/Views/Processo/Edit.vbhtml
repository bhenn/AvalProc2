@ModelType AvalProc.Processo

@Using (Ajax.BeginForm("Edit", "Processo", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "updateSuccess"
        }, New With {.id = "updateProcessoForm"}))
    
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Alterar Processo</legend>

        @Html.HiddenFor(Function(model) model.Id)

            @Html.LabelFor(Function(model) model.Descricao)
            @Html.EditorFor(Function(model) model.Descricao)
            @Html.ValidationMessageFor(Function(model) model.Descricao)

            @Html.LabelFor(Function(model) model.SubCategoriaId, "SubCategoria")
            @Html.DropDownListFor(Function(model) model.SubCategoriaId,New SelectList(ViewBag.SubCategorias, "Id", "Descricao", model.SubCategoriaId ))
            @Html.ValidationMessageFor(Function(model) model.SubCategoriaId)
    </fieldset>
End Using

