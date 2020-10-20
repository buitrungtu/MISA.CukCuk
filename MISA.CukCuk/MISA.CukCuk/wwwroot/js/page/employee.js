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
        var self = this;
        $.ajax({
            url: "/api/employeeApi",
            method: "GET",
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (data) {
            self.Data = data; // truyền lại dữ liệu sang cho base.js để hiển thị
        }).fail(function () { 
            $(".dialog-modal").show();
            $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
            $(".dialog-error").show();
        })  
    }

    /**
     * Overide lại hàm getObjData của base.js
     * Author: Bui Trung Tu (28/9/2020)
     * @param {string} objCode mã của đối tượng
     */
    getObjData(objID) {
        var self = this;
        console.log(objID);
        // lấy dữ liệu từ CSDL của đối tượng customer thông qua mã
        $.ajax({
            url: "/api/employeeApi/" + objID,
            method: "GET",
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (employee) {
            console.log(employee);
            if (employee.EmployeeID) {
                self.Obj = employee; // truyền lại dữ liệu của đối tượng sang cho base.js xử lý tiếp
            } else {
                $(".dialog-modal").show();
                $("#errorMessage").html("Không tìm thấy nhân viên, vui lòng thử lại!");
                $(".dialog-error").show();
            }
        }).fail(function () {
            $(".dialog-modal").show();
            $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
            $(".dialog-error").show();
        })
    }
    /**
     * Lưu dữ liệu xuôngs DB
     * Author: Bui Trung Tu (28/9/2020)
     * @param {object} employee đối tượng cần lưu xuống db
     * @param {string} Method phương thức lưu: POST hay là PUT
     */
    saveToDB(employee, Method) {
        var self = this;
        console.log(employee);      
        $.ajax({
            url: "/api/EmployeeApi",
            method: Method,
            data: JSON.stringify(employee),
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (res) {
            if (res > 0) {
                // Lưu thành công
                self.btnCloseOnClick();
                self.getData();
                self.loadData();
            }
        }).fail(function (res) {
            self.btnCloseOnClick();
            $(".dialog-modal").show();
            $("#errorMessage").html(res.responseJSON.Msg);
            $(".dialog-error").show();
        })
    }

    /**
     * Overide lại hàm deleteToDB của base.js
     * Author: Bui Trung Tu (28/9/2020)
     * @param {any} employeeCodes danh sách mã của nhân viên cần xóa
     */
    deleteToDB(employeeCodes) {
        var self = this;
        $.ajax({
            url: "/api/employeeApi/" + employeeCodes,
            method: "DELETE"
        }).done(function (res) {
            if (res == true) {
                // xóa thành công
                self.getData();
                self.loadData();
                self.btnCloseOnClick();
            } else {
                $(".dialog-modal").show();
                $("#errorMessage").html("Không tìm thấy nhân viên này, vui lòng thử lại!");
                $(".dialog-error").show();
            }
        }).fail(function () {
            $(".dialog-modal").show();
            $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
            $(".dialog-error").show();
        })
    }
}

