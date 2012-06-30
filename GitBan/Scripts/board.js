function Card(text, owner) {
    var self = this;
    self.txt = text;
    self.owner = owner;
}

function Column(name, wip) {
    var self = this;
    self.name = new ko.observable(name);
    self.wip = new ko.observable(wip);
    self.cards = new ko.observableArray([]);
}

var viewModel = {
    columns: new ko.observableArray([
        new Column("Backlog", "5"),
        new Column("Planning", "2")
    ])
};

$(function () {
    ko.applyBindings(viewModel);

    $.getJSON("https://api.github.com/repos/rally25rs/npp-DotNetScripting/issues?callback=?", null, function (response) {
        viewModel.columns()[0].cards.removeAll();
        for (var i = 0; i < response.data.length; i++) {
            viewModel.columns()[0].cards.push(ko.mapping.fromJS(response.data[i]));
        }
    });
});
