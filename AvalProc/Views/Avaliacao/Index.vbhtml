@ModelType IEnumerable(Of AvalProc.Avaliacao)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table table-striped">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Descricao)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Empresa.Nome)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Descricao)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Empresa.Nome)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.Id})

        </td>
    </tr>
Next

</table>
