
$('#submit_edificio').on('click', (e) => {
    let nome: string;
    let indirizzo: string;
    let disponibile: string;
    e.preventDefault()
    nome = $('#nome_edificio').val().toString();
    indirizzo = $('#indirizzo_edificio').val().toString();
    disponibile = $('#disponibile').prop("checked");
    console.log("nome: " + nome);
    console.log("indirizzo: " + indirizzo);
    console.log("disponibile: " + disponibile);
    let obj = {
        nome: nome,
        indirizzo: indirizzo,
        disponibile: disponibile
    }
    console.log(JSON.stringify(obj));
    $.ajax({
        url: "http://localhost:42877/api/Edificio/Add",
        contentType: "application/json",
        type: "POST",
        dataType: "json",
        data: JSON.stringify(obj)
    }).done(function (response) {
        window.location.href='./edificio_mostra.html';
    }).fail(function (xhr, ) {
        alert("Errore: non è stato possibile creare l'edificio!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    })
})
