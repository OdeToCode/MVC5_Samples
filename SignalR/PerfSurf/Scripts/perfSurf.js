(function () {
    var perfHub = $.connection.perfHub;
    $.connection.hub.start();
    perfHub.client.newMessage = function (message) {
        model.addMessage(message);
    };
    perfHub.client.newCounters = function (counters) {
        model.addCounters(counters);
    };

    var ChartEntry = function (name) {
        var self = this;
        self.name = name;
        self.chart = new SmoothieChart({ millisPerPixel: 50, labels: { fontSize: 15 } });
        self.timeSeries = new TimeSeries();
        self.chart.addTimeSeries(self.timeSeries, { lineWidth: 3, strokeStyle: '#00ff00' });

        self.start = function () {
            self.canvas = $("#" + name);
            self.chart.streamTo(self.canvas.get(0));
        };
    }

    var Model = function () {
        var self = this;
        self.message = ko.observable(""),
        self.messages = ko.observableArray(),
        self.counters = ko.observableArray()
    };

    Model.prototype = {

        addCounters: function (updatedCounters) {
            var self = this;

            $.each(updatedCounters, function (index, updatedCounter) {
                var entry = ko.utils.arrayFirst(self.counters(), function (counter) {
                    return counter.name == updatedCounter.name;
                });

                if (!entry) {
                    entry = new ChartEntry(updatedCounter.name);
                    self.counters.push(entry);
                    entry.start();
                }
                entry.timeSeries.append(new Date().getTime(), updatedCounter.value);
            });
        },

        addMessage: function (message) {
            var self = this;
            self.messages.push(message);
        },

        sendMessage: function () {
            var self = this;
            perfHub.server.send(self.message());
            self.message("");
        },
    };

    var model = new Model();

    var init = function () {
        ko.applyBindings(model);
    };

    $(init);
}());