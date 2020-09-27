/**
 * Đối tượng JS chứa các hàm sử dụng chung
 * Author: Bui Trung Tu (25/9/2020)
 * */
var commonJS = {
    /**
     * Định dạng ngày tháng
     * Author: Bui Trung Tu
     * @param {string|number|Date} date
     */
     formatDate(date) {
        var date = new Date(date);
        var month = date.getMonth() + 1;
        var day = date.getDate();
        var year = date.getFullYear();
        return year + "/" + month + "/" + day;
    },
     /**
      * Định dạng tiền tệ
      * Author: Bui Trung Tu
      * @param {number} money
      */
     formatMoney(money) {
        return money.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
    },
     /**
      * Định dạng địa chỉ
      * Author: Bui Trung Tu
      * @param {string} str
      */
    formatAddress(str) {
        var temp = str.split(",");
        return "..." + temp[temp.length - 1];
    }
}
