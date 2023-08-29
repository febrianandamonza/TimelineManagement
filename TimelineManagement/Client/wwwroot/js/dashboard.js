
const guidForProjectCount = document.getElementById("guidInput").value;
const tokenJWT3 = document.getElementById("jwtToken").value;

$(document).ready(function () {
    $.ajax({
        url: `https://localhost:7230/api/project-collaborators/count-project-by-employee/` + guidForProjectCount,
        headers: {
            'Authorization': 'Bearer ' + tokenJWT3
        },
        type: "GET",
        dataType: "json"
    }).done(function (response) {
        const totalProjects = response.data.total;
        const totalProjects2 = response.data.total;
        $("#totalProjects").text(totalProjects);
        $("#totalProjects2").text(totalProjects2);
    }).fail(function (error) {
        console.log("Error:", error);
    });
});

$(document).ready(function () {
    $.ajax({
        url: `https://localhost:7230/api/tasks/count-task-by-employee/` + guidForProjectCount,
        headers: {
            'Authorization': 'Bearer ' + tokenJWT3
        },
        type: "GET",
        dataType: "json"
    }).done(function (response) {
        const taskFinished = response.data.totalTaskFinished;
        const taskUnFinished = response.data.totalTaskUnFinished;
        $("#taskFinished").text(taskFinished);
        $("#taskUnFinished").text(taskUnFinished);
    }).fail(function (error) {
        console.log("Error:", error);
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
