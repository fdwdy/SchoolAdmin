var CommonListModificationHandler = (function () {
    return function (options) {

        let hb = $.connection.schoolHub;

        $.connection.hub.start().done(function () {

        });

        hb.client.broadcast = function (message) {
            console.log(message);
            if (message[1] == options.listModifiedEventName)
            {
                if ($('#search').val() != '') {
                    const notificationArea = options.listUpdatedNotificationArea;
                    notificationArea.show();
                    notificationArea.find('.list-updated-notification-link').click(
                        function () {
                            $(this).off('click');
                            notificationArea.hide();
                            $('#search').val('');
                            options.listUpdater.updateData(message[0][0])
                        });
                }
                else {
                    options.listUpdater.updateData(message[0][0])
                }
            }
        };
    };
}());