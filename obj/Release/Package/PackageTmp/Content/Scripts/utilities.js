function imagen(evento, elemento, imagen) {
    var length = evento.target.files.length;
    if (length !== 0) {
        // FileList object
        var files = evento.target.files;
        // Obtenemos la imagen del campo "file"
        for (var i = 0, f; f = files[i]; i++) {
            //Solo admitimos imágenes.
            if (!f.type.match("image.*")) {
                continue;
            }
            var reader = new FileReader();
            reader.onload = (function (theFile) {
                // Insertamos el nombre de la imágen
                $(elemento).siblings().html(theFile.name);
                return function (e) {
                    // Insertamos la imagen
                    $(elemento).parent().siblings().attr("src", e.target.result);
                };
            })(f);
            // Leemos el archivo de imagen como una URL de datos
            reader.readAsDataURL(f);
        }
    } else {
        $(elemento).parent().siblings().attr("src", imagen);
        $(elemento).siblings().html("...");
    }
}
function archivo(evento, elemento) {
    var length = evento.target.files.length;
    if (length !== 0) {
        // FileList object
        var files = evento.target.files;
        // Obtenemos el archivo del campo "file"
        for (var i = 0, f; f = files[i]; i++) {
            var reader = new FileReader();
            reader.onload = (function (theFile) {
                // Insertamos el nombre del archivo
                $(elemento).siblings().html(theFile.name);
            })(f);
            // Leemos el archivo como una URL de datos
            reader.readAsDataURL(f);
        }
    } else {
        $(elemento).siblings().html("...");
    }
}
var buscar = function (cadena, tabla) {
    cadena = cadena.trim();
    let filas = document.getElementById(tabla).tBodies[0].rows;
    let columnas = document.getElementById(tabla).rows[0].cells.length;
    let mensaje = "No hay registros para mostrar";
    let ultima = 0, mostrar = 0;
    ultima = filas[filas.length - 1].innerText.toLowerCase();
    if (filas.length > 1) {
        for (let i = 0; i < filas.length; i++) {
            if (filas[i].innerText.toLowerCase().indexOf(cadena) !== -1) {
            filas[i].className = "mostrar";
        } else {
            filas[i].className = "ocultar";
        }
        }
        mostrar = document.getElementsByClassName("mostrar");
        ultima = filas[filas.length - 1].innerText.toLowerCase();
        if (ultima !== mensaje.toLowerCase() && cadena.length > 0 && mostrar.length <= 0) {
            let elemento = document.getElementById(tabla);
            let fila = elemento.insertRow(-1);
            let celda = fila.insertCell(0);
            celda.colSpan = columnas;
            celda.style.textAlign = "center";
            let texto = document.createTextNode(mensaje);
            celda.appendChild(texto);
        }
        if (cadena.length == 0 && ultima == mensaje.toLowerCase() || mostrar.length > 0 && ultima == mensaje.toLowerCase()) {
            document.getElementById(tabla).deleteRow(-1);
        }
        ultima = filas[filas.length - 1].innerText.toLowerCase();
        if (ultima == mensaje.toLowerCase()) {
            filas[filas.length - 1].className = "mostrar";
        }
        let rows = document.getElementsByTagName("tr");
        for (let i = 0; i < rows.length; i++) {
            if (rows[i].className == "ocultar") {
                rows[i].style.display = "none";
            } else if (rows[i].className == "mostrar") {
                rows[i].style.display = "";
            }
        }
    }
};
$(document).ready(function () {
    $("body").on("contextmenu", function (event) {
        event.preventDefault();
    });
    $('body').bind("cut copy paste", function (event) {
        event.preventDefault();
    });
    $("input, textarea").on("keyup", function (event) {
        var cadena = event.target.value;
        event.target.value = cadena.replace(/\s+/g, " ");
    }).on("focusout", function (event) {
        var cadena = event.target.value;
        event.target.value = cadena.trim();
    });
    $("[name=fechanacimiento]").on("change", function () {
        var fecha = $(this).val().split("-");
        fecha = fecha[2] + "/" + fecha[1] + "/" + fecha[0];
        var hoy = new Date();
        hoy = hoy.toLocaleDateString("es-MX");
        if (fecha > hoy) {
            alert("La fecha de nacimiento no debe ser mayor a la fecha de hoy");
            $(this).val("");
        }
    });
    setInterval(tiempo, 1000);

    $(document).on("click", "[data-href]", function () {
        const href = $(this).data("href");
        $.ajax({
            url: href,
            type: "get",
            dataType: "html",
            beforeSend: function (xhr) {
                $('.modal').jqwLoader('open');
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error Interno del Servidor");
            },
            success: function (data, textStatus, jqXHR) {
                $('.modal').jqwLoader('close');
                $(".modal").jqwDialog(data);
            }
        });
    });
    $(document).on("click", "[data-estado]", function () {
        const href = $(this).data("estado");
        $.ajax({
            url: href,
            type: "get",
            dataType: "json",
            beforeSend: function (xhr) {
                $(".modal").jqwLoader("open");
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Error Interno del Servidor");
            },
            success: function (data, textStatus, jqXHR) {
                if (data.accion !== "Done") {
                    alert(data.respuesta);
                } else {
                    window.location.reload();
                }
            },
            complete: function (data, textStatus, jqXHR) {
                setTimeout(function () {
                    $(".modal").jqwLoader("close");
                }, 200);
            }
        });
    });
});
function tiempo() {
    var fecha = new Date();
    if (document.querySelectorAll(".hora").length > 0) {
        let formato = fecha.toLocaleDateString("es-MX").split("/");
        let dia = formato[0] <= 9 ? '0' + formato[0] : formato[0];
        let mes = formato[1] <= 9 ? '0' + formato[1] : formato[1];
        let anio = formato[2];
        var elementos = document.querySelectorAll(".fecha");
        elementos.forEach(function (elemento) {
            elemento.value = dia + "/" + mes + "/" + anio;
        });
    }

    var hora = fecha.getHours().toLocaleString("es-MX");
    var meridiano = hora > 12 ? "p.m." : "a.m.";
    var minuto = fecha.getMinutes().toLocaleString("es-MX");
    var segundo = fecha.getSeconds().toLocaleString("es-MX");
    hora = hora > 12 ? ((hora - 12) < 10) ? "0" + (hora - 12) : (hora - 12) : hora;
    minuto = minuto < 10 ? "0" + minuto : minuto;
    segundo = segundo < 10 ? "0" + segundo : segundo;
    if (document.querySelectorAll(".hora").length > 0) {
        var elementos = document.querySelectorAll(".hora");
        elementos.forEach(function (elemento) {
            elemento.value = hora + ":" + minuto + ":" + segundo + " " + meridiano;
        });
    }
}
window.onresize = function () {
    $("select").select2();
}
/*$(document).ready(function () {
    $('.tabla').on('dblclick', 'tr td', function (evt) {
        var target, idAlumno, valorSeleccionado;
        target = $(event.target);
        idAlumno = target.parent().data('id');
        valorSeleccionado = target.text();
        alert("Valor Seleccionado: " + valorSeleccionado + "\n idAlumno: " + idAlumno);
    });
});*/

