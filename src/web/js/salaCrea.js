// caricamento on load
$(function () {
    $.ajax({
        url: "http://localhost:42877/api/Edificio/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        associaSalaAdEdificio(response);
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile recuperare la lista delle sale!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
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
        $("#opzioni-edificio-per-sala").append(`<option value="${edificio.nome}">`);
    }
    creaSala(listaEdifici);
}
function creaSala(edificiEsistenti) {
    $('#submit_sala').on('click', (e) => {
        e.preventDefault();
        let nome;
        let edificioId;
        nome = $('#nome_sala').val().toString();
        let edificioSelezionato = $("input[name=opzioni-edificio-per-sala]").val();
        console.log("valore edificio: " + edificioSelezionato);
        if (nome && edificioSelezionato) {
            let edificioPresenteNelDatabase = edificiEsistenti.some(ed => ed.nome == edificioSelezionato);
            if (edificioPresenteNelDatabase) {
                edificioId = edificiEsistenti.filter(e => e.nome == edificioSelezionato)[0].id;
                console.log("edificioId: " + edificioId);
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
                }).fail(function (xhr) {
                    alert("Errore: non è stato possibile creare la sala!");
                    console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
                });
            }
            else {
                alert("Non puoi creare una sala in un edificio inesistente");
            }
        }
        else {
            alert("Devi riempire tutti i campi per poter effettuare l'operazione");
        }
    });
}
//# sourceMappingURL=salaCrea.js.map