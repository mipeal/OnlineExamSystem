

$("#AddTrainer").click(function () {
    createRowForAssignedTrainers();

});


var index = 0;
function createRowForAssignedTrainers() {

    //Get Selected Item from UI
    var selectedItem = getSelectedItem();

    //Check Last Row Index
    var index = $("#assignedTrainers").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='Trainers.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var itemTd = "<td> <input type='hidden' id='ItemName" + index + "'  name='Trainers[" + index + "].Name' value='" + selectedItem.Name + "' /> " + selectedItem.Name + " </td>";
    var qtyTd = "<td> <input type='hidden' id='ItemQty" + index + "'  name='Trainers[" + index + "].Type' value='" + selectedItem.Type + "' /> " + selectedItem.Type + " </td>";
    var edit ="<button class='btn btn-default btn-xs m-r-5' data-toggle='tooltip' data-original-title='Edit'><i class='fa fa-pencil font-14'></i></button>";
    var del ="<button class='btn btn-default btn-xs' data-toggle='tooltip' data-original-title='Delete'><i class='fa fa-trash font-14'></i></button>";
    var actions = "<td>" + edit + del + "</td>";
    
    var newRow = "<tr>" + indexTd + slTd + itemTd + qtyTd + actions+" </tr>";

    $("#assignedTrainers").append(newRow);
    $("#ItemName").val("");
    $("#ItemQty").val("");

}


function getSelectedItem() {
    var name = $("#trainers").val();
    var type = $("#TrainerId").val();

    var item = {
        "Name": name,
        "Type": type
    };

    return item;
}



$(document).ready(function () {
    
});


$("#GetCourseUpdate").click(function () {
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



