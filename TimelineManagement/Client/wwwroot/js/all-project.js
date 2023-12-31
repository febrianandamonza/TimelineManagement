const guid = document.getElementById("guidInput").value;
const tokenJWT = document.getElementById("jwtToken").value;

const img = ``
$.ajax({
    url: `https://localhost:7230/api/project-collaborators/all-by-employee/` + guid,
    headers: {
        'Authorization': 'Bearer ' + tokenJWT
    },
    async : false
}).done((result) => {
    let temp = "";
    let temp3 = "";
    $.each(result.data, (key, val) => {
        temp += `
        
        <div class="col col-3 my-3" style="max-height: 400px; min-width: 400px;">
        <a href="/Project/Index/${val.projectGuid}">
      <div class="card h-100" style="text-align: center; cursor: pointer" onmouseover="this.style.boxShadow='0 0 10px rgba(0,0,0,0.5)';" onmouseout="this.style.boxShadow='none';" >
        <img class="card-img-top" src="https://www.itworks.id/wp-content/uploads/2021/02/metrodata-logo.jpg" alt="Card image cap"/>
        <div class="card-body">
          <h5 class="card-title">${val.projectName}
        `;

        const projectGuid = val.projectGuid;
        $.ajax({
            url: `https://localhost:7230/api/tasks/count-task-by-project/` + projectGuid ,
            headers: {
                'Authorization': 'Bearer ' + tokenJWT
            },
            async : false
        }).done((result3) => {
            let unfinished = result3.data.totalTaskUnFinished
            let finished = result3.data.totalTaskFinished
            let totaltask = unfinished + finished
            let total = (finished / totaltask) * 100
            let handle ="";
            if (finished == 0){
                total = 0
            }else if (unfinished == 0){
                total = 100
            }
            if (total >= 75){
                handle = `<span class="badge badge-success ml-1">${total.toFixed(1) + "%"}</span>`
            }else if (total >= 50){
                handle = `<span class="badge badge-warning ml-1">${total.toFixed(1) + "%"}</span>`
            }else{
                handle = `<span class="badge badge-danger ml-1">${total.toFixed(1) + "%"}</span>`
            }
            temp += ` ${handle}</h5>
           
          <ul class="list-group list-group-flush">
              
              <div class="list-group-item textP">
              <span style="color: red">Start Date : </span>
              ${(() => {
                    const parts = val.projectStartDate.split('T')[0].split('-');
                    return `${parts[2]}-${parts[1]}-${parts[0]}`;
              })()}
              </div>

              <div class="list-group-item textP">
              <span style="color: red">End Date : </span>
              ${(() => {
                    const parts = val.projectEndDate.split('T')[0].split('-');
                    return `${parts[2]}-${parts[1]}-${parts[0]}`;
               })()}
              </div>
          </ul>     
        </div>
      </div>
      </a>
    </div> `;
            
        });
        $("#totalProjectTask").html(temp3);
    })  
    $("#projectCard2").html(temp);
    
});

var getStartDateTask = "";
var getEndDateTask = "";
var getStartDateProject = "";
var getEndDateProject = "";
$(function() {
    $('input[name="DateTask"]').daterangepicker({
        opens: 'left',
        drops : 'up'
    }, function(start, end, label) {
        getStartDateTask = start
        getEndDateTask = end
    });
});
$(function() {
    $('input[name="DateProject"]').daterangepicker({
        opens: 'left'
    }, function(start, end, label) {
        getStartDateProject = start
        getEndDateProject = end
    });
});
function InsertProject() {
    var obj = new Object();
    obj.name = $("#NameProject").val();
    obj.startDate = getStartDateProject.format('YYYY-MM-DD')
    obj.endDate = getEndDateProject.format('YYYY-MM-DD')
    obj.employeeGuid = $("#EmployeeGuid").val();
    obj.taskName = $("#TaskName").val();
    obj.priority = parseInt($("#PriorityProject").val());
    obj.startDateTask = getStartDateTask.format('YYYY-MM-DD')
    obj.endDateTask = getEndDateTask.format('YYYY-MM-DD')

    $.ajax({
        url: "https://localhost:7230/api/projects/create-default",
        type: "POST",
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + tokenJWT
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

