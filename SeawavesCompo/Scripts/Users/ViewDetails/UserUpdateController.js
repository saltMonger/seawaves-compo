$(document).ready(function () {
    //load page by calling bootstraping script on asscoiated view
    loadInitialData();
    var editModeIsOn = false;

    //setup handlers for save/submit buttons
    $("#submitEdit").on("click", function () {
        //create object for update
        var updateObject = {
            ProfileText: $("#userBioEditable").val(),
            UserHandle: $("#userHandle").text(),
            ID: model.ID
        };

        $.ajax({
            url: '../../api/UserApi/UpdateUserInformation/',
            type: 'POST',
            data: JSON.stringify(updateObject),
            contentType: "application/json",
            success: function (result) {
                console.log(result);
                if (result.ResponseCode === 1) {
                    console.log("writing stuff now...");
                    $("#userBio").text(result.ResponseObject.ProfileText);
                    $("#userHandle").text(result.ResponseObject.UserHandle);
                }

                //flip to normal view mode
                editModeIsOn = false;
                $('#userBioEditable').prop('hidden', true);
                $('#userBio').prop('hidden', false);
            }
        });
    });

    //setup handler for update toggle button
    $("#toggleEditMode").on("click", function () {
        console.log("editmodeIsOn: " + editModeIsOn);
        if (editModeIsOn !== false) {
            //unset toggle mode and hide save button
            $("#submitEdit").prop('disabled', true);
            editModeIsOn = false;
            $('#userBioEditable').prop('hidden', true);
            $('#userBio').prop('hidden', false);
        }
        else {
            $("#submitEdit").prop('disabled', false);
            console.log("should have changed here");
            editModeIsOn = true;
            $('#userBio').prop('hidden', true);
            $('#userBioEditable').prop('hidden', false).val($('#userBio').text());
        }
    })
})

