let map;

function initMap() {

    // Si no hay datos, evitamos errores
    if (!ubicaciones || ubicaciones.length === 0) {
        console.warn("No hay ubicaciones para mostrar.");
        return;
    }

    // Crear el mapa centrado en Buenos Aires
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: -34.6089, lng: -58.4311 },
        zoom: 13,
    });

    // Crear marcadores
    ubicaciones.forEach(ubi => {

        const marker = new google.maps.Marker({
            position: { lat: ubi.latitud, lng: ubi.longitud },
            map,
            title: ubi.titulo,
            icon: {
                path: google.maps.SymbolPath.FORWARD_CLOSED_ARROW,
                scale: 5,
                strokeColor: "#0112EB",
                rotation: 180
            }
        });

        // Evento click en el marcador
        marker.addListener("click", () => {

            document.getElementById("info-titulo").innerText = ubi.titulo;
            document.getElementById("info-detalle").innerText = ubi.descripcion ?? "Sin descripción disponible.";

            const panel = document.getElementById("info-panel");
            panel.style.display = "block";

            // Redirección al detalle
            if (ubi.id) {
                document.getElementById("btn-vermas").onclick = () => {
                    window.location.href = "/Organizaciones/Detalle/" + ubi.id;
                };
            } else {
                document.getElementById("btn-vermas").onclick = () => {
                    alert("Esta organización no tiene ID asignado.");
                };
            }
        });

    });

    // Cerrar panel al hacer click en el mapa
    map.addListener("click", () => {
        document.getElementById("info-panel").style.display = "none";
    });
}