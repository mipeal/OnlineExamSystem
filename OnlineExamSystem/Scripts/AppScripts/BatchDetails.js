$("#OrganizationDD").change(function () {
    var oId = $(this).val();
    if (oId !== undefined && oId !== "") {
        var params = { id: oId };
        $.ajax({

            type: "POST",
            url: "../../Batch/GetInfoByOrganizationId",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                $("#CourseId").empty();
                $("#CourseId").append("<option value=''>---Select Course---</option>");
                if (rData !== undefined && rData !== "") {
                    $.each(rData, function (k, v) {
                        $("#CourseId").append("<option value='" + v.Id + "'>" + v.Name + " - " + v.Code + "</option>");
                    });
                }
            }
        });
    }
});

$(document).ready(function () {
    
});
$("#AddParticipant").click(function () {
    createRowForAssignedParticipants();

});
$("#AddTrainer").click(function () {
    createRowForAssignedTrainers();

});

function createRowForAssignedParticipants() {

    var selectedItem = getSelectedParticipant();
    if (selectedItem !== "") {
        var index = $("#assignedParticipants").children("tr").length;
        var sl = index;
        var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='Participants.Index' value='" + index + "' /> </td>";
        var idTd = "<td style='display:none'><input type='hidden' id='ItemId" + index + "' name=Participants[" + index + "].Id' value='" + selectedItem.Id + "' /> </td>";
        var addressTd = "<td style='display:none'><input type='hidden' id='ItemAddress" + index + "' name='Participants[" + index + "].Address' value='" + selectedItem.Address + "' /> </td>";
        var batchTd = "<td style='display:none'><input type='hidden' id='ItemBatchId" + index + "' name='Participants[" + index + "].BatchId' value='" + selectedItem.BatchId + "' /> </td>";
        var cityTd = "<td style='display:none'><input type='hidden' id='ItemCity" + index + "' name='Participants[" + index + "].City' value='" + selectedItem.City + "' /> </td>";
        var contactTd = "<td style='display:none'><input type='hidden' id='ItemContactNo" + index + "' name='Participants[" + index + "].ContactNo' value='" + selectedItem.ContactNo + "' /> </td>";
        var countryTd = "<td style='display:none'><input type='hidden' id='ItemCountry" + index + "' name='Participants[" + index + "].Country' value='" + selectedItem.Country + "' /> </td>";
        var courseTd = "<td style='display:none'><input type='hidden' id='ItemCourseId" + index + "' name='Participants[" + index + "].CourseId' value='" + selectedItem.CourseId + "' /> </td>";
        var regNoTd = "<td style='display:none'><input type='hidden' id='ItemRegNo" + index + "' name='Participants[" + index + "].RegNo' value='" + selectedItem.RegNo + "' /> </td>";
        var highestAcademicTd = "<td style='display:none'><input type='hidden' id='ItemHighestAcademic" + index + "' name='Participants[" + index + "].HighestAcademic' value='" + selectedItem.HighestAcademic + "' /> </td>";
        var emailTd = "<td style='display:none'><input type='hidden' id='ItemEmail" + index + "' name='Participants[" + index + "].Email' value='" + selectedItem.Email + "' /> </td>";
        var postalTd = "<td style='display:none'><input type='hidden' id='ItemPostalCode" + index + "' name='Participants[" + index + "].PostalCode' value='" + selectedItem.PostalCode + "' /> </td>";

        var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";
        var nameTd = "<td> <input type='hidden' id='ItemName" + index + "'  name='Participants[" + index + "].Name' value='" + selectedItem.Name + "' /> " + selectedItem.Name + " </td>";
        var professionTd = "<td ><input type='hidden' id='ItemProfession" + index + "' name='Participants[" + index + "].Profession' value='" + selectedItem.Profession + "' />" + selectedItem.Profession + " </td>";

        var edit = "<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
        var del = "<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
        var actions = "<td>" + edit + del + "</td>";

        var newRow = "<tr>" + indexTd + idTd + cityTd + contactTd + countryTd + courseTd + regNoTd + highestAcademicTd+ addressTd + batchTd + emailTd + postalTd + slTd + nameTd + professionTd + actions + " </tr>";

        $("#assignedParticipants").append(newRow);
        $("#ItemName").val("");
        $("#ItemProfession").val("");
    }
}

