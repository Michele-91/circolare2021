$(function () {
    prenotazioni_mostra_filtraRisultati();
    prenotazioni_mostra_importaRisorse(false);
});
function prenotazioni_mostra_importaPrenotazioniPerFiltro() {
    let nuovoImportPrenotazioni = [];
    function risultatoImport(response) {
        nuovoImportPrenotazioni = response;
    }
    $.ajax({
        'async': false,
        url: "http://localhost:42877/api/Prenotazione/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        risultatoImport(response);
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile recuperare la lista delle prenotazioni!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
    console.log("nuovoImportPrenotazioni: " + nuovoImportPrenotazioni);
    return nuovoImportPrenotazioni;
}
function prenotazioni_mostra_importaRisorse(filtrato) {
    let prenotazioniFiltrate = false;
    if (filtrato) {
        prenotazioniFiltrate = true;
    }
    $.ajax({
        url: "http://localhost:42877/api/Risorsa/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        let listaRisorse = [];
        for (let r of response) {
            listaRisorse.push({
                id: r.id,
                nome: r.nome,
                cognome: r.cognome,
                userName: r.userName,
                emailPersonale: r.emailPersonale,
                emailReti: r.emailReti,
                abilitato: r.abilitato
            });
        }
        prenotazioni_mostra_importaEdifici(listaRisorse, prenotazioniFiltrate);
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile recuperare la lista delle risorse!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
}
function prenotazioni_mostra_importaEdifici(risorse, filtrato) {
    $.ajax({
        url: "http://localhost:42877/api/Edificio/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        let listaEdifici = [];
        for (let edificio of response) {
            listaEdifici.push({
                id: edificio.id,
                nome: edificio.nome,
                risorsa: edificio.indirizzo,
                inizio: edificio.disponibile
            });
        }
        prenotazioni_mostra_importaSale(risorse, listaEdifici, filtrato);
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile recuperare la lista degli edifici!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
}
function prenotazioni_mostra_importaSale(risorse, edifici, filtrato) {
    $.ajax({
        url: "http://localhost:42877/api/Sala/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        let listaSale = [];
        for (let sala of response) {
            let edificioPrenotato = edifici.filter(e => e.id == sala.edificioId)[0].nome;
            listaSale.push({
                id: sala.id,
                nome: sala.nome,
                edificioId: sala.edificioId,
                edificio: edificioPrenotato
            });
        }
        prenotazioni_mostra_importaPrenotazioniPerDettaglio(risorse, edifici, listaSale, filtrato);
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile recuperare la lista degli edifici!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
}
function prenotazioni_mostra_importaPrenotazioniPerDettaglio(risorse, edifici, sale, filtrato) {
    $.ajax({
        url: "http://localhost:42877/api/Prenotazione/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        prenotazioni_popolaTabella(response, risorse, edifici, sale, filtrato);
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile recuperare la lista delle prenotazioni!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
}
let prenotazioniGlobali = [];
function prenotazioni_popolaTabella(prenotazioni, risorse, edifici, sale, filtrato) {
    if (filtrato) {
        let input = $("#testo-filtro-prenotazioni").val().toString();
        console.log("input: " + input);
        $.ajax({
            'async': false,
            url: `http://localhost:42877/api/Prenotazione/Filter/${input}`,
            type: "GET",
            dataType: "json",
        }).done(function (response) {
            console.log("response: " + response);
            prenotazioni_OperazioniDinamicheTabella(response, risorse, edifici, sale, filtrato);
        }).fail(function (xhr) {
            alert("Errore: non è stato possibile recuperare la lista filtrata delle prenotazioni!");
            console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
        });
    }
    else {
        prenotazioni_OperazioniDinamicheTabella(prenotazioni, risorse, edifici, sale, filtrato);
    }
    prenotazioni_pulsantiDettaglio();
}
function prenotazioni_OperazioniDinamicheTabella(prenotazioni, risorse, edifici, sale, filtrato) {
    let table = $('tbody');
    console.log("prenotazioni: " + prenotazioni);
    $('tbody').children().remove();
    let count = 1;
    let oddOrEven = "";
    for (let p of prenotazioni) {
        count++;
        if (count % 2 == 0) {
            oddOrEven = `<tr class="even">`;
        }
        else {
            oddOrEven = `<tr class="odd">`;
        }
        let risorsaPrenotata = risorse.filter(r => r.id == p.risorsaId).map(r => r.userName);
        let salaPrenotata = sale.filter(s => s.id == p.salaId).map(r => r.nome);
        let edificioPrenotato = sale.filter(s => s.id == p.salaId).map(r => r.edificio);
        table.append(`${oddOrEven}
                <td>${p.id}</td>   
                <td>${p.descrizione}</td>
                <td>${risorsaPrenotata}</td>
                <td>${salaPrenotata}</td>
                <td>${edificioPrenotato}</td>
                <td>${p.inizio}</td>
                <td>${p.fine}</td>
                <td class="dettaglio-prenotazione">
                    <div class="dettagli-info-pr">
                        <button id="pulsante-modale-prenotazione" data-bs-toggle="modal" data-bs-target="#prenotazioneModal"
                            data-bs-id="${p.id}" data-bs-descrizione="${p.descrizione}" 
                            data-bs-risorsa-prenotata="${risorsaPrenotata}" 
                            data-bs-edificio-prenotato="${edificioPrenotato}" 
                            data-bs-inizio="${p.inizio}" 
                            data-bs-fine="${p.fine}" 
                            data-bs-sala-prenotata="${salaPrenotata}"
                            type="button" class="btn col ml-5 mr-5 p-1 pulsante-modale-prenotazione delete-button">
                            <i id="dettaglio-prenotazione-icona" class="fas fa-info-circle dettaglio-prenotazione-icona"></i>
                        </button>
                        <button type="button" class="btn col ml-5 mr-5 p-1 pulsante-elimina-prenotazione delete-button">
                            <i id="elimina-prenotazione-icona" class="fas fa-trash-alt"></i>
                        </button>
                    </div>
                </td>
            </tr>`);
    }
}
function prenotazioni_pulsantiDettaglio() {
    $(".pulsante-modale-prenotazione").on("click", function (e) {
        let dataId = e.target.getAttribute("data-bs-id");
        $("#prenotazione-modal-id").html(dataId);
        let dataDescrizione = e.target.getAttribute("data-bs-descrizione");
        $("#prenotazione-modal-descrizione").html(dataDescrizione);
        let dataEdificio = e.target.getAttribute("data-bs-edificio-prenotato");
        $("#prenotazione-modal-edificio").html(dataEdificio);
        let dataRisorsa = e.target.getAttribute("data-bs-risorsa-prenotata");
        $("#prenotazione-modal-risorsa").html(dataRisorsa);
        let dataSala = e.target.getAttribute("data-bs-sala-prenotata");
        $("#prenotazione-modal-sala").html(dataSala);
        let datainizio = e.target.getAttribute("data-bs-inizio");
        $("#prenotazione-modal-inizio").html(datainizio);
        let dataFine = e.target.getAttribute("data-bs-fine");
        $("#prenotazione-modal-fine").html(dataFine);
    });
    $(".pulsante-elimina-prenotazione").on("click", function (e) {
        // console.log(e.target.parentElement.parentElement.firstElementChild.getAttribute("data-bs-id"));
        let idPrenotazione = e.target.parentElement.parentElement.firstElementChild.getAttribute("data-bs-id");
        prenotazioni_eliminaPrenotazione(idPrenotazione);
    });
}
function prenotazioni_mostra_filtraRisultati() {
    $(".pulsante-filtro-prenotazioni").on("click", function (e) {
        let input = $("#testo-filtro-prenotazioni").val().toString();
        if (input.length > 0) {
            prenotazioni_mostra_importaRisorse(true);
        }
        else {
            prenotazioni_mostra_importaRisorse(false);
        }
    });
}
function prenotazioni_eliminaPrenotazione(id) {
    console.log(id);
    $.ajax({
        url: `http://localhost:42877/api/Prenotazione/Delete/${id}`,
        contentType: "application/json",
        type: "DELETE",
        dataType: "text",
        data: "{}"
    }).done(function (response) {
        console.log(response);
        location.reload();
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile aggiornate lo stato della risorsa!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
}
//# sourceMappingURL=prenotazioneMostra.js.map