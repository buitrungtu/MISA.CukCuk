/**
 * Class quản lý các function chung cua các trang
 * Author: Bui Trung Tu (25/9/2020)
 * */
class BaseJS {
    // khởi tạo
    constructor() {
        try {
            this.FormType = null;
            this.getData();
            this.initEvents();
            this.loadData();
        } catch (e) { }
    }
    // #region Gán sự kiện
    /**
    * Gán sự kiện cho các thành phần
    * Author: Bui Trung Tu (25/9/2020)
    * */
    initEvents() {
        // Gán sự kiện cho các element
        $("table").on("click", "tbody tr", this.rowOnClick);
        $('#btnCancel').click(this.btnCloseOnClick.bind(this));
        $('.title-button-close').click(this.btnCloseOnClick.bind(this));
        $('.dialog-modal').click(this.btnCloseOnClick.bind(this));
        $('.user').click(this.showUserSelection.bind(this));
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        $('#btnEdit').click(this.btnEditOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('#txtCustomerCode').blur(this.checkRequired);
        $('.required').blur(this.checkRequired);
        $("#btnLoad").click(this.btnReloadOnClick.bind(this));
        $('#iconbar').click(this.resizeContent);
        $('#btnCancel').blur(this.targetToStart);
        $('#btnDuplicate').click(this.btnDuplicate.bind(this));
        //$("#txtSalary, #txtDebitMoney").keyup(this.formatMoney);
    }
    // #endregion

    // #region Hàm Dựng

    /**
     * (Hàm dựng) Lấy dữ liệu
     * Author: Bui Trung Tu (24/9/2020)
     * */
    getData() {
        this.Data = [];
        // Các lớp kế thừa sẽ override lại hàm này
    }

    /**
     * (Hàm dựng) Lấy dữ liệu của 1 đối tượng
     * Author: Bui Trung Tu (24/9/2020)
     * */
    getObjData(objCode) {
        this.Obj = {};
        // Các lớp kế thừa sẽ override lại hàm này
    }

    /**
     * (Hàm dựng) Lưu dữ liệu xuống DB
     * Author: Bui Trung Tu (28/9/2020)
     * @param {object} obj
     * @param {string} Method
     */
    saveToDB(obj, Method) {
        // Các lớp kế thừa sẽ override lại hàm này
    }

    /**
     * (Hàm dựng) Gửi thông điệp xóa 1 đối tượng xuống DB 
     * Author: Bui Trung Tu (28/9/2020)
     * @param {object} objCode
     */
    deleteToDB(objCode) {
        // Các lớp kế thừa sẽ override lại hàm này
    }

    // #endregion

    // #region Phương thức chính

    /**
     * Load dữ liệu
     * Autor:Bui Trung Tu (24/9/2020)
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
                    // UI conventions
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
            alert("Có lỗi xảy ra, hãy thử lại");
        }
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
            try {
                var objCode = objSelected.children()[0].textContent;
                this.getObjData(objCode); // lấy dữ liệu của đối tượng được chọn (Thực hiện tại các lớp kế thừa)
                this.showDialogDetail();
                var fields = $(".dialog-body input,.dialog-body select,.dialog-body textarea");
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    //Binding dữ liệu lên form dialog
                    if (fieldName == "birthday") {
                        $(field).val(commonJS.formatDateForInput(self.Obj[fieldName]));
                    } else {
                        $(field).val(self.Obj[fieldName]);
                    }

                })
                self.FormType = "Edit";
            } catch (e) {
                alert("Có lỗi xảy ra, hãy thử lại");
            }
        } else {
            alert("Bạn phải chọn 1 bản ghi để thực hiện chức năng này");
        }
    }


    /**
     * Xóa 1 đối tượng
     * Author: Bui Trung Tu (25/9/2020)
     * */
    btnDeleteOnClick() {
        // kiểm tra đối tượng mà người dùng chọn
        var objSelected = $('.row-selected');
        if (objSelected.length > 0) {
            try {
                var objCode = objSelected.children()[0].textContent;
                this.deleteToDB(objCode); // xóa đối tượng (Thực hiện tại các lớp kế thừa)
            } catch (e) {
                alert("Có lỗi xảy ra, hãy thử lại")
            }
        } else {
            alert("Bạn phải chọn đối tượng muốn xóa!");
        }
    }

    /**
    * Lưu dữ liệu
    * Author: Bui Trung Tu (24/9/2020)
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
        var Method = "POST"; // Mặc định là thêm
        if (self.FormType == "Edit") {
            Method = "PUT";
        }
        try {
            var obj = {};
            var fields = $(".dialog-body input,.dialog-body select,.dialog-body textarea");
            $.each(fields, function (index, field) {
                var fieldName = $(field).attr('fieldName');
                fieldName = fieldName.charAt(0).toUpperCase() + fieldName.slice(1); // viết hoa chữ cái đầu tiên
                var format = $(field).attr('format');
                if (format == "number") {
                    obj[fieldName] = Number($(field).val().replace());
                } else {
                    obj[fieldName] = $(field).val();
                }
            })
            console.log(obj);
            // Lưu dữ liệu
            this.saveToDB(obj, Method); // Lưu dữ liệu xuống DB (Thực hiện tại các lớp kế thừa)
        } catch (e) {
            alert("Lưu dữ liệu thất bại, hãy thử lại");
        }
    }
    /**
     * Nhân đôi đối tượng
     * Author: Bui Trung Tu(29/9/2020)
     * */
    btnDuplicate() {
        // xác định đối tượng cần edit
        var objSelected = $('.row-selected');
        if (objSelected.length > 0) {
            try {
                var objCode = objSelected.children()[0].textContent;
                this.getObjData(objCode);
                this.saveToDB(this.Obj, "POST");
            } catch (e) {
                alert("Có lỗi xảy ra, hãy thử lại")
            }
        } else {
            alert("Bạn phải chọn 1 bản ghi để thực hiện chức năng này");
        }
    }
    // #endregion

    // #region Phương thức phụ

    /**
    * Load lại dữ liệu
    * Author: Bùi Trung Tú
    * */
    btnReloadOnClick() {
        this.getData();
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
     * */
    showUserSelection() {
        $('.user-selection').toggleClass('show-selectiton');
    }
    /**
     * Sự kiện thêm
     * Author: Bui Trung Tu (20/9/2020)
     * */
    btnAddOnClick() {
        this.showDialogDetail();
    }
    /**
     * Sự kiện thoát
     * Author: Bui Trung Tu (20/9/2020)
     * */
    btnCloseOnClick() {
        this.hideDialogDetail();
    }
    /**
     * Hiển thị form dialog
     * Author: Bui Trung Tu (20/9/2020)
     * */
    showDialogDetail() {
        $('#txtCustomerCode,#txtCustomerName,#txtMobile').removeClass("required-error");
        $('#txtCustomerCode,#txtCustomerName,#txtMobile').removeAttr("placeholder");
        $('.dialog input,textarea').val(null);
        $('.dialog select').val(1);
        $('.dialog-modal').show();
        $('.dialog').show();
        $('#txtCustomerCode').focus();
    }
    /**
     * Ẩn form dialog
     * Author: Bui Trung Tu (20/9/2020)
     * */
    hideDialogDetail() {
        $('.dialog-modal').hide();
        $('.dialog').hide();
    }

    /**
     * Đánh dấu 1 bản ghi được chọn trên table
     * Author: Bui Trung Tu (20/9/2020)
     * */
    rowOnClick() {
        $(this).addClass("row-selected");
        $(this).siblings().removeClass("row-selected");
    }

    /**
    * Quay trở lại ô nhập liệu đầu tiên khi người dùng bấm tab tại element cuối cùng
    * Author: Bui Trung Tu (22/9/2020)
    * */
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
    formatMoney() {
        $(this).val(commonJS.formatMoneyForDialog($(this).val()));
    }

    // #endregion
}
