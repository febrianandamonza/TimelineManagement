// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function Insert() {
    var obj = new Object();
    obj.Name = $("#Name").val();
    obj.StartDate = $("#StartDate").val();
    obj.EndDate = $("#EndDate").val();
    obj.EmployeeGuid = $("#EmployeeGuid").val();
    obj.TaskName = $("#TaskName").val();
    obj.Priority = $("#Priority").val();
    obj.StartDateTask = $("#StartDateTask").val();
    obj.EndDateTask = $("#EndDateTask").val();
    $.ajax({
        url: "https://localhost:7230/api/projects/create-default",
        type: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        Swal.fire
            (
                'Data Has Been Successfuly Inserted',
                'Success'
            ).then(() => {
                location.reload();
            })
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops',
            text: 'Failed to insert data, Please Try Again',
        })
    })
}