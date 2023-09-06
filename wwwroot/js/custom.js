$(document).ready(function () {
    var setCustomIcon = function (iconClass) {
        var sweet = $('#swal2-title');
        sweet.html('<i class="' + iconClass + '"></i>&nbsp;' + sweet.html());
    };
    //--RESPONSIVE SCREEN
    var startresponsive = function () {
        setTimeout(function () {
            $('.custom-sidebar-container').height($('.mdl-layout-custom-sidebar').height() - 90);
        }, 1500);
    };

    $(window).resize(function () {
        startresponsive();
    });

    //setTimeout(function () { startresponsive(); }, 150);

    $('.custom-sidebar-container').mouseover(function () {
        startresponsive();
    });
    
    setTimeout(function () { $('body').removeAttr('style').addClass('fadeIn'); }, 100);
    //-------------------

    //--SIDEBAR MENU
    if ($.sidebarMenu) {
        $.sidebarMenu($('.sidebar-menu'));
        var sidebar = $('.mdl-layout-custom-sidebar');
        var content = $('.mdl-layout__content');
        var btnSdbar = $('.btn-tgv-sidebar:first');
        //
        $('.btn-tgv-sidebar').click(function () {
            var dataFixed = sidebar.attr('data-fixed-nav');
            if (dataFixed == 'false') {
                sidebar.addClass('is-active');
                content.addClass('is-nav-active');
                sidebar.attr('data-fixed-nav', 'true');
                //btnSdbar.removeClass('rotate90');
                $(this).html('<i class="fa fa-thumb-tack icon-tamanhox" ></i>');
            } else {
                sidebar.removeClass('is-active');
                content.removeClass('is-nav-active');
                sidebar.attr('data-fixed-nav', 'false');
                //btnSdbar.addClass('rotate90');
                btnSdbar.html('<i class="fa fa-thumb-tack icon-tamanhox rotate90" ></i>');
                //$(this).html('<i class="fa fa-thumb-tack fa-2x" ></i>');
            };
            localStorage.setItem('FSXX0004FAA', dataFixed == 'true' ? 'true' : 'false');
            //-
            setTimeout(function () { $(window).trigger('resize'); }, 250);
            //-
            setTimeout(function () { ($('.dataTable').DataTable()).columns.adjust().draw(); }, 400);
        });
        //
        var dataSt = localStorage.getItem('FSXX0004FAA');
        if (dataSt) {            
            if (dataSt == 'false') {
                sidebar.addClass('is-active');
                content.addClass('is-nav-active');
                sidebar.attr('data-fixed-nav', 'true');
                //btnSdbar.removeClass('rotate90');
                btnSdbar.html('<i class="fa fa-thumb-tack icon-tamanhox" ></i>');
            } else {
                sidebar.removeClass('is-active');
                content.removeClass('is-nav-active');
                sidebar.attr('data-fixed-nav', 'false');
                //btnSdbar.addClass('rotate90');
                btnSdbar.html('<i class="fa fa-thumb-tack icon-tamanhox rotate90" ></i>');
            };
        };
    };
    //-------------------

    //--SIDEBAR USER INFO MENU
    $('[data-user-info]').click(function () {
        var container = $('.tgv-user-info-container');
        if (container.attr('data-is-content') == 'false') {
            container.addClass('is-content');
            container.attr('data-is-content', 'true');
            $('.tgv-user-info').addClass('is-info');
            $('.mdl-layout__header, .mdl-layout-custom-sidebar, .mdl-layout__content').addClass('tgv-blurred');
            $('body').css('overflow', 'hidden');
            $('#divFuncionario').show();
        } else {
            container.removeClass('is-content');
            container.attr('data-is-content', 'false');
            $('.tgv-user-info').removeClass('is-info');
            $('.blurred-container').removeClass('tgv-blurred');
            $('body').removeAttr('style');
        };
    });
    $('.tgv-user-info-container').click(function () {
        $('.tgv-user-info').removeClass('is-info');
        $(this).attr('data-is-content', 'false').removeClass('is-content');
        $('.mdl-layout__header, .mdl-layout-custom-sidebar, .mdl-layout__content').removeClass('tgv-blurred');
        $('#divFuncionario').hide();
    });
    //-------------------

    //--SIDEBAR OPORTUNIDADE FILTRO
    $('body').append($('.tp-filtro:not(.detached)').addClass('detached').detach());
    $('[side-opt-filtro]').click(function () {
        var container = $('.tgv-side-opt-info-container');
        if (container.attr('data-is-content') == 'false') {
            container.addClass('is-content');
            container.attr('data-is-content', 'true');
            $('.tgv-side-opt-info').addClass('is-info');
            $('.mdl-layout-custom-sidebar, .mdl-layout__content').addClass('tgv-blurred');
            //$('body').css('overflow', 'hidden');
        } else {
            container.attr('data-is-content', 'false').removeClass('is-content');
            $('.tgv-side-opt-info').removeClass('is-info');
            $('.blurred-container').removeClass('tgv-blurred');
            $('.mdl-layout-custom-sidebar, .mdl-layout__content').removeClass('tgv-blurred');
            //$('body').removeAttr('style');
        };
    });
    $('.tgv-side-opt-info-container').click(function () {
        $('.tgv-side-opt-info').removeClass('is-info');
        $(this).attr('data-is-content', 'false').removeClass('is-content');
        $('.mdl-layout-custom-sidebar, .mdl-layout__content').removeClass('tgv-blurred');
        //$('.tgv-side-opt-info').css({ visibility: 'hidden'});
    });
    //-------------------

    //Fehca o Refinar Pesquisa ao apertar 'ESC'
    $(window).keydown(function (e) {
        let keycode = (e.keyCode ? e.keyCode : e.which);
        if (keycode == 27) { $('[data-is-content="true"]').click(); }
    });

    //Realiza pesquisa ao apertar 'ENTER'
    $(window).keydown(function (e) {
        var keycode = (e.keyCode ? e.keyCode : e.which);
        if (keycode == 13) {
            if ($('#divPesquisa:visible').length == 0) {
                e.stopPropagation();
                return;
            } else {
                $('#btnPesquisarTela').click();
            };
        };
    });

    //--AUTO HEIGHT TEXTAREA.
    $('textarea[auto-height="true"]').keyup(function () {
        $(this).attr('style', 'height: 36px !important;');
        $(this).attr('style', 'height: ' + parseInt($(this).prop("scrollHeight")) + 'px !important;');
    });
    //-------------------

    //--INPUTS MASKS
    $('.numerico').each(function () {
        var len = parseInt($(this).attr('maximo'));
        if (len !== NaN) {
            var mask = "";

            for (var i = 0; i < len; i++)
                mask += "9";

            $(this).mask(mask.toString());
        };
    });

    $('.has-drop').each(function () {
        let element = $(this), target = element.attr('target'), onclose = element.attr('onclose');
        //if (onclose && onclose.trim().length > 0) {
        //    this.callonclose = function () { eval(onclose); };
        //    element.removeAttr('onclose');
        //}
        element.click(function () {
            $(target).parent().addClass("open").css({
                top: this.offsetTop + 30,
                left: this.offsetLeft
                //width: element.width()
            });
            $('.page-content').prepend($('<div class="tree-drop-background">').click(function () {
                $('.tree-drop-holder.open').removeClass('open');
                this.remove();
            }));
        });
    });

    $('.has-drop-filtro').each(function () {
        let treeFil = $(this), target = treeFil.attr('target');
        treeFil.click(function () {
            let top = this.offsetTop - $(this).parents('.filtro-scroller').scrollTop() + 20;
            $(target).parent().addClass("open").css({
                top: top
            });
            $('.filtro-scroller').prepend($('<div class="tree-drop-background">').click(function () {
                $('.tree-drop-holder.open').removeClass('open');
                this.remove();
                if (treeFil[0].callonclose) { treeFil[0].callonclose(); }
            }));
        });
    });

    try {
        $('.cnpj').mask('00.000.000/0000-00');

        $('.cpf').mask('000.000.000-00');

        //$(".telefone")
        //    .mask("(99) 9999-99999");

        //$(".telefone")
        //    .focusout(function (event) {
        //        var target, phone, element;
        //        target = (event.currentTarget) ? event.currentTarget : event.srcElement;
        //        phone = target.value.replace(/\D/g, '');
        //        element = $(target);
        //        if (phone.length > 10) {
        //            element.mask("(99) 99999-9999");
        //        } else {
        //            element.mask("(99) 9999-9999");
        //        }
        //    });

        //$('.telefone').blur(function () {
        //    var phone, element;
        //    element = $(this);
        //    phone = element.val().replace(/\D/g, '');
        //    if (phone.length > 10) {
        //        element.mask("(99) 99999-9999");
        //    } else {
        //        element.mask("(99) 9999-99999");
        //    }           
        //        //element.unmask();

        //}).trigger('blur');

        $('.telefone').mask('(00) 0000-00009');
        $('.telefone').blur(function (event) {
            if ($(this).val().length == 15) { // Celular com 9 dígitos + 2 dígitos DDD e 4 da máscara
                $(this).mask('(00) 00000-0009');
            } else {
                $(this).mask('(00) 0000-00009');
            }
        });

        $('.dinheiro').keydown(function (event) {
            $(this).mask('000.000.000.000.000,00', { reverse: true });
        });

        $('.dinheiro2').mask("#.##0,00", { reverse: true });

    } catch (ex) {
        if (ex.toString().indexOf('not defined') >= 0) {
            console.log(ex);
        };
    };
    //-------------------

    //--LIMPAR TOOLTIP
    $('.limparTooltipChange').change(function () {
        $(this).parent().find('.notifyjs-wrapper').trigger('notify-hide');
    });

    $('.limparTooltipKeyDown').keydown(function () {
        $(this).parent().find('.notifyjs-wrapper').trigger('notify-hide');
    });
    //-------------------


    //--ICON CLEAR (LIMPAR)
    $('.icon-clear').click(function () {
        var control = $(this).next();
        if (control && control.prop('tagName') == 'INPUT')
            control.val('').change();
        else if (control && control.prop('tagName') == 'SELECT') {
            control.val('0').trigger('change');
        } else {
            control.next().val('');
        };
    });
    //-------------------


    //--BOOTSTAP FIX
    $('.modal').on('shown.bs.modal', function () {
        $('body').append($(this).detach());
        $('#tgv-main-layout').addClass('tgv-blurred');

    });
    $('.modal').on('hidden.bs.modal', function () {
        $('#tgv-main-layout').removeClass('tgv-blurred');
    });
    //-------------------

    //--TGV SELECT MATERIAL
    $('.tgv-select-material').append('<div class="tgv-select-container">\
                                        <div class="tgv-select-subline"></div>\
                                      </div>');
    $('.tgv-select-material select').focus(function () {
        $(this).parent().addClass('focused');
    }).blur(function () {
        $(this).parent().removeClass('focused');
    });
    //-------------------

    //--SEARCH PAGES
    $('#txtSearch').keyup(function () {
        var srh = $(this).val().toLowerCase();
        var lis = $('.sidebar-menu li');
        lis.each(function () {
            let est = $(this);
            if (est.text().trim().toLowerCase().indexOf(srh) < 0) {
                est.fadeOut();
            } else {
                est.fadeIn();;
                if (est.attr('class').indexOf('treeview') > -1 && est.attr('class').indexOf('active') < 0)
                    est.addClass('active');
                else
                    est.removeClass('active');
            };
        });
    });
    //-------------------
});

