function GetProducts() {
    $.ajax({
        url: '/product/GetProducts',
        type: 'get',
        dataType: 'json', // Corrected the typo in 'datatype' to 'dataType'
        contentType: 'application/json;charset=utf-8', // Corrected the typo in 'uft-8' to 'utf-8'
        success: function (response) { // Corrected the typo in 'succsess' to 'success'
            if (response == null || response == undefined || response.length == 0) {
                var object = '';

                object += '<tr>';
                object += '<td colspan="5">' + 'Products not available' + '</td>';
                object += '</tr>';
                $('#tblBody').html(object);
            } else {
                var object = '';
                $.each(response, function (index, item) {
                    object += '<tr>';
                    object += '<td>' + item.id + '</td>';
                    object += '<td>' + item.pname + '</td>';
                    object += '<td>' + item.price + '</td>';
                    object += '<td>' + item.qty + '</td>';
                    object += '<td><a href="#" class="btn btn-primary btn-sm" onclick="Edit(' + item.id + ')">Edit</a> <a href="#" class="btn btn-danger btn-sm" onclick="Delete(' + item.id + ')">Delete</a></td>';
                    object += '</tr>';
                });
                $('#tblBody').html(object);
            }
        },
        error: function () {
            alert('Unable to fetch data'); // Corrected the typo in 'unable data' to 'Unable to fetch data'
        }
    });
}