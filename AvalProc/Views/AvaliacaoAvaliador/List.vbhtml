﻿@modeltype List(Of AvalProc.Avaliacao_Avaliador)


<table class="table table-striped">
    <tr>
        <th>Avaliador</th>
        <th>Tipo</th>
        <th></th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>@item.Avaliador.Nome</td>
            <td>@item.TipoAvaliador.Descricao</td>

            @code
            Dim ajaxOptions As New AjaxOptions
            ajaxOptions.UpdateTargetId = "tab2"
            ajaxOptions.OnFailure = "alert('Erro desconhecido');"
            ajaxOptions.Confirm = "Tem certeza que deseja excluir ?"
            ajaxOptions.HttpMethod = "POST"
            End Code

            <td>
                @Ajax.ActionLink("Excluir", "Delete", New With {.controller = "AvaliacaoAvaliador", .avalId = 1, .avaliacaoAvaliadorId = item.Id}, ajaxOptions,New With{.class = "btn"})
            </td>
        </tr>
    Next
</table>