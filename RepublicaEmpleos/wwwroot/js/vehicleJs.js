var ProfilesId = $("#ProfileID").val();
var vehicle = {
    id: 0,
    profileId: 0,
    vehicleType: {
        description: ""
    },
    vehicleTypeid: 0,
    matricula: ""
}
// Get all vehicle to display  
function getVehicleList(id) {
    // Call Web API to get a list of Vehicle  
    $.ajax({
        url: 'GetVehicle/'+id,
        type: 'GET',
        dataType: 'json',
        success: function (vehicle) {
            console.log(vehicle);
            VehicleListSuccess(vehicle);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}
// Display all Vehicle returned from Web API call  
function VehicleListSuccess(vehicle) {
    // Iterate over the collection of data  
    $("#VehicleTable tbody").remove();
    $.each(vehicle, function (index, vehicle) {
        // Add a row to the Vehicle table  
        VehicleAddRow(vehicle);
    });
}
// Add Vehicle row to <table>  
function VehicleAddRow(vehicle) {
    // First check if a <tbody> tag exists, add one if not  
    if ($("#VehicleTable tbody").length == 0) {
        $("#VehicleTable").append("<tbody></tbody>");
    }
    // Append row to <table>  
    $("#VehicleTable tbody").append(
        VehicleBuildTableRow(vehicle));
}
// Build a <tr> for a row of table data  
function VehicleBuildTableRow(vehicle) {
    var newRow = "<tr>" +
        "<td>" + vehicle.vehicleType.description + "</td>" +
        "<td> <div class='md-form form-lg'> <input class='input-Matricula form-control form-control-lg' type='text' value='" + vehicle.matricula + "'/></div> </td>" +
        "<td>" +
        "<button type='button' " +
        "onclick='VehicleUpdate(this);' " +
        "class='btn btn-default' " +
        "data-id='" + vehicle.id + "' " +
        "data-Matricula='" + vehicle.matricula + "' " +
        ">" +
        "<span class='glyphicon glyphicon-edit' /> Update" +
        "</button> " +
        " <button type='button' " +
        "onclick='VehicleDelete(this);'" +
        "class='btn btn-default' " +
        "data-id='" + vehicle.id + "'>" +
        "<span class='glyphicon glyphicon-remove' />Delete" +
        "</button>" +
        "</td>" +
        "</tr>";
    return newRow;
}

function onAddVehicle(item) {
    var options = {};
    options.url = "AddVehicle/";
    options.type = "POST";
    var obj = vehicle;
    obj.matricula = $("#descriptionVehicle").val();
    obj.ProfileId = parseInt(ProfilesId);
    obj.vehicleType = null;
    obj.VehicleTypeId = parseInt($("#VehicleID").val());
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg3) {
        console.log('msg3= ' + msg3);
        document.getElementById("msg3").innerHTML = msg3;
        getVehicleList(ProfilesId);
        $("#descriptionVehicle").val("");
    },
        options.error = function () {
            $("#msg3").html("Error while calling the Web API!");
        };
    $.ajax(options);
}

function VehicleUpdate(item) {
    var id = $(item).data("Id");
    var options = {};
    options.url = "EditVehicle/" + id;
    options.type = "PUT";

    var obj = vehicle;
    obj.id = $(item).data("id");
    obj.matricula = $(".input-Matricula", $(item).parent().parent()).val();
    obj.profileID = ProfilesId;
    obj.vehicleType = null;
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg3) {
        document.getElementById("msg3").innerHTML = msg3;
        getVehicleList(ProfilesId);
    };
    options.error = function () {
        $("#msg3").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function VehicleDelete(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "/DeleteVehicle/" + id;
    options.type = "DELETE";
    options.dataType = "html";
    options.success = function (msg3) {
        console.log('msg3= ' + msg3);
        document.getElementById("msg3").innerHTML = msg3;
        getVehicleList(ProfilesId);
        $("#descriptionVehicle").val("");
    };
    options.error = function () {
        $("#msg3").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

// Handle exceptions from AJAX calls  
function handleException(request, message, error) {
    var msg3 = "";
    msg3 += "Code: " + request.status + "\n";
    msg3 += "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg3 += "Message" + request.responseJSON.Message + "\n";
    }

    alert(msg3);
}  