﻿function testearConexion() {
    console.log("Conexion establecida");
}

function ingresarPalbraAAdivinar() {
    var pal = document.getElementById("palAAdiv").value;
    console.log(pal);
    console.log("Entro aca");
    $.ajax({
        url: "/Ahorcado/InsertePalabraAAdivinar",
        data: {
            palabra: pal
        },
        success: function(result) {
            document.getElementById("paladivin").innerHTML ="La palabra en juego es:" + result;
        }
    })

}

