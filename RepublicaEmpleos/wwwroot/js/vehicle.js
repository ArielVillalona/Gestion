// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var ProfilesId = $("#ProfileID").val();

var Vehicle = {
    id: 0,
    Tipo: "",
    Matricula: "",
    ProfileId: 0,
}

// Get all Vehicle to display  
function getVehicleList(id) {
    // Call Web API to get a list of Vehicle 
    $.ajax({
        url: 'GetVehicles/'+id,
        type: 'GET',
        dataType: 'json',
        success: function (Vehicle) {
            VehicleListSuccess(Vehicle);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

// Display all Vehicles returned from Web API call  
function VehicleListSuccess(Vehicle) {
    // Iterate over the collection of data  
    $("#VehicleTable tbody").remove();
    $.each(Vehicle, function (index, Vehicle) {
        // Add a row to the Vehicle table  
        VehicleAddRow(Vehicle);
    });
}

// Add Vehicle row to <table>  
function VehicleAddRow(Vehicle) {
    // First check if a <tbody> tag exists, add one if not  
    if ($("#VehicleTable tbody").length == 0) {
        $("#VehicleTable").append("<tbody></tbody>");
    }

    // Append row to <table>  
    $("#VehicleTable tbody").append(
        VehicleBuildTableRow(Vehicle));
}

// Build a <tr> for a row of table data  
function VehicleBuildTableRow(Vehicle) {
    var newRow = "<tr>" +
        "<td>" + Vehicle.id + "</td>" +
        "<td> <div class='md-form form-lg'> <input class='input-Tipo form-control form-control-lg' type='text' value='" + Vehicle.Tipo + "'/> </div> </td>" +
        "<td> <div class='md-form form-lg'> <input class='input-Matricula form-control form-control-lg' type='text' value='" + Vehicle.Matricula + "'/> </div> </td>" +
        "<td>" +
        "<button type='button' " +
        "onclick='VehicleUpdate(this);' " +
        "class='btn btn-default' " +
        "data-id='" + Vehicle.id + "' " +
        "data-Tipo='" + Vehicle.Tipo + "' " +
        "data-Matricula='" + Vehicle.Matricula + "' " +
        ">" +
        "<span class='glyphicon glyphicon-edit' /> Update" +
        "</button> " +
        " <button type='button' " +
        "onclick='VehicleDelete(this);'" +
        "class='btn btn-default' " +
        "data-id='" + Vehicle.id + "'>" +
        "<span class='glyphicon glyphicon-remove' />Delete" +
        "</button>" +
        "</td>" +
        "</tr>";
    return newRow;
}

function onAddVehicle(item) {
    var options = {};
    options.url = "AddVehicles/";
    options.type = "POST";
    var obj = Vehicle;
    obj.Tipo = $("#Tipo").val();
    obj.Matricula = $("#Matricula").val();
    obj.ProfileId = parseInt(ProfilesId);
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg) {
        console.log('msg= ' + msg);
        document.getElementById("msg").innerHTML = msg;
        getVehicleList(ProfilesId);
        $("#Tipo").val("");
        $("#Matricula").val("");
    },
        options.error = function () {
            $("#msg").html("Error while calling the Web API!");
        };
    $.ajax(options);
}

function VehicleUpdate(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "/EditVehicle/" + id;
    options.type = "PUT";

    var obj = Vehicle;
    obj.id = $(item).data("id");
    obj.Tipo = $(".input-Tipo", $(item).parent().parent()).val();
    obj.Matricula = $(".input-Matricula", $(item).parent().parent()).val();
    obj.ProfileId = ProfilesId;
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg) {
        console.log('msg= ' + msg);
        document.getElementById("msg").innerHTML = msg;
        getVehicleList(ProfilesId);
        
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function VehicleDelete(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "/DelectVehicle/" + id;
    options.type = "DELETE";
    options.dataType = "html";
    options.success = function (msg) {
        console.log('msg= ' + msg);
        document.getElementById("msg").innerHTML = msg;
        getVehicleList(ProfilesId);
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

// Handle exceptions from AJAX calls  
function handleException(request, message, error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg += "Message" + request.responseJSON.Message + "\n";
    }

    alert(msg);
}  