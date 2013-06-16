@ModelType AvalProc.SubCategoria

@Using (Ajax.BeginForm("Edit", "SubCategoria", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "updateSuccess"
        }, New With {.id = "updateSubCategoriaForm"}))
    
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Alterar Subcategoria</legend>

        @Html.HiddenFor(Function(model) model.Id)

            @Html.LabelFor(Function(model) model.Descricao)
            @Html.EditorFor(Function(model) model.Descricao)
            @Html.ValidationMessageFor(Function(model) model.Descricao)

            @Html.LabelFor(Function(model) model.Categoria)
            @*Html.DropDownListFor(Function(model) model.CategoriaId, ViewBag.categoriaId)*@
            @Html.DropDownListFor(Function(model) model.CategoriaId , New SelectList(ViewBag.categorias, "Id", "Descricao", model.CategoriaId))

            @Html.ValidationMessageFor(Function(model) model.Categoria)

    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