var CarregaDescricoes = function (idGrid,numColuna,idLista,idCampo) {
    var descricao = ($('#' + idGrid).DataTable()).data().column(numColuna).data();
    $("#" + idLista).html(null);
    if (descricao.length > 0) {
        for (var i = 0; i < descricao.length; i++) {
            $("#" + idLista).append(new Option(descricao[i]));
            if ($('#' + idCampo).val().toUpperCase().trim() == $("#" + idLista)[0].options[i].innerText.toUpperCase().trim()) {
                tooltipCampoObrigatorio('#' + idCampo, "Nome já registrado!");
            }
        }
    }
}

//Espelhamento filtros
var setMirror = function (ctrList) {
    try {
        if (ctrList && ctrList.length) {
            ctrList.forEach(function (controlSet) {
                controlSet.forEach(function (control, i) {
                    let nextControl = controlSet[i + 1]; // funcionando - melhorar lógica.
                    if (nextControl) {
                        $(control).on('keyup change', function () { $(nextControl).val(this.value); });
                    } else {
                        $(control).on('keyup change', function () { $(controlSet[0]).val(this.value); });
                    };
                });
            });
        };
    } catch (ex) {
        Util.CriaLogErro(ex, MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().ReflectedType.Name, JsonConvert.SerializeObject(objInserir)); 
 throw ex;
    };
};

