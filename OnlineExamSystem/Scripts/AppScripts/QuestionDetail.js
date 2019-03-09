$("#AddOptions").click(function () {
    createRowForCreatedOptions();

});

function createRowForCreatedOptions() {
    var selectedItem = getSubmittedExam();
    var index = $("#CreatedOptions").children("tr").length;
    var radio = "";
    if (selectedItem.Option !== "") {
        if ($('#QuestionAnswer').is(":checked")) {
            radio = "<input type='radio' checked='true' value='true' disabled/> <input type='hidden' id='ItemAnswer' name='Options[" + index + "].Answer' value='true' />";
        } else {
            radio = "<input type='radio' id='ItemAnswer' name='Options[" + index + "].Answer' value='' disabled/><input type='hidden' id='ItemAnswer' name='Options[" + index + "].Answer' value='false' />";
        }
        var sl = index;
        var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='Options.Index' value='" + index + "' /> </td>";
        var orderTd = "<td style='display:none'><input type='hidden' id='ItemId" + index + "' name='Options[" + index + "].Order' value='" + (++sl) + "' /> </td>";
        var optionTd = "<td> <input type='hidden' id='ItemOption" + index + "'  name='Options[" + index + "].Options' value='" + selectedItem.Option + "' /> " + radio + "  " + selectedItem.Option + " </td>";
        var edit = "<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
        var del = "<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
        var slTd = "<td id='Sl" + index + "'> " + sl + " </td>";
        var actions = "<td>" + edit + del + "</td>";

        var newRow = "<tr>" + indexTd +orderTd + slTd + optionTd + actions + " </tr>";

        $("#CreatedOptions").append(newRow);
        $("#ItemOption").val("");

    }
    
}

function getSubmittedExam() {
    var options = $("#QuestionOption").val();
    var item = {
        "Option": options
    };
    return item;
}
$("#OrganizationDD").change(function () {

    var oId = $(this).val();
    if (oId != undefined && oId != "") {
        var params = { id: oId };
        $.ajax({

            type: "POST",
            url: "../../QuestionBank/GetInfoByOrganizationId",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                $("#CourseId").empty();
                $("#CourseId").append("<option value=''>---Select Course---</option>");
                if (rData != undefined && rData != "") {
                    $.each(rData, function (k, v) {
                        $("#CourseId").append("<option value='" + v.Id + "'>" + v.Name + " - " + v.Code + "</option>");
                    });
                }
            }
        });
    }
});
$("#CourseId").change(function () {

    var cId = $(this).val();
    if (cId != undefined && cId != "") {
        var params = { id: cId };
        $.ajax({

            type: "POST",
            url: "../../QuestionBank/GetInfoByCourseId",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                $("#ExamId").empty();
                $("#ExamId").append("<option value=''>---Select Exam---</option>");
                if (rData != undefined && rData != "") {
                    $.each(rData, function (k, v) {
                        $("#ExamId").append("<option value='" + v.Id + "'>" + v.Code + "</option>");
                    });
                }
            }
        });
    }
});

$("#ExamId").change(function () {

    $("#SubmittedQuestions").empty();
    var eId = $(this).val();
    if (eId !== "") {
        var params = { id: eId };
        $.ajax({
            type: "POST",
            url: "../../QuestionBank/GetAllQuestionByExamId",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData != undefined && rData != "") {
                    $.each(rData, function (k, v) {
                        addRowsInList( v.Order, v.Question, v.Type, v.Options);
                    });
                }
            }
        });
    }
});


function addRowsInList(order, question, type, options) {

    var index = $("#SubmittedQuestions").children("tr").length;
    var orderTd = "<td ><input type='hidden' id='ItemOrder" + index + "' name='Questions[" + index + "].Id' value='" + order + "' />  " + order + "</td>";
    var questionTd = "<td> <input type='hidden' id='ItemQuestion" + index + "'  name='Questions[" + index + "].Question' value='" + question + "' /> " + question + "</td>";
    var typeTd = "<td> <input type='hidden' id='ItemType" + index + "'  name='Questions[" + index + "].Type' value='" + type + "' /> " + type + " </td>";
    var optionsTd = "<td> <input type='hidden' id='ItemOptions" + index + "'  name='Questions[" + index + "].Options' value='" + options + "' /> " + options + "</td>";
    var edit = "<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
    var del = "<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
    var actions = "<td>" + edit + del + "</td>";

    var newRow = "<tr>" + orderTd + questionTd + typeTd + optionsTd + actions + " </tr>";

    $("#SubmittedQuestions").append(newRow);

    $("#ItemQuestion").val("");
    $("#ItemOrder").val("");
    $("#ItemOptions").val("");
    $("#ItemType").val("");

}
$(document).ready(function () {
    $('.summernote').summernote({
        height: 150
    });
});
$("#QuestionSave").click(function () {
    var contents = $('.summernote').summernote('code');
    var question = $(contents).text();
    $('#Question').val(question);

    $("#SubmittedQuestions").empty();

    var eId = $("#ExamId").val();
    if (eId !== "") {
        var params = { id: eId };
        $.ajax({
            type: "POST",
            url: "../../QuestionBank/GetAllQuestionByExamId",
            contentType: "application/JSON; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData != undefined && rData != "") {
                    $.each(rData, function (k, v) {
                        addRowsInList(v.Order, v.Question, v.Type, v.Options);
                    });
                }
            }
        });
    }
});