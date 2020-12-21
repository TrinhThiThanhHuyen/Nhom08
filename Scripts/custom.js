    var soluong = document.getElementsByName('SoLuong');
    var DonGia = document.getElementsByName('DonGia'); 
    var tongtien = document.getElementsByName('ThanhTien');
    var tien = 0;
    tongtien.values(tien);
DonGia.keyup(function () {
    console.log('1');
    tien = soluong.values() * DonGia.values();
    tongtien.values(tien);
});
