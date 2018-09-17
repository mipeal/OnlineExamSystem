

$("#AddTrainer").click(function () {
    createRowForAssignedTrainers();

});
$("#AddExam").click(function () {
    createRowForSubmittedExams();

});

var index = 0;
function createRowForAssignedTrainers() {

    var selectedItem = getSelectedTrainer();
    var index = $("#assignedTrainers").children("tr").length;
    var sl = index;
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='Trainers.Index' value='" + index + "' /> </td>";
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var itemTd = "<td> <input type='hidden' id='ItemName" + index + "'  name='Trainers[" + index + "].Name' value='" + selectedItem.Name + "' /> " + selectedItem.Name + " </td>";
    var typeTd = "<td> <input type='hidden' id='ItemType" + index + "'  name='Trainers[" + index + "].Type' value='" + selectedItem.Type + "' /> <input type='checkbox' id='ItemType'/>  </td>";
    var edit ="<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
    var del ="<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
    var actions = "<td>" + edit + del + "</td>";
    
    var newRow = "<tr>" + indexTd + slTd + itemTd + typeTd + actions+" </tr>";

    $("#assignedTrainers").append(newRow);
    $("#ItemName").val("");
    $("#ItemType").val("");

}
function createRowForSubmittedExams() {

    var selectedItem = getSubmittedExam();
    var index = $("#SubmittedExams").children("tr").length;
    var sl = index;
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='Trainers.Index' value='" + index + "' /> </td>";
    //var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var typeTd = "<td> <input type='hidden' id='ItemType" + index + "'  name='Trainers[" + index + "].ExamType' value='" + selectedItem.Type + "' /> " + selectedItem.Type + " </td>";
    var codeTd = "<td> <input type='hidden' id='ItemCode" + index + "'  name='Trainers[" + index + "].Code' value='" + selectedItem.Code + "' /> " + selectedItem.Code + "  </td>";
    var topicTd = "<td> <input type='hidden' id='ItemTopic" + index + "'  name='Trainers[" + index + "].Topic' value='" + selectedItem.Topic + "' /> " + selectedItem.Topic + " </td>";
    var marksTd = "<td> <input type='hidden' id='ItemMarks" + index + "'  name='Trainers[" + index + "].FullMarks' value='" + selectedItem.Marks + "' /> " + selectedItem.Marks + " </td>";
    var durationTd = "<td> <input type='hidden' id='ItemDuration" + index + "'  name='Trainers[" + index + "].Duration' value='" + selectedItem.Duration + "' /> " + selectedItem.Duration + " </td>";
    var edit = "<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
    var del = "<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
    var actions = "<td>" + edit + del + "</td>";

    var newRow = "<tr>" + indexTd + typeTd + topicTd + codeTd+ durationTd + marksTd + actions + " </tr>";

    $("#SubmittedExams").append(newRow);
    $("#ItemType").val("");
    $("#ItemCode").val("");
    $("#ItemTopic").val("");
    $("#ItemMarks").val("");
    $("#ItemDuration").val("");

}

function getSelectedTrainer() {
    var organization = $(".TrainersDD").find(":selected").text();
    var type = $(".TrainersDD").val();

    var item = {
        "Name": name,
        "Type": type
    };

    return item;
}
function getSubmittedExam() {
    var examType = $("#ExamType").val();
    var examCode = $("#ExamCode").val();
    var examTopic = $("#ExamTopic").val();
    var examMarks = $("#ExamMarks").val();
    var examDuration = $("#ExamDuration").val();
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
        url: "../../Course/GetCourseUpdatePartial",
        contentType: "application/Json; charset=utf-8",
        data: JSON.stringify(),
        success: function (rData) {
            $("#LoadCourseEditPartial").html(rData);

        }
    });
});



$("#GetCourseCreateExam").click(function () {
        $.ajax({
            type: "POST",
            url: "../../Course/GetCreateExamsPartial",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(),
            success: function (rData) {
                $("#LoadCourseEditPartial").html(rData);

            }
        });
    });

    $("#GetCourseAssignTrainer").click(function () {
        $.ajax({
            type: "POST",
            url: "../../Course/GetAssignTrainersPartial",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(),
            success: function (rData) {
                $("#LoadCourseEditPartial").html(rData);

            }
        });
    });


