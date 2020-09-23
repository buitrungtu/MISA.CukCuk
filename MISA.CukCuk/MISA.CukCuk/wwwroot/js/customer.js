$(document).ready(function () {
    var customer = new CustomerJS();
})

class CustomerJS {
    constructor() {
        this.FormType = null;
        this.initEvents();
        this.loadData();
    }
    initEvents() {
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

        // dịch con trỏ khi bấm tab
        $('#btnHelpDialog').blur(this.targetToStart);
    }
    loadData() {
        var self = this;
        $.ajax({
            url: "/api/customer",
            method: "GET",
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (res) {
            $('.grid-content tbody').empty();
            $.each(res, function (i, item) {
                var trHTML = $(`<tr>
                                <td>`+ item.customerCode + `</td>
                                <td>`+ item.customerName + `</td>
                                <td class="text-center">`+ item.birdday + `</td>
                                <td>`+ item.email + `</td>
                                <td class="text-center">`+ item.mobile + `</td>
                                <td class="text-center" title="`+ item.address + `">` + self.shortAddress(item.address) + `</td>
                                <td title="`+ item.companyName + `">`+ self.shortCompanyName(item.companyName) + `</td>
                            </tr>`);
                $('.grid-content tbody').append(trHTML);
            })
        }).fail(function () {
            alert("Gặp lỗi khi load dữ liệu!");
        })
        
    }
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
    rowOnClick(sender) {
        //this.classList.add("row-selected");  or
        $(this).addClass("row-selected");
        $(this).siblings().removeClass("row-selected"); //.siblings() tìm tất cả anh em ruột của nó (ngoại trừ chính nó)
    }
    btnEditOnClick() {
        var self = this;
        var customerSelected = $('.row-selected');
        if (customerSelected.length > 0) {
            var customerCode = customerSelected.children()[0].textContent;
            this.showDialogDetail();
            $.ajax({
                url: "/api/customer/" + customerCode,
                method: "GET",
                contentType: "application/json",
                dataType: "json"
            }).done(function (customer) {
                if (customer == null) {
                    alert("Không có dữ liệu của khách hàng này");
                } else {
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
            if (isValid && valid.hasClass("required-error")){
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
        debugger;
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
    shortAddress(str) {
        var temp = str.split(",");
        return "... " + temp[temp.length-1];
    }
    shortCompanyName(str) {
        if (str.length > 20) {
            return str.slice(0, 20) + " ...";
        }
        return str;
    }
}

