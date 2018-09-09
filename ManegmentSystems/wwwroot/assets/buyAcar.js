
$("#buyCarForm").on('click',function () {
    var url = '@Url.Action("Create", "CustomerInformations")';
    debugger;
    var userData = {
        ownerName: $('#ownerName').val(),
        sellerName: $('#sellerName').val(),
        idNumber: $('#IdNumber').val(),
        phoneNumber: $('#phoneNumber').val(),
        idImgUrl:"sdsdf"

    };
    console.log(userData)
    $.post(url, { UserData: userData }, function (CustomerID) {
        debugger;
        if (isNumber(CustomerID)) {
            var url = '@Url.Action("Create", "carInformations")';
            var carInformation = {
                manfucatureshortName: $.trim($("#manfucatureshortName").val()),
                carModel: $.trim($("#carModel").val()),
                buyprice: $.trim($("#buyprice").val()),
                buyprice: $.trim($("#sellprice").val()),
                buyprice: $.trim($("#car_id").val()),
                buyprice: $.trim($("#other_details").val()),
                Userid: CustomerID
            };
            $.post(url, { CarInformation: carInformation }, function (carInformationID) {
                debugger;

                if (isNumber(carInformationID)) {


                    var url = '@Url.Action("Create", "checks")';
                    var checkLate = new Array();
                    for (let i = 0; i < $("#numberofcheck").val(); i++) {
                        var x = $("#amount" + i).val();
                        var y = $("#date" + i).val();
                        var z = $("#checkOwner" + i).val();
                        var m = $("#arrest" + i).val();
                        var imgUrl = $("imgUrl" + i).val();
                        checkLate.push({ x, y, z, m, imgUrl })
                    };



                    var check = {
                        check: checkLate
                    };
                    $.post(url, { Checks: check }, function (checkID) {
                        if (isNumber(checkID)) {
                            var url = '@Url.Action("Create", "cashes")';
                            var chaseLate = new Array();
                            for (let i = 0; i < $("#numberofcash").val(); i++) {
                                var x = $("#amounti" + i).val();
                                var y = $("#datei" + i).val();
                                var z = $("#cashPayi" + i).val();
                                var m = $("#arresti" + i).val();

                                chaseLate.push({ x, y, z, m })
                            };

                            var cash = {
                                cash: chaseLate

                            };

                            $.post(url, { cashLates: cash }, function (cashID) {

                                if (isNumber(cashID)) {
                                    var url = '@Url.Action("Create", "paymentInformations")';
                                    var paymentInformation = {
                                        cash: $.trim($("#cashMoney").val()),
                                        lateCashID: cashID,
                                        checkLateID: checkID,
                                        addDate: new Date().getDate()
                                    }
                                    $.post(url, { paymentInformations: paymentInformation }, function (paymentInformationID) {
                                        if (respons == true) {
                                            var url = '@Url.Action("Create", "paymentInformations")';
                                            var buyInformation = {
                                                carInformation: carInformationID,
                                                customerInformation: CustomerID,
                                                paymentInformation: paymentInformationID,
                                                buyDate: new Date().getDate()
                                            }
                                            $.post(url, { buyInformations: buyInformation }, function (response) {
                                                if (response == true) {
                                                    alert("done")
                                                }
                                            });
                                        }
                                    });
                                }
                            });
                        }
                    });
                }

            });

        }
    });
});