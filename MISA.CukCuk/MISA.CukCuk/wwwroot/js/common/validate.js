$(document).ready(function () {
    $('input[required]').blur(validData.initEventValidRequired)
})

var validData = {
    /**
     * Validate dữ liệu input
     * Autor:Bui Trung Tu (24/9/2020)
     * */
    initEventValidRequired: function () {
        validData.checkRequired(this);
    },
    /**
    * Thực hiện validate
    * Autor:Bui Trung Tu (24/9/2020)
    *
    * */
    checkRequired: function(input) {
        var value = $(input).val();
        if (!value && !(value && value.trim())) {
            $(input).addClass('required-error');
            $(input).attr("placeholder", "Bạn phải nhập thông tin này.");
            return true;
        } else {
            $(this).removeClass('required-error');
            return false;
        }
    }

} 

