"option strict"

function create() {

    var task = {

        Id: document.getElementById("pId").value,
        Name: document.getElementById("pTask").value,
        City: document.getElementById("pDueDate").value,
        State: document.getElementById("pDescription").value,
        Preferred: document.getElementById("pIsFinished").checked  
    }

    $.post("http://localhost:62885/BackEnd/Create", task)
        .done(function(resp){
            console.log(resp)
        });

}
