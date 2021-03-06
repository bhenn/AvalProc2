﻿@ModelType IEnumerable(Of AvalProc.Avaliacao)

@Code
    ViewData("Title") = "Avaliação"
End Code

<h2>Avaliações</h2>
<div id="commonMessage" class="alert alert-success" style="display: none;"></div>
<p>
    @Html.ActionLink("Novo", "Create", Nothing, New With{.class = "btn btn-small createAvaliacaoLink"})
</p>

<div id="listaAvaliacao">
    @code
        Html.RenderAction("List")
    End Code

</div>

<div id="updateDialogAvaliacao" ></div>

<script type="text/javascript">
    var linkObj;
    $(function () {
        $('.editLink').button();

        $('#updateDialogAvaliacao').dialog({
            autoOpen: false,
            width: 400,
            resizable: false,
            modal: true,
            buttons: {
                "Salvar": function () {
                    $("#update-message").html(''); //make sure there is nothing on the message before we continue                         
                    $("#updateAvaliacaoForm").submit();
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
        $(".createAvaliacaoLink").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#updateDialogAvaliacao');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateAvaliacaoForm");
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



    function createAvaliacaoSuccess(data) {
        atualizaListaAvaliacao(data, "Avaliação incluída com sucesso");
    }

    function deleteAvaliacaoSuccess(data) {
        atualizaListaAvaliacao(data, "Avaliação excluída com sucesso");
    }

    function atualizaListaAvaliacao(data, mensagem) {
        $('#listaAvaliacao').html(data);

        atribuiAcao();

        $('#updateDialogAvaliacao').dialog('close');
        $('#commonMessage').html(mensagem);
        $('#commonMessage').slideDown(200).delay(2000).slideUp(200);
    }
</script>