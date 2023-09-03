const guidLogin = document.getElementById("guidInput").value;
const tokenJWTProfile = document.getElementById("jwtToken").value;

$(document).ready(function () {
    $.ajax({
        url: `https://localhost:7230/api/employees/detail/` + guidLogin,
        headers: {
            'Authorization': 'Bearer ' + tokenJWTProfile
        },
        type: "GET",
        dataType: "json"
    }).done(function (response) {

        const userNik = response.data.nik;
        const userFullName = response.data.fullName;
        const userBirthDate = (() => {
            const parts = response.data.birthDate.split('T')[0].split('-');
            return `${parts[2]}-${parts[1]}-${parts[0]}`;
        })();
        const userGender = response.data.gender;
        const userHiringDate = (() => {
            const parts = response.data.hiringDate.split('T')[0].split('-');
            return `${parts[2]}-${parts[1]}-${parts[0]}`;
        })();
        const userEmail = response.data.email;
        const userPhoneNumber = response.data.phoneNumber;
        const userRole = response.data.role;
        let userImages = ""
        let userImagesTopBar = ""

        $("#nik").text(userNik);
        $("#fullName").text(userFullName);
        $("#birthDate").text(userBirthDate);
        $("#gender").text(userGender === 0 ? "Female" : "Male");
        $("#hiringDate").text(userHiringDate);
        $("#email").text(userEmail);
        $("#phoneNumber").text(userPhoneNumber);
        $("#role").text(userRole);
        
        if (userGender === 0) {
            userImages = ` <img src="https://img.freepik.com/premium-vector/female-user-profile-avatar-is-woman-character-screen-saver-with-emotions_505620-617.jpg"
                         alt="user-avatar"
                         class="d-block rounded"
                         height="200px"
                         width="200px"
                         id="uploadedAvatar" />
            `;
            userImagesTopBar = ` <img src="https://img.freepik.com/premium-vector/female-user-profile-avatar-is-woman-character-screen-saver-with-emotions_505620-617.jpg"
                         alt="user-avatar"
                         class="w-px-40 h-auto rounded-circle"
                         height="200px"
                         width="200px"
                         id="uploadedAvatar" />
            `;
        } else if (userGender === 1) {
            userImages = ` <img src="https://img.freepik.com/premium-vector/vector-illustration-winter-boy-concept-hello-winter-avataka-social-networks_469123-525.jpg"
                         alt="user-avatar"
                         class="d-block rounded"
                         height="200px"
                         width="200px"
                         id="uploadedAvatar">
            `;
            userImagesTopBar = ` <img src="https://img.freepik.com/premium-vector/vector-illustration-winter-boy-concept-hello-winter-avataka-social-networks_469123-525.jpg"
                         alt="user-avatar"
                         class="w-px-40 h-auto rounded-circle"
                         height="200px"
                         width="200px"
                         id="uploadedAvatar">
            `;
        }
        
        
        $("#userImages").html(userImages);
        $("#userImagesTopBar").html(userImagesTopBar);
    }).fail(function (error) {
        console.log("Error:", error);
    });
});
