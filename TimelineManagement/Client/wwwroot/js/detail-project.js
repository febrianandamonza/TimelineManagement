// Get the current URL
const currentUrl = window.location.href;
const projectGuid = currentUrl.substring(currentUrl.lastIndexOf("/") + 1);
const guid = document.getElementById("guidInput").value;
const tokenJWT = document.getElementById("jwtToken").value;

$.ajax({
    url: `https://localhost:7230/api/project-collaborators/all-by-employee/` + guid,
    headers: {
        'Authorization': 'Bearer ' + tokenJWT
    },
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

$.ajax({
    url: "https://localhost:7230/api/sections/",
    headers: {
        'Authorization': 'Bearer ' + tokenJWT
    },
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
            headers: {
                'Authorization': 'Bearer ' + tokenJWT
            },
            async : false
        }).done((result2) =>{
            let priorityValue = ""
            $.each(result2.data, (key2, val2) => {
                if (val2.taskSection == val.guid) {
                    if (val2.priority == 0) {
                        priorityValue = `<h5 class="badge badge-success">Low Priority</h5>`
                    } else if (val2.priority == 1) {
                        priorityValue = `<h5 class="badge badge-warning">Medium Priority</h5>`
                    } else if (val2.priority == 2) {
                        priorityValue = `<h5 class="badge badge-danger">High Priority</h5>`
                    }
                    temp += `
                        <div class="card m-2" draggable="true" style="color: black" onclick="detailTask('${val2.taskGuid}')" data-bs-toggle="modal" data-bs-target="#detailTask">
                            <div class="card-body taskPointer" onmouseover="this.style.boxShadow='0 0 10px rgba(0,0,0,0.5)';" onmouseout="this.style.boxShadow='none';">
                                
                     `;

                    let taskid = val2.taskGuid;
                    $.ajax({
                        url: `https://localhost:7230/api/task-comments/count-comment/` + taskid + `/` + projectGuid,
                        headers: {
                            'Authorization': 'Bearer ' + tokenJWT
                        },
                        async : false
                    }).done((result3) => {
                        let temp2 = "";
                        temp += `<h5 class="card-title" >${val2.taskName} <span class="badge badge-danger">${result3.data.total}</span></h5>
                                ${priorityValue}
                            </div>
                        </div>`;
                        temp2 += `<span class="badge badge-danger">${result3.data.total}</span> `;
                        $("#totalCommentTask").html(temp2);
                    });
                }
            })
            $("#nameHeader").text(`${result2.data[0].name}`);
        });
        temp += `</div>`

    })
    $("#cardSection").html(temp);

});



function detailTask(taskGuid){
    $.ajax({
        url: `https://localhost:7230/api/tasks/detail-task/` + taskGuid,
        headers: {
            'Authorization': 'Bearer ' + tokenJWT
        },
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
            let listComment ="";
            let insertComment = "";

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
                  <button class="btn btn-danger mt-1" onclick="UpdateSection('${result.data.projectGuid}','${result.data.guid}','${result.data.employeeGuid}')" data-bs-toggle="modal" data-bs-target="#changeSection">Change</button>
            </div>
                            `
            changeStatus = `
            <div class="modal-footer">
                 <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                 <button type="button" class="btn btn-primary" onclick="UpdateStatus('${result.data.projectGuid}','${result.data.guid}','${result.data.employeeGuid}')" data-bs-dismiss="modal">Change</button>
            </div>`

            listComment = `
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                <button class="btn btn-primary" data-bs-target="#historyModal" onclick="listHistory('${result.data.projectGuid}', '${result.data.guid}')" data-bs-toggle="modal" data-bs-dismiss="modal">Open History</button>
                <button class="btn btn-primary" data-bs-target="#commentModal" onclick="listComment('${result.data.projectGuid}', '${result.data.guid}')" data-bs-toggle="modal" data-bs-dismiss="modal">Open Comment <span data-taskid="${result.data.guid}" id="totalCommentTask"></span></button>
            </div>`

            insertComment = `
            <div class="modal-footer">
                  <button class="btn btn-primary" data-bs-target="#commentModal" data-bs-toggle="modal" data-bs-dismiss="modal">Back to comment</button>
                  <button class="btn btn-primary" onclick="InsertComment('${result.data.projectGuid}', '${result.data.guid}', '${guid}')" data-bs-toggle="modal" data-bs-dismiss="modal">Save</button>
            </div>
            `

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
            $('#listComment').html(listComment);
            $('#insertComment').html(insertComment);

            const taskGuid = $("#totalCommentTask").attr("data-taskid");
            console.log(taskGuid);
            $.ajax({
                url: `https://localhost:7230/api/task-comments/count-comment/` + taskGuid + `/` + projectGuid,
                headers: {
                    'Authorization': 'Bearer ' + tokenJWT
                },
                async : false
            }).done((result3) => {
                let temp = "";
                console.log(result3.data.total)
                temp += `<span class="badge badge-danger">${result3.data.total}</span> `;
                $("#totalCommentTask").html(temp);
            });

        },
        error: function (error){
            console.error(error);
        }
    });
}





