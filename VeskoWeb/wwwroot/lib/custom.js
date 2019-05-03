/*==========================================================================================

                                        SERVICES

==========================================================================================*/

$(function () {

    new WOW().init();

});

/*==========================================================================================

                                        Work

==========================================================================================*/

$(function () {

    $("#work").magnificPopup({
        /* Abre um popup com a imagem */
        delegate: 'a', // child items selector, by clicking on it popup will open
        type: 'image',
        /* Habilita o modo galeria no popup exibido */
        gallery: {
            enabled: true
        }
    });
});

/*==========================================================================================

                                        Team

==========================================================================================*/

$(function () {

    $("#team-members").owlCarousel({

        /* Atributos disponiveis na documentação: https://owlcarousel2.github.io/OwlCarousel2/docs/api-options.html */
        items: 3,
        autoplay: true,
        smartSpeed: 700,
        loop: true,
        autoplayHoverPause: true

    });

});

/*==========================================================================================

                                        Testimonial

==========================================================================================*/

$(function () {

    $("#customers-testimonials").owlCarousel({

        /* Atributos disponiveis na documentação: https://owlcarousel2.github.io/OwlCarousel2/docs/api-options.html */
        items: 1,
        autoplay: true,
        smartSpeed: 700,
        loop: true,
        autoplayHoverPause: true

    });



});

/*==========================================================================================

                                        STATS

==========================================================================================*/

$(function () {

    $('.counter').counterUp({
        delay: 10,
        time: 2000
    });

});

/*==========================================================================================

                                        CLIENTS

==========================================================================================*/


$(function () {

    $("#clients-list").owlCarousel({

        /* Atributos disponiveis na documentação: https://owlcarousel2.github.io/OwlCarousel2/docs/api-options.html */
        items: 6,
        autoplay: true,
        smartSpeed: 700,
        loop: true,
        autoplayHoverPause: true,
        responsive: {
            // breakpoint from 0 up
            0: {
                items: 1
            },
            // breakpoint from 480 up
            480: {
                items: 3
            },
            // breakpoint from 768 up
            768: {
                items: 5
            },
            // breakpoint from 992 up
            992: {
                items: 6
            }
        }

    });



});

/*==========================================================================================

                                        NAVGATION

==========================================================================================*/

$(function () {
    $(window).scroll(function () {



        /* 50 = 50px */
        if ($(this).scrollTop() < 50) {

            // Hide black nav

            $("nav").removeClass("vesco-top-nav");

            // Evento do botão back-to-top
            $("#back-to-top").fadeOut();

        } else {

            // Show nav

            $("nav").addClass("vesco-top-nav");

            $("#back-to-top").fadeIn();

        }

    });


});


// Smooth-Scroll

$(function () {

    $("a.smooth-scroll").click(function (event) {

        event.preventDefault();

        // get/return id like #about, #wortk and etc.
        var section = $(this).attr("href");

        $('html, body').animate({

            scrollTop: $(section).offset().top - 45 // -45: da uma margem do topo após animação para aparecer todo o conteúdo da seção
            // 1250: tempo da animação |  easeInOutExpo: Abiamação Easing 
        }, 1250, "easeInOutExpo");


    });


});

// Close mobile menu on click
$(function () {

    $(".navbar-collapse ul li a").on("click touch", function () {

        $(".navbar-toggler").click();

    });

});

// Active Link

// Cache selectors
var topMenu = $("#vesco-menu"),
    topMenuHeight = topMenu.outerHeight() + 15,
    // All list items
    menuItems = topMenu.find("a"),
    // Anchors corresponding to menu items
    scrollItems = menuItems.map(function () {
        var item = $($(this).attr("href"));
        if (item.length) { return item; }
    });

// Bind to scroll
$(window).scroll(function () {
    // Get container scroll position
    var fromTop = $(this).scrollTop() + topMenuHeight;

    // Get id of current scroll item
    var cur = scrollItems.map(function () {
        if ($(this).offset().top < fromTop)
            return this;
    });
    // Get the id of the current element
    cur = cur[cur.length - 1];
    var id = cur && cur.length ? cur[0].id : "";
    // Set/remove active class
    menuItems
        .parent().removeClass("active")
        .end().filter("[href='#" + id + "']").parent().addClass("active");
})




/*==========================================================================================

                                     CONTACT VALIDATION

==========================================================================================*/

//$("#contactForm").validate({
//    rules: {
//        name: {
//            required: true,
//            minlength: 3
//        },
//        email: {
//            required: true
//        },
//        message: {
//            required: true
//        },
//        subject: {
//            required: true
//        }
//    },
//    messages: {
//        name: {
//            required: "Por favor, informe seu nome",
//            minlength: "O nome deve ter pelo menos 3 caracteres"
//        },
//        email: {
//            required: "É necessário informar um email"
//        },
//        message: {
//            required: "A mensagem não pode ficar em branco"
//        },
//        subject: {
//            required: "Informe o motivo do contato  "
//        }
//    }
//});


//$("#submitContact").click(function () {
//    if (!$("#contactForm").valid()) {

//        $('html, body').animate({

//            scrollTop: $("#contact").offset().top - 100 // -45: da uma margem do topo após animação para aparecer todo o conteúdo da seção
//            // 1250: tempo da animação |  easeInOutExpo: Aniamação Easing 
//        }, "slow");
//        return false;     
//    }
//})


$(function () {
    var isSuccessForm = $("#isSuccessForm").val().toString().toLowerCase();
    if (isSuccessForm == "false") {
        //$('html, body').animate({

        //    scrollTop: $("#submitContact").offset().top // -45: da uma margem do topo após animação para aparecer todo o conteúdo da seção
        //    // 1250: tempo da animação |  easeInOutExpo: Aniamação Easing 
        //}, "slow");
        $(document).scrollTop($("#contact").offset().top - 40);
    }
});


/*==========================================================================================

                                    SUCCESS MODAL

==========================================================================================*/



$(function () {
    var isSuccessForm = $("#isSuccessForm").val().toString().toLowerCase();
    if (isSuccessForm == "true") {            
        $("body").css("overflow", "hidden");
        $("header").hide();
        $(".modal").show();
        $("#isSuccessForm").val("default");
        $("#name").val("");
        $("#subject").val("");
        $("#message").val("");
        $("#email").val("");
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
    }
});


$(".close-modal, .modal-sandbox").click(function () {
    $(".modal").hide();
    $("body").css("overflow", "auto");
    $("header").show();
    // $("body").css({"overflow-y": "auto"}); //Prevent double scrollbar.
});