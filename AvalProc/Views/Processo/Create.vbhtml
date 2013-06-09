@ModelType AvalProc.Processo

@Using (Ajax.BeginForm("Create", "Avaliador", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "createSuccess"
        }, New With {.id = "updateProcessoForm"}))
    
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Processo</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Descricao)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Descricao)
            @Html.ValidationMessageFor(Function(model) model.Descricao)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.SubCategoriaId, "SubCategoria")
        </div>
        <div class="editor-field">
            @*Html.DropDownList("SubCategoriaId", String.Empty)*@
            @Html.DropDownListFor(Function(model) model.SubCategoriaId , ViewBag.SubCategoriaId)
            @Html.ValidationMessageFor(Function(model) model.SubCategoriaId)
        </div>
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
