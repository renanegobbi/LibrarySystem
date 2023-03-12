var LivroManter = function () {

    var _exibirPopupEmprestarLivro = function (codigo = null) {
        AppModal.exibirPorRota(App.corrigirPathRota("exibir-popup-emprestar-livro?codigo=" + codigo), function () {

            App.aplicarMascaraCpf($("#iCpfUsuario"));

            $("#btn-devolver").click(function () {
                let LivroId = $("#iIdLivro").val();
                _realizarDevolucao(LivroId)
            });

            $("#btn-consultar").click(function () {
                $("#tblConsultaUsuario").DataTable().ajax.reload();
            });

            $('#tblConsultaUsuario').DataTable({
                ajax: {
                    url: App.corrigirPathRota("obter-usuario-por-cpf"),
                    type: "POST",
                    error: function (jqXhr) {
                        App.desbloquear();
                        var feedback = Feedback.converter(jqXhr.responseJSON);
                        feedback.exibir();
                    },
                    data: function (data) {
                        data.cpf = $('#iCpfUsuario').val();
                    }
                },
                autoWidth: false,
                info: false,
                serverSide: true,
                columns: [
                    {
                        data: "nome",
                        class: "text-nowrap",
                        orderable: false,
                    },
                    {
                        data: "cpf",
                        class: "text-nowrap text-center",
                        orderable: false,
                    },
                    {
                        data: null,
                        width: "1px",
                        class: "text-nowrap text-center",
                        orderable: false,
                        render: function (data, type, row) {
                            return "<button type=\"button\" data-codigo=\"" + row.id + "\" class=\"btn btn-xs btn-success tooltip-left emprestar-livro-usuario\" data-tooltip=\"Emprestar\"><i class=\"fa fa-pencil fa-fw\"></i></button>";
                        }
                    }
                ],
                order: [0, "asc"],
                ordering: false,
                searching: false,
                paging: false,
                lengthChange: false,
                processing: false,
                //}).on("processing.dt", function () {
                //    App.bloquear();
            }).on('draw.dt', function () {
                $("#div-grid").show();
                $("#tblConsultaUsuario").DataTable().columns.adjust();
                if ($('#iCpfUsuario').val().length == 0) { $("#tblConsultaUsuario > tbody > tr > td").hide(); }

                $("button[class*='emprestar-livro-usuario']").each(function () {
                    let idUsuario = $(this).data('codigo');

                    $(this).click(function () {
                        _realizarEmprestimo(idUsuario);
                    });
                });
            });
        });
    };

    var _realizarEmprestimo = function (codigo = null) {
        let entrada = {
            UsuarioId: codigo,
            LivroId: $("#iIdLivro").val(),
        };

        $.post(App.corrigirPathRota("emprestar-livro"), { model: entrada })
            .done(function (feedbackResult) {
                AppModal.ocultar();
                let feedback = Feedback.converter(feedbackResult._feedback);
                feedback.exibir(function () { $("#tblLivro").DataTable().ajax.reload(); });
            })
            .fail(function (jqXhr) {
                let feedback = Feedback.converter(jqXhr.responseJSON);
                feedback.exibir();
            });
    };

    var _realizarDevolucao = function (LivroId = null) {

        let codigo = LivroId;

        $.post(App.corrigirPathRota("devolver-livro"), { codigo })
            .done(function (feedbackResult) {
                AppModal.ocultar();
                let feedback = Feedback.converter(feedbackResult._feedback);
                feedback.exibir(function () { $("#tblLivro").DataTable().ajax.reload(); });
            })
            .fail(function (jqXhr) {
                let feedback = Feedback.converter(jqXhr.responseJSON);
                feedback.exibir();
            });
    };

    var _exibirPopupDetalharLivro = function (codigo) {
        AppModal.exibirPorRota(App.corrigirPathRota("exibir-popup-detalhar-livro?codigo=" + codigo))
    }

    var _exibirPopupLivro = function (codigo = null) {
        AppModal.exibirPorRota(App.corrigirPathRota("exibir-popup-livro?codigo=" + codigo), function () {

            let cadastro = codigo === null || codigo === undefined || codigo === 0;

            contadorCaracteres(1000);

            App.aplicarMascaraDiaMesAno($("#AnoPublicacao"))

            let frm = $('#form-manter-livro');

            $('#btn-salvar').click(function () {
                frm.submit();
            });

            frm.validate({
                rules: {
                    Imagem: {
                        required: true
                    },
                    Titulo: {
                        required: true
                    },
                    Descricao: {
                        required: true
                    },
                    Editora: {
                        required: true
                    },
                    AnoPublicacao: {
                        required: true
                    },
                    AnoPublicacao2: {
                        required: true
                    },
                },

                submitHandler: function () {

                    let model = new FormData();

                    model.append('Id', $("#iIdLivro").val());
                    model.append('Imagem', $("#Imagem").val().trim());
                    model.append('Titulo', $("#Titulo").val().trim());
                    model.append('Descricao', $("#Descricao").val().trim());
                    model.append('Editora', $("#Editora").val().trim());
                    model.append('AnoPublicacao', $("#AnoPublicacao").val());
                    model.append('ImagemUpload', $("#ImagemUpload")[0].files[0]);

                    $.ajax({
                        url: cadastro ? "/novo-livro" : "/editar-livro",
                        method: "POST",
                        processData: false,
                        contentType: false,
                        data: model,
                    })
                        .done(function (feedbackResult) {
                            AppModal.ocultar();
                            let feedback = Feedback.converter(feedbackResult._feedback);
                            feedback.exibir(function () { $("#tblLivro").DataTable().ajax.reload(); });
                        })
                        .fail(function (jqXhr) {
                            let feedback = Feedback.converter(jqXhr.responseJSON._feedback);
                            feedback.exibir();
                        });
                }
            });
        });
    };

    var _excluirLivro = function (codigo) {
        AppModal.exibirConfirmacao("Deseja realmente excluir o livro?", "Sim", "Não", function () {
            $.post(App.corrigirPathRota("excluir-livro?codigo=" + codigo))
                .done(function (feedbackResult) {
                    let feedback = Feedback.converter(feedbackResult._feedback);
                    feedback.exibir(function () { $("#tblLivro").DataTable().ajax.reload(); });
                })
                .fail(function (jqXhr) {
                    App.exibirSweetAlertPorJqXHR(jqXhr);
                });
        });
    }

    var _initGrid = function () {

        $("#tblLivro").DataTable({
            "lengthMenu": [[5, 10, 25, 50, 100], [5, 10, 25, 50, 100]],
            ajax: {
                url: App.corrigirPathRota("lista-de-livros"),
                type: "POST",
                datatype: "json",
                error: function (jqXhr) {
                },
                data: function (data) {
                    data.titulo = $("#iProcurarTitulo").val();
                    data.descricao = $("#sProcurarDescricao").val();
                },
            },
            autoWidth: true,
            info: true,
            serverSide: true,
            columns: [
                {
                    data: null,
                    width: "1px",
                    class: "text-nowrap",
                    orderable: false,
                    render: function (data, type, row) {
                        return "<img src=\"/Imagens/" + row.imagem + "\" alt=\"" + row.imagem + "\" style=\"width: 70px; height: 100px\" />";
                    }
                },
                {
                    data: "titulo",
                    class: "text-nowrap",
                    orderable: true
                },
                {
                    data: "descricao",
                    class: "text-nowrap",
                    orderable: true
                },
                {
                    data: null,
                    width: "1px",
                    class: "text-nowrap",
                    orderable: false,
                    render: function (data, type, row) {
                        return "<button type=\"button\" data-codigo=\"" + row.id + "\" class=\"btn btn-xs btn-success tooltip-left emprestar-livro\" data-tooltip=\"Emprestar\"><i class=\"fa fa-pencil fa-fw\"></i></button>";
                    }
                },
                {
                    data: null,
                    width: "1px",
                    class: "text-nowrap",
                    orderable: false,
                    render: function (data, type, row) {
                        return "<button type=\"button\" data-codigo=\"" + row.id + "\" class=\"btn btn-xs btn-warning tooltip-left detalhar-livro\" data-tooltip=\"Detalhar\"><i class=\"fa fa-search fa-fw\"></i></button>";
                    }
                },
                {
                    data: null,
                    width: "1px",
                    class: "text-nowrap text-center",
                    orderable: false,
                    render: function (data, type, row) {
                        return "<button type=\"button\" data-codigo=\"" + row.id + "\" class=\"btn btn-xs btn-primary tooltip-left alterar-livro\" data-tooltip=\"Editar\"><i class=\"fa fa-edit fa-fw\"></i></button>";
                    }
                },
                {
                    data: null,
                    width: "1px",
                    class: "text-nowrap text-center",
                    orderable: false,
                    visible: $("#iPermissao").val(),
                    render: function (data, type, row) {

                        return "<button type=\"button\" data-codigo=\"" + row.id + "\" class=\"btn btn-xs btn-danger tooltip-left excluir-livro\" data-tooltip=\"Excluir\"><i class=\"fa fa-trash fa-fw\"></i></button>";
                    }
                },
            ],
            order: [1, "asc"],
            searching: true,
            paging: true,
            pageLength: 5,
            lengthChange: true,
            processing: false
            //}).on("processing.dt", function () {
            //    App.bloquear();
        }).on('draw.dt', function () {
            $("#div-grid").show();
            $("#tblLivro").DataTable().columns.adjust();

            $("button[class*='emprestar-livro']").each(function () {
                let codigo = $(this).data('codigo');

                $(this).click(function () {
                    _exibirPopupEmprestarLivro(codigo);
                });
            });

            $("button[class*='detalhar-livro']").each(function () {
                let codigo = $(this).data('codigo');

                $(this).click(function () {
                    _exibirPopupDetalharLivro(codigo);
                });
            });

            $("button[class*='alterar-livro']").each(function () {
                let codigo = $(this).data('codigo');

                $(this).click(function () {
                    _exibirPopupLivro(codigo);
                });
            });

            $("button[class*='excluir-livro']").each(function () {
                let codigo = $(this).data('codigo');

                $(this).click(function () {
                    _excluirLivro(codigo);
                });
            });
        });
    };

    return {
        init: function () {

            _initGrid();

            $(document).on("input", ".somenteNumero", function () { this.value = this.value.replace(/\D/g, ''); });

            $("#btn-cadastrar").click(function () {
                _exibirPopupLivro();
            });
        }
    };
}();

$(document).ready(function () {
    App.configuraDataTables();
    LivroManter.init();
});

function contadorCaracteres(maximoCaracter) {

    var maximo = maximoCaracter;

    var campo = $(".campo-digitacao");
    campo.on("input", function () {
        var conteudo = campo.val();

        var qtdCaracteres = conteudo.length;
        var disponivel = maximo - qtdCaracteres;
        $("#contador-caracteres").text(disponivel);
    });
}

$.extend($.fn.datepicker.defaults, {
    autoclose: true,
    language: 'pt-BR',
    format: 'dd/mm/yyyy',
    todayBtn: 'linked',
    todayHighlight: true,
    orientation: "auto right"
});

