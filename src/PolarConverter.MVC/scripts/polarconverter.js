// Convert divs to queue widgets when the DOM is ready
$(document).ready(function () {
    $("#btnDropbox").click(function () {
        $("#hidViserDropbox").val(true);
        $("#divDropbox").show();
        $("#fileUploader").hide();
        $(".middleButton").css("margin-top", "48px");
        $(".middleButton").show();
    });
    $("#btnUpload").click(function () {
        $("#hidViserDropbox").val(false);
        $("#divDropbox").hide();
        $("#fileUploader").show();
        $(".middleButton").css("margin-top", "0px");
        $(".middleButton").show();
    });

    var uploader = new plupload.Uploader({
        runtimes: 'html5,flash,silverlight,html4',
        //browse_button: 'pickfiles', // you can pass in id...
        container: $('uploader'), // ... or DOM Element itself
        max_file_size: '10mb',
        url: '/Home/Upload/',
        flash_swf_url: '../../scripts/Moxie.swf',
        silverlight_xap_url: '../../scripts/Moxie.xap',
        filters: [
            { title: "Polar files", extensions: "gpx,hrm,xml" }
        ],

        //init: {
        //    PostInit: function () {
        //        $('filelist').innerHTML = '';

        //        $('uploadfiles').onclick = function () {
        //            uploader.start();
        //            return false;
        //        };
        //    },

        //    FilesAdded: function (up, files) {
        //        for (var i in files) {
        //            $('filelist').innerHTML += '<div id="' + files[i].id + '">' + files[i].name + ' (' + plupload.formatSize(files[i].size) + ') <b></b></div>';
        //        }
        //    },

        //    UploadProgress: function (up, file) {
        //        $(file.id).getElementsByTagName('b')[0].innerHTML = '<span>' + file.percent + "%</span>";
        //    },

        //    Error: function (up, err) {
        //        $('console').innerHTML += "\nError #" + err.code + ": " + err.message;
        //    }
        //}
    });

    uploader.init();
    
    //var timezone = jstz.determine();
    //$("#TimeZoneCorrection option:contains('" + timezone.name() + "')").attr('selected', true);
   
    //$("#uploader").pluploadQueue({
    //    // General settings
    //    runtimes: 'silverlight',
    //    url: '/Home/Upload/',
    //    max_file_size: '10mb',
    //    chunk_size: '1mb',
    //    unique_names: true,
    //    multiple_queues: false,

    //    // Specify what files to browse for
    //    filters: [
    //        { title: "Polar files", extensions: "gpx,hrm,xml" }
    //    ],

    //    // Silverlight settings
    //    silverlight_xap_url: '../../scripts/plupload.silverlight.xap'
    //});

    // Client side form validation
    $('form').submit(function (e) {
        var uploader = $('#uploader').pluploadQueue();
        var dropboxAutorisert = Boolean("@Model.DropboxAutorisert");
        var n = $('input:checked').length;
        var viserDropbox = $("#divDropbox").is(":visible");
        if ($('#SendTilStrava').checked)
            n--;
        // Files in queue upload them first
        if (uploader.files.length > 0) {
            // When all files are uploaded submit form
            uploader.bind('StateChanged', function () {
                if (uploader.files.length === (uploader.total.uploaded + uploader.total.failed)) {
                    $('form')[0].submit();
                }
            });

            uploader.start();
        }
        else if (n === 0 || dropboxAutorisert == false || !viserDropbox) {
            $("#dialogIngenFiler").dialog('open');
        }
        else {
            $('form')[0].submit();
        }

        return false;
    });
});

$(function () {
    $("#dialog").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        title: 'Result',
        modal: true,
        open: function (event, ui) {
            $(this).load("/Home/HentDialog/");
        },
        buttons: {
            "Close": function () {
                $(this).dialog("close");
                location.reload();
            }
        }
    });
});

$(function () {
    $("#dialogIngenFiler").dialog({
        autoOpen: false,
        width: 400,
        resizable: false,
        title: 'Error',
        modal: true,
        open: function (event, ui) {
            $(this).load("/Home/HentDialog/No%20files%20choosen!");
        },
        buttons: {
            "Close": function () {
                $(this).dialog("close");
            }
        }
    });
});

function fbs_click() {
    u = location.href; t = document.title; window.open('http://www.facebook.com/sharer.php?u=' + encodeURIComponent(u) + '&t=' + encodeURIComponent(t), 'sharer', 'toolbar=0,status=0,width=626,height=436'); return false;
}