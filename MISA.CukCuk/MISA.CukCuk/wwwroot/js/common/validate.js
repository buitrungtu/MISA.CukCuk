$(document).ready(function () {
    $('input[required]').blur(validData.initEventValidRequired)
})

var validData = {
    /**
     * Validate dữ liệu input
     * Autor:BTTu (24/9/2020)
     * */
    initEventValidRequired: function () {
        validData.checkRequired(this);
    },
   
    /**
     * Thực hiện validate
     * @param {object} input selector
     * Author: BTTu (24/9/2020)
     */
    checkRequired: function (input) {
        try {
            var value = $(input).val();
            // Thực hiện kiểm tra xem dữ liệu có nhập hay không (khoảng trắng hoặc null...):
            if (!value || !(value && value.trim())) {
                $(input).addClass('required-error');
                $(input).attr('placeholder', 'Trường này không dược phép để trống');
                return false;
            } else {
                $(input).removeClass('required-error');
                $(input).removeAttr('placeholder');
                return true;
            }
            var email = $("#email").val();
            const reg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (reg.test(String(email).toLowerCase())) {               
                $("#email").removeClass('required-error');
                $("#email").removeAttr('placeholder');
                return true;
            } else {
                $("#email").addClass('required-error');
                $("#email").attr('placeholder', 'Email không đúng định dạng');
                return false;
            }
        } catch{

        }
        
    }
} 

