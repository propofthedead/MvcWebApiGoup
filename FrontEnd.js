"option strict"

var tasks = []

function loaded() {
    $.getJSON("http://localhost:62885/api/BackEnd/List")
        .done(function(resp){
            console.log(resp)
            display(resp);
        });

}
function display(tasks) {
var tbody = document.getElementById("tbody");
tbody.innerHTML = "";
for (var task of tasks) {
    var row = "";
    row += "<tr>";
    row += "<td>" + task.Id + "</td>";
    row += "<td>" + task.Task + "</td>";
    row += "<td>" + task.DueDate + "</td>";
    row += "<td>" + task.Description + "</td>";
    row += "<td>" + task.IsFinished + "</td>";
    row += "<button onclick='change(this)' value=" + task.id + ">Edit</button>"
    row += "<button onclick='remove(this)' value=" + task.id + ">Delete</button>"
    row += "<tr>";
    tbody.innerHTML +=row;
    }

}

function create() {

    var task = {

        Id: document.getElementById("pId").value,
        Task: document.getElementById("pTask").value,
        DueDate: document.getElementById("pDueDate").value,
        Description: document.getElementById("pDescription").value,
        IsFinished: document.getElementById("pIsFinished").checked  
    }

    $.post("http://localhost:62885/api/BackEnd/Create", task)
        .done(function(resp){
            console.log(resp)
        });

}

function change(fred) {

    var task = {

        Id: document.getElementById("pId").value,
        Task: document.getElementById("pTask").value,
        DueDate: document.getElementById("pDueDate").value,
        Description: document.getElementById("pDescription").value,
        IsFinished: document.getElementById("pIsFinished").checked  
        
    }

    $.post("http://localhost:62885/api/BackEnd/Change", task)
        .done(function(resp){
            console.log(resp)
            ;
        });

}

function remove(fred) {

    var task = {

        Id: document.getElementById("pId").value,
        Task: document.getElementById("pTask").value,
        DueDate: document.getElementById("pDueDate").value,
        Description: document.getElementById("pDescription").value,
        IsFinished: document.getElementById("pIsFinished").checked 
        
    }  

    $.post("http://localhost:62885/api/BackEnd/Remove", task)
        .done(function(resp){
            console.log(resp);
        });


}