var EmprestimoManter = function () {

    var _initGrid = function () {

        $("#tblEmprestimo").DataTable({
            ajax: {
                url: App.corrigirPathRota("lista-de-emprestimos"),
                type: "POST",
                datatype: "json",
                error: function (jqXhr) {
                },
                data: function (data) {
                    //data.nome = $("#iProcurarNome").val();
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
                    data: "titulo",
                    class: "text-nowrap",
                    orderable: true
                },
                {
                    data: "dataRetirada",
                    class: "text-nowrap text-center",
                    orderable: true
                },
                {
                    data: "dataDevolucao",
                    class: "text-nowrap text-center",
                    orderable: true
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
            $("#tblEmprestimo").DataTable().columns.adjust();
        });
    };

    return {
        init: function () {

            _initGrid();

        }
    };
}();

$(document).ready(function () {
    App.configuraDataTables();
    EmprestimoManter.init();
});
