 

$("#AddTrainer").click(function () {
    createRowForAssignedTrainers();

});
$("#AddExam").click(function () {
    createRowForSubmittedExams();

});

var index = 0;
function createRowForAssignedTrainers() {

    var selectedItem = getSelectedTrainer();
    if (selectedItem !== "") {
        var index = $("#assignedTrainers").children("tr").length;
        var sl = index;
        var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='Trainers.Index' value='" + index + "' /> </td>";
        var idTd = "<td style='display:none'><input type='hidden' id='ItemId" + index + "' name='Trainers["+index+"].Id' value='" + selectedItem.Id + "' /> </td>";
        var codeTd = "<td style='display:none'><input type='hidden' id='ItemCode" + index + "' name='Trainers[" + index +"].Code' value='" + selectedItem.Code + "' /> </td>";
        var addressTd = "<td style='display:none'><input type='hidden' id='ItemAddress" + index + "' name='Trainers[" + index +"].Address' value='" + selectedItem.Address + "' /> </td>";
        var batchTd = "<td style='display:none'><input type='hidden' id='ItemBatchId" + index + "' name='Trainers[" + index +"].BatchId' value='" + selectedItem.BatchId + "' /> </td>";
        var cityTd = "<td style='display:none'><input type='hidden' id='ItemCity" + index + "' name='Trainers[" + index +"].City' value='" + selectedItem.City + "' /> </td>";
        var contactTd = "<td style='display:none'><input type='hidden' id='ItemContactNo" + index + "' name='Trainers[" + index +"].ContactNo' value='" + selectedItem.ContactNo + "' /> </td>";
        var countryTd = "<td style='display:none'><input type='hidden' id='ItemCountry" + index + "' name='Trainers[" + index +"].Country' value='" + selectedItem.Country + "' /> </td>";
        var courseTd = "<td style='display:none'><input type='hidden' id='ItemCourseId" + index + "' name='Trainers[" + index +"].CourseId' value='" + selectedItem.CourseId + "' /> </td>";
        var emailTd = "<td style='display:none'><input type='hidden' id='ItemEmail" + index + "' name='Trainers[" + index +"].Email' value='" + selectedItem.Email + "' /> </td>";
        var postalTd = "<td style='display:none'><input type='hidden' id='ItemPostalCode" + index + "' name='Trainers[" + index +"].PostalCode' value='" + selectedItem.PostalCode + "' /> </td>";
        var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";
        var typeTdChecked = "";
        if (selectedItem.Type !== true) {
            typeTdChecked = "";
        } else {
            typeTdChecked = 'checked = "checked"';
        }
        var itemTd = "<td> <input type='hidden' id='ItemName" +index +"'  name='Trainers[" +index +"].Name' value='" +selectedItem.Name +"' /> " +selectedItem.Name +" </td>";
        var typeTd = "<td> <input type='hidden' id='ItemType" +index +"'  name='Trainers[" +index +"].Type' value='" +selectedItem.Type +"' /> <input type='checkbox' id='ItemType' " +typeTdChecked +"/>  </td>";
        var edit ="<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
        var del ="<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
        var actions = "<td>" + edit + del + "</td>";

        var newRow = "<tr>" + indexTd+idTd+codeTd+cityTd+contactTd+countryTd+courseTd+addressTd+batchTd+emailTd+postalTd + slTd + itemTd + typeTd + actions + " </tr>";

        $("#assignedTrainers").append(newRow);
        $("#ItemName").val("");
        $("#ItemType").val("");
    } 
}
function createRowForSubmittedExams() {

    var selectedItem = getSubmittedExam();
    var index = $("#SubmittedExams").children("tr").length;
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='Exams.Index' value='" + index + "' /> </td>";

    var slTd = "<td> <input type='hidden' id='ItemSerial" + index + "'  name='Exams[" + index + "].Serial' value='" + selectedItem.Serial + "' /> " + selectedItem.Serial + " </td>";
    var typeTd = "<td> <input type='hidden' id='ItemType" + index + "'  name='Exams[" + index + "].ExamType' value='" + selectedItem.Type + "' /> " + selectedItem.Type + " </td>";
    var codeTd = "<td> <input type='hidden' id='ItemCode" + index + "'  name='Exams[" + index + "].Code' value='" + selectedItem.Code + "' /> " + selectedItem.Code + "  </td>";
    var topicTd = "<td> <input type='hidden' id='ItemTopic" + index + "'  name='Exams[" + index + "].Topic' value='" + selectedItem.Topic + "' /> " + selectedItem.Topic + " </td>";
    var marksTd = "<td> <input type='hidden' id='ItemMarks" + index + "'  name='Exams[" + index + "].FullMark' value='" + selectedItem.Marks + "' /> " + selectedItem.Marks + " </td>";
    var durationTd = "<td> <input type='hidden' id='ItemDuration" + index + "'  name='Exams[" + index + "].Duration' value='" + selectedItem.Duration + "' /> " + selectedItem.Duration + " </td>";
    var edit = "<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
    var del = "<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
    var actions = "<td>" + edit + del + "</td>";
    
    var newRow = "<tr>" + indexTd + slTd + typeTd + topicTd + codeTd+ durationTd + marksTd + actions + " </tr>";

    $("#SubmittedExams").append(newRow);
    $("#ItemType").val("");
    $("#ItemCode").val("");
    $("#ItemTopic").val("");
    $("#ItemMarks").val("");
    $("#ItemDuration").val("");
    $("#ItemSerial").val("");

}

