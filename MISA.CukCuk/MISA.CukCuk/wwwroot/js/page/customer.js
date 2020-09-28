$(document).ready(function () {
    var customer = new CustomerJS();
})

/**
 * Class quản lý các function cho trang Customer
 * Author: Bui Trung Tu (25/9/2020)
 * */
class CustomerJS extends BaseJS {
    constructor() {
        super();
    }
    
    /**
     * Overide lại hàm getData của base.js
     * Author: Bui Trung Tu (25/9/2020)
     * */
    getData() {
        try {
            var self = this;
            $.ajax({
                url: "/api/customer",
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (data) {
                self.Data = data;
            }).fail(function () {
                alert("Có lỗi khi lấy dữ liệu");
            })
        } catch (e) {

        }
    }
    /**
     * Overide lại hàm saveToDB của base.js
     * Author: Bui Trung Tu (28/9/2020)
     * */
    saveToDB(customer, Method) {
        var self = this;
        $.ajax({
            url: "/api/customer",
            method: Method,
            data: JSON.stringify(customer),
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (res) {
            if (res) {
                self.btnCloseOnClick();
                self.getData();
                self.loadData();
            }
        }).fail(function () {
            alert("Có lỗi, hãy thử lại!");
        })
    }
    /**
     * Overide lại hàm deleteToDB của base.js
     * Author: Bui Trung Tu (28/9/2020);
     * */
    deleteToDB(customerCode) {
        var self = this;
        $.ajax({
            url: "/api/customer/" + customerCode,
            method: "DELETE"
        }).done(function (res) {
            if (res == true) {
                self.getData();
                self.loadData();
            } else {
                alert("Không tìm thấy khách hàng này");
            }
        }).fail(function () {
            alert("Xóa thất bại");
        })
    }
    /**
     * Overide lại hàm getObjData của base.js
     * Author: Bui Trung Tu (28/9/2020)
     * */
    getObjData() {
        try {
            var self = this;
            // lấy dữ liệu từ CSDL của đối tượng customer thông qua mã
            $.ajax({
                url: "/api/customer/" + self.objCode,
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (customer) {
                self.Obj = customer;
            })
        } catch (e) {

        }   
    }
}

