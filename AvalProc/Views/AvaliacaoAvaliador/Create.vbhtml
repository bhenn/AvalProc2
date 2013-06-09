@ModelType AvalProc.Avaliacao_Avaliador 

@Code
    ViewData("Title") = "Create"
End Code

@Using (Ajax.BeginForm("Create", "AvaliacaoAvaliador", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "createAvaliadorSuccess"
        }, New With {.id = "updateAvaliacaoAvaliadorForm"}))

    @<fieldset>
        <legend>@ViewBag.Avaliacao.Descricao</legend>

        <div class="editor-field">
            <p>
                @Html.Hidden("AvaliacaoId",Request("avalId"))
            </p>
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.AvaliadorId, "Avaliador")
        </div>
        <div class="editor-field">
            @Html.DropDownList("AvaliadorId", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.AvaliadorId)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.TipoAvaliadorId, "Tipo Avaliador")
        </div>
        <div class="editor-field">
            @Html.DropDownList("TipoAvaliadorId", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.TipoAvaliador)
        </div>
    </fieldset>
End Using


