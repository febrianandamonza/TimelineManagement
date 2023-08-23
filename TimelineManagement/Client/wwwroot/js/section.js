let lists = document.getElementsByClassName("card");
let leftBox = document.getElementById("left");
let rightBox = document.getElementById("right");
let right2Box = document.getElementById("right2");
let right3Box = document.getElementById("right3");


for (card of lists) {
    card.addEventListener("dragstart", function (e) {
        let selected = e.target;

        rightBox.addEventListener("dragover", function (e) {
            e.preventDefault();
        });

        rightBox.addEventListener("drop", function (e) {
            rightBox.appendChild(selected);
            selected = null;
        });

        leftBox.addEventListener("dragover", function (e) {
            e.preventDefault();
        });

        leftBox.addEventListener("drop", function (e) {
            leftBox.appendChild(selected);
            selected = null;
        });

        right2Box.addEventListener("dragover", function (e) {
            e.preventDefault();
        });

        right2Box.addEventListener("drop", function (e) {
            right2Box.appendChild(selected);
            selected = null;
        });

        right3Box.addEventListener("dragover", function (e) {
            e.preventDefault();
        });

        right3Box.addEventListener("drop", function (e) {
            right3Box.appendChild(selected);
            selected = null;
        });
    })
}