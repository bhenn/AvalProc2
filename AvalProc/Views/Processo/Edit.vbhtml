@modeltype AvalProc.Processo 

@Using (Ajax.BeginForm("Edit", "Processo", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "updateSuccess"
        }, New With {.id = "updateProcessoForm"}))
    
    
    
    @Html.ValidationSummary(true)

    
    @<div id="update-message" class="error invisible"></div>
    
    @<fieldset>
        <legend>Processo</legend>
        @Html.HiddenFor(Function(model) model.Id)

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Descricao)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(mode) mode.Descricao)
            @Html.ValidationMessageFor(Function(mode) mode.Descricao)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.SubCategoriaId, "SubCategoria")
        </div>
        <div class="editor-field">
            @Html.DropDownList("SubCategoriaId", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.SubCategoriaId)
        </div>
    </fieldset>
    
End Using 











@*@ModelType AvalProc.Avaliador

@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Avaliador</legend>

        @Html.HiddenFor(Function(model) model.Id)

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

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section*@
