function Card(text, owner) {
    var self = this;
    self.txt = text;
    self.owner = owner;
}

function Column(name, wip) {
    var self = this;
    self.name = new ko.observable(name);
    self.wip = new ko.observable(wip);
    self.cards = new ko.observableArray([
    ]);
}

var viewModel = {
    columns: new ko.observableArray([
        new Column("Backlog", "5"),
        new Column("Planning", "2")
    ]),
    isColumnFull: function (parent) {
        return true;
    }
};

$(function () {
    $.getJSON("https://api.github.com/repos/rally25rs/npp-DotNetScripting/issues", function (data) {
        viewModel.columns()[0].cards = ko.mapping.fromJS(data);
        ko.applyBindings(viewModel);
    });
});
