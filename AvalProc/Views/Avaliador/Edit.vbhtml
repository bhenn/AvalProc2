@modeltype AvalProc.Avaliador 

@Using (Ajax.BeginForm("Edit", "Avaliador", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "updateSuccess"
        }, New With {.id = "updateAvaliadorForm"}))
    
    
    
    @Html.ValidationSummary(true)
    
    @<div id="update-message" class="error invisible"></div>
    
    @<fieldset>
        <legend>Alterar Avaliador</legend>
        @Html.HiddenFor(Function(model) model.Id)

            @Html.LabelFor(Function(model) model.Nome)
            @Html.EditorFor(Function(mode) mode.Nome)
            @Html.ValidationMessageFor(Function(mode) mode.Nome)

            @Html.LabelFor(Function(model) model.Cpf)
            @Html.EditorFor(Function(mode) mode.Cpf)
            @Html.ValidationMessageFor(Function(mode) mode.Cpf)
    </fieldset>
End Using 

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section