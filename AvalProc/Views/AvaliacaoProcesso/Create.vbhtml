@ModelType AvalProc.Avaliacao_processo

@Code
    ViewData("Title") = "Create"
End Code

@Using (Ajax.BeginForm("Create", "AvaliacaoProcesso", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "associaProcessoSuccess"
        }, New With {.id = "updateAvaliacaoProcessoForm"}))

    @<fieldset>
        <legend>@ViewBag.Avaliacao.Descricao</legend>

        <div class="editor-field">
            <p>
                @Html.Hidden("AvaliacaoId",Request("avalId"))
            </p>
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.ProcessoId, "Processo")
        </div>
        <div class="editor-field">
            @Html.DropDownList("ProcessoId", String.Empty)
            @Html.ValidationMessageFor(Function(model) model.ProcessoId)
        </div>
    </fieldset>
End Using


