var request = GXmlHttp.create();
        request.open("GET", "../markers.xml", true);
        request.onreadystatechange = function() {
            if (request.readyState == 4) {
                var xmlDoc = GXml.parse(request.responseText);
                // obtain the array of markers and loop through it
                var markers = xmlDoc.documentElement.getElementsByTagName("marker");

                for (var i = 0; i < markers.length; i++) {
                    // obtain the attribues of each marker
                    var lat = parseFloat(markers[i].getAttribute("lat"));
                    var lng = parseFloat(markers[i].getAttribute("lng"));
                    var point = new GLatLng(lat,lng);
                    var html = markers[i].getAttribute("html");
                    var label = markers[i].getAttribute("label");
                    var icon = markers[i].getAttribute("icon");
                    var iconshadow = markers[i].getAttribute("iconshadow");
                    // create the marker
                    var marker = createMarker(point,label,html, icon, iconshadow);
                    //var marker = createMarker(point,label,html);
                    map.addOverlay(marker);

                    map.setCenter(new GLatLng(lat,lng),13);
                }
                


                // ========= Now process the polylines ===========
                var lines = xmlDoc.documentElement.getElementsByTagName("line");
                // read each line
                for (var a = 0; a < lines.length; a++) {
                    // get any line attributes
                    var colour = lines[a].getAttribute("colour");
                    var width  = parseFloat(lines[a].getAttribute("width"));
                    // read each point on that line
                    var points = lines[a].getElementsByTagName("point");
                    var pts = [];
                    for (var i = 0; i < points.length; i++) {
                        pts[i] = new GLatLng(parseFloat(points[i].getAttribute("lat")),
                        parseFloat(points[i].getAttribute("lng")));
                    }
                    map.addOverlay(new GPolyline(pts,colour,width));
                }
                // ================================================
            }
        }
        request.send(null);/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */


