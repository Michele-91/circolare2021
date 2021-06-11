

// caricamento on load
$(function () {
    $.ajax({
        url: "http://localhost:42877/api/Risorsa/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        let table = $('tbody');
        let count = 1;
        let oddOrEven = "";
        let abilitato = "";
        for (let obj of response) {
            count++;
            if (count % 2 == 0) {
                oddOrEven = `<tr class="even">`
            } else {
                oddOrEven = `<tr class="odd">`
            }
            abilitato = obj.abilitato ?
                "<button class='abilita-disabilita' id='utente-abilitato-button'>Disabilita</button>" :
                "<button class='abilita-disabilita' id='utente-disabilitato-button'>Abilita</button>";
            table.append(
                `${oddOrEven}
                <td>${obj.id}</td>   
                <td>${obj.nome}</td>
                <td>${obj.cognome}</td>
                <td>${obj.userName}</td>
                <td>${obj.emailReti}</td>
                <td>${obj.emailPersonale}</td>
                <td class="abilitato-button">${abilitato}</td>
                <td class="dettaglio-risorsa">
                    <div class="dettagli-info-pr">
                        <button id="pulsante-modale-risorsa" data-bs-toggle="modal" data-bs-target="#risorsaModal"
                            data-bs-id="${obj.id}" data-bs-nome="${obj.nome}" 
                            data-bs-cognome="${obj.cognome}" 
                            data-bs-username="${obj.userName}" 
                            data-bs-email-reti="${obj.emailReti}" 
                            data-bs-email-personale="${obj.emailPersonale}"
                            data-bs-abilitato="${obj.abilitato ? "Si" : "No"}"
                            type="button" class="btn col ml-5 mr-5 p-1 pulsante-modale-risorsa delete-button">
                            <i id="dettaglio-risorsa-icona" class="fas fa-info-circle dettaglio-risorsa-icona"></i>
                        </button>
                    </div>
                </td>
            </tr>`
            );
        }
        $(".pulsante-modale-risorsa").on("click", function (e) {
            let dataId = e.target.getAttribute("data-bs-id");
            $("#risorsa-modal-id").html(dataId);
            let dataNome : any = e.target.getAttribute("data-bs-nome");
            $("#risorsa-modal-nome").html(dataNome);
            let dataCognome = e.target.getAttribute("data-bs-cognome");
            $("#risorsa-modal-cognome").html(dataCognome);
            let dataUserName = e.target.getAttribute("data-bs-username");
            $("#risorsa-modal-username").html(dataUserName);
            let dataEmailReti = e.target.getAttribute("data-bs-email-reti");
            $("#risorsa-modal-email-reti").html(dataEmailReti);
            let dataEmailPersonale = e.target.getAttribute("data-bs-email-personale");
            $("#risorsa-modal-email-personale").html(dataEmailPersonale);
            let abilitato = e.target.getAttribute("data-bs-abilitato");
            $("#risorsa-modal-abilitato").html(abilitato);
        })
        $(".abilita-disabilita").on("click", function (e) {
            let idUtente = e.target.parentElement.parentElement.firstElementChild.textContent;
            aggiornaStatoUtente(idUtente);
        })
    }).fail(function (xhr) {
        console.log("Errore: non è stato possibile recuperare la lista delle risorse!");
        console.log("Status: " + xhr.status);
        console.log("Error: " + xhr.statusText);
        console.dir(xhr);
    })
})

function aggiornaStatoUtente(id: string) {
    $.ajax({
        url: `http://localhost:42877/api/Risorsa/UpdateState/${id}`,
        contentType: "application/json",
        type: "PUT",
        dataType: "text",
        data: "{}"
    }).done(function (response) {
        location.reload();
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile aggiornate lo stato della risorsa!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    })
}

