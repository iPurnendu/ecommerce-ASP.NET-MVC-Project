$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/Admin/Product/getall' },
        "columns": [
            { data: 'productName', "width": "25%" },
            { data: 'storage', "width": "15%" },
            { data: 'brand', "width": "10%" },
            { data: 'color', "width": "10%" },
            { data: 'price', "width": "10%" },
            { data: 'disccountPrice', "width": "10%" },
            { data: 'category.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/product/upsertproduct?id=${data}" class="btn btn-info mx-3"> <i class="fa-solid fa-pen-to-square fa-bounce fa-xl"></i></a>               
                     <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-3"> <i class="fa-solid fa-trash fa-bounce fa-xl"></i></a>
                    </div>`
                },
                "width": "10%"
            }

        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}

