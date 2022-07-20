var option = document.getElementById("calllogId");
$('#bas').click(function (event) {



    if (option == null) {
        event.preventDefault();
        alert("Kayıtlı olmayan müşteriler iş olarak eklenemez . Lütfen müşteri olarak ekleyiniz.");
    }


});