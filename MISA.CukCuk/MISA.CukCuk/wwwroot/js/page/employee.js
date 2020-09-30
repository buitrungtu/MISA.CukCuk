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
                self.Data = data; // truyền lại dữ liệu sang cho base.js để hiển thị
            }).fail(function () { 
                alert("Có lỗi khi lấy dữ liệu");
            })
        } catch (e) {

        }
    }

    /**
     * Overide lại hàm getObjData của base.js
     * Author: Bui Trung Tu (28/9/2020)
     * @param {string} objCode
     */
    getObjData(objCode) {
        debugger;
        var self = this;
        // lấy dữ liệu từ CSDL của đối tượng customer thông qua mã
        $.ajax({
            url: "/api/employee/" + objCode,
            method: "GET",
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (employee) {
            if (employee) {
                self.Obj = employee; // truyền lại dữ liệu của đối tượng sang cho base.js xử lý tiếp

            }
        }).fail(function () {
            alert("Lỗi khi lấy dữ liệu");
        })
    }
    /**
     * Lưu dữ liệu xuôngs DB
     * Author: Bui Trung Tu
     * @param {object} employee
     * @param {string} Method
     */
    saveToDB(employee, Method) {
        var self = this;
        debugger;
        $.ajax({
            url: "/api/employee",
            method: Method,
            data: JSON.stringify(employee),
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (res) {
            if (res) {
                // Lưu thành công
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
    deleteToDB(employeeCode) {
        var self = this;
        $.ajax({
            url: "/api/employee/" + employeeCode,
            method: "DELETE"
        }).done(function (res) {
            if (res == true) {
                // xóa thành công
                self.getData();
                self.loadData();
            } else {
                alert("Không tìm thấy khách hàng này");
            }
        }).fail(function () {
            alert("Xóa thất bại");
        })
    }
}

