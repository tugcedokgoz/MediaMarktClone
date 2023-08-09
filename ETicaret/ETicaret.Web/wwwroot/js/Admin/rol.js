function RolleriGetir() {
    $.ajax({
        type: "GET",
        url: `${BASE_API_URI}/api/Rol/TumRoller`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.success) {

                var html = `<table class="table table-hover">` +
                    `<tr><th style="width:50px">Id</th><th>Rol Adı</th><th></th></tr>`;

                var arr = response.data;

                for (var i = 0; i < arr.length; i++) {
                    html += `<tr>`;
                    html += `<td>${arr[i].id}</td><td>${arr[i].ad}</td>`;
                    html += `<td><i class="bi bi-trash text-danger" onclick='RolSil(${arr[i].id})'></i><i class="bi bi-pencil-square" onclick='RolDuzenle(${arr[i]})'></i></td>`;
                    html += `</tr>`
                }
                html += `</table>`;

                $("#divRoller").html(html);
            }
            else {
                alert(response.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });
}

function RolKaydet() {
    var rol = {
        Id: 0,
        Ad: $("#inputRolAd").val()
    };

    $.ajax({
        type: "POST",
        url: `${BASE_API_URI}/api/Rol/Kaydet`,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(rol),
        success: function (response) {
            if (response.success) {
                RolleriGetir();
            }
            else {
                alert(response.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
        }
    });

}
function RolDuzenle() {

}

function RolSil(id) {
    if (confirm("Kaydı silmek istediğinizden emin misiniz?")) {
        $.ajax({
            type: "DELETE",
            url: `${BASE_API_URI}/api/Rol/Sil?id=${id}`,
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.success) {
                    RolleriGetir();
                }
                else {
                    alert(response.message);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert(XMLHttpRequest + "-" + textStatus + "-" + errorThrown);
            }
        });
    }
}

$(document).ready(function () {
    RolleriGetir();
});