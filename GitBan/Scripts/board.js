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
        new Card("Card One", "Jeff"),
        new Card("Card Two", "Jeff")
    ]);
}

function Board() {
    var self = this;
}

var viewModel = {
    columns: new ko.observableArray([
        new Column("Backlog", "5"),
        new Column("Planning", "2")
    ]),
    isColumnFull: function (parent) {
        return parent().length < 3;
    }
};

function findPos(obj) {
    var curleft = curtop = 0;
    if (obj.offsetParent) {
        do {
            curleft += obj.offsetLeft;
            curtop += obj.offsetTop;
        } while (obj = obj.offsetParent);
    }
    return [curleft, curtop];
}

$(function () {
    ko.applyBindings(viewModel);
});
