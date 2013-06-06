@modeltype avalproc.Avaliacao 
@Code
    ViewData("Title") = "Edit"
End Code

<h2>Edit</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Avaliacao</legend>
        <div class="tabbable">
            <ul class="nav nav-tabs">
                <li class="active"><a href="#tab1" data-toggle="tab">Geral</a></li>
                <li><a href="#tab2" data-toggle="tab">Avaliadores</a></li>
                <li><a href="#tab3" data-toggle="tab">Teste</a></li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane active" id="tab1">
                    @Html.HiddenFor(Function(model) model.Id)

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
                        <input type="submit" value="Save" />
                    </p>
                </div>
                <div class="tab-pane" id="tab2">
                    @Html.ActionLink("Incluir", "Create", New With {.controller = "AvaliacaoAvaliador", .avalId = Model.Id}, New With {.class = "btn"})
                    <table class="table table-striped">
                        <tr>
                            <th >Avaliador</th>
                            <th >Tipo</th>
                            <th></th>
                        </tr>
                        @For Each aval As AvalProc.Avaliacao_Avaliador In ViewBag.AvaliacaoAvaliadores
                                @<tr>
                                    <td>@aval.Avaliador.Nome</td>
                                    <td>@aval.TipoAvaliador.Descricao</td>
                                 </tr>
                        Next
                    </table>
                </div>


                 <div class="tab-pane" id="tab3">
                 @code
                     Html.RenderPartial("ListAvaliador")
                 End Code
                </div>
            </div>
        </div>
    </fieldset>
                    End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
