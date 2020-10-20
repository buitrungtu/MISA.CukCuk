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
                url: "/api/customerApi",
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
     * @param {object} customer thông tin khách hàng cần lưu
     * @param {string} Method phương thức lưu (POST hay PUT)
     */
    saveToDB(customer, Method) {
        try {
            var self = this; // form base
            customer.customerID = self.objID;
            $.ajax({
                url: "/api/customerApi",
                method: Method,
                data: JSON.stringify(customer),
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (res) {
                console.log(res);
                if (res) { // lưu thành công
                    self.btnCloseOnClick();
                    self.getData();
                    self.loadData();
                    commonJS.hideButton();
                }
            }).fail(function () {
                alert("Lỗi khi lưu xuống DB");
            })
        } catch(e){

        }
        
    }

    /**
     * Overide lại hàm deleteToDB của base.js
     *  Author: Bui Trung Tu (28/9/2020)
     * @param {string} customerCodes danh sách mã của các đối tượng cần xóa
     */
    deleteToDB(customerCodes) {
        try {
            var self = this;
            $.ajax({
                url: "/api/customerApi/" + customerCodes,
                method: "DELETE",
                async: false
            }).done(function (res) {
                if (res == true) {
                    self.getData();
                    self.loadData();
                    self.btnCloseOnClick();
                    commonJS.hideButton();
                } else {
                    alert("Không tìm thấy khách hàng này");
                }
            }).fail(function () {
                alert("Xóa thất bại");
            })
        } catch (e) {

        }
        
    }

    /**
    * Overide lại hàm getObjData của base.js
    * Author: Bui Trung Tu (28/9/2020)
    * @param {string} objCode mã của đối tượng
    */
    getObjData(customerID) {
        try {
            var self = this;
            // lấy dữ liệu từ CSDL của đối tượng customer thông qua mã
            $.ajax({
                url: "/api/customerApi/" + customerID,
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done(function (customer) {
                console.log(customer);
                if (customer) {
                    self.Obj = customer; // truyền lại dữ liệu của đối tượng sang cho base.js xử lý tiếp
                }
            }).fail(function () {
                alert("Lỗi khi lấy dữ liệu");
            })
        } catch (e) {

        }
        
    }
}

