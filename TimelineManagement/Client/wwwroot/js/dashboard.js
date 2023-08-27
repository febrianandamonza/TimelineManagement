

const guidForProjectCount = document.getElementById("guidInput").value;
$(document).ready(function () {
    $.ajax({
        url: `https://localhost:7230/api/project-collaborators/count-project-by-employee/` + guidForProjectCount,
        type: "GET",
        dataType: "json"
    }).done(function (response) {
        const totalProjects = response.data.total;
        $("#totalProjects").text(totalProjects);
    }).fail(function (error) {
        console.log("Error:", error);
    });
});

const employeeProjectGuid = document.getElementById("guidInput").value;

$.ajax({
    url: `https://localhost:7230/api/tasks/count-task-by-employee/` + employeeProjectGuid
}).done((result) => {
    var xValues = ["Finished", "Unfinished"];
    var yValues = [result.data.totalTaskFinished, result.data.totalTaskUnFinished];
    new Chart($('#taskChart'), {
        type: 'pie',
        data: {
            labels: xValues,
            datasets: [{
                label: 'Total',
                data: yValues,
                backgroundColor: getRandomColor(xValues),
                hoverOffset: 4
            }]
        }
    });
});

function getRandomColor(count) { //generates random colours and puts them in string
    var colors = [];
    for (var i = 0; i < count.length; i++) {
        var letters = '0123456789ABCDEF'.split('');
        var color = '#';
        for (var x = 0; x < 6; x++) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        colors.push(color);
    }
    return colors;
}