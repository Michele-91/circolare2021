console.log("pagina di creazione risorse");
// class Risorsa
// {
//     id: string
//     nome: number;
//     cognome: string;
//     emailPersonale: string;
//     abilitato: boolean;
//     constructor(risorsa?: any) {
//         if (risorsa != null) {
//             this.id = risorsa.id;
//             this.nome = risorsa.nome;
//             this.cognome = risorsa.cognome;
//             this.emailPersonale = risorsa.emailPersonale;
//             this.abilitato = risorsa.abilitato;
//         }
//     }
// }
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
    console.log(JSON.stringify(obj));
    // abilitato = $('#form-check-input').val().toString();
    console.log("nome: " + nome);
    console.log("cognome: " + cognome);
    console.log("emailPersonale: " + emailPersonale);
    console.log(abilitato);
    $.ajax({
        url: "http://localhost:42877/api/Risorsa/Add",
        contentType: "application/json",
        type: "POST",
        dataType: "json",
        data: JSON.stringify(obj)
    }).done(function (response) {
        window.location.href = './risorsa_mostra.html';
        // let form = $('form');
        // form.after(`
        //     <div id="responseContent">
        //         <p class="userIdResp">UserId: ${response.userId}</p>
        //         <p class="idResp">id: ${response.id}</p>
        //         <p class="titleResp">title: ${response.title}</p>
        //         <p class="bodyResp">body: ${response.body}</p>
        //     </div>
        // `);
    }).fail(function (xhr, status, errorThrown) {
        console.log("Errore: non è stato possibile creare la risorsa!");
        console.log("Status: " + xhr.status);
        console.log("Error: " + xhr.statusText);
        console.dir(xhr);
    });
});
//# sourceMappingURL=risorsaCrea.js.map