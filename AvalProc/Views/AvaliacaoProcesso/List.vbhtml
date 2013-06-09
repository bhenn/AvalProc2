@modeltype List(Of AvalProc.Avaliacao_Processo)

<table class="table table-striped">
    <tr>
        <th>Processo</th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>@item.Processo.Descricao  </td>

            @code
            Dim ajaxOptions As New AjaxOptions
            ajaxOptions.OnFailure = "alert('Erro desconhecido');"
            ajaxOptions.Confirm = "Tem certeza que deseja excluir ?"
            ajaxOptions.HttpMethod = "POST"
            ajaxOptions.OnSuccess = "desassociaProcessoSuccess"
            End Code

            <td>
                @Ajax.ActionLink("Excluir", "Delete", New With {.controller = "AvaliacaoProcesso", .avalId = 1, .avaliacaoProcessoId = item.Id}, ajaxOptions,New With{.class = "btn"})
            </td>
        </tr>
    Next
</table>