$("#OrganizationDD").change(function () {

    var oId = $(this).val();
    if (oId != undefined && oId != "") {
        var params = { id: oId };
        $.ajax({

            type: "POST",
            url: "../../Exam/GetInfoByCourseId",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                $("#CourseDD").empty();
                $("#CourseDD").append("<option value=''>---Select Course---</option>");
                if (rData != undefined && rData != "") {
                    $.each(rData, function (k, v) {
                        $("#CourseDD").append("<option value='" + v.Id + "'>" + v.Name +" - "+v.Code+ "</option>");
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
