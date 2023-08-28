const guidForMyProfile = document.getElementById("guidForMyProfile").value;
$(document).ready(function () {
    $.ajax({
        url: `https://localhost:7230/api/employees/detail/` + guidForMyProfile,
        type: "GET",
        dataType: "json"
    }).done(function (response) {

        const userNik = response.data.nik;
        const userFullName = response.data.fullName;
        const userBirthDate = response.data.birthDate.split('T')[0];
        const userGender = response.data.gender;
        const userHiringDate = response.data.hiringDate.split('T')[0];
        const userEmail = response.data.email;
        const userPhoneNumber = response.data.phoneNumber;
        const userRole = response.data.role;

        $("#nik").text(userNik);
        $("#fullName").text(userFullName);
        $("#birthDate").text(userBirthDate);
        $("#gender").text(userGender === 0 ? "Female" : "Male");
        $("#hiringDate").text(userHiringDate);
        $("#email").text(userEmail);
        $("#phoneNumber").text(userPhoneNumber);
        $("#role").text(userRole);

        const profileImage = document.getElementById("profileImage");
        if (userGender === 0) {
            profileImage.src = "~/assets/img/avatars/0.png";
        } else if (userGender === 1) {
            profileImage.src = "~/assets/img/avatars/1.png";
        }
    }).fail(function (error) {
        console.log("Error:", error);
        console.log(url);
    });
});
