var viewModel = {
    loginClicked: function () {
        window.location.href = "https://github.com/login/oauth/authorize?client_id=7ce4ceec9afd17668e3c&scope=repo&redirect_uri=http://localhost:2023/Auth";
    }
};

$(document).ready(function () {
    ko.applyBindings(viewModel);
});