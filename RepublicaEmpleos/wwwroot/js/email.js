// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var ProfilesId = $("#ProfileID").val();

var Email = {
    id: 0,
    description: "",
    ProfileId: 0,
}

// Get all Email to display  
function getEmailList(id) {
    // Call Web API to get a list of Email  
    $.ajax({
        url: 'GetEmails/'+id,
        type: 'GET',
        dataType: 'json',
        success: function (Email) {
            EmailListSuccess(Email);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

// Display all Emails returned from Web API call  
function EmailListSuccess(Email) {
    // Iterate over the collection of data  
    $("#EmailTable tbody").remove();
    $.each(Email, function (index, Email) {
        // Add a row to the Email table  
        EmailAddRow(Email);
    });
}

// Add Email row to <table>  
function EmailAddRow(Email) {
    // First check if a <tbody> tag exists, add one if not  
    if ($("#EmailTable tbody").length == 0) {
        $("#EmailTable").append("<tbody></tbody>");
    }

    // Append row to <table>  
    $("#EmailTable tbody").append(
        EmailBuildTableRow(Email));
}

// Build a <tr> for a row of table data  
function EmailBuildTableRow(Email) {
    var newRow = "<tr>" +
        "<td>" + Email.id + "</td>" +
        "<td> <div class='md-form form-lg'> <input class='input-description form-control form-control-lg' type='text' value='" + Email.description + "'/> </div> </td>"+
        "<td>" +
        "<button type='button' " +
        "onclick='EmailUpdate(this);' " +
        "class='btn btn-default' " +
        "data-id='" + Email.id + "' " +
        "data-description='" + Email.description + "' " +
        ">" +
        "<span class='glyphicon glyphicon-edit' /> Update" +
        "</button> " +
        " <button type='button' " +
        "onclick='EmailDelete(this);'" +
        "class='btn btn-default' " +
        "data-id='" + Email.id + "'>" +
        "<span class='glyphicon glyphicon-remove' />Delete" +
        "</button>" +
        "</td>" +
        "</tr>";
    return newRow;
}

function onAddEmail(item) {
    var options = {};
    options.url = "AddEmails/";
    options.type = "POST";
    var obj = Email;
    obj.description = $("#descriptionEmail").val();
    obj.ProfileId = parseInt(ProfilesId);
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg) {
        console.log('msg= ' + msg);
        document.getElementById("msg").innerHTML = msg;
        getEmailList(ProfilesId);
        $("#descriptionEmail").val("");
    },
        options.error = function () {
            $("#msg").html("Error while calling the Web API!");
        };
    $.ajax(options);
}

function EmailUpdate(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "/EditEmail/" + id;
    options.type = "PUT";

    var obj = Email;
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
        getEmailList(ProfilesId);
        
    };
    options.error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function EmailDelete(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "/DelectEmail/" + id;
    options.type = "DELETE";
    options.dataType = "html";
    options.success = function (msg) {
        console.log('msg= ' + msg);
        document.getElementById("msg").innerHTML = msg;
        getEmailList(ProfilesId);
        $("#descriptionEmail").val("");
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