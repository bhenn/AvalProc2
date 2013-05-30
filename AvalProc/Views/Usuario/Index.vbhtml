@ModelType IEnumerable(Of AvalProc.Usuario)

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
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Email)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.Id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.Id})
        </td>
    </tr>
Next

</table>
