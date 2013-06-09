﻿@ModelType AvalProc.Avaliador

@Using (Ajax.BeginForm("Create", "Avaliador", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "createSuccess"
        }, New With {.id = "updateAvaliadorForm"}))

    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Avaliador</legend>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Nome)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Nome)
            @Html.ValidationMessageFor(Function(model) model.Nome)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Cpf)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Cpf)
            @Html.ValidationMessageFor(Function(model) model.Cpf)
        </div>
    </fieldset>
End Using


@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
