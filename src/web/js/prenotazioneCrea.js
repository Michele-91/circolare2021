// caricamento on load
$(function () {
    prenotazioni_crea_impostaDataMinima();
    prenotazioni_crea_importaRisorse();
});
function prenotazioni_crea_impostaDataMinima() {
    $('input[name=prenotazione-inizio]').prop('min', function () {
        let dataInizioMinima = turnIntoISOString(new Date());
        return dataInizioMinima;
    });
    // .prop('value', function () {
    //     let dataInizioAttuale = turnIntoISOString(new Date());
    //     return dataInizioAttuale;
    // });
    // $('input[name=prenotazione-fine]').prop('value', function () {
    //     let dataInizioAttuale = turnIntoISOString(new Date(500000 + 4 * 3600 * 1000));
    //     return dataInizioAttuale;
    // });
}
function turnIntoISOString(value) {
    const selectedDay = fromSingletoDoubleDigit(value.getDate());
    const selectedMonth = fromSingletoDoubleDigit(value.getMonth() + 1);
    const selectedYear = fromSingletoDoubleDigit(value.getFullYear());
    const selectedHours = value.getHours();
    const selectedMinutes = value.getMinutes();
    const selectedSeconds = value.getSeconds();
    return `${selectedYear}-${selectedMonth}-${selectedDay}T${selectedHours}:${selectedMinutes}:${selectedSeconds}`;
}
function fromSingletoDoubleDigit(dateNumber) {
    return dateNumber >= 0 && dateNumber <= 9 ? "0" + String(dateNumber) : String(dateNumber);
}
function prenotazioni_crea_importaRisorse() {
    $.ajax({
        url: "http://localhost:42877/api/Risorsa/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        let listaRisorse = [];
        for (let r of response) {
            if (r.abilitato) {
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
        }
        // console.log(listaRisorse);
        prenotazioni_crea_importaSale(listaRisorse);
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile recuperare la lista delle risorse!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
}
function prenotazioni_crea_importaSale(risorse) {
    $.ajax({
        url: "http://localhost:42877/api/Sala/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        let listaSale = [];
        for (let sala of response) {
            listaSale.push({
                id: sala.id,
                nome: sala.nome,
                edificioId: sala.edificioId
            });
        }
        prenotazioni_crea_validaRisultati(risorse, listaSale);
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile recuperare la lista degli edifici!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
}
function prenotazioni_crea_validaRisultati(risorse, sale) {
    for (let risorsa of risorse) {
        $("#opzioni-risorsaprenotazione").append(`<option value=${risorsa.userName}>`);
    }
    for (let sala of sale) {
        $("#opzioni-salaprenotazione").append(`<option value=${sala.nome}>`);
    }
    let nomePrenotazioneSelezionato;
    let risorsaSelezionata;
    let salaSelezionata;
    let dataInizioSelezionata;
    let dataFineSelezionata;
    $("#nome_prenotazione").on('change', function () {
        nomePrenotazioneSelezionato = $(this).val().toString();
    });
    $("input[name=opzioni-risorsaprenotazione]").on('change', function () {
        risorsaSelezionata = $(this).val();
    });
    $("input[name=prenotazione-inizio]").on('change', function () {
        dataInizioSelezionata = $(this).val();
    });
    $("input[name=prenotazione-fine]").on('change', function () {
        dataFineSelezionata = $(this).val();
    });
    $("input[name=opzioni-salaprenotazione]").on('change', function () {
        salaSelezionata = $(this).val();
    });
    $('#submit_prenotazione').on('click', (e) => {
        e.preventDefault();
        if (risorsaSelezionata && nomePrenotazioneSelezionato && salaSelezionata && dataInizioSelezionata && dataFineSelezionata) {
            prenotazioni_crea_submit(risorse, sale, nomePrenotazioneSelezionato, risorsaSelezionata, salaSelezionata, dataInizioSelezionata, dataFineSelezionata);
        }
        else {
            alert("Devi riempire tutti i campi per poter effettuare l'operazione");
        }
    });
}
function prenotazioni_crea_submit(risorse, sale, descrizioneParam, risorsaParam, salaParam, dataInizioParam, dataFineParam) {
    let descrizione = descrizioneParam;
    let risorsaId;
    let salaId;
    let dataInizio = dataInizioParam;
    let dataFine = dataFineParam;
    risorsaId = risorse.filter(e => e.userName == risorsaParam)[0].id;
    salaId = sale.filter(s => s.nome == salaParam)[0].id;
    let obj = {
        descrizione: descrizione,
        risorsaId: risorsaId,
        salaId: salaId,
        inizio: dataInizio,
        fine: dataFine,
    };
    $.ajax({
        url: "http://localhost:42877/api/Prenotazione/Add",
        contentType: "application/json",
        type: "POST",
        dataType: "json",
        data: JSON.stringify(obj)
    }).done(function (response) {
        window.location.href = './prenotazione_mostra.html';
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile creare la prenotazione!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
}
//# sourceMappingURL=prenotazioneCrea.js.map