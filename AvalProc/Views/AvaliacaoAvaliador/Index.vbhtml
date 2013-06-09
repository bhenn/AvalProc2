@Code
    ViewData("Title") = "Avaliador"
End Code

<p>
    @Html.ActionLink("Novo", "Create", New With {.avalId = ViewBag.avalId}, New With {.class = "btn btn-small createAvaliadorLink"})
</p>

<div id="listaAvaliador">
    @code
        Html.RenderAction("List", New With {.avalId = ViewBag.avalId})
    End Code

</div>

<div id="updateDialogAvaliador" ></div>

<script type="text/javascript">
    var linkObj;
    $(function () {

        $('#updateDialogAvaliador').dialog({
            autoOpen: false,
            width: 400,
            resizable: false,
            modal: true,
            buttons: {
                "Salvar": function () {
                    $("#update-message").html(''); //make sure there is nothing on the message before we continue                         
                    $("#updateAvaliacaoAvaliadorForm").submit();
                },
                "Cancelar": function () {
                    $(this).dialog("close");
                }
            }
        });

        atribuiAcaoAvaliador();

    })

    function atribuiAcaoAvaliador() {
        //CREATE
        $(".createAvaliadorLink").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#updateDialogAvaliador');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateAvaliacaoAvaliadorForm");
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



    function createAvaliadorSuccess(data) {
        atualizaListaAvaliador(data, "Avaliador associado com sucesso");
    }

    function deleteAvaliadorSuccess(data) {
        atualizaListaAvaliador(data, "Avaliador desassociado com sucesso");
    }

    function atualizaListaAvaliador(data, mensagem) {
        $('#listaAvaliador').html(data);

        atribuiAcaoAvaliador();

        $('#updateDialogAvaliador').dialog('close');
        $('#commonMessage').html(mensagem);
        $('#commonMessage').fadeIn('slow');
        $('#commonMessage').fadeOut(4000);
        //$('#commonMessage').slideDown(200).delay(2000).slideUp(200);
    }
</script>