//--COPIA O TEXTO DO ELEMENTO
var copiarTexto = function (el, swalOptions) {
    if (el) {
        var inputID = null;

        if (el.prop('tagName') !== 'INPUT' && el.prop('tagName') !== 'TEXTAREA') {
            inputID = 'copyTx' + (Math.random() * 100).toFixed(0);
            var htmlTratado = el.html().replace(/<br>/g, '\n');
            $('body').append($('<textarea id="' + inputID + '">' + htmlTratado + '"</textarea>'));
            $('#' + inputID).select();
        } else {
            el.select();
        };

        document.execCommand('copy');

        if (inputID) { $('#' + inputID).remove(); };

        if (window.getSelection) {
            window.getSelection().removeAllRanges();
        } else if (document.selection) {
            document.selection.empty();
        };

        if (swalOptions) { swal(swalOptions); };
    };
};
//-------------------

//--TRANSFORMA O DATATABLES EM EDITAVEL
var edTable = function (idString, ignoredCols) {
    //--Verificando se o id foi informado.
    if (!idString) { return; };

    //--Setando o nome.
    this.name = String(idString);

    //--Informa se as alterações já foram aplicadas.
    this.isBaked = false;

    //--Grid
    var table = $(this.name).DataTable();

    //--Colunas
    var columns = table.settings().init().aoColumns;

    //--Ignoradas
    var igColumns = ignoredCols;

    //--Dados do Grid.
    var data = table.data();

    //--Limpando as funções da linha grid. (garantia)
    $(this.name + ' tr').css('cursor', 'default').unbind('click');

    //--Adicionando o input.
    let insertInput = function (td) {
        if (td.prop('class').indexOf('botoesGrid') < 0) {
            var inpVal = data.cell(td).data();
            if (igColumns && igColumns.length && igColumns.length > 0) {
                var idx = data.cell(td).index().column;
                if (igColumns.indexOf(columns[idx].data) < 0)
                    td.html('<input class="data-tables-form-control" type="text" value="' + (inpVal !== null ? inpVal : '') + '">');
            } else {
                td.html('<input class="data-tables-form-control" type="text" value="' + (inpVal !== null ? inpVal : '') + '">');
            };
        };
    };

    $(this.name + ' td').each(function () { insertInput($(this)); });
    //-------------------

    //--Seta os dados no grid.
    this.bake = function () {
        $(this.name + ' td').each(function () {
            var td = $(this);
            if (td.prop('class').indexOf('botoesGrid') < 0 && td.children().length > 0) {
                data.cell(td).data(td.children().val());
            };
        });
        //
        this.isBaked = true;
        //
        table.draw();
        //
        return data;
    };

    //--Obtem os dados do grid.
    this.data = function () { return table.data(); };

    //--Refaz o grid.
    this.rework = function () {
        $(this.name + ' tr').css('cursor', 'default').unbind();
        $(this.name + ' td').each(function () { insertInput($(this)); });
        //-
        this.isBaked = false;
        table.draw();
    };

    //--Re-draw grid.
    table.draw();
};
//-------------------

