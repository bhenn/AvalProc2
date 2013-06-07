@ModelType AvalProc.Avaliacao

@Using (Ajax.BeginForm("Create", "Avaliacao", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "createSuccess"
        }, New With {.id = "updateAvaliacaoForm"}))

    @Html.ValidationSummary(True)
    
    @<fieldset>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Descricao)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Descricao)
            @Html.ValidationMessageFor(Function(model) model.Descricao)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.EmpresaId, "Empresa")
        </div>
        <div class="editor-field">
            @Html.DropDownListFor(Function(model) model.EmpresaId , ViewBag.EmpresaId)
            @Html.ValidationMessageFor(Function(model) model.EmpresaId)
        </div>

    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
