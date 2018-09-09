
    $(document).ready(function () {
        $("#buyCarForm").on('click', function () {
           
            debugger;
            var userData = {
                ownerName: $('#sellerName').val(),
                Adress: $('#Adress').val(),
                phoneNumber: $('#phoneNumber').val(),
                ID_Photo: uplode('ID_Photo')
              

            };
            console.log(userData)
            $.ajax({
                type: "post",
                data: userData,
                url: "/api/SalePersons",

                success: function (sellerPersonID) {
                    var carData = {
                        manfucatureshortName: $('#manfucatureshortName').val(),
                        carModel: $('#carModel').val(),
                        OwnerName: $('#OwnerName').val(),
                        Insurance: $('input[name=Insurance]:checked').val(),
                        car_id: $('#car_id').val(),
                        more_deatils: $('.textarea_editor').val()


                    };
                    console.log(carData)
                    $.ajax({
                        type: "post",
                        data: carData,
                        url: "/api/car",

                        success: function (Carid) {
                            var cashdata = {
                                Cash_money_payid: $('#Car_price').val(),
                                                           };
                            console.log(carData)
                            $.ajax({
                                type: "post",
                                data: cashdata,
                                url: "/api/outcomes",

                                success: function (outcomerID) {
                                    var cashdata1 = {
                                        amount: $('#Cash_money_payid').val(),
                                        arrested:1,
                                         outcome_ID: outcomerID
                                    };
                                    console.log(carData)
                                    $.ajax({
                                        type: "post",
                                        data: cashdata1,
                                        url: "/api/cashs",

                                        success: function (outcomerID) {

                                        },
                                        error: function (data) {


                                        }
                                    });
                                    var values = [];
                                    var dates = [];
                                    var arrested = [];

                                    $('input[name="amounti[]"]').each(function () {
                                        values.push($(this).val());
                                    });
                                    $('input[name="datei[]"]').each(function () {
                                        dates.push($(this).val());
                                    });
                                    $('input[name="arresti[]"]').each(function () {
                                        arrested.push($(this).val());
                                    });
                                        var cashdata = {
                                            amount: values,
                                            dateArrested: dates,
                                            arrested: arrested,
                                            outcome_ID: outcomerID
                                        };
                                        console.log(carData)
                                        $.ajax({
                                            type: "post",
                                            data: cashdata,
                                            url: "/api/cash",

                                            success: function (outcomerID) {

                                            },
                                            error: function (data) {


                                            }
                                        });
                                    

                                    var amounts = [];
                                    var dates = [];
                                    var photo = [];
                                    var Names=[]

                                    $('input[name="amount2[]"]').each(function () {
                                        values.push($(this).val());
                                    });
                                    $('input[name="date2[]"]').each(function () {
                                        dates.push($(this).val());
                                    });
                                    $('input[name="checkOwner[]"]').each(function () {
                                        arrested.push($(this).val());
                                    });
                                        var checkdata = {
                                            amount: amounts,
                                            dueDate: dates,
                                            photo: uplodecheck,
                                            Name:Names,
                                            outcome_ID: outcomerID
                                        };
                                        console.log(carData)
                                        $.ajax({
                                            type: "post",
                                            data: checkdata,
                                            url: "/api/checks",

                                            success: function (outcomerID) {

                                            },
                                            error: function (data) {


                                            }
                                        });
                                    

                                },
                                error: function (data) {


                                }
                            });
                        },
                        error: function (data) {


                        }
                    });
                },
                error: function (data) {


                }
            });
        });
});
function uplode(id) {
    var formData = new FormData();
    formData.append('file', $('#' + id)[0].files[0]); // myFile is the input type="file" control

    console.log($('#' + id)[0].files[0]);
    var data =$.ajax({
        type: "POST",
        datatype: "application/json",
        url: "/api/SalePersons",
        contentType: false,
        processData: false,
        data: formData,
        success: function (message) {
            return JSON.parse( message)
        },
        error: function (data) {
         
        }
    });
    console.log(data);
    return data;

}
$(document).ready(function () {
    var deta;
    $.ajax({
        type: "GET",

        url: "/api/Manufacture",
        success: function (data) {

            for (let i = 0; i < data.length; i++) {
                $('#manfucatureshortName').append("<option value='" + data[i]['Id'] + "'>" + data[i]['Name'] + "</option>");


            }
            deta = data;

        },
        error: function (data) {
            console.log(data)

        }
    })
    $('#manfucatureshortName').on('change', function () {
        var id = $('#manfucatureshortName').val();
        console.log(deta[parseInt(id) - 1]['Model']);



        for (let i = 0; i < deta[parseInt(id) - 1]['Model'].length; i++) {
            $('#carModel').append("<option value='" + deta[parseInt(id) - 1]['Model'][i]['id'] + "'>" + deta[parseInt(id) - 1]['Model'][i]['Name'] + "</option>");
        }



    });

});
function uplodecheck() {
    var formData = new FormData();
    $('input[name="checkphoto[]"]')[0].files[0].each(function () {
        formData.append("files",$(this).val());
    });
  //  formData.append('file', $('#' + id)[0].files[0]); // myFile is the input type="file" control


    var data = $.ajax({
        type: "POST",
        url: "/api/checkUplode",
        contentType: false,
        processData: false,
        data: formData,
        success: function (message) {
            return message
        },
        error: function (data) {
            console.log(data);
        }
    });
    return data;

}
