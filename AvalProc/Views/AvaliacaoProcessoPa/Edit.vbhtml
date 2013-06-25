@Modeltype IEnumerable(Of AvalProc.Avaliacao_Processo_pa)


@Using (Ajax.BeginForm("Edit", "AvaliacaoProcessoPa", New AjaxOptions With {
            .InsertionMode = InsertionMode.Replace,
            .HttpMethod = "POST",
            .OnSuccess = "editAvaliacaoProcessoSuccess"
        }, New With {.id = "updateAvaliacaoProcessoForm"}))
    
    @Html.ValidationSummary(true)

    @<table class="table table-striped table-condensed">
        @If Model.Count > 0 Then
            @Html.Hidden("avaliacaoId",ViewBag.avaliacaoId)        
            @Html.Hidden("avaliacaoProcessoId",Model(0).AvaliacaoProcessoId)
        End If

        @code
            Dim listPontuacao As New List(Of AvalProc.Pontuacao)
            
            listPontuacao.Add(New AvalProc.Pontuacao With {.Nome = "N"})
            listPontuacao.Add(New AvalProc.Pontuacao With {.Nome = "P"})
            listPontuacao.Add(New AvalProc.Pontuacao With {.Nome = "L"})
            listPontuacao.Add(New AvalProc.Pontuacao With {.Nome = "F"})
        End Code

        @For Each item In Model
            @<tr>
                <td>
                    @Html.HiddenFor(Function(modelItem) item.Id)
                </td>

                <td>
                    @item.Pa.Nome 
                </td>

                <td>
                    @Html.DropDownListFor(Function(modelItem) item.Pontuacao, New SelectList(listPontuacao,"Nome","Nome",item.Pontuacao),New With{.class = "span1"})
                    @Html.TextAreaFor(Function(modelItem) item.Observacao, 2, 40, Nothing)
                </td>
            </tr>
        Next

    </table>
End Using
