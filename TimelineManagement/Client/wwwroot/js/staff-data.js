$(document).ready(function () {
    let table = new DataTable('#staffTable', {
        ajax: {
            url: "https://localhost:7230/api/employees/staff",
            dataSrc: "data",
            dataType: "json" // dataType is lowercase
        },
        dom: 'Bfrtip',
        buttons: [
            'colvis', 'copy', 'csv', 'excel', 'pdf', 'print'
        ],
        columns: [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + 1;
                }
            },
            {
                data: "fullName",
            },
            {
                data: 'birthDate',
                render: function (data) {
                    const date = new Date(data);
                    const formattedDate = date.toISOString().slice(0, 10);
                    return formattedDate;
                }
            },
            {
                data: 'gender',
                render: function (data) {
                    return data === 0 ? 'Male' : 'Female';
                }
            },
            {
                data: 'hiringDate',
                render: function (data) {
                    const date = new Date(data);
                    const formattedDate = date.toISOString().slice(0, 10);
                    return formattedDate;
                }
            },
            {
                data: 'email'
            },
            {
                data: 'phoneNumber'
            }
        ]
    });
});
