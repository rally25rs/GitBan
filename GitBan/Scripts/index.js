var viewModel = {
    loginClicked: loginClicked()
};

$(document).ready(function () {
    ko.applyBindings(viewModel);
});