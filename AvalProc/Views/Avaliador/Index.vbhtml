@ModelType IEnumerable(Of AvalProc.Avaliador)

@Code
    ViewData("Title") = "Avaliador"
End Code

<h3>Avaliadores</h3>
<div id="commonMessage" class="alert alert-success" style="display: none; float:none  "></div>
 
<p>
    @Html.ActionLink("Novo", "Create", Nothing, New With{.class = "btn btn-small createLink"})
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
        //CREATE
        $(".createLink").click(function () {
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

        //EDIT
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

    function createSuccess(data) {
        atualizaLista(data, "Avaliador incluído com sucesso");
    }

    function updateSuccess(data) {
        atualizaLista(data,"Avaliador atualizado com sucesso");
    }

    function deleteSuccess(data) {
        atualizaLista(data, "Avaliador excluído com sucesso");
    }

    function atualizaLista(data,mensagem) {
        $('#lista').html(data);

        atribuiAcao();

        $('#updateDialog').dialog('close');
        $('#commonMessage').html(mensagem);
        $('#commonMessage').slideDown(200).delay(2000).slideUp(200);
    }
</script>


