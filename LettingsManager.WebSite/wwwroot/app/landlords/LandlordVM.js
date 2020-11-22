(function (app) {
    app.landlordItem = function (data) {
        var self = this;
        self.id = ko.observable(data.id);
        self.name = ko.observable(data.name).extend({ required: true });
        self.address1 = ko.observable(data.address1).extend({ required: true });
        self.address2 = ko.observable(data.address2).extend({ required: true });
        self.address3 = ko.observable(data.address3).extend({ required: true });
        self.address4 = ko.observable(data.address4).extend({ required: true });
        self.address5 = ko.observable(data.address5);
        self.mobile = ko.observable(data.mobile).extend({ required: true });
        self.email = ko.observable(data.email).extend({ required: true, email: true });
        self.errors = ko.validation.group(self);
        self.toJson = function () { return ko.toJSON(self); };
    };


})(window.app = window.app || {});
