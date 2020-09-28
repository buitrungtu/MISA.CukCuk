$(document).ready(function () {
    var customer = new CustomerJS();
})

/**
 * Class quản lý các function cho trang employee
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
                url: "/api/employee",
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (data) {
                debugger;
                self.Data = data;
            }).fail(function () {
                alert("Có lỗi khi lấy dữ liệu");
            })
        } catch (e) {

        }
    }
    getObjData() {
        try {
            var self = this;
            // lấy dữ liệu từ CSDL của đối tượng customer thông qua mã
            $.ajax({
                url: "/api/employee/" + self.objCode,
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (employee) {
                self.Obj = employee;
            })
        } catch (e) {

        }
    }
    /**
     * Overide lại hàm saveToDB của base.js
     * Author: Bui Trung Tu (28/9/2020)
     * */
    saveToDB(employee, Method) {
        var self = this;
        $.ajax({
            url: "/api/employee",
            method: Method,
            data: JSON.stringify(employee),
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (res) {
            if (res) {
                self.btnCloseOnClick();
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
    deleteToDB(employeeCode) {
        var self = this;
        $.ajax({
            url: "/api/employee/" + employeeCode,
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
    }
}

