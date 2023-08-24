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
                $.each(result2.data, (key2, val2) => {
                    if (val2.taskSection == val.guid) {
                        
                        temp += `
                        <div class="card m-2" draggable="true" style="color:black">
                            <div class="card-body">
                                <h5 class="card-title">${val2.taskName}</h5>
                                <button type="button" class="btn btn-primary" onclick="detailTask('${val2.taskGuid}')"  data-bs-toggle="modal" data-bs-target="#detailTask">Detail</button>
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

function detailTask(taskGuid){
    $.ajax({
        url: `https://localhost:7230/api/tasks/detail-task/` + taskGuid,
        success: function (result){
            let name = "";
            let startDate = "";
            let endDate = "";
            let isFinished = "";
            let priority = "";
            let projectName = "";
            let projectManager = "";
            let sectionName = "";
            let employeeName = "";
            let employeePhoneNumber = "";
            let employeeMail = "";
            
            name = ` <input type="text" id="Name" name="Name" class="form-control" value="${result.data.name}" disabled="true"/>`
            startDate = `<input type="text" id="StartDate" name="StartDate" class="form-control" value="${result.data.startDate}" disabled="true"/>`
            endDate = `<input type="text" id="EndDate" name="EndDate" class="form-control" value="${result.data.endDate}" disabled="true"/>`
            isFinished = ` <input type="text" id="isFinished" name="isFinished" class="form-control" value="${result.data.isFinished}" disabled="true"/>`
            priority = `<input type="text" id="Priority" name="Priority" class="form-control" value="${result.data.priority}" disabled="true"/>`
            projectName = `<input type="text" id="ProjectName" name="ProjectName" class="form-control" value="${result.data.projectName}" disabled="true"/>`
            projectManager = `<input type="text" id="ProjectManager" name="ProjectManager" class="form-control" value="${result.data.projectManager}" disabled="true"/>`
            sectionName = `<input type="text" id="SectionName" name="SectionName" class="form-control" value="${result.data.sectionName}" disabled="true"/>`
            employeeName =`<input type="text" id="EmployeeName" name="EmployeeName" class="form-control" value="${result.data.employeeName}" disabled="true"/>`
            employeePhoneNumber = `<input type="text" id="EmployeePhoneNumber" name="EmployeePhoneNumber" class="form-control" value="${result.data.employeePhoneNumber}" disabled="true"/>`
            employeeMail = `<input type="text" id="EmployeeEmail" name="EmployeeEmail" class="form-control" value="${result.data.employeeEmail}" disabled="true"/>`
            
            $('#name').html(name);
            $('#startDate').html(startDate);
            $('#endDate').html(endDate);
            $('#isFinished').html(isFinished);
            $('#priority').html(priority);
            $('#projectName').html(projectName);
            $('#projectManager').html(projectManager);
            $('#sectionName').html(sectionName);
            $('#employeeName').html(employeeName);
            $('#employeePhoneNumber').html(employeePhoneNumber);
            $('#employeeMail').html(employeeMail);
            
           /* $('#StartDate').val(result.data.startDate);
            $('#EndDate').val(result.data.endDate);
            $('#IsFinished').val(result.data.isFinished);
            $('#Priority').val(result.data.priority);
            $('#ProjectName').val(result.data.projectName);
            $('#ProjectManager').val(result.data.projectManager);
            $('#SectionName').val(result.data.sectionName);
            $('#EmployeeName').val(result.data.employeeName);
            $('#EmployeePhoneNumber').val(result.data.employeePhoneNumber);
            $('#EmployeeEmail').val(result.data.employeeEmail);*/
            
        },
        error: function (error){
            console.error(error);
        }
    });
}


