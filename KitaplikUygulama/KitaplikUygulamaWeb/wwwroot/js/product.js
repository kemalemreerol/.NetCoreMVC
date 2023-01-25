var dataTable;

$((document).ready(function () {

    loadDataTable();
});

function loadDataTable() {

    dataTable = $("#tblData").DataTable({

        "ajax": {
            "url": "/Admin/Product/GetAll"

        },

        "column": [

            { "data": "Title", "width":"15%"},
            { "data": "ISBN", "width":"15%"},
            { "data": "Price", "width":"15%"},
            //{ "data": "Title", "width":"15%"},
            //{ "data": "Title", "width":"15%"}

        ]

        

    });

}