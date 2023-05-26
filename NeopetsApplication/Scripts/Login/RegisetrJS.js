$(function () {
    $('#formRegisetr').click(function () {
        var name = $("#txtName").val();
        var pass = $("#txtPwd").val();
        var code = $("#code").val();
        if (name == '') {
            $("#txtName").focus();
            return false;
        }
        else if (pass == '') {
            $("#txtPwd").focus();
            return false;
        }
        else if (code == '') {
            $("#code").focus();
            return false;
        }
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/login/RegisetrUser",
            data: { "userName": name, "userPwd": pass, "verifyCode": code },
            success: function (result) {
                if (result == 200) {
                    location.href = "/login/index"
                } else if (result == 201) {
                    $('#codeImg').attr("src", "/login/SecurityCode" + "?" + Math.random());
                    alert('验证码不正确！！！');
                } else {
                    $('#codeImg').attr("src", "/login/SecurityCode" + "?" + Math.random());
                    alert('用户名已存在！！！');
                };
            },
            error: function () {
                alert('异常');
            }
        });
    });
})