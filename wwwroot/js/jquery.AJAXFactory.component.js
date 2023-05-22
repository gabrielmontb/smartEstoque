// ┌───────────────────────────────────┐ \\
// │ jQuery AJAXFactory Component 1.0.0 │ \\
// ├───────────────────────────────────┤ \\
// │         Michel Oliveira           │ \\
// │      Prime Team Tecnologia        │ \\
// ├───────────────────────────────────┤ \\
// │             Martins               │ \\
// └───────────────────────────────────┘ \\
function ComponenteAJAXFactory() {
    //
    this.modelo = {
        /** URL de POST de onde os dados serão buscados */
        ajaxURL: '',
        idsEnviarRequisicaoAjax: [],
        /** Array com os IDs dos elementos que serão enviados na requisição */
        get addidsEnviarRequisicaoAjax() {
            var itmPush = this.idsEnviarRequisicaoAjax;
            //
            var pushObj = {
                /** Nome (key) do JSON que será enviado */
                nomeJsonEnviar: '',
                /** Tipo do JSON que será enviado (Padrao tipoTexto) OPÇÕES: tipoTexto,
                                                                             tipoNumerico,
                                                                             tipoCheckBox,
                                                                             tipoParametro,
                                                                             tipoName,
                                                                             tipoFuncao */
                tipoJsonEnviar: '',
                /** ID do elemento em que será extraído o valor utilizando o método val() do elemento jQuery */
                idJsonEnviar: ''
            };
            //
            itmPush.push(pushObj);
            return pushObj;
        },
        /** Método de CallBack que será chamado após a execução com sucesso da requisição */
        ajaxSuccessCallbackMethod: function () { },
        /** Se o método será executado assíncronamente ou não */
        async: false
    }

    this.inicializar = function () {
        var modelo = this.modelo;
        //
        var obj;
        var arr = [];
        modelo.idsEnviarRequisicaoAjax.forEach(function (itm, idx) {
            //
            if (itm.tipoJsonEnviar == 'tipoNumerico' ||
                itm.tipoJsonEnviar == 'tipoTexto') {
                arr[itm.nomeJsonEnviar] =
                    isNullOrEmpty((obj = $('#' + itm.idJsonEnviar).val())) ? (itm.tipoJsonEnviar == 'tipoNumerico' ? "-1" : "") : obj;
            } else if (itm.tipoJsonEnviar == 'tipoCheckBox') {
                arr[itm.nomeJsonEnviar] = (($('#' + itm.idJsonEnviar).is(':checked')) ? "1" : "0");
            } else if (itm.tipoJsonEnviar == 'tipoName') {
                arr[itm.nomeJsonEnviar] = ($("[name='" + itm.idJsonEnviar + "']").val());
            } else if (itm.tipoJsonEnviar == 'tipoFuncao') {
                arr[itm.nomeJsonEnviar] = itm.idJsonEnviar();
            }
        });
        $.ajax({
            async: modelo.async,
            url: modelo.ajaxURL,
            type: "POST",
            data: $.extend(true, {}, arr),
            headers: { '__RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val() },
            success: modelo.ajaxSuccessCallbackMethod,
            error: function (xhr, status, error) {
                //showAlert('', 'Ocorreu um erro interno, por favor, contacte o suporte.', '');
                //alert('Error message: ' + error + '\nURL: ' + status + '\nLine Number: ' + xhr);

                if (xhr.status == 401 || xhr.status == 405) {
                    //swal({
                    //    title: '<i class="material-icons">info</i>&nbsp;Sessão expirada',
                    //    text: 'Sua sessão expirou, favor efetuar o login novamente!'
                    //}).then(function () {
                    //    window.location = loginLocation;
                    //});
                    //return;
                    window.location = expiredLocation;
                }
                var messagem = xhr.responseText.toString().substring(1, 200);
                var shortmessage = messagem;
                if (messagem.indexOf(".") != -1) {
                    shortmessage = messagem.split(".")[0];
                }

                
                console.log(xhr);
                swal({
                    title: 'Erro Interno!',
                    html: '<div class="swal-error-content">' +
                        '<br><b><h4>Entrar em contato o administrador!&nbsp;</h4></b>' +
                        '<br><p>Descrição erro: &nbsp; <br>' + '<i>' +
                        String(shortmessage) + '</i></p>' + '</div>',
                    cancelButtonColor: '#3085d6',
                    cancelButtonText: 'Ok'
                })
                setCustomIcon('fa fa-window-close');

            }   
        });
    }
}