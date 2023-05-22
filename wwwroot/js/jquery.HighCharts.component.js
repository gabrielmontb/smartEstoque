// ┌───────────────────────────────────┐ \\
// │ jQuery HighCharts Component 1.0.0 │ \\
// ├───────────────────────────────────┤ \\
// │         Michel Oliveira           │ \\
// │      Prime Team Tecnologia        │ \\
// ├───────────────────────────────────┤ \\
// │             Martins               │ \\
// └───────────────────────────────────┘ \\
function ComponenteHighCharts() {
    //
    this.modelo = {
        /** URL de POST de onde os dados serão buscados */
        ajaxPostURL: '',
        /** ID do controle que será gerado */
        idControle: '',
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
        /** Texto que será mostrado no gráfico */
        texto: '',
        /** Subtexto que será mostrado no gráfico */
        subtexto: '',
        /** Descrição que será mostrado no gráfico */
        descricao: '',
        series: [],
        /** Series que será mostrada no gráfico */
        get addseries() {
            var itmPush = this.series;
            //
            var pushObj = {
                /** Nome da Series */
                seriesName: '',
                /** Array que viria da requisição ajax */
                seriesDataArray: '',
                /** Cor da series */
                cor: '',
                /** Stack da series */
                seriesStack: ''
            };
            //
            itmPush.push(pushObj);
            return pushObj;
        }
    }
    //
    this.inicializar = function (configuracao) {
        var modelo = this.modelo;
        //
        $.ajax({
            async: true,
            url: modelo.ajaxPostURL,
            type: "POST",
            data: parametrosGrafico(modelo),
            headers: { __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val() },
            success: function (data) {
                montarHighCharts(data, modelo, configuracao);
            }, error: function (xhr, status, error) {
                //showAlert('', 'Ocorreu um erro interno, por favor, contacte o suporte.', '');
                //alert('Error message: ' + msg + '\nURL: ' + url + '\nLine Number: ' + linenumber);
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
                return false;

            }
        });
    }

    function montarHighCharts(data, modelo, configuracao) {
        //
        var settingsHighCharts = {
            chart: {
                type: 'column'
            },
            title: {
                text: modelo.texto
            },
            subtitle: {
                text: modelo.subtexto
            },
            xAxis: {
                type: 'category'
            },
            yAxis: {
                endOnTick: false,
                title: {
                    text: modelo.descricao
                },
                stackLabels: {
                    enabled: true,
                    style: {
                        fontWeight: 'bold',
                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'black'
                    }
                }
            },
            tooltip: {
                pointFormat:
                '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b> {point.percentage:.0f}%<br/>',
                shared: true
            },
            plotOptions: {
                column: {
                    stacking: 'normal',
                    dataLabels: {
                        enabled: true,
                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                        format: '<b>{point.y}</b><br/>{point.percentage:.0f}%'
                    }
                }
            },
            series: obterSeries(data, modelo)
        };
        //
        if (configuracao != null) {
            for (var key in configuracao) {
                Function("settings, value", "settings." + key + " = value;")(settingsHighCharts, configuracao[key]);
            }
        }
        //
        Highcharts.chart(modelo.idControle, settingsHighCharts);
    };

    function parametrosGrafico(modelo) {
        var obj;
        var arr = [];
        $(modelo.idsEnviarRequisicaoAjax).each(function (idx, itm) {
            //
            if (itm.tipoJsonEnviar == 'tipoNumerico' ||
                itm.tipoJsonEnviar == 'tipoTexto') {
                arr[itm.nomeJsonEnviar] =
                    isNullOrEmpty((obj = $('#' + itm.idJsonEnviar).val())) ?
                        (itm.tipoJsonEnviar == 'tipoNumerico' ? "-1" : "") :
                        obj.concat(itm.tratamentoJsonEnviar !== undefined ? itm.tratamentoJsonEnviar : "");
            }
            else if (itm.tipoJsonEnviar == 'tipoCheckBox') {
                arr[itm.nomeJsonEnviar] = (($('#' + itm.idJsonEnviar).is(':checked')) ? "1" : "0");
            }
            else if (itm.tipoJsonEnviar == 'tipoName') {
                arr[itm.nomeJsonEnviar] = ($("[name='" + itm.idJsonEnviar + "']").val());
            }
        });
        return $.extend(true, {}, arr);
    }

    function obterSeries(data, modelo) {
        var ret = [];
        $(modelo.series).each(function (idx, itm) {
            var func = Function("data", "return data." + itm.seriesDataArray + ";");
            ret.push({
                name: itm.seriesName,
                data: func(data),
                color: itm.cor,
                stack: itm.seriesStack
            });
        });

        if (ret.length === 0) {
            return null;
        } else {
            return ret;
        }
    }
}