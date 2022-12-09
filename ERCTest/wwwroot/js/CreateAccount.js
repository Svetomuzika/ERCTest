'use strict'

let i = 0;

function add_field() {
    var myDiv = document.getElementsByClassName("residents");
    var inputs = myDiv[i].children;

    for (let e = 0; e < 3; e++) {
        inputs[e].setAttribute("type", "text");
    }

    i++;
}

function submitForm() {
    var start = document.getElementById("startDate");
    var end = document.getElementById("endDate");
    var submit = document.getElementById("submitFormId");

    if (start.value >= end.value) {
        alert("Дата начала действия ЛС < Даты окончания действия ЛС");
    }
    else {
        submit.setAttribute("type", "submit")
    }
}