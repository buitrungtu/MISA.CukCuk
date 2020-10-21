/**
 * Class quản lý các function chung cua các trang
 * Author: Bui Trung Tu (25/9/2020)
 * */

class BaseJS {
    // khởi tạo
    constructor() {
        try {
            this.FormType = null; // check xem là sửa hay thêm mới
            this.objID = null;           
            this.initEvents();
            this.loadData();
            this.SaveAndAdd = false; //check xem là cất xong thêm hay không
        } catch (e) { }
    }
    // #region Gán sự kiện
    /**
    * Gán sự kiện cho các thành phần
    * Author: Bui Trung Tu (25/9/2020)
    * */
    initEvents() {
        try {
            //lưu vết lựa chọn người dùng
            $("table").on("click", "tbody tr", this.rowOnClick);
            //thoát form dialog
            $('#btnCancel').click(this.btnCloseOnClick.bind(this));
            $('.title-button-close').click(this.btnCloseOnClick.bind(this));
            $('#btnNo').click(this.btnCloseOnClick.bind(this));
            $("#btnOK").click(this.btnErrorOnClickOK.bind(this));
            //thêm 1 bản ghi
            $('#btnAdd').click(this.btnAddOnClick.bind(this));
            //Sửa 1 bản ghi
            $('#btnEdit').click(this.btnEditOnClick.bind(this));
            // Lưu thêm or sửa
            $('#btnSave').click(this.btnSaveOnClick.bind(this));
            $('#btnSaveAndAdd').click(this.btnSaveAndAddOnClick.bind(this));
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
            $(".money").keyup(this.formatMoney);
            // sử lý phím tắt
            $(document).keypress(this.KeyOnPress.bind(this));
            // phân trang
            $("#pageNext").click(this.PagingNext.bind(this)); //trang kế tiếp
            $("#pagePrev").click(this.PagingPrev.bind(this)); //trang trước đó
            $("#pageFirst").click(this.PagingFirst.bind(this)); //trang đầu tiên 
            $("#pageLast").click(this.PagingLast.bind(this)); //trang cuối cùng
            $("#txbNumberRecord").change(this.PagingRecordOnChange.bind(this)); // thay đổi số bản ghi 1 trang
            $("#txtPageNumber").change(this.PagingOnChange.bind(this)); // thay đổi số trang
            // hết phân trang

            //Tải ảnh
            $('#btnUpload').click(function () {
                $('#avatarUpload').trigger('click');
                $('#avatarUpload').change(function () {
                    var reader = new FileReader();
                    reader.onload = function (e) {
                        $('.avatar').attr('src', e.target.result);
                    }
                    reader.readAsDataURL(this.files[0]);
                })
            });
            $('#btn-remove').click(function () {
                $('.avatar').attr('src', "/content/Images/avatardefault.png");
            })
        } catch{
            $(".dialog-modal.error").show();
            $("#errorMessage").html("Bảo trì");
            $(".dialog-error").show();
            $("#btnOK").focus();
        }
    }
    // #endregion

