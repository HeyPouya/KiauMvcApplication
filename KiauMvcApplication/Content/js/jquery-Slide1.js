/*----------------------------  مطلب */
$(document).ready(function () {

    $(".btn-slide_matlab").click(function () {
        $("#panel_matlab").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});

/*---------------------------- صوت و آهنگ */
$(document).ready(function () {

    $(".btn-slide_sound").click(function () {
        $("#panel_sound").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});
/*---------------------------- فیلم و نماهنگ */
$(document).ready(function () {

    $(".btn-slide_video").click(function () {
        $("#panel_video").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});
/*---------------------------- عکس و تصاویر */
$(document).ready(function () {

    $(".btn-slide_photo").click(function () {
        $("#panel_photo").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});
/*---------------------------- آمار و گزارشگیری */

$(document).ready(function () {

    $(".btn-slide_amar").click(function () {
        $("#panel_amar").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});
/*---------------------------- تنظیمات */

$(document).ready(function () {

    $(".btn-slide_settings").click(function () {
        $("#panel_settings").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});
/*---------------------------- سـایر */
$(document).ready(function () {

    $(".btn-slide_extra").click(function () {
        $("#panel_extra").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});

/*---------------------------- فایل ها */
$(document).ready(function () {

    $(".btn-slide_file").click(function () {
        $("#panel_file").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});


/*---------------------------- صوت و آهنگ */
$(document).ready(function () {

    $(".btn-slide_soundU").click(function () {
        $("#panel_soundU").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});
/*---------------------------- فیلم و نماهنگ */
$(document).ready(function () {

    $(".btn-slide_videoU").click(function () {
        $("#panel_videoU").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});
/*---------------------------- عکس و تصاویر */
$(document).ready(function () {

    $(".btn-slide_photoU").click(function () {
        $("#panel_photoU").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});
/*----------------------------  آموزش */
$(document).ready(function () {

    $(".btn-slide_learning").click(function () {
        $("#panel_learning").slideToggle("slow");
        $(this).toggleClass("active"); return false;
    });
});




/*---------------------------- POP UP */

$(document).ready(function () {

    // if user clicked on button, the overlay layer or the dialogbox, close the dialog	
    $('a.btn-ok, #dialog-overlay, #dialog-box').click(function () {
        $('#dialog-overlay, #dialog-box').hide();
        return false;
    });

    // if user resize the window, call the same function again
    // to make sure the overlay fills the screen and dialogbox aligned to center	
    $(window).resize(function () {

        //only do it if the dialog box is not hidden
        if (!$('#dialog-box').is(':hidden')) popup();
    });


});

//Popup dialog
function popup(message) {

    // get the screen height and width  
    var maskHeight = $(document).height();
    var maskWidth = $(window).width();

    // calculate the values for center alignment
    var dialogTop = (maskHeight / 3) - ($('#dialog-box').height());
    var dialogLeft = (maskWidth / 2) - ($('#dialog-box').width() / 2);

    // assign values to the overlay and dialog box
    $('#dialog-overlay').css({ height: maskHeight, width: maskWidth }).show();
    $('#dialog-box').css({ top: dialogTop, left: dialogLeft }).show();

    // display the message
    $('#dialog-message').html(message);

}

/*---------------------------- DDDDDDDDDDDDDDDD */