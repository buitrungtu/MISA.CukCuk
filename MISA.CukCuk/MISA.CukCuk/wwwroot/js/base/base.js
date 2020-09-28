/**
 * Class quản lý các function chung cua các trang
 * Author: Bui Trung Tu (25/9/2020)
 * */
class BaseJS {
    constructor() {
        try {
            this.FormType = null;
            this.getData();
            this.initEvents();
            this.loadData();
        } catch (e) {}
    }
    /**
     * Gán sự kiện cho các thành phần
     * Author: Bui Trung Tu (25/9/2020)
     * */
    initEvents() {
        // Gán sự kiện
        $("table").on("click", "tbody tr", this.rowOnClick);
        $('#btnCancel').click(this.btnCloseOnClick.bind(this));
        $('.title-button-close').click(this.btnCloseOnClick.bind(this));
        $('.dialog-modal').click(this.btnCloseOnClick.bind(this));
        $('.UserSection').click(this.ShowUserSelection.bind(this));
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        $('#btnEdit').click(this.btnEditOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('#txtCustomerCode').blur(this.checkRequired);
        $('.required').blur(this.checkRequired);
        $("#btnLoad").click(this.btnReloadOnClick.bind(this));
        $('#iconbar').click(this.resizeContent);
        // dịch con trỏ khi bấm tab
        $('#btnCancel').blur(this.targetToStart);

    }

    /**
     * Lấy dữ liệu
     * Author: Bui Trung Tu (24/9/2020)
     * */
    getData() {
        this.Data = [];
    }

    /**
     * Lấy dữ liệu của 1 đối tượng
     * Author: Bui Trung Tu (24/9/2020)
     * */
    getObjData() {
        this.Obj = {};
    }
    /**
     * Load dữ liệu
     * Autor:Bui Trung Tu (24/9/2020)
     * 
     * */
    //TODO: Test todo
    loadData() {
        try {
            $('#tbListData tbody').empty();
            // đọc thông tin các cột dữ liệu:
            var fields = $('table#tbListData thead th');
            $.each(this.Data, function (i, obj) {
                var tr = $(`<tr></tr>`);
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    var format = $(field).attr('format');
                    var value, td;
                    switch (format) {
                        case 'money':
                            value = commonJS.formatMoney(obj[fieldName]);
                            td = $(`<td class="text-right">` + value + `</td>`);
                            break;
                        case 'date':
                            value = commonJS.formatDate(obj[fieldName]);
                            td = $(`<td class="text-center">` + value + `</td>`);
                            break;
                        case 'address':
                            value = commonJS.formatAddress(obj[fieldName]);
                            td = $(`<td title="` + obj[fieldName] + `">` + value + `</td>`);
                            break;
                        default:
                            value = obj[fieldName];
                            td = $(`<td>` + value + `</td>`);
                    }
                    $(tr).append(td);
                })
                // binding dữ liệu lên UI
                $('#tbListData tbody').append(tr);
            })
        } catch (e) {

        }
    }

    /**
     * Load lại dữ liệu
     * Author: Bùi Trung Tú
     * */
    btnReloadOnClick() {
        this.loadData();
    }
    /**
     * Validate dữ liệu input
     * Autor:Bui Trung Tu (24/9/2020)
     *
     * */
    checkRequired() {
        var value = this.value;
        if (!value) {
            $(this).addClass('required-error');
            $(this).attr("placeholder", "Bạn phải nhập thông tin này.");
            return true;
        } else {
            $(this).removeClass('required-error');
            return false;
        }
    }
    /**
     * Toggle khi người dùng click vào show User-detail
     * Autor:Bui Trung Tu (24/9/2020)
     *
     * */
    ShowUserSelection() {
        $('.User-selection').toggleClass('Show-selectiton');
    }

    btnAddOnClick() {
        this.showDialogDetail();
    }


    btnCloseOnClick() {
        this.hideDialogDetail();
    }
    showDialogDetail() {
        $('#txtCustomerCode,#txtCustomerName,#txtMobile').removeClass("required-error");
        $('#txtCustomerCode,#txtCustomerName,#txtMobile').removeAttr("placeholder");
        $('.dialog input,textarea').val(null);
        $('.dialog select').val(1);
        $('.dialog-modal').show();
        $('.dialog').show();
        $('#txtCustomerCode').focus();
    }
    hideDialogDetail() {
        $('.dialog-modal').hide();
        $('.dialog').hide();
    }
    rowOnClick() {
        $(this).addClass("row-selected");
        $(this).siblings().removeClass("row-selected");
    }

    /**
    * Edit dữ liệu
    * Autor:Bui Trung Tu (24/9/2020)
    * */
    btnEditOnClick() {
        var self = this;
        // xác định đối tượng cần edit
        var objSelected = $('.row-selected');
        if (objSelected.length > 0) {
            // lấy customerCode
            this.objCode = objSelected.children()[0].textContent;
            this.getObjData();
            this.showDialogDetail();
            var fields = $(".dialog-body input,.dialog-body select,.dialog-body textarea");
            $.each(fields, function (index, field) {
                var fieldName = $(field).attr('fieldName');             
                $(field).val(self.Obj[fieldName]);
            })
            self.FormType = "Edit";
        } else {
            alert("Bạn phải chọn 1 khách hàng để thực hiện chức năng này");
        }
    }
    /**
    * Cất dữ liệu
    * Autor:Bui Trung Tu (24/9/2020)
    * */
    btnSaveOnClick() {
        // validate dữ liệu
        var inputRequireds = $('.required');
        var isValid = true;
        $.each(inputRequireds, function (i, item) {
            var valid = $('input').trigger("blur");
            if (isValid && valid.hasClass("required-error")) {
                isValid = false;
            }
        })
        if (isValid == false) {
            return;
        }
        // check xem là thêm mới hay sửa thông tin
        var self = this;
        var Method = "POST";
        if (self.FormType == "Edit") {
            Method = "PUT";
        }
        var obj = {};
        var fields = $(".dialog-body input,.dialog-body select,.dialog-body textarea");
        $.each(fields, function (index, field) {
            var fieldName = $(field).attr('fieldName');
            fieldName = fieldName.charAt(0).toUpperCase() + fieldName.slice(1);
            if (fieldName == "DebitMoney") {
                obj[fieldName] = Number($(field).val());
            } else {
                obj[fieldName] = $(field).val();
            }
            console.log(obj[fieldName]);
            
        })
        this.saveToDB(obj, Method);
    }
    /**
     * Lưu dữ liệu vào CSDL
     * */
    saveToDB(obj,Method) {

    }
    btnDeleteOnClick() {
        var objSelected = $('.row-selected');
        if (objSelected.length > 0) {
            var objCode = objSelected.children()[0].textContent;
            this.deleteToDB(objCode);
        } else {
            alert("Bạn phải chọn đối tượng muốn xóa!");
        }
    }
    deleteToDB(objCode) {
    }
    targetToStart() {
        $("#txtCustomerCode").focus();
    }

    /**
     * Ẩn thanh menu bên trái
     * Author: Bui Trung Tu (25/9/2020)
     * */
    resizeContent() {
        $(".menu").slideToggle("slow");
        $(".content").toggleClass("resize-content");
    }
}

