$(function () {
    $(function () {
        $("#txtName").after("<span style='color:red'>*</span>");
        $("#txtPwd").after("<span style='color:red'>*</span>");
        $("#codeImg").after("<span style='color:red'>*</span>");
    });

    $(function () {
        $("#txtName").blur(function () {
            if ($("#txtName").val() == '') {
                $("#errorMsg").text('邮箱或电话号码不能为空！！！');
                $("#txtName").focus();
            } else {
                var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$|(^(13[0-9]|14[01456879]|15[0-35-9]|16[2567]|17[0-8]|18[0-9]|19[0-35-9])\d{8}$)/;
                // ^[A-Za-z0-9\u4e00-\u9fa5]+@@[a-zA-Z0-9_-]+(.[a-zA-Z0-9_-]+)+$  ^[a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$
                //var myreg = /^(([a-z0-9A-Z]+[-|\\.]?)+[a-z0-9A-Z]@([a-z0-9A-Z]+(-[a-z0-9A-Z]+)?\\.)+[a-zA-Z]{2,}$)|(^(13[4,5,6,7,8,9]|15[0,8,9,1,7]|188|187)\\d{8}$)/;
                // /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$|(^(13[0-9]|14[01456879]|15[0-35-9]|16[2567]|17[0-8]|18[0-9]|19[0-35-9])\d{8}$)/
                if (!myreg.test($('#txtName').val())) {
                    $("#errorMsg").css({
                        "color": "red"
                    });
                    $("#errorMsg").text('邮箱或电话号码格式不正确！！！');
                    $("#txtName").focus();
                } else {
                    $("#errorMsg").css({
                        "color": "green"
                    });
                    $("#errorMsg").text('验证通过');
                }
            }
        })
    });

    $(function () {
        $("#txtPwd").blur(function () {
            if ($("#txtPwd").val() == '') {
                $("#pwdErrorMsg").text('密码不能为空！！！');
                $("#txtPwd").focus();
            } else {
                var myreg = /^.*(?=.{6,})(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*? ]).*$/;
                if (!myreg.test($('#txtPwd').val())) {
                    $("#pwdErrorMsg").css({
                        "color": "red"
                    });
                    $("#pwdErrorMsg").text('密码格式必须为大小写字母加数字加特殊字符且为六位！！！');
                    $("#txtPwd").focus();
                } else {
                    $("#pwdErrorMsg").css({
                        "color": "green"
                    });
                    $("#pwdErrorMsg").text('验证通过');
                }
            }
        })
    });

    $(function () {
        $("#code").blur(function () {
            if ($("#code").val() == '') {
                $("#vCodeErrorMsg").text('验证码不能为空！！！');
                $("#code").focus();
            } else {
                if ($("#code").val().length < 4) {
                    $("#vCodeErrorMsg").css({
                        "color": "red"
                    });
                    $("#vCodeErrorMsg").text('验证码需为四位！！！');
                } else if ($("#code").val().length > 5) {
                    $("#vCodeErrorMsg").css({
                        "color": "red"
                    });
                    $("#vCodeErrorMsg").text('验证码需为四位！！！');
                }
                else {
                    $("#vCodeErrorMsg").css({
                        "color": "green"
                    });
                    $("#vCodeErrorMsg").text('验证通过');
                }
            }
        })
    });


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


    $(".screenbg ul li").each(function () {
        $(this).css("opacity", "0");
    });
    $(".screenbg ul li:first").css("opacity", "1");
    var index = 0;
    var t;
    var li = $(".screenbg ul li");
    var number = li.length;
    function change(index) {
        li.css("visibility", "visible");
        li.eq(index).siblings().animate({ opacity: 0 }, 3000);
        li.eq(index).animate({ opacity: 1 }, 3000);
    }
    function show() {
        index = index + 1;
        if (index <= number - 1) {
            change(index);
        } else {
            index = 0;
            change(index);
        }
    }
    t = setInterval(show, 8000);
    //根据窗口宽度生成图片宽度
    var width = $(window).width();
    $(".screenbg ul img").css("width", width + "px");
});