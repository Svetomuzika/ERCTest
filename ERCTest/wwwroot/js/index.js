"use strict";

const accounts = document.getElementsByClassName("account");
const details = document.getElementsByClassName("detail");
const inputs = document.getElementsByClassName("input");
const labels = document.getElementsByClassName("label");
const edits = document.getElementsByClassName("editContent");
const deletes = document.getElementsByClassName("deleteContent");

for (let i in details) {
    details[i].addEventListener('click', function (event) {
        const residents = accounts[i].children[7].children;

        for (let e = i * 4; e < (i * 4) + 4; e++) {
            inputs[e].hidden = !inputs[e].hidden
        }

        for (let e = i * 5; e < (i * 5) + 5; e++) {
            labels[e].hidden = !labels[e].hidden
            labels[e].disabled = !labels[e].disabled;
            labels[e].style.background = labels[e].getAttribute('onclick') != null ? "#f0f0f0" : "transparent";
        }

        for (let resident of residents) {
            for (let e of resident.children) {
                e.hidden = !e.hidden
            }
        }

        edits[i].hidden = !edits[i].hidden;
        deletes[i].hidden = !deletes[i].hidden;

        edits[i].addEventListener('click', function (event) {
            var start = document.getElementById("startDate");
            var end = document.getElementById("endDate");

            if (edits[i].value == "Редактировать") {
                for (let e = i * 4; e < (i * 4) + 4; e++) {
                    inputs[e].readOnly = false;
                    inputs[e].style.background = "white";
                }

                for (let resident of residents) {
                    for (let e of resident.children) {
                        e.readOnly = false;
                        e.style.background = "white";
                    }
                }

                edits[i].setAttribute("type", "button");
                edits[i].value = "Сохранить";
            }
            else {
                if (start.value >= end.value) {
                    edits[i].setAttribute("type", "button");
                    edits[i].value = "Сохранить";

                    alert("Дата начала действия ЛС < Даты окончания действия ЛС");
                }
                else {
                    for (let e = i * 4; e < (i * 4) + 4; e++) {
                        inputs[e].readOnly = true;
                        inputs[e].style.background = "transparent";
                    }

                    for (let resident of residents) {
                        for (let e of resident.children) {
                            e.readOnly = true;
                            e.style.background = "transparent";
                        }
                    }

                    edits[i].setAttribute("type", "submit")
                    edits[i].value = "Редактировать";
                }                
            }
        });
    });
}