(function (app) {
    var httpVerbs = {
        POST: 'POST',
        PUT: 'PUT',
        GET: 'GET',
        DEL: 'DELETE'
    };
    app.getHouse = function () {
        return $.ajax({
            type: httpVerbs.GET,
            url: '/api/Houses/GetHouses/',
            contentType: "application/json",
            beforeSend: function () {
                 $("#spinkit").show();
            },            
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };
    app.saveHouse = function (data) {
        return $.ajax({
            type: httpVerbs.POST,
            url: '/api​/Houses​/AddHouse/',
            contentType: "application/json",
            data: data,
            beforeSend: function () {
                $("#spinkit").show();
            },
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };
    app.updateHouse = function (data, id) {
        return $.ajax({
            type: httpVerbs.PUT,
            url: '/api/Houses/UpdateHouse/' + id,
            contentType: "application/json",
            cache: false,
            data: data,
            beforeSend: function () {
                $("#spinkit").show();
            },
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };
    app.getHomeById = function (id) {
        return $.ajax({
            type: httpVerbs.GET,
            url: '​/api​/Houses​/GetHouseById​/' + id,
            contentType: "application/json",
            beforeSend: function () {
                $("#spinkit").show();
            },
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };
   
    app.deleteHouse = function (id) {
        return $.ajax({
            type: httpVerbs.DEL,
            url: '/api/Houses/DeleteHouse/' + id,
            contentType: "application/json",
            beforeSend: function () {
                $("#spinkit").show();
            },
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };
    app.getLandlord = function () {
        return $.ajax({
            type: httpVerbs.GET,
            url: '/api/Landlords/GetLandlords',
            contentType: "application/json",
            beforeSend: function () {
                $("#spinkit").show();
            },
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };
    app.getLandlordById = function (id) {
        return $.ajax({
            type: httpVerbs.GET,
            url: '/api/Landlords/GetLandlord/' + id,
            contentType: "application/json",
            beforeSend: function () {
                $("#spinkit").show();
            },
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };
    app.saveLandlord = function (data) {
        return $.ajax({
            type: httpVerbs.POST,
            url: '/api/Landlords/AddLandlord/',
            contentType: "application/json",
            data: data,
            beforeSend: function () {
                $("#spinkit").show();
            },
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };
    app.updateLandlord = function (data, id) {
        return $.ajax({
            type: httpVerbs.PUT,
            url: '/api/Landlords/UpdateLandlord/' + id,
            contentType: "application/json",
            cache: false,
            data: data,
            beforeSend: function () {
                $("#spinkit").show();
            },
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };
    app.deleteLandlord = function (id) {
        return $.ajax({
            type: httpVerbs.DEL,
            url: '/api/Landlords/DeleteLandlord/' + id,
            contentType: 'json',
            beforeSend: function () {
                $("#spinkit").show();
            },
            complete: function () {
                $("#spinkit").hide();
            },
        });
    };


})(window.app = window.app || {});