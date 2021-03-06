﻿@modeltype IEnumerable(Of AvalProc.SubCategoria )


<table class="table table-striped table-condensed">
    <tr>
        <th>
            Descrição
        </th>
        <th>
            Categoria
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.ActionLink(currentItem.Descricao, "Edit", New With {.id = currentItem.Id}, New With {.class = "editLink"})
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Categoria.Descricao)
        </td>

        @code
            Dim ajaxOptions As New AjaxOptions
            ajaxOptions.OnSuccess = "deleteSuccess"
            ajaxOptions.OnFailure = "alert('Erro desconhecido');"
            ajaxOptions.Confirm = "Tem certeza que deseja excluir ?"
            ajaxOptions.HttpMethod = "POST"
        End Code

        <td style="text-align:right">
            @Ajax.ActionLink("Excluir", "Delete", New With {.id = currentItem.id}, ajaxOptions, New With {.class = "btn btn-small"})
        </td>
    </tr>
Next

</table>