var index = 0;
function createRowForAssignedTrainers() {

    var selectedItem = getSelectedTrainer();
    if (selectedItem !== "") {
        var index = $("#assignedTrainers").children("tr").length;
        var sl = index;
        var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='Trainers.Index' value='" + index + "' /> </td>";
        var idTd = "<td style='display:none'><input type='hidden' id='ItemId" + index + "' name='Trainers[" + index + "].Id' value='" + selectedItem.Id + "' /> </td>";
        var codeTd = "<td style='display:none'><input type='hidden' id='ItemCode" + index + "' name='Trainers[" + index + "].Code' value='" + selectedItem.Code + "' /> </td>";
        var addressTd = "<td style='display:none'><input type='hidden' id='ItemAddress" + index + "' name='Trainers[" + index + "].Address' value='" + selectedItem.Address + "' /> </td>";
        var batchTd = "<td style='display:none'><input type='hidden' id='ItemBatchId" + index + "' name='Trainers[" + index + "].BatchId' value='" + selectedItem.BatchId + "' /> </td>";
        var cityTd = "<td style='display:none'><input type='hidden' id='ItemCity" + index + "' name='Trainers[" + index + "].City' value='" + selectedItem.City + "' /> </td>";
        var contactTd = "<td style='display:none'><input type='hidden' id='ItemContactNo" + index + "' name='Trainers[" + index + "].ContactNo' value='" + selectedItem.ContactNo + "' /> </td>";
        var countryTd = "<td style='display:none'><input type='hidden' id='ItemCountry" + index + "' name='Trainers[" + index + "].Country' value='" + selectedItem.Country + "' /> </td>";
        var courseTd = "<td style='display:none'><input type='hidden' id='ItemCourseId" + index + "' name='Trainers[" + index + "].CourseId' value='" + selectedItem.CourseId + "' /> </td>";
        var emailTd = "<td style='display:none'><input type='hidden' id='ItemEmail" + index + "' name='Trainers[" + index + "].Email' value='" + selectedItem.Email + "' /> </td>";
        var postalTd = "<td style='display:none'><input type='hidden' id='ItemPostalCode" + index + "' name='Trainers[" + index + "].PostalCode' value='" + selectedItem.PostalCode + "' /> </td>";
        var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";
        var typeTdChecked = "";
        if (selectedItem.Type !== true) {
            typeTdChecked = "";
        } else {
            typeTdChecked = 'checked = "checked"';
        }
        var itemTd = "<td> <input type='hidden' id='ItemName" + index + "'  name='Trainers[" + index + "].Name' value='" + selectedItem.Name + "' /> " + selectedItem.Name + " </td>";
        var typeTd = "<td> <input type='hidden' id='ItemType" + index + "'  name='Trainers[" + index + "].Type' value='" + selectedItem.Type + "' /> <input type='checkbox' id='ItemType' " + typeTdChecked + "/>  </td>";
        var edit = "<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
        var del = "<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
        var actions = "<td>" + edit + del + "</td>";

        var newRow = "<tr>" + indexTd + idTd + codeTd + cityTd + contactTd + countryTd + courseTd + addressTd + batchTd + emailTd + postalTd + slTd + itemTd + typeTd + actions + " </tr>";

        $("#assignedTrainers").append(newRow);
        $("#ItemName").val("");
        $("#ItemType").val("");
    }
}


function getSelectedParticipant() {
    var participantId = $("#ParticipantsDD").find(":selected").val();
    var batchNo = $("#BatchNo").val();
    var item = "";
    if (participantId !== "") {
        var params = { id: participantId };
        $.ajax({
            type: "POST",
            url: "../../Batch/GetInfoByParticipantId",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== undefined && rData !== "") {
                    item = {
                        "Name": rData.Name,
                        "Id": rData.Id,
                        "ContactNo": rData.ContactNo,
                        "Email": rData.Email,
                        "Address": rData.Address,
                        "City": rData.City,
                        "PostalCode": rData.PostalCode,
                        "Country": rData.Country,
                        "CourseId": rData.CourseId,
                        "BatchId": batchNo,
                        "RegNo": rData.RegNo,
                        "Profession": rData.Profession,
                        "HighestAcademic": rData.HighestAcademic
                    };
                }
            }
        });
    }
    return item;
}

function getSelectedTrainer() {
    var trainerId = $("#TrainersDD").find(":selected").val();
    var batchNo = $("#BatchNo").val();
    var item = "";
    if (trainerId !== "") {
        var params = { id: trainerId };
        $.ajax({
            type: "POST",
            url: "../../Batch/GetInfoByTrainerId",
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
                        "BatchId": batchNo
                    };
                }
            }
        });
    }
    return item;
}

var item = '';
$("#ScheduleExamDD").change(function () {

    var eId = $(this).val();
    if (eId !== "") {
        var params = { id: eId };
        $.ajax({
            type: "POST",
            url: "../../Batch/GetExamById",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== undefined && rData !== "") {
                        item = {
                            "Id": rData.Id,
                            "Type": rData.ExamType,
                            "Code": rData.Code,
                            "Topic": rData.Topic,
                            "Mark": rData.FullMark,
                            "Duration": rData.Duration
                        };
                }
            }
        });
    }
});


$("#ScheduleExam").click(function () {
    var schedule = $("#ExamDate").val() + " " + $("#ExamTime").val();
    var batchNo = $("#BatchNo").val();
    if (item!=="" && item!==undefined) {
        addRowsInList(item.Id, item.Type, item.Topic, item.Code, item.Duration, item.Mark, schedule, batchNo);
    }
    
});
function addRowsInList(id,type, topic, code,duration, mark,schedule,batch ) {
    var time = duration.Hours + ":" + duration.Minutes;
    var index = $("#SubmittedExams").children("tr").length;
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='ScheduleExams.Index' value='" + index + "' /> </td>";
    var idTd = "<td style='display:none'><input type='hidden' id='ItemId" + index + "' name='ScheduleExams[" + index + "].ExamId' value='" + id + "' /> </td>";
    var batchTd = "<td style='display:none'><input type='hidden' id='ItemId" + index + "' name='ScheduleExams[" + index + "].BatchId' value='" + batch + "' /> </td>";
    
    var typeTd = "<td> " + type + " </td>";
    var codeTd = "<td> " + code + "  </td>";
    var topicTd = "<td>  " + topic + " </td>";
    var marksTd = "<td> " + mark + " </td>";
    var durationTd = "<td>" + time + " </td>";
    var scheduleTd = "<td> <input type='hidden' id='ItemSchedule" + index + "'  name='ScheduleExams[" + index + "].Schedule' value='" + schedule + "' /> " + schedule+ " </td>";
    var edit = "<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
    var del = "<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
    var actions = "<td>" + edit + del + "</td>";

    var newRow = "<tr>" + indexTd + idTd+batchTd + typeTd + topicTd + codeTd + durationTd + marksTd+scheduleTd + actions + " </tr>";

    $("#SubmittedExams").append(newRow);
    $("#ItemSchedule").val("");

}