@modeltype IEnumerable(Of AvalProc.avaliador)


<table class="table table-striped table-condensed">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nome)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Cpf)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @*@Html.DisplayFor(Function(modelItem) currentItem.Nome)*@
            @Html.ActionLink(currentItem.Nome, "Edit", New With {.id = currentItem.Id}, New With {.class = "editLink"})
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Cpf)
        </td>
        <td style="text-align:right">
            @*Html.ActionLink("Edit", "Edit", new with {.id = currentItem.Id }, new with{ .class = "btn editLink btn-small" })*@
            @Html.ActionLink("Excluir", "Delete", New With {.id = currentItem.Id}, New with{.class = "btn btn-small"})
        </td>
    </tr>
Next

</table>