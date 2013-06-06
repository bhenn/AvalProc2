@modeltype IEnumerable(Of AvalProc.Teste)

<script src="~/Scripts/jquery-1.9.1.js"></script>
<script src="~/Scripts/jquery-ui-1.8.24.js"></script>
<link href="~/Content/themes/base/minified/jquery-ui.min.css" rel="stylesheet" />

<script type="text/javascript">

    $(document).ready(function () {

        $.ajaxSetup({ cache: false });

        $('.confirmDialog').on('click', function (e) {
            var url = $(this).attr('href');
            $('.dialog-confirm').dialog({
                autoOpen: false,
                height: 170,
                width: 350,
                modal: true 
            })

            $('.dialog-confirm').dialog('open');
            return false;
            //alert(url);
        });

        //$('.confirmDialog').on('click', function (e) {

        //    var url = $(this).attr('href');
        //    $('#dialog-confirm').dialog({
        //        autoOpen: false,
        //        resizable: false,
        //        height: 170,
        //        width: 350,
                
        //        modal: true,
        //        draggable: true
                
        //    });
        //    $("#dialog-confirm").dialog('open');
        //    return false;
        //});



        $("#btncancel").on("click", function (e) {
            $("#dialog-edit").dialog('close');

        });
    });

</script>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table table-striped">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.id)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.descricao)
        </th>
        <th></th>
    </tr>

    @For Each item In Model
        Dim currentItem = item
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.id)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) currentItem.descricao)
            </td>
            <td>
                @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.id}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.id}, New With {.class = "confirmDialog"})
            </td>
        </tr>
    Next
</table>


<div id="dialog-confirm" style="display: none">
    <p>
        <span class="ui-icon ui-icon-alert" style="float: left; margin: 0 7px 20px 0;"></span>
        Are you sure to delete ?
    </p>
</div>

