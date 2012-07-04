function unescapeHTML(html) {
    return $("<div />").html(html).text();
}

var viewModel = {
    projects: JSON.parse(unescapeHTML(projectsJson)),
    openProject: function (project) {
        document.location = "/Projects/Board/" + project.Id;
    }
};

$(document).ready(function () {
    ko.applyBindings(viewModel);
});