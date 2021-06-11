
// caricamento on load
$(function () {
    $.ajax({
        url: "http://localhost:42877/api/Sala/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        importaEdifici(response);
    }).fail(function (xhr) {
        console.log("Errore: non è stato possibile recuperare la lista degli edifici!");
        console.log("Status: " + xhr.status);
        console.log("Error: " + xhr.statusText);
        console.dir(xhr);
    })

})

function importaEdifici(sale) {
    let listaSale = [];
    for (let sala of sale) {
        listaSale.push({
            id: sala.id,
            nome: sala.nome,
            edificioId: sala.edificioId,
        })
    }
    $.ajax({
        url: "http://localhost:42877/api/Edificio/",
        type: "GET",
        dataType: "json",
    }).done(function (response) {
        let table = $('tbody');
        let count = 1;
        let oddOrEven = "";
        for (let obj of response) {
            count++;
            if (count % 2 == 0) {
                oddOrEven = `<tr class="even">`
            } else {
                oddOrEven = `<tr class="odd">`
            }
            console.log(response);
            let saleEdificio = "";
            saleEdificio += listaSale.filter(s => s.edificioId == obj.id).map(o => o.nome);
            console.log(saleEdificio);
            table.append(
                `${oddOrEven}
                <td>${obj.id}</td>   
                <td>${obj.nome}</td>
                <td>${obj.indirizzo}</td>
                <td>${saleEdificio}</td>
                <td>${obj.disponibile ? "Si" : "No"}</td>
                <td class="dettaglio-edificio">
                    <div>
                        <button id="pulsante-modale-edificio" data-bs-toggle="modal" data-bs-target="#edificioModal"
                            data-bs-id="${obj.id}" data-bs-nome="${obj.nome}" 
                            data-bs-indirizzo="${obj.indirizzo}" 
                            data-bs-sale="${saleEdificio}" 
                            data-bs-disponibile="${obj.disponibile ? "Si": "No"}"
                            type="button" class="btn col ml-5 mr-5 p-1 pulsante-modale-edificio delete-button">
                            <i id="dettaglio-edificio-icona" class="fas fa-info-circle dettaglio-edificio-icona"></i>
                        </button>
                    </div>
                </td>
            </tr>`
            );
        }
        $(".pulsante-modale-edificio").on("click", function (e) {
            let dataId = e.target.getAttribute("data-bs-id");
            $("#edificio-modal-id").html(dataId);
            let dataNome : any = e.target.getAttribute("data-bs-nome");
            $("#edificio-modal-nome").html(dataNome);
            let dataIndirizzo = e.target.getAttribute("data-bs-indirizzo");
            $("#edificio-modal-indirizzo").html(dataIndirizzo);
            let dataSale = e.target.getAttribute("data-bs-sale");
            $("#edificio-modal-sale").html(dataSale);
            let dataDisponibile = e.target.getAttribute("data-bs-disponibile");
            $("#edificio-modal-disponibile").html(dataDisponibile);
        })
    }).fail(function (xhr) {
        console.log("Errore: non è stato possibile recuperare la lista degli edifici!");
        console.log("Status: " + xhr.status);
        console.log("Error: " + xhr.statusText);
        console.dir(xhr);
    })
}