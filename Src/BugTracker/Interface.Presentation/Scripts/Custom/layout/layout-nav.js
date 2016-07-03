﻿'use strict'
$(function () {

    $('.link[data-target-id="' + document.title + '"]').addClass('active');

    $("#imgInput").change(function () {
        readURL(this);
    });

})

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imgShow').attr('src', e.target.result);
            $('#project-img').slideDown('slow');
        }

        reader.readAsDataURL(input.files[0]);
    }
}
