@ModelType AvalProc.Avaliacao_Avaliador 

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

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

        <p>
            <input type="submit" value="Incluir" class="btn" />
        </p>
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
