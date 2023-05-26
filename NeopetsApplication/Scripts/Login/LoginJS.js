$(function () {
    $(document).ready(function () {
        var name = $.cookie('name');
        var password = $.cookie('pass');
        if (name != null) {
            $("#txtName").val(name);
        }
        if (password != null) {
            $("#txtPwd").val(password);
            $('input:checkbox').attr("checked", true);
        }
    })

    $('#formLogin').click(function () {
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
        } else {
            var sa = $("#remember").is(":checked");
            //var sa = $("input[name='check']:checked").val()As@1;
            if (sa) {
                $.cookie('name', name, { expires: 7 });
                $.cookie('pass', pass, { expires: 7 });
            } else {
                var name = $.removeCookie('name');
                var pass = $.removeCookie('pass');
                $("#txtPwd").val() == ''
                $("#txtName").val() == ''
            }
        }
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/login/UserLogin",
            data: {"userName":name,"userPwd": pass ,"verifyCode":code},
            success: function (result) {
                if (result == 200) {
                    location.href="/pethome/index"
                } else if (result == 201) {
                    $('#codeImg').attr("src", "/login/SecurityCode" + "?" + Math.random());
                    alert('验证码不正确！！！');
                } else {
                    $('#codeImg').attr("src", "/login/SecurityCode" + "?" + Math.random());
                    alert('用户名或密码不正确！！！');
                };
            },
            error: function () {
                alert('异常');
            }
        });
    });
});