//--VALIDADORES
var valControls = function (elements) {
    try {

        var valido = true;

        if (elements)
            for (let i = 0; i < elements.length; i++) {
                var idStr = elements[i].id.toString(), elm = $(idStr);
                if (elm.val().length < parseInt(elements[i].min)) {
                    tooltipCampoObrigatorio(idStr, elements[i].msgMin);
                    valido = false;
                };
                if (elm.val().length > parseInt(elements[i].max)) {
                    tooltipCampoObrigatorio(idStr, elements[i].msgMax);
                    valido = false;
                };
            };

        return valido;

    } catch (ex) {
        console.log(ex);
        swal('Erro ao validar campos.', String(ex));
        setCustomIcon('fa fa-window-close');
    };
};

//validador cpf
function TestaCPF(strCPF) {

    var Soma;
    var Resto;
    Soma = 0;
    if (strCPF == "00000000000") return false;
    if (strCPF == "11111111111") return false;
    if (strCPF == "22222222222") return false;
    if (strCPF == "33333333333") return false;
    if (strCPF == "44444444444") return false;
    if (strCPF == "55555555555") return false;
    if (strCPF == "66666666666") return false;
    if (strCPF == "77777777777") return false;
    if (strCPF == "88888888888") return false;
    if (strCPF == "99999999999") return false;

    for (i = 1; i <= 9; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(9, 10))) return false;

    Soma = 0;
    for (i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i);
    Resto = (Soma * 10) % 11;

    if ((Resto == 10) || (Resto == 11)) Resto = 0;
    if (Resto != parseInt(strCPF.substring(10, 11))) return false;
    return true;
}
//-------------------

