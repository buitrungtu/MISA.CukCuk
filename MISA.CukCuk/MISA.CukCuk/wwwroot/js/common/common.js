/**
 * Đối tượng JS chứa các hàm sử dụng chung
 * Author: Bui Trung Tu (25/9/2020)
 * */
var commonJS = {
    /**
     * Định dạng ngày tháng
     * Author: Bui Trung Tu (23/9/2020)
     * @param {string|number|Date} date
     */
    formatDate(date) {
        try {
            var date = new Date(date);
            var month = date.getMonth() + 1;
            if (month < 10) {
                month = "0" + month;
            }
            var day = date.getDate();
            if (day < 10) {
                day = "0" + day;
            }
            var year = date.getFullYear();
            return day + "/" + month + "/" + year;
        } catch{}
    },
    /**
     * Định dạng ngày tháng cho input date html
     * Author: Bui Trung Tu (30/9/2020)
     * @param {string|number|Date} date
     */
    formatDateForInput(date) {
        try {
            var date = new Date(date);
            var month = date.getMonth() + 1;
            if (month < 10) {
                month = "0" + month;
            }
            var day = date.getDate();
            if (day < 10) {
                day = "0" + day;
            }
            var year = date.getFullYear();
            return year + "-" + month + "-" + day;
        } catch{
        }
        
    },
     /**
      * Định dạng tiền tệ
      * Author: Bui Trung Tu (23/9/2020)
      * @param {number} money
      */
    formatMoney(money) {
        try {
            if (money == null) return 0;
            return money.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
        } catch{
        }
        
    },

     /**
      * Định dạng tiền tệ ngay khi người dùng nhập số tiền
      * Author: Bui Trung Tu (30/9/2020)
      * @param {string} money
      */
    formatMoneyForDialog(money) {
        try {
            debugger;
            var x = money;
            x = x.replace(/\./g, ""); // xóa hết dấu . cũ đi
            x = x.split("").reverse().join(""); // đảo chuỗi
            x = x.replace(/.../g, function (e) { // cứ 3 ký tự thì thêm 1 dấu chấm
                return e + ".";
            });
            x = x.split("").reverse().join("");// đảo lại chuỗi
            x = x.replace(/^\./, ""); // xóa đi dấu . thừa ở đầu chuỗi nếu có
            return x;
        } catch{
        }
    },
    hideButton() {
        $("#btnDuplicate,#btnEdit,#btnDelete,#btnMerge").addClass("hiden");
    }
   
}