    // #region Phân trang
    /**
     * Tiến lên 1 trang
     * Author: Bùi Trung Tú (8/10/2020)
     * */
    PagingNext() {
        try {
            var currentPageNumber = $('#txtPageNumber').val();
            if (currentPageNumber) {
                $("#txtPageNumber").val(Number(currentPageNumber) + 1);
            }
            this.loadData();
        } catch{
        }
    }
    /**
     * Lùi lại 1 trang
     * Author: Bùi Trung Tú (8/10/2020)
     * */
    PagingPrev() {
        try {
            var currentPageNumber = $('#txtPageNumber').val();
            if (currentPageNumber && currentPageNumber > 0) {
                $("#txtPageNumber").val(Number(currentPageNumber) - 1);
            }
            this.loadData();
        } catch{
        }
        
    }
    /**
     * Về trang đầu tiên
     * Author: Bùi Trung Tú (8/10/2020)
     * */
    PagingFirst() {
        try {
            $("#txtPageNumber").val(1);
            this.loadData();
        } catch{
        }       
    }
    /**
     * Tới trang cuối cùng
     * Author: Bùi Trung Tú (8/10/2020)
     * */
    PagingLast() {
        try {
            var pageLast = $("#pageLast").data('totalPage');
            $("#txtPageNumber").val(pageLast);
            this.loadData();
        } catch{
        }
    }
    PagingRecordOnChange() {
        this.loadData();
    }
    PagingOnChange() {
        this.loadData();
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

    // #endregion

    // #region Phương thức chính

    /**
     * Load dữ liệu
     * Autor:Bui Trung Tu (24/9/2020)
     * */
    loadData() {
        try {
            // disable các nút
            $('#btnDuplicate,#btnEdit,#btnDelete,#btnMerge').addClass('hiden');
            //Lấy dữ liệu từ các lớp kế thừa
            this.getData();
            // xóa dữ liệu cũ
            $('#tbListData tbody').empty();
            // đọc thông tin các cột dữ liệu:
            var fields = $('table#tbListData thead th');
            //binding dữ liệu lên table
            $.each(this.Data, function (i, obj) {
                var tr = $(`<tr></tr>`);
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    var format = $(field).attr('format');
                    var value = obj[fieldName], td;
                    if (value == null) value = "";
                    switch (format) {
                        case 'money':
                            value = commonJS.formatMoney(value);
                            td = $(`<td title="` + value + ` VNĐ" class="text-right Salary">` + value + `</td>`);
                            break;
                        case 'date':
                            td = $(`<td class="text-center Birdday">` + commonJS.formatDate(value) + `</td>`);
                            break;
                        default:
                            td = $(`<td title="` + value + `" class="` +fieldName + `">` + value + `</td>`);
                    }
                    $(tr).data('keyID', obj.EmployeeID);
                    $(tr).append(td);
                })
                // binding dữ liệu lên UI
                $('#tbListData tbody').append(tr);
            })
        } catch (e) {
            $(".dialog-modal.error").show();
            $("#errorMessage").html("Có lỗi xảy ra, vui lòng thử lại!");
            $(".dialog-error").show();
            $("#btnOK").focus();
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
                    if (self.Obj != null) {
                        // reset validate
                        $('input[required]').removeClass("required-error");
                        $('input[required]').removeAttr("placeholder");
                        // hiện form sửa thông tin
                        this.showDialogDetail();
                        var fields = $(".dialog-body input,.dialog-body select,.dialog-body textarea");
                        //binding dữ liệu lên form:
                        $.each(fields, function (index, field) {
                            var fieldName = $(field).attr('fieldName');
                            var format = $(field).attr('format');
                            if (format == "date") {
                                $(field).val(commonJS.formatDateForInput(self.Obj[fieldName]));
                            } else if (format == "money") {
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
                    }
                } else {
                    $(".dialog-modal.error").show();
                    $("#errorMessage").html("Chỉ có thể sửa 1 nhân viên");
                    $(".dialog-error").show();
                    $("#btnOK").focus();
                }
            }
        } catch (e) {
            $(".dialog-modal.error").show();
            $("#errorMessage").html("Có lỗi xảy ra, vui lòng thử lại!");
            $(".dialog-error").show();
            $("#btnOK").focus();
        }
    }

