﻿!function (t) {
    "use strict";
    new LazyLoad({
        elements_selector: ".lazy"
    }),
        t(".custom_select select").niceSelect(),
        t(".categories_carousel").owlCarousel({
            center: !1,
            items: 2,
            loop: !1,
            margin: 20,
            dots: !1,
            nav: !0,
            lazyLoad: !0,
            navText: ["<i class='arrow_carrot-left'></i>", "<i class='arrow_carrot-right'></i>"],
            responsive: {
                0: {
                    nav: !1,
                    dots: !0,
                    items: 1
                },
                480: {
                    nav: !1,
                    dots: !0,
                    items: 2
                },
                768: {
                    nav: !1,
                    dots: !0,
                    items: 3
                },
                1025: {
                    nav: !1,
                    dots: !0,
                    items: 4
                },
                1340: {
                    nav: !0,
                    dots: !1,
                    items: 5
                }
            }
        }),
        t(".carousel_1").owlCarousel({
            items: 1,
            loop: !1,
            lazyLoad: !0,
            margin: 0,
            dots: !0,
            nav: !1
        }),
        t(".carousel_4").owlCarousel({
            items: 4,
            loop: !1,
            margin: 20,
            dots: !1,
            lazyLoad: !0,
            navText: ["<i class='arrow_carrot-left'></i>", "<i class='arrow_carrot-right'></i>"],
            nav: !0,
            responsive: {
                0: {
                    items: 1,
                    nav: !1,
                    dots: !0
                },
                560: {
                    items: 2,
                    nav: !1,
                    dots: !0
                },
                768: {
                    items: 2,
                    nav: !1,
                    dots: !0
                },
                991: {
                    items: 3,
                    nav: !0,
                    dots: !1
                },
                1230: {
                    items: 4,
                    nav: !0,
                    dots: !1
                }
            }
        }),
        t(window).on("scroll", function () {
            1 < t(this).scrollTop() ? t(".element_to_stick").addClass("sticky") : t(".element_to_stick").removeClass("sticky")
        }),
        t(window).scroll(),
        t(".background-image").each(function () {
            t(this).css("background-image", t(this).attr("data-background"))
        }),
        t(".categories_carousel .item a").hover(function () {
            t(this).find("i").toggleClass("rotate-x")
        }),
        t("a.open_close").on("click", function () {
            t(".main-menu").toggleClass("show"),
                t(".layer").toggleClass("layer-is-visible")
        }),
        t("a.show-submenu").on("click", function () {
            t(this).next().toggleClass("show_normal")
        }),
        t(".opacity-mask").each(function () {
            t(this).css("background-color", t(this).attr("data-opacity-mask"))
        }),
        t(window).scroll(function () {
            800 <= t(window).scrollTop() ? t("#toTop").addClass("visible") : t("#toTop").removeClass("visible")
        }),
        t("#toTop").on("click", function () {
            return t("html, body").animate({
                scrollTop: 0
            }, 500),
                !1
        });
    var o = t("footer h3");
    t(window).resize(function () {
        t(window).width() <= 768 ? o.attr("data-bs-toggle", "collapse") : o.removeAttr("data-bs-toggle", "collapse")
    }).resize(),
        o.on("click", function () {
            t(this).toggleClass("opened")
        }),
        t('a[href^="#"].btn_scroll').on("click", function (o) {
            o.preventDefault();
            var s = this.hash
                , o = t(s);
            t("html, body").stop().animate({
                scrollTop: o.offset().top
            }, 800, "swing", function () {
                window.location.hash = s
            })
        }),
        t(".btn_hero.wishlist").on("click", function (o) {
            o.preventDefault(),
                t(this).toggleClass("liked")
        }),
        t("#sign-in").magnificPopup({
            type: "inline",
            fixedContentPos: !0,
            fixedBgPos: !0,
            overflowY: "auto",
            closeBtnInside: !0,
            preloader: !1,
            midClick: !0,
            removalDelay: 300,
            closeMarkup: '<button title="%title%" type="button" class="mfp-close"></button>',
            mainClass: "my-mfp-zoom-in"
        }),
        t("#password, #password_sign").hidePassword("focus", {
            toggle: {
                className: "my-toggle"
            }
        }),
        t(".accordion_2").on("hidden.bs.collapse shown.bs.collapse", function (o) {
            t(o.target).prev(".card-header").find("i.indicator").toggleClass("icon_minus-06 icon_plus")
        })
}(window.jQuery);

