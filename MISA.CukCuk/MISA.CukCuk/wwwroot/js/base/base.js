﻿/**
 * Class quản lý các function chung cua các trang
 * Author: Bui Trung Tu (25/9/2020)
 * */
class BaseJS {
    // khởi tạo
    constructor() {
        try {
            this.FormType = null;
            this.objID = null;
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
        //lưu vết lựa chọn người dùng
        $("table").on("click", "tbody tr", this.rowOnClick);
        //thoát form dialog
        $('#btnCancel').click(this.btnCloseOnClick.bind(this));
        $('.title-button-close').click(this.btnCloseOnClick.bind(this));
        $('.dialog-modal').click(this.btnCloseOnClick.bind(this));
        $('#btnNo').click(this.btnCloseOnClick.bind(this));
        //show lựa chọn với tài khoản
        $('.user').click(this.showUserSelection.bind(this));
        //thêm 1 bản ghi
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        //Sửa 1 bản ghi
        $('#btnEdit').click(this.btnEditOnClick.bind(this));
        // Lưu thêm or sửa
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        // Xóa bản ghi
        $('.dialog-confirm #btnYes').click(this.DeleteObjs.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        // nhân bản 1 bản ghi
        $('#btnDuplicate').click(this.btnDuplicate.bind(this));
        // load lại dữ liệu
        $("#btnLoad").click(this.btnReloadOnClick.bind(this));
        // hành trình bấm tab trên form dialog
        $('#btnHelpDialog').blur(this.targetToStart);
        $('#btnNo').blur(function () {
            $('#btnYes').focus();
        })
        // định dạng tiền tệ trực tiếp trên form dialog 
        $("#txtSalary, #txtDebitMoney").keyup(this.formatMoney);


        // phân trang
        $("#pageNext").click(this.PagingNext.bind(this));
        $("#pagePrev").click(this.PagingPrev.bind(this));
        $("#pageFirst").click(this.PagingFirst.bind(this));
        $("#pageLast").click(this.PagingLast.bind(this));
    }
    // #endregion

    // #region Phân trang
    /**
     * Tiến lên 1 trang
     * Author: Bùi Trung Tú (8/10/2020)
     * */
    PagingNext() {
        
        var currentPage = $('#txtPageNumber').val();
        var currentPage = Number(currentPage) + 1;
        var record = $('#txbNumberRecord').val();
        debugger;
        this.Paging(record,currentPage); // thực hiện tại lớp kế thừa 
        $("#txtPageNumber").val(currentPage + ''); //cập nhật lại số trang
    }
    /**
     * Lùi lại 1 trang
     * Author: Bùi Trung Tú (8/10/2020)
     * */
    PagingPrev() {
        var currentPage = $('#txtPageNumber').val();
        if (currentPage > 0) {
            var currentPage = $('#txtPageNumber').val();
            var currentPage = Number(currentPage) - 1;
            var record = $('#txbNumberRecord').val();
            this.Paging(record,currentPage); // thực hiện tại lớp kế thừa 
            $("#txtPageNumber").val(currentPage + ''); //cập nhật lại số trang
        }
    }
    /**
     * Về trang đầu tiên
     * Author: Bùi Trung Tú (8/10/2020)
     * */
    PagingFirst() {
        var record = $('#txbNumberRecord').val();
        this.Paging(record,0); // thực hiện tại lớp kế thừa 
        $('#txtPageNumber').val("0");
    }
    /**
     * Tới trang cuối cùng
     * Author: Bùi Trung Tú (8/10/2020)
     * */
    PagingLast() {
        var record = $('#txbNumberRecord').val();
        this.Paging(record,16); // thực hiện tại lớp kế thừa 
        $('#txtPageNumber').val("16");
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
    getObjData(objID) {
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
     * (Hàm dựng) Gửi thông điệp xóa đối tượng xuống DB 
     * Author: Bui Trung Tu (28/9/2020)
     * @param {object} objCode
     */
    deleteToDB(objCode) {
        // Các lớp kế thừa sẽ override lại hàm này
    }
    Paging(record,currentPage) {

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
                    var value = obj[fieldName], td;
                    if (value == null) value = "";
                    // UI conventions                    
                    switch (format) {
                        case 'money':
                            td = $(`<td class="text-right">` + commonJS.formatMoney(value) + `</td>`);
                            break;
                        case 'date':
                            td = $(`<td class="text-center">` + commonJS.formatDate(value) + `</td>`);
                            break;
                        case 'address':                           
                            td = $(`<td title="` + obj[fieldName] + `">` + value + `</td>`);
                            break;
                        default:
                            td = $(`<td>` + value + `</td>`);
                    }
                    $(tr).data('keyID', obj.customerID);
                    $(tr).append(td);
                })
                //$(tr).data('objID', obj[Object.keys(obj)[0]]); // lấy ra trường đầu tiên của đối tượng obj
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
        try {
            if ($("#btnEdit").hasClass("hiden") == false) {
                var self = this;
                // xác định đối tượng cần edit
                var objSelected = $('.row-selected');
                if (objSelected.length == 1) {
                    // lấy customerID
                    var objID = objSelected.data('keyID');
                    this.getObjData(objID); // lấy dữ liệu của đối tượng được chọn (Thực hiện tại các lớp kế thừa)
                    console.log(this.Obj)
                    this.showDialogDetail();
                    var fields = $(".dialog-body input,.dialog-body select,.dialog-body textarea");
                    //binding dữ liệu lên form:
                    $.each(fields, function (index, field) {
                        var fieldName = $(field).attr('fieldName');
                        if (fieldName == "birthday") {
                            $(field).val(commonJS.formatDateForInput(self.Obj[fieldName]));
                        } else if (fieldName == "debitAmount" || fieldName == "salary") {
                            $(field).val(commonJS.formatMoney(self.Obj[fieldName]));
                        }
                        else {
                            if (self.Obj[fieldName] == null) {
                                self.Obj[fieldName] = "";
                            }
                            $(field).val(self.Obj[fieldName]);
                        }
                    })
                    // chuyển trạng thái cho nút Save thành edit 
                    self.objID = objID;
                    self.FormType = "Edit";
                } else {
                    alert("Chỉ có thể sửa từng bản ghi một");
                }
            }
        } catch (e) {
            alert("Có lỗi, hãy thử lại");
        }
    }



    /**
     * Xóa 1 đối tượng
     * Author: Bui Trung Tu (25/9/2020)
     * */
    btnDeleteOnClick() {
        try {
            // nếu nút không bị ẩn (đã có ít nhất 1 dòng được chọn)
            if ($("#btnDelete").hasClass('hiden') == false) {
                //  Hiện form yêu cầu xác nhận lần 2
                $('.dialog-modal').show();
                $('.dialog-confirm').show();
                $('.dialog-confirm #btnYes').focus();
            }
        } catch (e) {
            alert("Có lỗi xảy ra, hãy thử lại");
        }
    }
    /**
     * Thực hiện việc xóa đối tượng
     * */
    DeleteObjs() {
        // xóa 1
        try {
            debugger;
            var objSelecteds = $('.row-selected');
            if (objSelecteds.length == 1) {
                debugger;
                this.deleteToDB(objSelecteds.data('keyID'));
            }
        } catch (e) {
            alert("Có lỗi xảy ra, hãy thử lại");
            console.log(e);
        }




        //TODO: Gặp vấn đề trong vòng lặp, phần tử con không gọi được thuộc tính data("keyID")
        // xóa nhiều
        //try {
        //    var objSelecteds = $('.row-selected');
        //    var deleteObjs = "";
        //    $.each(objSelecteds, function (i, objSelected) {
        //        var objID = objSelected.data("keyID");
        //        deleteObjs += "," + objID; // gom tất cả mã cần xóa thành 1 chuỗi
        //    })
        //    console.log(deleteObjs);
        //    deleteObjs = deleteObjs.substring(1); // xóa ký tự đầu chuỗi (là dấu ',' thừa)
        //    this.deleteToDB(deleteObjs);// xóa đối tượng (Thực hiện tại các lớp kế thừa)
        //} catch (e) {
        //    alert("Có lỗi xảy ra, hãy thử lại");
        //}
    }


    /**
    * Lưu dữ liệu
    * Author: Bui Trung Tu (24/9/2020)
    * */
    btnSaveOnClick() {
        try {
            // validate dữ liệu
            var inputRequireds = $('input[required]');
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
            var obj = {};
            var fields = $(".dialog-body input,.dialog-body select,.dialog-body textarea");
            $.each(fields, function (index, field) {
                var fieldName = $(field).attr('fieldName');
                fieldName = fieldName.charAt(0).toUpperCase() + fieldName.slice(1); // viết hoa chữ cái đầu tiên
                var format = $(field).attr('format');
                if (format == "number") {
                    obj[fieldName] = Number($(field).val().split(',').join(''));
                } else {
                    obj[fieldName] = $(field).val();
                }
            })
            console.log(obj);
            // Lưu dữ liệu
            this.saveToDB(obj, Method); // Lưu dữ liệu xuống DB (Thực hiện tại các lớp kế thừa)
        } catch (e) {
            alert("Lưu dữ liệu thất bại");
        }

    }
    /**
     * Nhân đôi đối tượng
     * Author: Bui Trung Tu(29/9/2020)
     * */
    btnDuplicate() {
        try {
            if ($('#btnDuplicate').hasClass('hiden') == false) {
                // xác định đối tượng cần edit
                var objSelected = $('.row-selected');
                if (objSelected.length > 0) {
                    var objCode = objSelected.children()[0].textContent;
                    this.getObjData(objCode);
                    this.saveToDB(this.Obj, "POST");
                }
            }
        } catch (e) {
            alert("Có lỗi, hãy thử lại");
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
        $('.dialog-confirm').hide();
        this.deleteObjs = "";
    }

    /**
     * Đánh dấu 1 bản ghi được chọn trên table
     * Author: Bui Trung Tu (20/9/2020)
     * */
    rowOnClick() {
        if (event.ctrlKey) { // nếu đang bấm ctrl
            if ($(this).hasClass("row-selected")) {
                $(this).removeClass("row-selected");
            } else {
                $(this).addClass("row-selected");
            }
        } else {
            $(this).addClass("row-selected");
            $(this).siblings().removeClass("row-selected");
        }
        // check để bỏ ẩn các nút cần lựa chọn đối tượng trước khi thực hiện
        if ($('table#tbListData tbody').children().hasClass("row-selected")) {
            $('.grid .toolbar').children().removeClass('hiden');
        } else {
            $('#btnDuplicate').addClass('hiden');
            $('#btnEdit').addClass('hiden');
            $('#btnDelete').addClass('hiden');
            $('#btnMerge').addClass('hiden');
        }
    }

    /**
    * Quay trở lại ô nhập liệu đầu tiên khi người dùng bấm tab tại element cuối cùng
    * Author: Bui Trung Tu (22/9/2020)
    * */
    targetToStart() {
        $("#txtCustomerCode").focus();
    }

    formatMoney() {
        $(this).val(commonJS.formatMoneyForDialog($(this).val()));
    }

    // #endregion
}
