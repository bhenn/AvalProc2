@Code
    ViewData("Title") = "Processo"
End Code

<p>
    @Html.ActionLink("Novo", "Create", New With {.avalId = ViewBag.avalId}, New With {.class = "btn btn-small createProcessoLink"})
</p>

<div id="listaProcesso">
    @code
        Html.RenderAction("List", New With {.avalId = ViewBag.avalId})
    End Code
</div>

<div id="updateDialogProcesso" ></div>

<script type="text/javascript">
    var linkObj;
    $(function () {

        $('#updateDialogProcesso').dialog({
            autoOpen: false,
            width: 400,
            resizable: false,
            modal: true,
            buttons: {
                "Salvar": function () {
                    $("#update-message").html(''); //make sure there is nothing on the message before we continue                         
                    $("#updateAvaliacaoProcessoForm").submit();
                },
                "Cancelar": function () {
                    $(this).dialog("close");
                }
            }
        });

        atribuiAcao();

    })

    function atribuiAcao() {
        //CREATE
        $(".createProcessoLink").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#updateDialogProcesso');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateAvaliacaoProcessoForm");
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

        //EDIT
        $(".editAvaliacaoProcessoPaLink").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#updateDialogProcesso');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateAvaliacaoProcessoForm");
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



    function associaProcessoSuccess(data) {
        atualizaListaProcesso(data, "Processo associado com sucesso");
    }

    function desassociaProcessoSuccess(data) {
        atualizaListaProcesso(data, "Processo desassociado com sucesso");
    }

    function editAvaliacaoProcessoSuccess(data) {
        atualizaListaProcesso(data, "");
    }

    function atualizaListaProcesso(data, mensagem) {
        $('#listaProcesso').html(data);

        atribuiAcao();

        $('#updateDialogProcesso').dialog('close');
        $('#commonMessage').html(mensagem);
        $('#commonMessage').fadeIn('slow');
        $('#commonMessage').fadeOut(4000);
        //$('#commonMessage').slideDown(200).delay(2000).slideUp(200);
    }
</script>
