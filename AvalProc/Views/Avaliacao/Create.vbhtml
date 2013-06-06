﻿@ModelType AvalProc.Avaliacao

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Avaliacao</legend>

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
            @Html.DropDownList("EmpresaId", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.EmpresaId)
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
