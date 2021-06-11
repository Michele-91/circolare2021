// caricamento on load
$(function () {
    $.ajax({
        url: "http://localhost:42877/api/Edificio/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        associaSalaAdEdificio(response);
    }).fail(function (xhr, status, errorThrown) {
        console.log("Errore: non è stato possibile recuperare la lista delle sale!");
        console.log("Status: " + xhr.status);
        console.log("Error: " + xhr.statusText);
        console.dir(xhr);
    });
});
function associaSalaAdEdificio(response) {
    let listaEdifici = [];
    for (let obj of response) {
        if (obj.disponibile == true) {
            listaEdifici.push({
                id: obj.id,
                nome: obj.nome,
                indirizzo: obj.indirizzo,
            });
        }
    }
    for (let edificio of listaEdifici) {
        $("#opzioni-edificio-per-sala").append(`<option value=${edificio.nome}>`);
    }
    console.log($("#opzioni-edificio-per-sala")[0]);
    $("input[name=opzioni-edificio-per-sala]").on('change', function () {
        let result = $(this).val();
        if (result) {
            submitSala(result, listaEdifici);
        }
        else {
            alert("Devi selezionare un edificio");
        }
    });
}
function submitSala(edificioSelezionato, edificiEsitenti) {
    $('#submit_sala').on('click', (e) => {
        e.preventDefault();
        let nome;
        let edificioId;
        edificioId = edificiEsitenti.filter(e => e.nome == edificioSelezionato)[0].id;
        console.log("edificioId: " + edificioId);
        e.preventDefault();
        nome = $('#nome_sala').val().toString();
        if (!nome) {
            alert("Devi selezionare un nome");
            return;
        }
        let obj = {
            nome: nome,
            edificioId: edificioId
        };
        $.ajax({
            url: "http://localhost:42877/api/Sala/Add",
            contentType: "application/json",
            type: "POST",
            dataType: "json",
            data: JSON.stringify(obj)
        }).done(function (response) {
            window.location.href = './sala_mostra.html';
        }).fail(function (xhr, status, errorThrown) {
            console.log("Errore: non è stato possibile creare la sala!");
            console.log("Status: " + xhr.status);
            console.log("Error: " + xhr.statusText);
            console.dir(xhr);
        });
    });
}
//# sourceMappingURL=salaCrea.js.map