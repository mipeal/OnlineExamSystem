$("#OrganizationDD").change(function () {
    var oId = $(this).val();
    if (oId != undefined && oId != "") {
        var params = { id: oId };
        $.ajax({

            type: "POST",
            url: "../../Batch/GetInfoByOrganizationId",
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