function UpdateSection(projectGuid,taskGuid,employeeGuid) {
    var valueOne =  $("#Section").val().split(',')[0]
    var valueTwo =  $("#Section").val().split(',')[1]
    let data = {
        guid : taskGuid,
        sectionGuid: valueOne
        
    };
    $.ajax({
        url: `https://localhost:7230/api/tasks/change-section/`,
        headers: {
            'Authorization': 'Bearer ' + tokenJWT
        },
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(data)
    }).done((result) => {
        InsertHistorySection(projectGuid,taskGuid,employeeGuid,valueTwo)
        
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Failed to change section! Please try again.'
        })
        console.log(error)
        console.log(data)
    })
}

function UpdateStatus(projectGuid,taskGuid,employeeGuid) {
    var valueOne =  $("#isFinishedStatus").val() == "1" ? true : false;
    var valueTwo =  $("#isFinishedStatus").val() == 1 ? "Finished" : "Unfinished";
    let data = {
        guid : taskGuid,
        isFinished: valueOne
    };
    console.log(valueOne);
    $.ajax({
        url: `https://localhost:7230/api/tasks/change-status/`,
        headers: {
            'Authorization': 'Bearer ' + tokenJWT
        },
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(data)
    }).done((result) => {
        console.log(data)
        InsertHistoryStatus(projectGuid,taskGuid,employeeGuid,valueTwo)
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Failed to change status! Please try again.'
        })
        
    })
}
function openAddColabModal() {
    const currentUrl = window.location.href;
    const projectGuid = currentUrl.substring(currentUrl.lastIndexOf("/") + 1);

    document.getElementById("ProjectGuid").value = projectGuid;
}

function InsertCollab() {
    var obj = new Object();
    obj.email = $("#Email").val();
    obj.projectGuid = $("#ProjectGuid").val();

    $.ajax({
        url: "https://localhost:7230/api/project-collaborators/create-by-email",
        type: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + tokenJWT
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        Swal.fire
        (
            'Invitation Collaborator has been send',
            'Success'
        ).then(() => {
            location.reload();
        })
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops',
            text: 'Failed send invite collaborator, Please Try Again',
        })
    })
}

function InsertTask() {
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
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + tokenJWT
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        Swal.fire
        (
            'Data Has Been Successfully Inserted',
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

function listComment(projectGuid, taskGuid) {
    $.ajax({
        url: `https://localhost:7230/api/task-comments/detail-task-comments-by-task/` + projectGuid + `/` + taskGuid,
        headers: {
            'Authorization': 'Bearer ' + tokenJWT
        },
        success: function (result) {
            let temp = ``;
            $.each(result.data, (key, val) => {
                temp += `
          </div>
          <div class="d-flex justify-content-between">
                    <label class="control-label form-label">${val.employeeName}</label>
                        <small >${val.createdDateComment.split('T')[0]}</small>
                </div>
                <textarea class="form-control" id="Comment" rows="3" disabled="true" >${val.description}</textarea>
                <br>
            `;
            })
            $('#commentBody').html(temp);
        }

    });
}

function listHistory(projectGuid, taskGuid) {
    $.ajax({
        url: `https://localhost:7230/api/task-histories/detail-task-histories-by-task/` + projectGuid + `/` + taskGuid,
        headers: {
            'Authorization': 'Bearer ' + tokenJWT
        },
        success: function (result) {
            let temp = ``;
            $.each(result.data, (key, val) => {
                temp += `
          </div>
          <div class="d-flex justify-content-between">
                    <label class="control-label form-label">${val.employeeName}</label>
                        <small >${val.createdDateHistory.split('T')[0]}</small>
                </div>
                <textarea class="form-control" id="History" rows="3" disabled="true" >${val.description}</textarea>
                <br>
            `;
            })
            $('#historyBody').html(temp);
        }

    });
}

function InsertComment(projectGuid, taskGuid, employeeGuid) {
    var obj = new Object();
    obj.description = $("#CommentInsert").val();
    obj.taskGuid = taskGuid;
    obj.employeeGuid = employeeGuid;
    obj.projectGuid = projectGuid;

    $.ajax({
        url: "https://localhost:7230/api/task-comments/",
        type: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + tokenJWT
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        InsertHistoryComment(projectGuid, taskGuid, employeeGuid)
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops',
            text: 'Failed to insert data, Please Try Again',
        })

    })
    console.log(obj);
}

