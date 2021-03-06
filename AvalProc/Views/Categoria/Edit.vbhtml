﻿@ModelType AvalProc.Categoria

@Using (Ajax.BeginForm("Edit", "Categoria", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "updateSuccess"
        }, New With {.id = "updateCategoriaForm"}))

    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Alterar Categoria</legend>

        @Html.HiddenFor(Function(model) model.Id)

            @Html.LabelFor(Function(model) model.Descricao)
            @Html.EditorFor(Function(model) model.Descricao)
            @Html.ValidationMessageFor(Function(model) model.Descricao)
        
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
