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
        } catch (e) {

        }
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

    getData() {
        this.Data = [];
    }


    /**
     * Load dữ liệu
     * Autor:Bui Trung Tu (24/9/2020)
     * 
     * */
    //TODO: Test todo
    loadData() {
        try {
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
                            td = $(`<td title="` + obj[fieldName] +`">` + value + `</td>`);
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
    /**
    * Toggle khi người dùng click vào show User-detail
    * Autor:Bui Trung Tu (24/9/2020)
    *
    * */
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
        var customerSelected = $('.row-selected');
        console.log(customerSelected);
        if (customerSelected.length > 0) {
            // lấy customerCode
            var customerCode = customerSelected.children()[0].textContent;
            debugger;
            console.log(customerCode);
            this.showDialogDetail();
            // lấy dữ liệu từ CSDL của đối tượng customer thông qua mã
            $.ajax({
                url: "/api/customer/" + customerCode,
                method: "GET",
                contentType: "application/json",
                dataType: "json"
            }).done(function (customer) {
                if (customer == null) {
                    alert("Không có dữ liệu của khách hàng này");
                } else {
                    // hiện dữ liệu của customer hiện tại cho người dùng
                    $("#txtCustomerCode").val(customer["customerCode"]);
                    $("#txtCustomerName").val(customer["customerName"]);
                    $("#txtMemberCode").val(customer["memberCode"]);
                    $("#MemberRank").val(customer["memberRank"]);
                    $("#CustomerType").val(customer["customerType"]);
                    $("#txtMobile").val(customer["mobile"]);
                    $("#txtBirdday").val(customer["birdday"]);
                    $("#txtCompanyName").val(customer["companyName"]);
                    $("#txtTaxCode").val(customer["taxCode"]);
                    $("#txtEmail").val(customer["email"]);
                    $("#txtAddress").val(customer["address"]);
                    $("#txtNote").val(customer["customerNote"]);
                    //chuyển FormType thành edit
                    self.FormType = "Edit";
                }
            }).fail(function () {
                alert("Có lỗi khi lấy thông tin khách hàng này");
            })
        } else {
            alert("Bạn phải chọn 1 khách hàng để thực hiện chức năng này");
        }
    }
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
        var self = this;
        var Method = "POST";
        if (self.FormType == "Edit") {
            Method = "PUT";
        }
        var customer = {};
        customer.CustomerCode = $('#txtCustomerCode').val();
        customer.CustomerName = $('#txtCustomerName').val();
        customer.MemberCode = $('#txtMemberCode').val();
        customer.MemberRank = $('#MemberRank').val();
        customer.CustomerType = $('#CustomerType').val();
        customer.Email = $('#txtEmail').val();
        customer.Mobile = $('#txtMobile').val();
        customer.Address = $('#txtAddress').val();
        customer.CustomerType = $('#CustomerType').val();
        customer.Birdday = $('#txtBirdday').val();
        customer.CompanyName = $('#txtCompanyName').val();
        customer.TaxCode = $('#txtTaxCode').val();
        customer.Note = $('#txtNote').val();
        $.ajax({
            url: "/api/customer",
            method: Method,
            data: JSON.stringify(customer),
            contentType: "application/json",
            dataType: "json"
        }).done(function (res) {
            if (res) {
                self.btnCloseOnClick();
                self.loadData();
            }
        }).fail(function () {
            alert("Có lỗi, hãy thử lại!");
        })
    }
    btnDeleteOnClick() {
        var self = this;
        var customerSelected = $('.row-selected');
        if (customerSelected.length > 0) {
            var customerCode = customerSelected.children()[0].textContent;
            $.ajax({
                url: "/api/customer/" + customerCode,
                method: "DELETE"
            }).done(function (res) {
                if (res == true) {
                    self.loadData();
                } else {
                    alert("Không tìm thấy khách hàng này");
                }
            }).fail(function () {
                alert("Xóa thất bại");
            })
        } else {
            alert("Bạn phải chọn đối tượng muốn xóa!");
        }
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

