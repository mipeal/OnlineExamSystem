$("#OrganizationDD").change(function () {

    var oId = $(this).val();
    if (oId != undefined && oId != "") {
        var params = { id: oId };
        $.ajax({
            type: "POST",
            url: "../../Exam/GetInfoByOrganizationId",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                $("#CourseId").empty();
                $("#CourseId").append("<option value=''>---Select Course---</option>");
                if (rData != undefined && rData != "") {
                    $.each(rData, function (k, v) {
                        $("#CourseId").append("<option value='" + v.Id + "'>" + v.Name +" - "+v.Code+ "</option>");
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
            url: "../../Exam/GetExamInfoByCourseId",
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
        $.ajax({

            type: "POST",
            url: "../../Exam/GetParticipantInfoByCourseId",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                $("#ParticipantId").empty();
                $("#ParticipantId").append("<option value=''>---Select Participant---</option>");
                if (rData != undefined && rData != "") {
                    $.each(rData, function (k, v) {
                        $("#ParticipantId").append("<option value='" + v.Id + "'>" + v.Name +" - "+v.RegNo+ "</option>");
                    });
                }
            }
        });
    }
});


$("#ExamSave").click(function () {
    var courseId = $("#CourseDD").find(":selected").val();
    var examDuration = $("#txtHours").val() + ":" + $("#txtMinutes").val();

    $("#ExamCourseId").val(courseId);
    $("#Duration").val(examDuration);

});