    btnSaveOnClick() {
        try {
            //validate dữ liệu trước khi thêm hoặc sửa lần nữa
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
            //check email
            var email = $("#email").val();
            const reg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            if (reg.test(String(email).toLowerCase())) {
                $("#email").removeClass('required-error');
                $("#email").removeAttr('placeholder');
                return true;
            } else {
                $("#email").addClass('required-error');
                $("#email").attr('title', 'Email không đúng định dạng');
                return false;
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
                if (fieldName == "Salary") {
                    obj[fieldName] = Number($(field).val().split('.').join(''));
                }else {
                    obj[fieldName] = $(field).val();
                }
            })
            // Lưu dữ liệu
            console.log(obj);
            this.saveToDB(obj, Method); // Lưu dữ liệu xuống DB (Thực hiện tại các lớp kế thừa)
            if (self.SaveAndAdd == true) {//Nếu bấm cất và thêm
                self.btnAddOnClick();
                self.SaveAndAdd = false;
            }
        } catch (e) {
            $(".dialog-modal.error").show();
            $("#errorMessage").html("Có lỗi xảy ra, vui lòng thử lại!");
            $(".dialog-error").show();
            $("#btnOK").focus();
        }

    }


    /**
     * Sự kiện xóa đối tượng
     * Author: Bui Trung Tu (25/9/2020)
     * */
    btnDeleteOnClick() {
        try {
            // nếu nút không bị ẩn (đã có ít nhất 1 dòng được chọn)
            if ($("#btnDelete").hasClass('hiden') == false) {
                //  Hiện form yêu cầu xác nhận lần 2
                $('.dialog-modal.error').show();
                $("#confirmMessage").html("Bạn có chắc chắn muốn xóa các nhân viên đã chọn không?");
                $('.dialog-confirm').show();
                $('.dialog-confirm #btnYes').focus();
            }
        } catch (e) {
            $(".dialog-modal.error").show();
            $("#errorMessage").html("Có lỗi xảy ra, vui lòng thử lại!");
            $(".dialog-error").show();
            $("#btnOK").focus();
        }
    }
    /**
     * Thực hiện việc xóa đối tượng
     * Author: BTTu (18/10/2020)
     * */
    DeleteObjs() {
        // xóa 1
        try {
            this.btnCloseOnClick();
            var objSelecteds = $('.row-selected');
            if (objSelecteds.length == 1) {
                this.deleteToDB(objSelecteds.data('keyID'));
            }
        } catch (e) {
            $(".dialog-modal").show();
            $("#errorMessage").html("Có lỗi xảy ra, vui lòng thử lại!");
            $(".dialog-error").show();
            $("#btnOK").focus();
        }

        // xóa nhiều
        //try {
        //    var objSelecteds = $('.row-selected');
        //    var deleteObjs = "";
        //    debugger;
        //    $.each(objSelecteds, function (i, objSelected) {
        //        debugger;
        //        var objID = objSelected.keyID;
        //        deleteObjs += "," + objID; // gom tất cả mã cần xóa thành 1 chuỗi
        //        console.log(objID);
        //    })
        //    deleteObjs = deleteObjs.substring(1); // xóa ký tự đầu chuỗi (là dấu ',' thừa)
        //    console.log(deleteObjs);
        //    //this.deleteToDB(deleteObjs);// xóa đối tượng (Thực hiện tại các lớp kế thừa)
        //} catch (e) {
        //    $(".dialog-modal").show();
        //    $("#errorMessage").html("Có lỗi xảy ra, vui lòng thử lại!");
        //    $(".dialog-error").show();
        //    $("#btnOK").focus();
        //}
    }

    /**
     * Lấy ra mã lớn nhất
     * Author: BTTu (19/10/2020)
     * */
    getMaxCode() {
        $.ajax({
            url: "/api/employeeApi/GetCode/maxCode",
            method: "GET",
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (res) {
            $("#txtCustomerCode").val(res.responseText);
        }).fail(function (res) {
            $("#txtCustomerCode").val(res.responseText);
        })
    }
    /**
     * Sự kiện nút cất và thêm
     * Author: BTTu (19/10/2020)
     * */
    btnSaveAndAddOnClick() {
        this.SaveAndAdd = true;
        this.btnSaveOnClick();
    }
    /**
    * Lưu dữ liệu
    * Author: Bui Trung Tu (24/9/2020)
    * */


    /**
     * Nhân bản đối tượng
     * Author: Bui Trung Tu(29/9/2020)
     * */
    btnDuplicate() {
        try {
            if ($('#btnDuplicate').hasClass('hiden') == false) {
                // xác định đối tượng cần edit
                var objSelected = $('.row-selected');
                if (objSelected.length == 1) {
                    var objID = objSelected.data('keyID');
                    this.getObjData(objID); // lấy dữ liệu của nhân viên cần nhân bản
                    this.getMaxCode(); //Lấy ra mã nhân viên lớn nhất
                    this.objID = null; //Để id = null;
                    this.Obj.EmployeeCode = $("#txtCustomerCode").val(); // gán mã nhân viên mới là mã lớn nhất
                    this.saveToDB(this.Obj, "POST");
                } else {
                    $(".dialog-modal").show();
                    $("#errorMessage").html("1 thời điểm chỉ được nhân bản 1 nhân viên");
                    $(".dialog-error").show();
                }
            }
        } catch (e) {
            $(".dialog-modal").show();
            $("#errorMessage").html("Có lỗi xảy ra, hãy thử lại");
            $(".dialog-error").show();
        }

    }
    // #endregion

    // #region Phương thức phụ


    /**
    * Load lại dữ liệu
    * Author: Bùi Trung Tú
    * */
    btnReloadOnClick() {
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
        try {
            //đề xuất mã nhân viên cho người dùng
            this.showDialogDetail();
            this.getMaxCode();
            //call api lấy danh sách phòng ban
            $.ajax({
                url: "/api/departmentApi/getdata",
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (res) {
                $.each(res, function (i, opt) {
                    var option = $(`<option value="` + opt.DepartmentID + `">` + opt.DepartmentName + `</option>`);
                    $("#department").append(option);
                })
                $("#department").val(res[0].DepartmentID); //set giá trị mặc định 
            }).fail(function () {
                $(".dialog-modal").show();
                $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
                $(".dialog-error").show();
            })
            //call api lấy danh sách vị trí
            $.ajax({
                url: "/api/positionApi/getdata",
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (res) {
                $.each(res, function (i, opt) {
                    var option = $(`<option value="` + opt.PositionID + `">` + opt.PositionName + `</option>`);
                    $("#position").append(option);
                })
                $("#position").val(res[0].PositionID); // set giá trị mặc định
            }).fail(function () {
                $(".dialog-modal").show();
                $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
                $(".dialog-error").show();
            })
            $("#gender").val(1); // set giá trị mặc định
            $("#workStatus").val(0);
        } catch (e) {
            $(".dialog-modal").show();
            $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
            $(".dialog-error").show();
        }       
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
        $('input[required]').removeClass("required-error");
        $('input[required]').removeAttr("placeholder");
        $('.dialog input,textarea').val(null);
        $('.dialog select').val(1);
        $('.dialog-modal.info').show();
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
        $(".dialog-error").hide();
    }

    /**
     * Đánh dấu 1 bản ghi được chọn trên table
     * Author: Bui Trung Tu (20/9/2020)
     * */
    rowOnClick() {
        if (event.ctrlKey) { // nếu đang bấm ctrl thì cho chọn nhiều bản ghi
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
            // disable các nút
            $('#btnDuplicate,#btnEdit,#btnDelete,#btnMerge').addClass('hiden');
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
    btnErrorOnClickOK() {
        $(".dialog-modal.error").hide();
        $(".dialog-error").hide();
    }

    /**
     * Thiết lập phím tắt
     * Author: BTTu (20/10/2020)
     * */
    KeyOnPress() {
        var self = this;

        //phím tắt cho tắt dialog
        if (event.key == "Escape") {
            self.hideDialogDetail();
        }
        // phím tắt cho cất
        if (event == "Control" && event.key == "s") {
            self.btnSaveOnClick();
        }
        // phím tắt cho cất và thêm
        
        if (event == "Control" && event.key == "Shift" && event.key == "s") {
            console.log("1");
            //self.btnSaveAndAddOnClick();
        }
    }
    // #endregion
}
