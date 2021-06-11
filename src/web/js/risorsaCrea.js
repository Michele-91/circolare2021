$('#submit').on('click', (e) => {
    let nome;
    let cognome;
    let emailPersonale;
    let abilitato;
    e.preventDefault();
    nome = $('#nome_risorsa').val().toString();
    cognome = $('#cognome_risorsa').val().toString();
    emailPersonale = $('#email_personale_risorsa').val().toString();
    abilitato = $('#abilitato_prenotazione').prop("checked");
    let obj = {
        nome: nome,
        cognome: cognome,
        emailPersonale: emailPersonale,
        abilitato: abilitato
    };
    $.ajax({
        url: "http://localhost:42877/api/Risorsa/Add",
        contentType: "application/json",
        type: "POST",
        dataType: "json",
        data: JSON.stringify(obj)
    }).done(function (response) {
        window.location.href = './risorsa_mostra.html';
    }).fail(function (xhr) {
        alert("Errore: non è stato possibile creare la risorsa!");
        console.log(`Error - ${xhr.statusText} (${xhr.status}): ${xhr.responseText}`);
    });
});
//# sourceMappingURL=risorsaCrea.js.map