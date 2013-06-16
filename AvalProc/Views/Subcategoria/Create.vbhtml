@ModelType AvalProc.SubCategoria

@Using (Ajax.BeginForm("Create", "SubCategoria", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "updateSuccess"
        }, New With {.id = "updateSubCategoriaForm"}))
    
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Incluir Subcategoria</legend>

            @Html.LabelFor(Function(model) model.Descricao)
            @Html.EditorFor(Function(model) model.Descricao)
            @Html.ValidationMessageFor(Function(model) model.Descricao)

            @Html.LabelFor(Function(model) model.Categoria)
            @Html.DropDownListFor(Function(model) model.CategoriaId, ViewBag.CategoriaId)
            @Html.ValidationMessageFor(Function(model) model.Categoria)

    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
