$(function () {

    var hb = $.connection.employeeHub;

    hb.client.broadcast = function (message) {
        getAll();
    };

    $.connection.hub.start().done(function () {
        getAll();
    });

});

function getAll() {
    var model = $('#results');
    $.ajax({
        url: '/Employee/GetEmployeeData',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (result) { model.empty().append(result); }
    });
}