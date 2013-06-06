
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
                <li class="active"><a href="#tab1" data-toggle="tab">Avaliadores</a></li>
                <li><a href="#tab2" data-toggle="tab">Teste</a></li>
            </ul>
            <div class="tab-content">
                <div class="tab-pane" id="tab1">
                    Geral
                </div>
                
                 <div class="tab-pane" id="tab2">
                     @code
                        Html.RenderAction("ListAvaliador", "" , New With {.avalId = 1})
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
