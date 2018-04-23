
function CompetitionViewModelEdit() {
    self = this;

    //bind down data
    self.VL = ko.observable(1);
    self.CL = ko.observable(1);
    self.CompoStartDate = ko.observable(new moment());
    console.log(self.CompoStartDate());
    self.CompoLength = ko.computed(function () {
        return self.CompoStartDate().add(self.CL(), 'hours');
    });
    self.VoteLength = ko.computed(function () {
        var diff = self.CompoStartDate().diff(self.CompoLength());
        return self.CompoStartDate().add(self.VL(), 'hours').add(diff, 'milliseconds');
    });
    self.CurrentPhase = ko.observable();
    self.CompetitionType = ko.observable();
    self.Title = ko.observable();
}