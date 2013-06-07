@modeltype avalproc.Avaliacao 

@Code
    ViewData("Title") = "Edit"
End Code

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)
    @<fieldset>
        <legend>Avaliação - @Model.Descricao </legend>
        <div class="tabbable">
            <ul class="nav nav-tabs">
                <li class="active"><a href="#tab1" data-toggle="tab">Informações</a></li>
                <li><a href="#tab2" data-toggle="tab">Avaliadores</a></li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane active" id="tab1">
                    <p>
                    @Html.LabelFor(Function(model) model.Descricao)
                    @Model.Descricao 
                    </p>
                    <p>
                        @Html.LabelFor(Function(model) model.Empresa.Nome)
                        @Model.Empresa.Nome 
                    </p>
                </div>
                
                 <div class="tab-pane" id="tab2">
                     @code
                         Html.RenderAction("Index", "AvaliacaoAvaliador", New With {.avalId = Model.Id})
                     End Code
                </div>
            </div>
        </div>
    </fieldset>
 End Using

<div>
    @Ajax.ActionLink("Atualizar", "ListAvaliador", "Avaliacao" , New With {.avalId = 1}, New AjaxOptions With {.UpdateTargetId = "tab2"})

    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
