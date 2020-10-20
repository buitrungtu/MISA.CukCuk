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
        var page = $('#txtPageNumber').val();
        var record = $("#txbNumberRecord").val();
        //call api 
        $.ajax({
            url: "/api/employeeApi/paging?page=" + page + "&record=" + record,
            method: "GET",
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (data) {
            self.Data = data; // truyền lại dữ liệu sang cho base.js để hiển thị
        }).fail(function () { 
            //Hiện dialog báo lỗi
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

        //call api
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
                // hiện thông báo
                $(".dialog-modal").show();
                $("#errorMessage").html("Không tìm thấy nhân viên, vui lòng thử lại!");
                $(".dialog-error").show();
            }
        }).fail(function () {
            // hiện dialog báo lỗi
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
        //call api
        $.ajax({
            url: "/api/EmployeeApi",
            method: Method,
            data: JSON.stringify(employee),
            contentType: "application/json",
            dataType: "json",
            async: false
        }).done(function (res) {
            if (res > 0) {
                // Lưu thành công, hiện lại dữ liệu
                self.btnCloseOnClick();
                self.getData();
                self.loadData();
            }
        }).fail(function (res) {
            //hiện dialog thông báo lỗi
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
    deleteToDB(employeeID) {
        var self = this;
        //call api
        $.ajax({
            url: "/api/employeeApi/" + employeeID,
            method: "DELETE"
        }).done(function (res) {
            if (res == true) {
                // xóa thành công
                self.getData();
                self.loadData();
                self.btnCloseOnClick();
            }
        }).fail(function (res) {
            if (res.responseJSON.Msg) {
                // thông báo kết quả nếu không thể xóa
                $(".dialog-modal").show();
                $("#errorMessage").html(res.responseJSON.Msg[1]);
                $(".dialog-error").show();
            } else {
                //thông báo lỗi
                $(".dialog-modal").show();
                $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
                $(".dialog-error").show();
            }      
        })
    }
}

