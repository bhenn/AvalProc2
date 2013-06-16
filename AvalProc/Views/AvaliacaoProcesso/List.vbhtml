@modeltype List(Of AvalProc.Avaliacao_Processo)

<table class="table table-striped">
    <tr>
        <th>Processo</th>
        <th>Nível</th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.ActionLink(item.Processo.Descricao, "Edit", New With {.controller = "AvaliacaoProcessoPa", .avaliacaoProcessoId = item.Id, .avaliacaoId = item.AvaliacaoId}, New With {.class = "editAvaliacaoProcessoPaLink"})
            </td>
            <td>
                @item.NivelCapacidade
            </td>

            @code
            Dim ajaxOptions As New AjaxOptions
            ajaxOptions.OnFailure = "alert('Erro desconhecido');"
            ajaxOptions.Confirm = "Tem certeza que deseja excluir ?"
            ajaxOptions.HttpMethod = "POST"
            ajaxOptions.OnSuccess = "desassociaProcessoSuccess"
            End Code

            <td>
                @Ajax.ActionLink("Excluir", "Delete", New With {.controller = "AvaliacaoProcesso", .avalId = 1, .avaliacaoProcessoId = item.Id}, ajaxOptions, New With {.class = "btn"})
            </td>
        </tr>
    Next
</table>