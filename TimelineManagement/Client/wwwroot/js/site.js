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
}


// Get the current URL
const currentUrl = window.location.href;
const projectGuid = currentUrl.substring(currentUrl.lastIndexOf("/") + 1);

$.ajax({
    url: "https://localhost:7230/api/sections/",
    async: false
}).done((result) => {
    let temp = "";
    let temp2 = "";
    let sectionGuid;
    let sectionGuidInnTask;
    $.each(result.data, (key, val) => {
        sectionGuid = val.guid;
        temp += `
                    <div id="left" class="card h-100"  height: 100px">
                        <div style="color: white; height: 50px; text-align: center;">
                            <h4 class="card-title"  style="color : white;">${val.name}</h4>  
                        </div>
                            <div id="cardTask${key}"></div>
            `;

        $.ajax({
            url: `https://localhost:7230/api/projects/detail-project/${projectGuid}`,
            async : false
        }).done((result2) =>{

            console.log("block" + val.guid);
            
                $.each(result2.data, (key2, val2) => {
                    
                    if (val2.taskSection == val.guid) {
                        
                        console.log("ini task" + val2.taskSection);
                        console.log("");
                        temp += `
                        <div class="card m-2" draggable="true" style="color:black">
                            <div class="card-body">
                                <h5 class="card-title">${val2.taskName}</h5>
                                <button type="button" class="btn btn-primary" onclick="GetAll(${val2.taskGuid})"  data-bs-toggle="modal" data-bs-target="#detailTask">Detail</button>
                               
                            </div>
                        </div>
                        
                     `;
                    }else{
                        return;
                    }
                    
                })
            
        }); 
    
        temp += `</div>`
    })
    $("#cardSection").html(temp);
});

