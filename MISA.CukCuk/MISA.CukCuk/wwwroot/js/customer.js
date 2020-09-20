$(document).ready(function () {
    var customer = new CustomerJS();
})

class CustomerJS {
    constructor() {
        this.initEvents();
        this.loadData();
    }
    initEvents() {
        $("table").on("click", "tbody tr", this.rowOnClick);
        $('#btnCancel').click(this.btnCloseOnClick.bind(this));
        $('.title-button-close').click(this.btnCloseOnClick.bind(this));
        $('.dialog-modal').click(this.btnCloseOnClick.bind(this));
        $('.UserSection').click(this.ShowUserSelection.bind(this));
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        $('#btnEdit').click(this.btnEditOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
    }
    loadData() {
        $('.grid-content tbody').empty();
        $.each(data, function (i, item) {
            var trHTML = $(`<tr>
                                <td>`+ item.CustomerCode + `</td>
                                <td>`+ item.CustomerName + `</td>
                                <td>`+ item.Email + `</td>
                                <td>`+ item.Mobile + `</td>
                                <td>`+ item.Address + `</td>
                            </tr>`);
            $('.grid-content tbody').append(trHTML);
        })
    }
    ShowUserSelection() {
        $('.User-selection').toggleClass('Show-selectiton');
    }
    btnAddOnClick() {
        this.showDialogDetail();
    }
    btnCloseOnClick() {
        this.hideDialogDetail();
    }
    showDialogDetail() {
        $('.dialog input,textarea').val(null);
        $('.dialog select').val(1);
        $('.dialog-modal').show();
        $('.dialog').show();
    }
    hideDialogDetail() {
        $('.dialog-modal').hide();
        $('.dialog').hide();
    }
    rowOnClick(sender) {
        //this.classList.add("row-selected");   
        //$('#btnDuplicate,#btnEdit,#btnDelete').removeClass('btn-Disable');
        $(this).addClass("row-selected");
        $(this).siblings().removeClass("row-selected"); //.siblings() tìm tất cả anh em ruột của nó (ngoại trừ chính nó)
    }
    btnEditOnClick() {
        alert("Đã click vào nút Edit");
    }
    btnSaveOnClick() {
        var customer = new CustomerJS();
        customer.CustomerCode = $('#txtCustomerCode').val();
        customer.CustomerName = $('#txtCustomerName').val();
        customer.Email = $('#txtEmail').val();
        customer.Mobile = $('#txtMobile').val();
        customer.Address = $('#txtAddress').val();
        customer.CustomerType = $('#CustomerType').val();
        customer.Birdday = $('#txtBirdday').val();
        customer.CompanyName = $('#txtCompanyName').val();
        customer.TaxCode = $('#txtTaxCode').val();
        customer.CustomerNote = $('#txtNote').val();

        data.push(customer);
        this.btnCloseOnClick();
        this.loadData();
    }
}
var data = [
    {
        CustomerCode: "KH001",
        CustomerName: "Vũ Khắc Việt",
        CustomerType: "3",
        Mobile: "0966246357",
        Birdday: "1/2/1990",
        CompanyName: "HowKteam",
        TaxCode:"09123",
        Email: "vietkhac90@gmail.com",
        Address: "Thủ Đức, Hồ Chí Minh",
        Note: ""
    },
    {
        CustomerCode: "KH002",
        CustomerName: "Nguyễn Văn Mạnh",
        CustomerType: "3",
        Mobile: "0999123789",
        Birdday: "30/2/1990",
        CompanyName: "Công Ty MISA",
        TaxCode: "0999",
        Email: "manhnv@gmail.com",
        Address: "Cầu Giấy, Hà Nội",
        Note: ""
    },
    {
        CustomerCode: "KH003",
        CustomerName: "Nguyễn Thị Thu Hà",
        CustomerType: "1",
        Mobile: "0329968561",
        Birdday: "7/2/1999",
        CompanyName: "Sinh Viên Tình Nguyện MTA",
        TaxCode: "",
        Email: "hakhan1999@gmail.com",
        Address: "Đan Phượng, Hà Nội",
        Note: ""
    },
    {
        CustomerCode: "KH004",
        CustomerName: "Bùi Ngọc Toàn",
        CustomerType: "2",
        Mobile: "0945362125",
        Birdday: "12/2/1999",
        CompanyName: "MTA Univercity",
        TaxCode: "",
        Email: "toanngoc99@gmail.com",
        Address: "Hoài Đức, Hà Nội",
        Note: ""
    },
    {
        CustomerCode: "KH005",
        CustomerName: "Phan Tấn Trung",
        CustomerType: "3",
        Mobile: "0966285369",
        Birdday: "1/2/1990",
        CompanyName: "SBTC Academy",
        TaxCode: "",
        Email: "baroibeo@gmail.com",
        Address: "Quận 3, Hồ Chí Minh",
        Note: ""
    },
    {
        CustomerCode: "KH006",
        CustomerName: "Vũ Khắc Ngọc",
        CustomerType: "2",
        Mobile: "0973665911",
        Birdday: "1/6/1988",
        CompanyName: "HocMai",
        TaxCode: "09129",
        Email: "saobang1987@gmail.com",
        Address: "Minh Khai, Hà Nội",
        Note: ""
    },
    {
        CustomerCode: "KH007",
        CustomerName: "Đặng Việt Hùng",
        CustomerType: "3",
        Mobile: "0966289651",
        Birdday: "30/5/1989",
        CompanyName: "Hoc24h",
        TaxCode: "09199",
        Email: "hungteacher@gmail.com",
        Address: "Thanh Xuân, Hà Nội",
        Note: ""
    },
    {
        CustomerCode: "KH008",
        CustomerName: "Đoàn Mạnh Quang",
        CustomerType: "2",
        Mobile: "0963654248",
        Birdday: "1/1/1998",
        CompanyName: "JAV",
        TaxCode: "",
        Email: "dmquang1998@gmail.com",
        Address: "Bắc Từ Liêm, Hà Nội",
        Note: ""
    },
    {
        CustomerCode: "KH009",
        CustomerName: "Trần Văn Hà",
        CustomerType: "1",
        Mobile: "0113652314",
        Birdday: "9/8/1998",
        CompanyName: "Le Quy Don",
        TaxCode: "",
        Email: "hatran1999@gmail.com",
        Address: "Dark lak, Tây Nguyên",
        Note: ""
    },
    {
        CustomerCode: "KH010",
        CustomerName: "Đàm Thế Phong",
        CustomerType: "3",
        Mobile: "0978693125",
        Birdday: "10/12/1976",
        CompanyName: "Nguyễn Thị Minh Khai High School",
        TaxCode: "00101",
        Email: "windposition@gmail.com",
        Address: "Bắc Từ Liêm, Hà Nội",
        Note: ""
    },
]