function getSelectedTrainer() {
    var trainerId = $("#TrainersDD").find(":selected").val();
    var item = "";
    if (trainerId !== "") {
        var params = { id: trainerId };
            $.ajax({
                type: "POST",
                url: "../../Course/GetInfoByTrainerId",
                contentType: "application/JSON; charset=utf-8",
                data: JSON.stringify(params),
                success: function (rData) {
                    if (rData !== undefined && rData !== "") {
                        item = {
                            "Type": rData.Type,
                            "Name": rData.Name,
                            "Id": rData.Id,
                            "Code": rData.Code,
                            "ContactNo": rData.ContactNo,
                            "Email": rData.Email,
                            "Address": rData.Address,
                            "City": rData.City,
                            "PostalCode": rData.PostalCode,
                            "Country": rData.Country,
                            "CourseId": rData.CourseId,
                            "BatchId": rData.BatchId
                        };
                    }
                }
            });
    }
    return item;
}
function getSubmittedExam() {
    var examType = $("#ExamType").val();
    var examCode = $("#ExamCode").val();
    var examTopic = $("#ExamTopic").val();
    var examMarks = $("#ExamMarks").val();
    var examDuration = $("#txtHours").val() + ":" + $("#txtMinutes").val();
    var examSerial = $("#ExamSerial").val();
    var item = {
        "Type": examType,
        "Code": examCode,
        "Topic": examTopic,
        "Marks": examMarks,
        "Duration": examDuration,
        "Serial": examSerial
    };

    return item;
}


$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "../../Course/GetAllTrainers",
        contentType: "application/Json; charset=utf-8",
        data: JSON.stringify(),
        success: function (rData) {
            $("#TrainersDD").empty();
            $("#TrainersDD").append("<option value=''>Select Trainer</option>");
            if (rData != undefined && rData != "") {
                $.each(rData, function (k, v) {
                    $("#TrainersDD").append("<option value='" + v.Id + "'>" + v.Name + "</option>");
                });

            }
        }
    });
    var sl = 0;
    $.ajax({
        type: "POST",
        url: "../../Course/GetSearchInformation",
        contentType: "application/JSON; charset=utf-8",
        data: JSON.stringify(),
        success: function (rData) {
            if (rData != undefined && rData != "") {
                $.each(rData, function (k, v) {
                    addRowsInSearch(++sl,v.Id, v.Name, v.Duration, v.Fees, v.Participants, v.Trainers, v.Batches);
                });
            }
        }
    });
});
$("#OrganizationDDSearch").change(function () {

    $("#SearchedInfo").empty();
    var oId = $(this).val();
    var sl = 0;
    if (oId !== "") {
        var params = { id: oId };
        $.ajax({
            type: "POST",
            url: "../../Course/GetSearchInfo",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData != undefined && rData != "") {
                    $.each(rData, function (k, v) {
                        addRowsInSearch(++sl,v.Id, v.Name, v.Duration, v.Fees, v.Participants, v.Trainers, v.Batches);
                    });
                }
            }
        });
    }
});
function addRowsInSearch(sl, id, name, duration, fees, participants, trainers, batches) {

    var index = $("#SearchedInfo").children("tr").length;
    var idTd = "<td style='display:none'><input type='hidden' id='ItemId" + index + "' name='Course[" + index + "].Id' value='" + id + "' /> </td>";
    var slTd = "<td> <input type='hidden' id='ItemSerial" + index + "'  name='Course[" + index + "].Serial' value='" + sl + "' /> " + sl + " </td>";
    var nameTd = "<td> <input type='hidden' id='ItemName" + index + "'  name='Course[" + index + "].Name' value='" + name + "' /> " + name + " </td>";
    var durationTd = "<td> <input type='hidden' id='ItemDuration" + index + "'  name='Course[" + index + "].Duration' value='" + duration + "' /> " + duration + " Month  </td>";
    var feesTd = "<td> <input type='hidden' id='ItemFees" + index + "'  name='Course[" + index + "].Fees' value='" + fees + "' /> ৳. " + fees + " </td>";
    var participantsTd = "<td> <input type='hidden' id='ItemParticipants" + index + "'  name='Course[" + index + "].Participants' value='" + participants+ "' /> " + participants + " </td>";
    var trainersTd = "<td> <input type='hidden' id='ItemTrainers" + index + "'  name='Course[" + index + "].Trainers' value='" + trainers + "' /> " + trainers + " </td>";
    var batchesTd = "<td> <input type='hidden' id='ItemBatches" + index + "'  name='Course[" + index + "].Batches' value='" + batches + "' /> " + batches + " </td>";
    var edit = "<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
    var del = "<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
    var actions = "<td>" + edit + del + "</td>";

    var newRow = "<tr>" + idTd+slTd + nameTd + durationTd + feesTd + participantsTd + trainersTd +batchesTd + actions + " </tr>";

    $("#SearchedInfo").append(newRow);
    
    $("#ItemSerial").val("");
    $("#ItemName").val("");
    $("#ItemDuration").val("");
    $("#ItemFees").val("");
    $("#ItemParticipants").val("");
    $("#ItemTrainers").val("");
    $("#ItemBatches").val("");

}
