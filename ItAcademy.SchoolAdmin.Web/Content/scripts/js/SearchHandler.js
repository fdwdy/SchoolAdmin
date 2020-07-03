var SearchHandlerWrapper = (function () {
    return function (options) {

        let handler = new SearchHandler(options.controllerName, options.actionName, options.updater);

        $('#search').on('input', function () {
            return showResults(handler, false)
        });

        $('#search').on('keyup', function () {
            return showResults(handler, false)
        });

        $('#search').on('paste', function () {
            return showResults(handler, false)
        });

        $('#submit').click(function () {
            return showResults(handler, true)
        });

        function showResults(handler, enableShortSearch) {

            var query = $('#search').val();

            query = encodeURIComponent(query);

            if (query.length < 3 && !enableShortSearch) {
                return
            }

            if (handler.xhr.readyState != 4) {
                handler.xhr.abort();
            }

            handler.setQuery(query);
            handler.processQuery(handler.getUrl());
        };
    };
}());

class SearchHandler {

    prevQuery = '';

    query = '';

    xhr = new XMLHttpRequest();

    url = '';

    constructor(controller, action, updater) {
        this.controllerName = controller;
        this.actionName = action;
        this.updater = updater;
        console.log('sdfsdfsdfsd');
    }

    setQuery(query) {
        this.query = query;
    }

    getUrl() {
        return "http://localhost:13693/" + this.controllerName + "/" + this.actionName + "?";
    }

    processQuery(url) {
        console.log(this);

        if (this.query == this.prevQuery) {
            return;
        }

        this.xhr = $.ajax(url, {
            data: "query=" + this.query,
            type: "GET",
            timeout: 300,
            success: data => {
                console.log(data);
                this.updater.updateData(data)
            }
        })

        this.prevQuery = this.query;

    };
}