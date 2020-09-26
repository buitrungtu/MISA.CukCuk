/**
 * Đối tượng JS chứa các hàm sử dụng chung
 * Author: Bui Trung Tu (25/9/2020)
 * */
var commonJS = {
    // ẩn hiện menu
    btnIconBarOnClick() {
        $(".menu").stop().slideToggle(400);
        $(".content").toggleClass("resize-content");
    },

    /**
     * Định dạng ngày tháng
     * Author: Bui Trung Tu
     * @param {string} date
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
      * @param {any} money
      */
     formatMoney(money) {
        return money.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
    },
     /**
      * Định dạng địa chỉ
      * Author: Bui Trung Tu
      * @param {any} str
      */
    formatAddress(str) {
        var temp = str.split(",");
        return "... " + temp[temp.length - 1];
    }
}
