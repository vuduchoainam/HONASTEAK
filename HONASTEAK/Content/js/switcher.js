﻿window.console = window.console || function () {
    var r = {};
    return r.log = r.warn = r.debug = r.info = r.error = r.time = r.dir = r.profile = r.clear = r.exception = r.trace = r.assert = function () { }
        ,
        r
}(),
    jQuery(document).ready(function (e) {
        e("#style-switcher .default").click(function () {
            return e("#colors").attr("href", "#"),
                !1
        }),
            e("#style-switcher .aqua").click(function () {
                return e("#colors").attr("href", "css/color-aqua.css"),
                    !1
            }),
            e("#style-switcher .orange").click(function () {
                return e("#colors").attr("href", "css/color-orange.css"),
                    !1
            }),
            e("#style-switcher .blue").click(function () {
                return e("#colors").attr("href", "css/color-blue.css"),
                    !1
            }),
            e("#style-switcher .beige").click(function () {
                return e("#colors").attr("href", "css/color-beige.css"),
                    !1
            }),
            e("#style-switcher .gray").click(function () {
                return e("#colors").attr("href", "css/color-gray.css"),
                    !1
            }),
            e("#style-switcher .green-2").click(function () {
                return e("#colors").attr("href", "css/color-green-2.css"),
                    !1
            }),
            e("#style-switcher .purple").click(function () {
                return e("#colors").attr("href", "css/color-purple.css"),
                    !1
            }),
            e("#style-switcher .red").click(function () {
                return e("#colors").attr("href", "css/color-red.css"),
                    !1
            }),
            e("#style-switcher .violet").click(function () {
                return e("#colors").attr("href", "css/color-violet.css"),
                    !1
            }),
            e("#style-switcher h6 a").click(function (r) {
                r.preventDefault();
                var c = e("#style-switcher");
                console.log(c.css("left")),
                    "-205px" === c.css("left") ? e("#style-switcher").animate({
                        left: "0px"
                    }) : e("#style-switcher").animate({
                        left: "-205px"
                    })
            }),
            e(".colors li a").click(function (r) {
                r.preventDefault(),
                    e(this).parent().parent().find("a").removeClass("active"),
                    e(this).addClass("active")
            })
    });
