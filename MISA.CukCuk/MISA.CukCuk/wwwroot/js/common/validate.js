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
    checkRequired: function(input) {
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
    }
} 