//validador cnpj
function ValidarCNPJ(ObjCnpj) {
    var cnpj = ObjCnpj;
    if (cnpj.length > 0) {

        var valida = new Array(6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2);
        var dig1 = new Number;
        var dig2 = new Number;

        exp = /\.|\-|\//g
        cnpj = cnpj.toString().replace(exp, "");

        if (cnpj == "00000000000000" ||
            cnpj == "11111111111111" ||
            cnpj == "22222222222222" ||
            cnpj == "33333333333333" ||
            cnpj == "44444444444444" ||
            cnpj == "55555555555555" ||
            cnpj == "66666666666666" ||
            cnpj == "77777777777777" ||
            cnpj == "88888888888888" ||
            cnpj == "99999999999999") {
            swal('Verificar!', "CNPJ Inválido!!");
            setCustomIcon('fa fa-window-close');
            ObjCnpj = '';
        }

        var digito = new Number(eval(cnpj.charAt(12) + cnpj.charAt(13)));

        for (i = 0; i < valida.length; i++) {
            dig1 += (i > 0 ? (cnpj.charAt(i - 1) * valida[i]) : 0);
            dig2 += cnpj.charAt(i) * valida[i];
        }
        dig1 = (((dig1 % 11) < 2) ? 0 : (11 - (dig1 % 11)));
        dig2 = (((dig2 % 11) < 2) ? 0 : (11 - (dig2 % 11)));

        if (((dig1 * 10) + dig2) != digito) {
            swal('Verificar!', "CNPJ Inválido!!");
            setCustomIcon('fa fa-window-close');
            ObjCnpj = '';
        }
    }
}
//-------------------


function ValidarCNPJNovo(cnpj) {

    cnpj = cnpj.replace(/[^\d]+/g, '');

    if (cnpj == '') {
        swal('Verificar!', "CNPJ Inválido!!");
        setCustomIcon('fa fa-window-close');
        cnpj = '';
        return false;
    }

    if (cnpj.length != 14) {
        swal('Verificar!', "CNPJ Inválido!!");
        setCustomIcon('fa fa-window-close');
        cnpj = '';
        return false;
    }


    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" ||
        cnpj == "11111111111111" ||
        cnpj == "22222222222222" ||
        cnpj == "33333333333333" ||
        cnpj == "44444444444444" ||
        cnpj == "55555555555555" ||
        cnpj == "66666666666666" ||
        cnpj == "77777777777777" ||
        cnpj == "88888888888888" ||
        cnpj == "99999999999999") {
        swal('Verificar!', "CNPJ Inválido!!");
        setCustomIcon('fa fa-window-close');
        cnpj = '';
        return false;
    }

    return true;

}

//--VERIFICAR SE CONTEM DETERMINADO TEXTO NO INPUT.
var valTexto = function (input, substr) {
    var str = input.val();
    var substr = substr;

    if (str.indexOf(substr) > -1) {
        return true;
    }
    else {
        return false;
    }
}
//-------------------

//INSERE ICONE MENSAGEM SWAL
var setCustomIcon = function (iconClass) {
    var sweet = $('#swal2-title');
    sweet.html('<i class="' + iconClass + '"></i>&nbsp;' + sweet.html());
};

