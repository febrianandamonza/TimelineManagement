
const employeeGuid = document.getElementById("employeeGuidInput").value;

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
    url: `https://localhost:7230/api/project-collaborators/waiting-by-employee/` + employeeGuid,
    headers: {
        'Authorization': 'Bearer ' + tokenJWT
    },
    async: false
}).done((result) => {
    const tableBody = $("#tbodyInbox");

    $.each(result.data, (key, val) => {
        const projectName = val.projectName;
        const status = getStatusText(val.status);
        const employeeName = val.employeeName;
        const guid = val.guid;

        const newRow = `
            <tr>
                <td>${projectName}</td>
                <td>${status}</td>
                <td>${employeeName}</td>
                <td>
                    <button class="btn btn-success accept-btn" onclick="acceptCollaborator('${guid}')">Accept</button>
                    <button class="btn btn-danger reject-btn" onclick="rejectCollaborator('${guid}')">Reject</button>
                </td>
            </tr>
        `;
        tableBody.append(newRow);
        console.log("token");
    });
    
});

function getStatusText(status) {
    if (status === 0) {
        return "Waiting";
    } else if (status === 1) {
        return "Rejected";
    } else if (status === 2) {
        return "Accepted";
    } else {
        return "Unknown";
    }
}

function acceptCollaborator(guid) {
    Swal.fire({
        title: 'Accept Project',
        text: 'Are you sure?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, Accept'
    }).then((result) => {

        UpdateStatus(guid, 2);

    });
}

function rejectCollaborator(guid) {
    Swal.fire({
        title: 'Reject Project',
        text: 'Are you sure?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, Reject'
    }).then((result) => {

        UpdateStatus(guid, 1);

    });
}

function UpdateStatus(guid, newStatus) {
    let data = {
        guid: guid,
        status: newStatus
    };

    $.ajax({
        url: `https://localhost:7230/api/project-collaborators/change-status/`,
        headers: {
            'Authorization': 'Bearer ' + tokenJWT
        },
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(data)
    }).done((result) => {
        Swal.fire({
            title: 'Data has been successfully updated!',
            icon: 'success'
        }).then(() => {
            location.reload();
        });
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Failed to change data! Please try again.'
        });
        console.log(error);
        console.log(data);
    });
}