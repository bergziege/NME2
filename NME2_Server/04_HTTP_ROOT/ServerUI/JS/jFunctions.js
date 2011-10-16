
$(document).ready(function(){

    $.tablesorter.defaults.widgets = ['zebra'];
        $("#Missions").tablesorter({
        // pass the headers argument and assing a object
        headers: {
//            // assign the secound column (we start counting zero)
//            0: {
//                // disable it by setting the property sorter to false
//                sorter: false
//            },
//            // assign the third column (we start counting zero)
//            1: {
//                // disable it by setting the property sorter to false
//                sorter: false
//            }
        }
    });

    $("#sendmail").click(function(){

        var valid = '';
        var isr = ' wird ben&ouml;tigt.';
        var name = $("#name").val();
        var mail = $("#mail").val();
        var subject = $("#subject").val();
        var text = $("#text").val();
        if (name.length<1) {
            valid += '<br />Name'+isr;
        }
        if (!mail.match(/^([a-z0-9._-]+@[a-z0-9._-]+\.[a-z]{2,4}$)/i)) {
            valid += '<br />Eine g&uuml;ltige Mailadresse'+isr;
        }
        if (subject.length<1) {
            valid += '<br />Betreff'+isr;
        }
        if (text.length<1) {
            valid += '<br />Nachricht'+isr;
        }
        if (valid!='') {
            $("#sendstatus").html("");
            $("#response").fadeIn("slow");
            $("#response").html(valid);
        }
        else {
            $("#response").html("");
            var datastr ='name=' + name + '&mail=' + mail + '&subject=' + subject + '&text=' + encodeURIComponent(text);
            $("#sendstatus").css("display", "block");
            $("#sendstatus").html("Nachricht wird versand .... ");
            $("#sendstatus").fadeIn("slow");
            setTimeout("send('"+datastr+"')",2000);
        }
        return false;
    });

    $("#resetform").click(function(){
        $("#name").val('');
        $("#mail").val('');
        $("#subject").val('');
        $("#text").val('');
        return false;
    });
});

function send(datastr){
    $.ajax({
        type: "POST",

        // TODO: Für Release die Adresse auf lokal legen und PHP Skript mitliefern!
        url: "http://mail.berndnet-2000.de/mail.php?" + datastr,
        
        data: datastr,
        cache: false
    });
    $("#sendstatus").html("Nachricht wurde versendet.");
}