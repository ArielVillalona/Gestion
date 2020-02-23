// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

var ProfilesId = $("#ProfileID").val();

var ProfileDocType = {
    docTypeID: 0,
    profileID: 0,
    docType: {
        description: ""
    },
    numberDocument: ""
}

// Get all ProfileDocType to display  
function getDocumentList(id) {
    // Call Web API to get a list of Document  
    $.ajax({
        url: 'GetDocument/'+id,
        type: 'GET',
        dataType: 'json',
        success: function (ProfileDocType) {
            console.log(ProfileDocType);
            DocumentListSuccess(ProfileDocType);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

// Display all Document returned from Web API call  
function DocumentListSuccess(ProfileDocType) {
    // Iterate over the collection of data  
    $("#DocumentTable tbody").remove();
    $.each(ProfileDocType, function (index, ProfileDocType) {
        // Add a row to the Document table  
        DocumentAddRow(ProfileDocType);
    });
}

// Add Document row to <table>  
function DocumentAddRow(ProfileDocType) {
    // First check if a <tbody> tag exists, add one if not  
    if ($("#DocumentTable tbody").length == 0) {
        $("#DocumentTable").append("<tbody></tbody>");
    }

    // Append row to <table>  
    $("#DocumentTable tbody").append(
        DocumentBuildTableRow(ProfileDocType));
}

// Build a <tr> for a row of table data  
function DocumentBuildTableRow(ProfileDocType) {
    var newRow = "<tr>" +
        "<td>" + ProfileDocType.docType.description + "</td>" +
        "<td> <div class='md-form form-lg'> <input class='input-description form-control form-control-lg' type='text' value='" + ProfileDocType.numberDocument + "'/> </div> </td>" +
        "<td>" +
        "<button type='button' " +
        "onclick='DocumentUpdate(this);' " +
        "class='btn btn-default' " +
        "data-id='" + ProfileDocType.docTypeID + "' " +
        "data-numberDocument='" + ProfileDocType.numberDocument + "' " +
        ">" +
        "<span class='glyphicon glyphicon-edit' /> Update" +
        "</button> " +
        " <button type='button' " +
        "onclick='DocumentDelete(this);'" +
        "class='btn btn-default' " +
        "data-id='" + ProfileDocType.docTypeID + "'>" +
        "<span class='glyphicon glyphicon-remove' />Delete" +
        "</button>" +
        "</td>" +
        "</tr>";
    return newRow;
}

function onAddDocument(item) {
    var options = {};
    options.url = "AddDocument/";
    options.type = "POST";
    var obj = ProfileDocType;
    obj.numberDocument = $("#descriptionDocument").val();
    obj.docTypeID = parseInt($("#DocID").val());
    obj.ProfileId = parseInt(ProfilesId);
    obj.docType = null;
    console.dir(obj);
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg3) {
        console.log('msg3= ' + msg3);
        document.getElementById("msg3").innerHTML = msg3;
        getDocumentList(ProfilesId);
        $("#descriptionDocument").val("");
    },
        options.error = function () {
            $("#msg3").html("Error while calling the Web API!");
        };
    $.ajax(options);
}

function DocumentUpdate(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "EditDocument/" + id;
    options.type = "PUT";

    var obj = ProfileDocType;
    obj.docTypeID = $(item).data("id");
    obj.numberDocument = $(".input-description", $(item).parent().parent()).val();
    obj.profileID = ProfilesId;
    obj.docType = null;
    options.data = JSON.stringify(obj);
    options.contentType = "application/json";
    options.dataType = "html";
    options.success = function (msg3) {
        document.getElementById("msg3").innerHTML = msg3;
        getDocumentList(ProfilesId);
    };
    options.error = function () {
        $("#msg3").html("Error while calling the Web API!");
    };
    $.ajax(options);
}

function DocumentDelete(item) {
    var id = $(item).data("id");
    var options = {};
    options.url = "/DeleteDocument/" + ProfilesId + "/" + id;
    options.type = "DELETE";
    options.dataType = "html";
    options.success = function (msg3) {
        console.log('msg3= ' + msg3);
        document.getElementById("msg3").innerHTML = msg3;
        getDocumentList(ProfilesId);
        $("#descriptionDocument").val("");
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