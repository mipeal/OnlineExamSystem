$("#OrganizationDD").change(function () {

    var oId = $(this).val();
    if (oId != undefined && oId != "") {
        var params = { id: oId };
        $.ajax({

            type: "POST",
            url: "../../Participant/GetInfoByOrganizationId",
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
            url: "../../Participant/GetInfoByCourseId",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                $("#BatchId").empty();
                $("#BatchId").append("<option value=''>---Select Exam---</option>");
                if (rData != undefined && rData != "") {
                    $.each(rData, function (k, v) {
                        $("#BatchId").append("<option value='" + v.Id + "'>" + v.No + "</option>");
                    });
                }
            }
        });
    }
});