//--CHECKBOX COLUMN DATATABLES
var checkBoxGrid = function (id) {

    this.id = id;

    this.markList = [];

    var verifyChecked = function (stringClasse) {
        var allChecks = $(stringClasse + ' .check-son'), chkCount = 0;
        //
        allChecks.each(function () {
            if (this.checked) { chkCount++; };
        });
        //
        if (chkCount > 0 && chkCount == allChecks.length)
            $(stringClasse + ' .check-father').prop('checked', true);
    };

    //Datatable grid consulta
    this.reworkConsulta = function (stringClasse = "dataTables_consulta") {
        try {
            /*var stringClasse = ".dataTables_consulta";*/
            $('.' + stringClasse + ' ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="' + stringClasse + ' check-father">');
                } else {
                    cell.html('<input type="checkbox" class="' + stringClasse + ' check-son">').css('text-align', 'center');
                };
            });
            //
            $('.' + stringClasse + ' .check-father').click(function () {
                if (this.checked)
                    $('.' + stringClasse + ' .check-son').prop('checked', false).trigger('click');
                else
                    $('.' + stringClasse + ' .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.' + stringClasse + ' .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.' + stringClasse + ' .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked('.'+stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.' + stringClasse + ' .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked('.'+stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkConsulta();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };

    //Rework datatable personalizado
    this.reworkGridPersonalizado = function () {
        try {
            var stringClasse = ".dataTables_personalizado";
            $('.dataTables_personalizado ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizado check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizado check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizado .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizado .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizado .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizado .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizado .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizado .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizado();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };

    //Rework datatable modal
    this.reworkModal = function () {
        try {
            var stringClasse = ".dataTables_modal";
            $('.dataTables_modal ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_modal check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_modal check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_modal .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_modal .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_modal .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_modal .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_modal .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_modal .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkModal();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };

    //Rework datatable personalizado 2, é utilizado quando existem duas grid na mesma tela para separação dos checks
    this.reworkGridPersonalizado2 = function () {
        try {
            var stringClasse = ".dataTables_personalizado2";
            $('.dataTables_personalizado2 ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizado2 check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizado2 check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizado2 .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizado2 .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizado2 .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizado2 .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizado2 .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizado2 .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizado2();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };

    this.reworkGridPersonalizado3 = function () {
        try {
            var stringClasse = ".dataTables_personalizado3";
            $('.dataTables_personalizado3 ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizado3 check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizado3 check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizado3 .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizado3 .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizado3 .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizado3 .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizado3 .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizado3 .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizado3();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };

    this.reworkGridPersonalizadoAdq = function () {
        try {
            var stringClasse = ".dataTables_personalizadoAdq";
            $('.dataTables_personalizadoAdq ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizadoAdq check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizadoAdq check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizadoAdq .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizadoAdq .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizadoAdq .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizadoAdq .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizadoAdq .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizadoAdq .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizadoAdq();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };
    
    //Rework datatable personalizado 2, é utilizado quando existem duas grid na mesma tela para separação dos checks
    this.reworkGridPersonalizadoPix = function () {
        try {
            var stringClasse = ".dataTables_personalizadoPix";
            $('.dataTables_personalizadoPix ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizadoPix check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizadoPix check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizadoPix .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizadoPix .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizadoPix .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizadoPix .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizadoPix .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizadoPix .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizadoPix();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };

    //Rework datatable personalizado 2, é utilizado quando existem duas grid na mesma tela para separação dos checks
    this.reworkGridPersonalizadoDMP = function () {
        try {
            var stringClasse = ".dataTables_personalizadoDMP";
            $('.dataTables_personalizadoDMP ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizadoDMP check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizadoDMP check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizadoDMP .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizadoDMP .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizadoDMP .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizadoDMP .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizadoDMP .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizadoDMP .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizadoDMP();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };


    this.reworkGridPersonalizadoEndereco = function () {
        try {
            var stringClasse = ".dataTables_personalizadoEndereco";
            $('.dataTables_personalizadoEndereco ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizadoEndereco check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizadoEndereco check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizadoEndereco .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizadoEndereco .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizadoEndereco .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizadoEndereco .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizadoEndereco .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizadoEndereco .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizadoEndereco();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };


    //Rework datatable personalizado 2, é utilizado quando existem duas grid na mesma tela para separação dos checks
    this.reworkGridPersonalizadoContato = function () {
        try {
            var stringClasse = ".dataTables_personalizadocontato";
            $('.dataTables_personalizadocontato ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizadocontato check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizadocontato check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizadocontato .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizadocontato .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizadocontato .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizadocontato .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizadocontato .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizadocontato .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizadoContato();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };

    //Rework datatable personalizado 2, é utilizado quando existem duas grid na mesma tela para separação dos checks
    this.reworkGridPersonalizadoConsultoria = function () {
        try {
            var stringClasse = ".dataTables_personalizadoconsultoria";
            $('.dataTables_personalizadoconsultoria ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizadoconsultoria check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizadoconsultoria check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizadoconsultoria .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizadoconsultoria .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizadoconsultoria .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizadoconsultoria .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizadoconsultoria .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizadoconsultoria .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizadoConsultoria();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };


    //Rework datatable personalizado 2, é utilizado quando existem duas grid na mesma tela para separação dos checks
    this.reworkGridPersonalizadoTitulos = function () {
        try {
            var stringClasse = ".dataTables_personalizadotitulos";
            $('.dataTables_personalizadotitulos ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_personalizadotitulos check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_personalizadotitulos check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_personalizadotitulos .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_personalizadotitulos .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_personalizadotitulos .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_personalizadotitulos .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_personalizadotitulos .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_personalizadotitulos .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkGridPersonalizadoTitulos();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };


    //Rework datatable personalizado
    this.reworkModal = function () {
        try {
            var stringClasse = ".dataTables_modal";
            $('.dataTables_modal ' + this.id + '_wrapper .check-this').each(function () {
                var cell = $(this), div = cell.find('div');
                cell.unbind('click').removeClass('sorting');
                setTimeout(function () { cell.unbind('click'); }, 15);
                //
                if (div.length > 0) {
                    div.html('<input type="checkbox" class="dataTables_modal check-father">');
                } else {
                    cell.html('<input type="checkbox" class="dataTables_modal check-son">').css('text-align', 'center');
                };
            });
            //
            $('.dataTables_modal .check-father').click(function () {
                if (this.checked)
                    $('.dataTables_modal .check-son').prop('checked', false).trigger('click');
                else
                    $('.dataTables_modal .check-son').prop('checked', true).trigger('click');
            });
            //
            let bindButtons = function (marks, mId) {
                $('.dataTables_modal .check-son').click(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    if (!this.checked) {
                        $('.dataTables_modal .check-father').prop('checked', false);
                        if (marks.length > 0) {
                            let rem = marks.filter(function (x) { return x == lineData; });
                            if (rem && rem.length > 0) {
                                let idx = marks.indexOf(rem[0]);
                                if (idx > -1)
                                    marks.splice(idx, 1);
                            };
                        };
                    } else {
                        verifyChecked(stringClasse);
                        //
                        if (marks.indexOf(lineData) < 0)
                            marks.push(lineData);
                    };
                    //
                });
                $('.dataTables_modal .check-son').each(function () {
                    var lineData = $(mId).DataTable().rows($(this).parent().parent()).data()[0];
                    this.checked = (marks.indexOf(lineData) > -1);
                });
                //
                verifyChecked(stringClasse);
            }(this.markList, this.id);
            //
            this.clear = function () {
                this.markList = [];
                this.reworkModal();
            }.bind(this);
        } catch (e) {
            console.log(e);
            swal('Erro ao definir checkbox.', e.message);
            setCustomIcon('fa fa-window-close');
        };
    };
};
//-------------------

//Repeater Core.

//Extensions.
String.prototype.replaceAll = function (oldValue, newValue) {
    let string = this.toString();
    while (string.indexOf(oldValue) > -1) {
        string = string.replace(oldValue, newValue);
    };
    return string;
};

//Repeater.
var Repeater = function (options) {

    if (!options || typeof options != 'object') {
        return {
            code: 0,
            error: "The options parameter must be defined."
        };
    };

    this.ajax = $.ajax;

    this.container = $(options.containerId);

    this.parameters = options;

    this.data = [];

    this.onsucces = function (data, status, xhr, me) { };

    this.reload = function () {
        this.ajax(this.parameters);
        return this;
    };

    this.draw = function (data) {
        if (data) {
            if (this.parameters.model && typeof this.parameters.model == 'string') {
                let html_resource = '';
                for (let i = 0; i < data.length; i++) {
                    let regLine = data[i], model_resource = this.parameters.model;
                    for (let name in regLine) {
                        model_resource = model_resource.replaceAll('{' + name + '}', regLine[name]);
                    };
                    html_resource += model_resource;
                };
                this.container.html(html_resource);
            };
        };
        return this;
    };

    var success = function (data, status, xhr) {
        this.draw(data);
        this.data = data;
        //-
        if (this.onsucces && typeof this.onsucces == 'function') {
            this.onsucces(data, status, xhr, this);
        };
    }.bind(this);

    this.parameters.success = success;

    this.autor = {
        nome: "Gabriel M. Barbacena",
        data: "25/04/2023",
        versao: "1.0"
    };

    this.ajax(this.parameters);

    return this;
};

//Editor de tabela
var TableEditor = function (options) {
    if (!options) {
        return {
            code: 1,
            error: 'The options parameter must be defined.'
        };
    };

    this.parameters = options;

    this.table = $(this.parameters.tableId).DataTable();

    this.data = this.table.data;

    this.columns = this.parameters.columns;

    this.interval = this.parameters.interval ? this.parameters.interval : 100;

    this.isApplied = false;

    this.affterDraw = function () { };

    let _doAffterDraw = function () {
        this.isApplied = false;
        setTimeout(function () {
            this.affterDraw();
        }.bind(this), this.interval);
    }.bind(this);

    this.draw = function () {
        let dat = this.data();
        let dCols = this.columns;
        let tCols = this.table.settings().init().aoColumns;
        let selector = $(this.parameters.tableId + ' td');
        let eachFunc = function () {
            let cell = $(this);
            if (cell.attr('class') && cell.attr('class').indexOf('botoesGrid') < 0 && dat.cell(cell).index() != undefined) {
                let _cell = dat.cell(cell),
                    ci = _cell.index().column,
                    val = _cell.data();
                let _model = dCols.filter(function (c) {
                    return c.name == tCols[ci].data
                });
                if (_model && _model.length && _model.length > 0) {
                    this.innerHTML = (_model[0].model.replace('[]', val));
                };
            };
        };
        if (selector.each(eachFunc)) { _doAffterDraw(); };
    };

    this.apply = function () {
        let data = this.data();
        let selector = $(this.parameters.tableId + ' td');
        let eachFunc = function () {
            let cell = $(this);
            if (cell.attr('class') && (cell.attr('class').indexOf('botoesGrid') < 0)) {
                let element = cell.children();
                if (element.length > 0) {
                    if (element[0].tagName == 'INPUT') {
                        data.cell(cell).data(element.val());
                    } else if (element[0].tagName == 'SELECT') {
                        data.cell(cell).data(String(element[0].value));
                    } else {
                        data.cell(cell).data(element[0].innerText);
                    };
                };
            };
        };
        if (selector.each(eachFunc)) {
            this.isApplied = true;
            this.table.draw();
            return data;
        } else {
            return null;
        };
    };

    this.draw();

    return this;
};

function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1] - 1, mdy[0]);
};

function parseDateFormated(str) {
    var mdy = '';
    var strFormat = '';
    var _return = '';
    if (str == null || str == '')
        return '';
    if (str.indexOf('T') >= 0) {
        strFormat = str.split('T')[0];
        if (strFormat.indexOf('/') >= 0) {
            mdy = strFormat.split('/');
        }
        else if (strFormat.indexOf('-') >= 0) {
            mdy = strFormat.split('-');
        }
    }
    else {
        if (str.indexOf('/') >= 0) {
            mdy = str.split('/');
        }
        else if (str.indexOf('-') >= 0) {
            mdy = str.split('-');
        }
    }
    if (mdy[0] == '0001')
        return '';
    if (mdy == '') {
        return '';
    }
    else
        return _return = mdy[2] + "/" + mdy[1] +"/"+ mdy[0];
};

//Função que converte string para data e compara se data inicial não é maior
function datediff(first, second, idField) {
    var arr = [];
    arr = first.split("/");
    first = `${arr[2]}${arr[1]}${arr[0]}`;
    arr = second.split("/");
    second = `${arr[2]}${arr[1]}${arr[0]}`;
    if (parseFloat(first) > parseFloat(second)) {
        tooltipCampoObrigatorio(idField, 'Data inicial não pode ser maior');
        return;
    } else {
        return true;
    }
};

function GetNumber(val) {
    if (typeof val == 'number') {
        return val;
    }
    else {
        return val.replace(/\./g, "").replace(",", ".");
    }
};
function ParseDateToNumOfMonths(date) {
    var _mestemp = parseInt(date.split("/")[1]);
    var now = new Date;
    var retorno;
    var auxMonth = 0;
    var auxYear = 0;
    var oneYear = 0;
    if (parseInt(date.split("/")[2]) == now.getFullYear()) {
        if (_mestemp <= (now.getMonth() + 1))
            return 1;
        else {
           retorno = (_mestemp - (now.getMonth()));
            if (retorno < 0)
                retorno = retorno * -1;
            return retorno;
        }
    }
    else if (parseInt(date.split("/")[2]) > now.getFullYear()) {
        if (now.getMonth() >= (parseInt(date.split("/")[1]))) {
            auxMonth = (((12 - (now.getMonth())) + (parseInt(date.split("/")[1]))));
            oneYear = 1;
        }
        else {
            auxMonth = ((now.getMonth()) - (parseInt(date.split("/")[1])));
            oneYear = 0;
        }
        if (auxMonth < 0)
            auxMonth = auxMonth * -1;
        auxYear = ((parseInt(date.split("/")[2])) - now.getFullYear() - oneYear);
        retorno = ((auxYear * 12) + auxMonth);
        if (retorno < 0)
            retorno = retorno * -1;
        return retorno;
    }
    else if (parseInt(date.split("/")[2]) < now.getFullYear()) {
        return 1;
    }
}
function retira_acentos(str) {
    com_acento = "ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝŔÞßàáâãäåæçèéêëìíîïðñòóôõöøùúûüýþÿŕ";
    sem_acento = "AAAAAAACEEEEIIIIDNOOOOOOUUUUYRsBaaaaaaaceeeeiiiionoooooouuuuybyr";
    novastr = "";
    for (i = 0; i < str.length; i++) {
        troca = false;
        for (a = 0; a < com_acento.length; a++) {
            if (str.substr(i, 1) == com_acento.substr(a, 1)) {
                novastr += sem_acento.substr(a, 1);
                troca = true;
                break;
            }
        }
        if (troca == false) {
            novastr += str.substr(i, 1);
        }
    }
    return novastr;
};