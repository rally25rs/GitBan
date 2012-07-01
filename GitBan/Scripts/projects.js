var viewModel = {
    projects: new ko.observableArray([])
};

$(document).ready(function () {
    ko.applyBindings(viewModel);
});