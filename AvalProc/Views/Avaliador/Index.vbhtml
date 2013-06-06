@ModelType IEnumerable(Of AvalProc.Avaliador)

@Code
    ViewData("Title") = "Index"
End Code

<h3>Avaliadores</h3>
<div id="commonMessage" class="alert alert-success" style="display: none;"></div>
<p>
    @Html.ActionLink("Novo", "Create", Nothing, New With{.class = "btn btn-small"})
</p>
<div id="lista">
    @code
        Html.RenderAction("List")
    End Code

</div>

<div id="updateDialog" title="Alterar Avaliador"></div>

<script type="text/javascript">
    var linkObj;
    $(function () {
        $('.editLink').button();

        $('#updateDialog').dialog({
            autoOpen: false,
            width: 400,
            resizable: false,
            modal: true,
            buttons: {
                "Salvar": function () {
                    $("#update-message").html(''); //make sure there is nothing on the message before we continue                         
                    $("#updateAvaliadorForm").submit();
                },
                "Cancelar": function () {
                    $(this).dialog("close");
                }
            }
        });
        
        atribuiAcao();

    })

    function atribuiAcao() {
        $(".editLink").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#updateDialog');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateAvaliadorForm");
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
                //open dialog
                dialogDiv.dialog('open');
            });
            return false;
        });
    }


    function updateSuccess(data) {
        $('#lista').html(data);

        atribuiAcao();
       
        $('#updateDialog').dialog('close');
        $('#commonMessage').html("Avaliador Atualizado");
        $('#commonMessage').delay(400).slideDown(400).delay(3000).slideUp(400);

    }


</script>
