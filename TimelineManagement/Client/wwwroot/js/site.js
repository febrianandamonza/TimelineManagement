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
    obj.projectGuid = $("#ProjectGuid").val();
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
                    <div id="left" class="card h-100" >
                        <div style=" height: 50px; text-align: center; ">
                            <h4 class="card-title" style="color : white; margin-top: 15px;">${val.name}</h4>  
                        </div>
                            <div id="cardTask${key}"></div>
            `;

        $.ajax({
            url: `https://localhost:7230/api/projects/detail-project/${projectGuid}`,
            async : false
        }).done((result2) =>{
            let priorityValue = ""
                $.each(result2.data, (key2, val2) => {
                    if (val2.taskSection == val.guid) {
                        if (val2.priority == 0) {
                            priorityValue = `<h5 class="badge badge-success">Low Priority</h5>`
                        }
                        else if (val2.priority == 1) {
                            priorityValue = `<h5 class="badge badge-warning">Medium Priority</h5>`
                        }
                        else if (val2.priority == 2) {
                            priorityValue = `<h5 class="badge badge-danger">High Priority</h5>`
                        }
                        temp += `
                        <div class="card m-2" draggable="true" style="color:black" onclick="detailTask('${val2.taskGuid}')"  data-bs-toggle="modal" data-bs-target="#detailTask">
                            <div class="card-body">
                                <h5 class="card-title">${val2.taskName}</h5>
                                ${priorityValue}
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
            let changeSection = "";
            let changeStatus = "";
            let employeeName = "";
            let employeePhoneNumber = "";
            let employeeMail = "";
            let priorityValue = "";
            let statusValue = "";
            
            name = ` <input type="text" id="Name" name="Name" class="form-control" value="${result.data.name}" disabled="true"/>`
            startDate = `<input type="text" id="StartDate" name="StartDate" class="form-control" value="${result.data.startDate.split('T')[0]}" disabled="true"/>`
            endDate = `<input type="text" id="EndDate" name="EndDate" class="form-control" value="${result.data.endDate.split('T')[0]}" disabled="true"/>`
            
            if(result.data.isFinished == true){
                statusValue = "Finished"
            }
            else if(result.data.isFinished == false){
                statusValue = "Unfinished"
            }
            isFinished = ` <input type="text" id="isFinished" name="isFinished" class="form-control" value="${statusValue}" disabled="true"/>`
           
            if (result.data.priority == 0) {
                priorityValue = "Low"
            }
            else if (result.data.priority == 1) {
                priorityValue = "Medium"
            }
            else if (result.data.priority == 2) {
                priorityValue = "High"
            }
            priority = `<input type="text" id="Priority" name="Priority" class="form-control" value="${priorityValue}" disabled="true"/>`
            projectName = `<input type="text" id="ProjectName" name="ProjectName" class="form-control" value="${result.data.projectName}" disabled="true"/>`
            projectManager = `<input type="text" id="ProjectManager" name="ProjectManager" class="form-control" value="${result.data.projectManager}" disabled="true"/>`
            sectionName = `
<input type="text" id="SectionName" name="SectionName" class="form-control" value="${result.data.sectionName}" disabled="true"/>
<button class="btn btn-danger mt-1" data-bs-toggle="modal" data-bs-target="#changeSection">Change</button>
                            
`
            employeeName =`<input type="text" id="EmployeeName" name="EmployeeName" class="form-control" value="${result.data.employeeName}" disabled="true"/>`
            employeePhoneNumber = `<input type="text" id="EmployeePhoneNumber" name="EmployeePhoneNumber" class="form-control" value="${result.data.employeePhoneNumber}" disabled="true"/>`
            employeeMail = `<input type="text" id="EmployeeEmail" name="EmployeeEmail" class="form-control" value="${result.data.employeeEmail}" disabled="true"/>`
            changeSection = `
<div class="modal-footer">       
<button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
<button class="btn btn-danger mt-1" onclick="UpdateSection('${result.data.guid}')" data-bs-toggle="modal" data-bs-target="#changeSection">Change</button>
</div>
`
            changeStatus = `<div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" onclick="UpdateStatus('${result.data.guid}')" data-bs-dismiss="modal">Change</button>
                </div>`
            
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
            $('#sectionChange').html(changeSection);
            $('#statusChange').html(changeStatus);
            
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

function UpdateSection(taskGuid) {
    let data = {
        guid : taskGuid,
        sectionGuid: $("#Section").val()
    };
    $.ajax({
        url: `https://localhost:7230/api/tasks/change-section/`,
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(data)
    }).done((result) => {
        Swal.fire(
            'Data has been successfully updated!',
            'success'
        ).then(() => {
            location.reload();
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Failed to change data! Please try again.'
        })
        console.log(error)
        console.log(data)
    })
}

function UpdateStatus(taskGuid) {
    let data = {
        guid : taskGuid,
        taskStatus: true
    };
    $.ajax({
        url: `https://localhost:7230/api/tasks/change-status/`,
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(data)
    }).done((result) => {
        Swal.fire(
            'Data has been successfully updated!',
            'Success'
        ).then(() => {
            console.log(data)
            console.log(result)
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Failed to change data! Please try again.'
        })
        console.log(error)
        console.log(data)
        console.log(taskGuid)
    })
}

