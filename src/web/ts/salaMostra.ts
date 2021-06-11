
window.onload = function () {
};

// caricamento on load
$(function () {
    $.ajax({
        url: "http://localhost:42877/api/Edificio/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        importaSale(response);
        // console.log(listaEdifici);
    }).fail(function (xhr, status, errorThrown) {
        console.log("Errore: non è stato possibile recuperare la lista delle sale!");
        console.log("Status: " + xhr.status);
        console.log("Error: " + xhr.statusText);
        console.dir(xhr);
    })

})


function importaSale(edifici) {
    let listaEdifici = [];
    for (let obj of edifici) {
        if (obj.disponibile == true) {
            listaEdifici.push({
                id: obj.id,
                nome: obj.nome,
                indirizzo: obj.indirizzo,
            })
        }
    }
    $.ajax({
        url: "http://localhost:42877/api/Sala/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        let table = $('tbody');
        let count = 1;
        let oddOrEven = "";
        // console.log(response);
        for (let obj of response) {
            count++;
            if (count % 2 == 0) {
                oddOrEven = `<tr class="even">`
            } else {
                oddOrEven = `<tr class="odd">`
            }
            let edificio: string = listaEdifici.filter(e => e.id == obj.edificioId)[0].nome;
            table.append(
                `${oddOrEven}
                <td>${obj.id}</td>   
                <td>${obj.nome}</td>
                <td>${edificio}</td>
                <td class="dettaglio-sala">
                    <div>
                        <button id="pulsante-modale-sala" data-bs-toggle="modal" data-bs-target="#salaModal"
                            data-bs-id="${obj.id}" data-bs-nome="${obj.id}" 
                            data-bs-nome="${obj.nome}" 
                            data-bs-edificio="${edificio}" 
                            type="button" class="btn col ml-5 mr-5 p-1 pulsante-modale-sala delete-button">
                            <i id="dettaglio-sala-icona" class="fas fa-info-circle dettaglio-sala-icona"></i>
                        </button>
                    </div>
                </td>
            </tr>`
            );
        }
        $(".pulsante-modale-sala").on("click", function (e) {
            const dataId = e.target.getAttribute("data-bs-id");
            $("#sala-modal-id").html(dataId);
            const dataNome : any = e.target.getAttribute("data-bs-nome");
            $("#sala-modal-nome").html(dataNome);
            const dataEdificio = e.target.getAttribute("data-bs-edificio");
            $("#sala-modal-edificio").html(dataEdificio);
        })
    }).fail(function (xhr, status, errorThrown) {
        console.log("Errore: non è stato possibile recuperare la lista degli edifici!");
        console.log("Status: " + xhr.status);
        console.log("Error: " + xhr.statusText);
        console.dir(xhr);
    })


}

