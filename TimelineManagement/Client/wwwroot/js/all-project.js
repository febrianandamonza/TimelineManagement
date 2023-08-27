const guid = document.getElementById("guidInput").value;

$.ajax({
    url: `https://localhost:7230/api/project-collaborators/all-by-employee/` + guid
}).done((result) => {
    let temp = "";
    $.each(result.data, (key,val) => {
        temp += `
                <li class="menu-item">
                    <a class="menu-link" href="/Project/Index/${val.projectGuid}">
                    <div>${val.projectName}</div>
                    </a>
                </li>
            `;
    })
    $("#project-list").html(temp);
});
const img = ``
$.ajax({
    url: `https://localhost:7230/api/project-collaborators/all-by-employee/` + guid
}).done((result) => {
    let temp = "";
    $.each(result.data, (key, val) => {
        temp += `
                    <div class="col-3 my-3">
                    
                    <a href="/Project/Index/${val.projectGuid}">
                    <div class="card" style="border: 5px solid #696cff; text-align: center" >
                      <img src="https://www.itworks.id/wp-content/uploads/2021/02/metrodata-logo.jpg" class="img-thumbnail" alt="...">
                      <div class="card-body">
                        <h5 class="card-title">${val.projectName}</h5>
                        </div>
                      <ul class="list-group list-group-flush">
                         <div class="list-group-item textP"><span style="color: red">Start Date : </span> ${val.projectStartDate.split('T')[0]}</div>
                      <div class="list-group-item"><span style="color: red">End Date : </span>${val.projectStartDate.split('T')[0]}</div>
                      </ul>
                    </div>
                    </a>
                    </div>
                        
            `;
    })
    $("#project-card").html(temp);
});

function InsertProject() {
    var obj = new Object();
    obj.name = $("#NameProject").val();
    obj.startDate = $("#StartDateProject").val();
    obj.endDate = $("#EndDateProject").val();
    obj.employeeGuid = $("#EmployeeGuid").val();
    obj.taskName = $("#TaskName").val();
    obj.priority = parseInt($("#PriorityProject").val());
    obj.startDateTask = $("#StartDateTask").val();
    obj.endDateTask = $("#EndDateTask").val();

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
        console.log(obj);
    })
}