function InsertHistoryComment(projectGuid, taskGuid, employeeGuid) {
    var obj = new Object();
    obj.description = "Add Comment";
    obj.taskGuid = taskGuid;
    obj.employeeGuid = employeeGuid;
    obj.projectGuid = projectGuid;

    $.ajax({
        url: "https://localhost:7230/api/task-histories/",
        type: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + tokenJWT
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        Swal.fire(
            'Comment has been successfully inserted!',
            'success'
        ).then(() => {
            location.reload();
        });
    }).fail((error) => {

    })
    console.log(obj);
}

function InsertHistorySection(projectGuid, taskGuid, employeeGuid, sectionName) {
    var obj = new Object();
    obj.description = "Change Section to " + sectionName;
    obj.taskGuid = taskGuid;
    obj.employeeGuid = employeeGuid;
    obj.projectGuid = projectGuid;

    $.ajax({
        url: "https://localhost:7230/api/task-histories/",
        type: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + tokenJWT
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        Swal.fire(
            'Section has been successfully updated!',
            'success'
        ).then(() => {
            location.reload();
        });
    }).fail((error) => {

    })
    console.log(obj);
}

function InsertHistoryStatus(projectGuid, taskGuid, employeeGuid, statusName) {
    var obj = new Object();
    obj.description = "Change task status to " + statusName;
    obj.taskGuid = taskGuid;
    obj.employeeGuid = employeeGuid;
    obj.projectGuid = projectGuid;

    $.ajax({
        url: "https://localhost:7230/api/task-histories/",
        type: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + tokenJWT
        },
        data: JSON.stringify(obj)
    }).done((result) => {
        
        Swal.fire(
            'Status has been successfully updated!',
            'success'
        ).then(() => {
            location.reload();
        });
    }).fail((error) => {

    })
    console.log(obj);
}

function ShowUpdate(projectGuid) {
    $.ajax({
        url: "https://localhost:7230/api/projects/" + projectGuid,
        type: "GET",
        dataType: "json"
    }).done((result) => {
        previousData = {
            guid: result.data.guid,
            name: result.data.name,
            isDelete: result.data.isDelete,
            startDate: moment(result.data.startDate).format("YYYY-MM-DD"),
            endDate: moment(result.data.endDate).format("YYYY-MM-DD"),
            employeeGuid: result.data.employeeGuid
        };

        $("#guidUpdate").val(previousData.guid);
        $("#nameUpdate").val("");
        $("#isDeleteUpdate").val(previousData.isDelete);
        $("#startDateUpdate").val(previousData.startDate);
        $("#endDateUpdate").val("");
        $("#employeeGuidUpdate").val(previousData.employeeGuid);

        $("#nameUpdate").attr("placeholder", previousData.name);
        $("#endDateUpdate").attr("placeholder", previousData.endDate);

        $("#editProjectModal").modal("show");
    }).fail((error) => {
        alert("Failed to fetch employee data. Please try again.");
    });
    console.log(url)
}

function UpdateProject() {
    let name = $("#nameUpdate").val() || previousData.name; 
    let endDate = $("#endDateUpdate").val() || previousData.endDate; 

    let data = {
        guid: $("#guidUpdate").val(),
        name: name,
        isDelete: $("#isDeleteUpdate").val(),
        startDate: $("#startDateUpdate").val(),
        endDate: endDate,
        employeeGuid: $("#employeeGuidUpdate").val(),
    };
    $.ajax({
        url: "https://localhost:7230/api/projects/",
        type: "PUT",
        contentType: "application/json",
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
            text: 'Failed to insert data! Please try again.'
        })
        console.log(error)
        console.log(data)
        console.log(projectGuid)
    })
}

