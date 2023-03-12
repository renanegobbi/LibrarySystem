var UsuarioManter = function () {

    var _exibirPopupUsuario = function (codigo = null) {
        AppModal.exibirPorRota(App.corrigirPathRota("exibir-popup-usuario?codigo=" + codigo), function () {

            let cadastro = codigo === null || codigo === undefined || codigo === 0;

            App.aplicarMascaraCpf($("#iCpfUsuario"));
            App.aplicarMascaraCep($("#Endereco_Cep"));

            $("#Endereco_Cep").blur(BuscaCep());

            let frm = $('#form-manter-usuario');

            $('#btn-salvar').click(function () {
                frm.submit();
            });

            frm.validate({
                rules: {
                    iNomeUsuario: {
                        required: true
                    },
                    iCpfUsuario: {
                        required: true
                    },
                    Endereco_Cep: {
                        required: true
                    },
                    Endereco_Logradouro: {
                        required: true
                    },
                    Endereco_Numero: {
                        required: true
                    },
                    Endereco_Bairro: {
                        required: true
                    },
                    Endereco_Cidade: {
                        required: true
                    },
                    Endereco_Estado: {
                        required: true
                    },
                },

                submitHandler: function () {
                    let entrada = {
                        Id: $("#iIdUsuario").val(),
                        Nome: $("#iNomeUsuario").val().trim(),
                        Cpf: $("#iCpfUsuario").val(),
                        Endereco: {
                            Cep: $("#Endereco_Cep").val(),
                            Logradouro: $("#Endereco_Logradouro").val(),
                            Numero: $("#Endereco_Numero").val(),
                            Complemento: $("#Endereco_Complemento").val(),
                            Bairro: $("#Endereco_Bairro").val(),
                            Cidade: $("#Endereco_Cidade").val(),
                            Estado: $("#Endereco_Estado").val(),
                        },
                    };

                    $.post(App.corrigirPathRota(cadastro ? "novo-usuario" : "editar-usuario"), { model: entrada })
                        .done(function (feedbackResult) {
                            AppModal.ocultar();
                            let feedback = Feedback.converter(feedbackResult._feedback);
                            feedback.exibir(function () { $("#tblUsuario").DataTable().ajax.reload(); });
                        })
                        .fail(function (jqXhr) {
                            let feedback = Feedback.converter(jqXhr.responseJSON._feedback);
                            feedback.exibir();
                        });
                }
            });
        });
    };

    var _excluirUsuario = function (codigo) {
        AppModal.exibirConfirmacao("Deseja realmente excluir o usuário?", "Sim", "Não", function () {
            $.post(App.corrigirPathRota("excluir-usuario?codigo=" + codigo))
                .done(function (feedbackResult) {
                    let feedback = Feedback.converter(feedbackResult._feedback);
                    feedback.exibir(function () { $("#tblUsuario").DataTable().ajax.reload(); });
                })
                .fail(function (jqXhr) {
                    App.exibirSweetAlertPorJqXHR(jqXhr);
                });
        });
    }

    var _exibirPopupDetalharUsuario = function (codigo) {
        AppModal.exibirPorRota(App.corrigirPathRota("exibir-popup-detalhar-usuario?codigo=" + codigo))
    }

    var _initGrid = function () {

        $("#tblUsuario").DataTable({
            ajax: {
                url: App.corrigirPathRota("lista-de-usuarios"),
                type: "POST",
                datatype: "json",
                error: function (jqXhr) {
                },
                data: function (data) {
                    data.nome = $("#iProcurarNome").val();
                    data.cpf = $("#sProcurarCpf").val();
                }
            },
            autoWidth: true,
            info: true,
            serverSide: true,
            columns: [
                {
                    data: "id",
                    class: "text-nowrap text-center",
                    orderable: false,
                },
                {
                    data: "nome",
                    class: "text-nowrap",
                    orderable: true
                },
                {
                    data: "cpf",
                    class: "text-nowrap text-center",
                    orderable: false
                },
                {
                    data: null,
                    width: "1px",
                    class: "text-nowrap text-center",
                    orderable: false,
                    render: function (data, type, row) {
                        return "<button type=\"button\" data-codigo=\"" + row.id + "\" class=\"btn btn-xs btn-warning tooltip-left detalhar-usuario\" data-tooltip=\"Detalhar\"><i class=\"fa fa-search fa-fw\"></i></button>";
                    }
                },
                {
                    data: null,
                    width: "1px",
                    class: "text-nowrap text-center",
                    orderable: false,
                    render: function (data, type, row) {
                        return "<button type=\"button\" data-codigo=\"" + row.id + "\" class=\"btn btn-xs btn-primary tooltip-left alterar-usuario\" data-tooltip=\"Editar\"><i class=\"fa fa-edit fa-fw\"></i></button>";
                    }
                },
                {
                    data: null,
                    width: "1px",
                    class: "text-nowrap text-center",
                    orderable: false,
                    visible: $("#iPermissao").val(),
                    render: function (data, type, row) {
                        return "<button type=\"button\" data-codigo=\"" + row.id + "\" class=\"btn btn-xs btn-danger tooltip-left excluir-usuario\" data-tooltip=\"Excluir\"><i class=\"fa fa-trash fa-fw\"></i></button>";
                    }
                },
            ],
            order: [1, "asc"],
            searching: true,
            paging: true,
            pageLength: 10,
            lengthChange: true,
            processing: false
            //}).on("processing.dt", function () {
            //    App.bloquear();
        }).on('draw.dt', function () {
            $("#div-grid").show();
            $("#tblUsuario").DataTable().columns.adjust();

            $("button[class*='detalhar-usuario']").each(function () {
                let codigo = $(this).data('codigo');

                $(this).click(function () {
                    _exibirPopupDetalharUsuario(codigo);
                });
            });

            $("button[class*='alterar-usuario']").each(function () {
                let codigo = $(this).data('codigo');

                $(this).click(function () {
                    _exibirPopupUsuario(codigo);
                });
            });

            $("button[class*='excluir-usuario']").each(function () {
                let codigo = $(this).data('codigo');

                $(this).click(function () {
                    _excluirUsuario(codigo);
                });
            });
        });


    };

    return {
        init: function () {

            _initGrid();

            $(document).on("input", ".somenteNumero", function () { this.value = this.value.replace(/\D/g, ''); });

            $("#btn-cadastrar").click(function () {
                _exibirPopupUsuario();
            });
        }
    };
}();

$(document).ready(function () {
    App.configuraDataTables();
    UsuarioManter.init();
});