$.fn.jqwLoader = function (accion) {
    switch (accion) {
        case "open":
            var loading = '<div class="body">' +
                '<div class="loader-img"></div>' +
                '<span class="loader-text">Espere un momento por favor...</span>' +
                '</div>';
            this.append(loading);
            this.fadeIn("fast").css({ display: "flex" });
            break;
        case "close":
            this.fadeOut("fast").children().remove();
            break;
    }
};
$.fn.jqwNotificacion = function (alerta, mensaje) {
    this.children().remove();
    var contenido = "";
    switch (alerta) {
        case "exitoso":
            contenido = '<div class="exitoso" style="display: flex;"><p>' + mensaje + '</p><span>&times;</span></div>';
            break;
        case "error":
            contenido = '<div class="error" style="display: flex;"><p>' + mensaje + '</p><span>&times;</span></div>';
            break;
        case "info":
            contenido = '<div class="info" style="display: flex;"><p>' + mensaje + '</p><span>&times;</span></div>';
            break;
    }
    this.append(contenido);
    this.children().fadeIn("fast");
};
$.fn.jqwDialog = function (html) {
    this.children().remove();
    var contenido = '<div class="body" style="width: 45%;">' + html + '</div>';
    this.append(contenido);
    this.fadeIn("fast").css({ display: "flex" });
    $(".cerrar").on("click", function () {
        setTimeout(function () {
            window.location.reload();
        }, 200);
        $(".modal").fadeOut("fast").children().remove();
    });
};