
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
            var page = $('#txtPageNumber').val();
            var record = $("#txbNumberRecord").val();
            //call api 
            $.ajax({
                url: "/api/employeeApi?page=" + page + "&record=" + record,
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (res) {
                self.Data = res.Data;
                // cập nhật lại tổng số trang
                $("#totalPage").text("trên " + res.TotalPage);
                $("#pageLast").data('totalPage', res.TotalPage);
                // Hiển thị tổng số bản ghi
                $("#totalRecord").text(res.TotalRecord);
                //Cập nhật lại miền giá trị
                if (page == res.TotalPage) {
                    $("#maxRecord").text(res.TotalRecord);
                } else {
                    $("#maxRecord").text(page * record);
                }
                $("#minRecord").text((page * record) - record + 1);
            }).fail(function (res) {
                debugger;
                //Hiện dialog báo lỗi
                $(".dialog-modal.error").show();
                $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
                $(".dialog-error").show();
            })  
        } catch{
            $(".dialog-modal.error").show();
            $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
            $(".dialog-error").show();
        }
        
    }

    /**
     * Overide lại hàm getObjData của base.js
     * Author: Bui Trung Tu (28/9/2020)
     * @param {string} objCode mã của đối tượng
     */
    getObjData(objID) {
        try {
            var self = this;
            //call api
            $.ajax({
                url: "/api/employeeApi/" + objID,
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (employee) {
                if (employee.EmployeeID) {
                    self.Obj = employee; // truyền lại dữ liệu của đối tượng sang cho base.js xử lý tiếp
                    if (employee.Avatar) {
                        $('#avatar').attr('src', "/content/Images/" + employee.Avatar);
                    }
                } else {
                    // hiện thông báo
                    $(".dialog-modal.error").show();
                    $("#errorMessage").html("Không tìm thấy nhân viên, vui lòng thử lại!");
                    $(".dialog-error").show();
                }
            }).fail(function () {
                // hiện dialog báo lỗi
                $(".dialog-modal.error").show();
                $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
                $(".dialog-error").show();
            })
        } catch{
            $(".dialog-modal.error").show();
            $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
            $(".dialog-error").show();
        }
        
    }
    /**
     * Lưu dữ liệu xuôngs DB
     * Author: Bui Trung Tu (28/9/2020)
     * @param {object} employee đối tượng cần lưu xuống db
     * @param {string} Method phương thức lưu: POST hay là PUT
     */
    saveToDB(employee, Method) {
        try {
            var self = this;
            employee.EmployeeID = self.objID;
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
                    self.loadData();
                    self.objID = null;
                }
            }).fail(function (res) {
                //hiện dialog thông báo lỗi
                $(".dialog-modal.error").show();
                var error = "";
                $.each(res.responseJSON.Msg, function (i, msg) {
                    error += ", " + msg;
                })
                error = error.substring(1);
                $("#errorMessage").html(error);
                $(".dialog-error").show();
            })
        } catch{
            $(".dialog-modal.error").show();
            $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
            $(".dialog-error").show();
        }
        
    }

    /**
     * Overide lại hàm deleteToDB của base.js
     * Author: Bui Trung Tu (28/9/2020)
     * @param {any} employeeCodes danh sách mã của nhân viên cần xóa
     */
    deleteToDB(employeeID) {
        try {
            var self = this;
            //call api
            $.ajax({
                url: "/api/employeeApi/" + employeeID,
                method: "DELETE"
            }).done(function (res) {
                if (res == true) {
                    // xóa thành công
                    self.loadData();
                    self.btnCloseOnClick();
                }
            }).fail(function (res) {
                if (res.responseJSON.Msg) {
                    // thông báo kết quả nếu không thể xóa
                    $(".dialog-modal.error").show();
                    $("#errorMessage").html(res.responseJSON.Msg[1]);
                    $(".dialog-error").show();
                } else {
                    //thông báo lỗi
                    $(".dialog-modal.error").show();
                    $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
                    $(".dialog-error").show();
                }
            })
        } catch{
            $(".dialog-modal.error").show();
            $("#errorMessage").html("Có lỗi khi truyền dữ liệu tới server, vui lòng thử lại!");
            $(".dialog-error").show();
        }
    }
}

