@ModelType IEnumerable(Of AvalProc.Avaliacao_Avaliador)

<h2>Avaliação avaliador</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table table-striped">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Avaliacao.Descricao)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Avaliador.Nome)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Avaliacao.Descricao)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Avaliador.Nome)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.Id})
        </td>
    </tr>
Next

</table>
