$(document).ready(function () {
    var commom = new Common();
})

class Common {
    constructor() {
        this.initEvents();
    }
    initEvents() {
        $("#iconbar").click(this.btnIconBarOnClick);
    }
    // ẩn hiện menu
    btnIconBarOnClick() {
        $(".menu").stop().slideToggle(400);
        $(".content").toggleClass("resize-content");
    }
    // hàm định dạng ngày tháng
    formatDate(date) {
        var day = date.getDate();
        var month = date.getMonth() + 1;
        var year = date.getFullYear();
        return day + "/" + month + "/" + year;
    }
   

}