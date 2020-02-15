// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var ProfilesId = $("#ProfileID").val();

var Phone = {
    id: 0,
    description: "",
    ProfileId: 0,
}

// Get all phone to display  
function getPhoneList(id) {
    // Call Web API to get a list of Phone  
    $.ajax({
        url: 'GetPhones/'+id,
        type: 'GET',
        dataType: 'json',
        success: function (Phone) {
            phoneListSuccess(Phone);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

// Display all Phones returned from Web API call  
function phoneListSuccess(Phone) {
    // Iterate over the collection of data  
    $("#PhoneTable tbody").remove();
    $.each(Phone, function (index, Phone) {
        // Add a row to the Phone table  
        PhoneAddRow(Phone);
    });
}

// Add Phone row to <table>  
function PhoneAddRow(Phone) {
    // First check if a <tbody> tag exists, add one if not  
    if ($("#PhoneTable tbody").length == 0) {
        $("#PhoneTable").append("<tbody></tbody>");
    }

    // Append row to <table>  
    $("#PhoneTable tbody").append(
        PhoneBuildTableRow(Phone));
}

// Build a <tr> for a row of table data  
function PhoneBuildTableRow(Phone) {
    var newRow = "<tr>" +
        "<td>" + Phone.id + "</td>" +
        "<td> <div class='md-form form-lg'> <input class='input-description form-control form-control-lg' type='text' value='" + Phone.description + "'/> </div> </td>"+
        "<td>" +
        "<button type='button' " +
        "onclick='PhoneUpdate(this);' " +
        "class='btn btn-default' " +
        "data-id='" + Phone.id + "' " +
        "data-description='" + Phone.description + "' " +
        ">" +
        "<span class='glyphicon glyphicon-edit' /> Update" +
        "</button> " +
        " <button type='button' " +
        "onclick='PhoneDelete(this);'" +
        "class='btn btn-default' " +
        "data-id='" + Phone.id + "'>" +
        "<span class='glyphicon glyphicon-remove' />Delete" +
        "</button>" +
        "</td>" +
        "</tr>";
    return newRow;
}

function onAddPhone(item) {
    var options = {};
    options.url = "AddPhones/";
    options.type = "POST";
    var obj = Phone;
    obj.description = $("#description").val();
    obj.ProfileId = parseInt(ProfilesId);
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg) {
        console.log('msg= ' + msg);
        document.getElementById("msg").innerHTML = msg;
        getPhoneList(ProfilesId);
        $("#description").val("");
    },
        options.error = function () {
            $("#msg").html("Error while calling the Web API!");
        };
    $.ajax(options);
}

function PhoneUpdate(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "/Editphone/" + id;
    options.type = "PUT";

    var obj = Phone;
    obj.id = $(item).data("id");
    obj.description = $(".input-description", $(item).parent().parent()).val();
    obj.ProfileId = ProfilesId;
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg) {
        console.log('msg= ' + msg);
        document.getElementById("msg").innerHTML = msg;
        getPhoneList(ProfilesId);
        
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function PhoneDelete(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "/DelectPhone/" + id;
    options.type = "DELETE";
    options.dataType = "html";
    options.success = function (msg) {
        console.log('msg= ' + msg);
        document.getElementById("msg").innerHTML = msg;
        getPhoneList(ProfilesId);
        $("#description").val("");
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