// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function Insert() {
    var obj = new Object();
    obj.name = $("#Name").val();
    obj.startDate = $("#StartDate").val();
    obj.endDate = $("#EndDate").val();
    obj.employeeGuid = $("#EmployeeGuid").val();
    obj.taskName = $("#TaskName").val();
    obj.priority = parseInt($("#Priority").val());
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
    })
    console.log(obj);
}

const guid = document.getElementById("guidInput").value;

$.ajax({
    url: `https://localhost:7230/api/projects/project-by-employee/` + guid
}).done((result) => {
    let temp = "";
    $.each(result.data, (key,val) => {
        temp += `
                <li class="menu-item">
                    <a class="menu-link" href="/Project/Index/${val.guid}">
                    <div>${val.projectName}</div>
                    </a>
                </li>
            `;
        console.log(val.projectName);
    })
    $("#project-list").html(temp);
});

function openAddColabModal() {
    const currentUrl = window.location.href;
    const projectGuid = currentUrl.substring(currentUrl.lastIndexOf("/") + 1);

    document.getElementById("ProjectGuid").value = projectGuid;
}

function Insert() {
    var obj = new Object();
    obj.email = $("#Email").val();
    obj.projectGuid = $("#ProjectGuid").val();

    $.ajax({
        url: "https://localhost:7230/api/project-collaborators/create-by-email",
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
    console.log(obj);
}

function Insert() {
    var obj = new Object();
    obj.name = $("#Name").val();
    obj.startDate = $("#StartDate").val();
    obj.endDate = $("#EndDate").val();
    obj.priority = parseInt($("#Priority").val());
    obj.projectName = $("#ProjectName").val();
    obj.employeeEmail = $("#EmployeeEmail").val();

    $.ajax({
        url: "https://localhost:7230/api/tasks/create-default",
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
    console.log(obj);
}

$.ajax({
    url: "https://localhost:7230/api/sections/"
}).done((result) => {
    let temp = "";
    $.each(result.data, (key, val) => {
        temp += `
                    <div id="left" class="card h-100" style="background: white; height: 100px">
                        <div style="color: white; height: 200; text-align: center;">
                            <h4 class="card-title">${val.name}</h4>     
                            <h1>Task</h1>
                        </div>                        
                    </div>
            `;
    })
    $("#cardSection").html(temp);
});


// Get the current URL
const currentUrl = window.location.href;
const projectGuid = currentUrl.substring(currentUrl.lastIndexOf("/") + 1);

if (projectGuid) {
    $.ajax({
        url: `https://localhost:7230/api/projects/detail-project/${guid}`
    }).done((result) => {
        let temp = "";
        $.each(result.data, (key, val) => {
            temp += `
                <div class="card m-2" draggable="true" style="">
                    <div class="card-body">
                        <h5 class="card-title">${val.taskName}</h5>
                        <p class="card-text">${val.priority}</p>
                        <p class="card-text">${val.startDateTask}</p>
                        <p class="card-text">${val.endDateTask}</p>
                    </div>
                </div>
            `;
        })
        $("#cardTask").html(temp);
        
    });
} else {
    // Handle the case where the guid is not found in the URL
    console.error("GUID not found in the URL");
    console.log(projectGuid);
}




//$.ajax({
//    url: "https://localhost:7230/api/projects/detail-project/"
//}).done((result) => {
//    let temp = "";
//    $.each(result.data, (key, val) => {
//        temp += `
//                    <div class="card m-2" draggable="true" style="">
//                        <div class="card-body">
//                            <h5 class="card-title">${val.taskName}</h5>
//                            <p class="card-text">${val.priority}</p>
//                            <p class="card-text">${val.startDateTask}</p>
//                            <p class="card-text">${val.endDateTask}</p>
//                        </div>
//                    </div>
//            `;
//    })
//    $("#cardTask").html(temp);
//});
