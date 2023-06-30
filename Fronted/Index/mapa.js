let Locations = [];
document.addEventListener('DOMContentLoaded', async function () {
    await obtenerMarcadores();

    CargarUbicacion();
})



var platform = new H.service.Platform({
    'apikey': '{zUg1x8FtiI9z3W3rteywqwWcVynlNUp9l5UZXTRe79c}'
});


var defaultLayers = platform.createDefaultLayers();

var map = new H.Map(
    document.getElementById('mapContainer'),
    defaultLayers.vector.normal.map,
    {
        zoom: 12,
        center: { lat: -31.4586388, lng: -64.1993268 }
    });

var ui = H.ui.UI.createDefault(map, defaultLayers, 'es-ES');

var mapEvents = new H.mapevents.MapEvents(map);
var behavior = new H.mapevents.Behavior(mapEvents);
map.addEventListener('tap', function (evt) {
    console.log(evt.type, evt.currentPointer.type);
});





function CargarUbicacion() {
    for (let i = 0; i < Locations.length; i++) {
        const item = Locations[i];
        var point = new H.map.Marker({ lat: item.latitud, lng: item.longitud });
        point.setData(item.info);
        var bubble = new H.ui.InfoBubble({ lat: item.latitud, lng: item.longitud }, {
            content: `<b>${item.info}</b>`
        });

        ui.addBubble(bubble);

    }
};


async function obtenerMarcadores() {
    const url = "https://localhost:7038/obtenerMarcadores";
    try {
        const response = await fetch(url,
            {
                method: "GET",
                headers: {
                    'Content-Type': 'application/json'
                }
            });
        let data = await response.json();
        if (response.ok) {
            Locations.length = 0;
            Locations = data.litadoMarcadores;
            console.log(Locations);
        }
    }
    catch (e) {
        console.error('Error:', e);
        alert("Verifique si la API esta encendida")

    }
}



