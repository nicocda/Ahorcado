function testearConexion() {
    console.log("Conexion establecida");
}

function ingresarPalbraAAdivinar() {
    var palabra = document.getElementById("palIngre").value;
    var adiv = document.getElementById("palAAdiv").value;
    var sco = document.getElementById("scoreTot").value;
    var vid = document.getElementById("vidas").value;
    console.log(palabra);
    console.log("Entro aca");
    $.ajax({
        url: "/Ahorcado/ArriesgarPalabra",
        data: {
            pal: palabra,
            palAdiv: adiv,
            score: sco,
            vidas: vid
        },
        dataType: 'html',
        success: function (result) {
            var cosas = result;
            //document.getElementById("score").innerHTML = cosas.logica.Juego.Score;
            //document.getElementById("palModAct").innerHTML = cosas.logica.Juego.PalabraModeloActual;
        }
    })
}

