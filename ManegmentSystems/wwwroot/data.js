$button = $('#dd');
$(function () {

    $button.click(function () {

        debugger;
        var checkOwner = $('#owner').val();
        var checkAmount = $('#amount').val();
        var checkdate = $('#date').val();
        var formdata = new FormData(); //FormData object
        var fileInput = $(#'Photo');
        //Iterating through each files selected in fileInput
        for (i = 0; i < fileInput.files.length; i++) {
            //Appending each file to FormData object
            formdata.append('Photo', fileInput.files[i]);
        }
        formdata.append('checkOwner', checkOwner);
        formdata.append('checkamount', checkAmount);
        formdata.append('dueDate', date);

        //Creating an XMLHttpRequest and sending
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/api/check/addAsync');
        xhr.send(formdata);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                alert(xhr.responseText);
            }
        }
        return false;

    });

});
