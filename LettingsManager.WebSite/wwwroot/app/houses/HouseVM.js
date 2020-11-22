(function (app) {
    app.HouseItem = function (data) {
        ko.validation.rules.pattern.message = 'Invalid.';

        ko.validation.init({
            registerExtenders: true,
            messagesOnModified: true,
            insertMessages: true,
            parseInputAttributes: true,
            messageTemplate: null
        }, true);
        var self = this;
        self.id = ko.observable(data.id);
        self.tenant2 = ko.observable(data.tenant2);
        self.tenant1 = ko.observable(data.tenant1).extend({ required: true });
        self.address1 = ko.observable(data.address1).extend({ required: true });;
        self.address2 = ko.observable(data.address2).extend({ required: true });;
        self.address3 = ko.observable(data.address3);
        self.address4 = ko.observable(data.address4);
        self.address5 = ko.observable(data.address5);
        self.dateFrom = ko.observable(new Date(data.dateFrom)).extend({ required: true });
        self.dateTo = ko.observable(new Date(data.dateTo)).extend({ required: true });
        self.dateFromFormat = ko.observable(moment(new Date(data.dateFrom)).format("DD-MM-YYYY"));
        self.dateToFormat = ko.observable(moment(new Date(data.dateTo)).format("DD-MM-YYYY"));
        self.landlordId = ko.observable(data.landlordId);
        self.rent = ko.observable(data.rent).extend({ required: true });
        self.deposit = ko.observable(data.deposit).extend({ required: true });
        self.mobile = ko.observable(data.mobile).extend({ required: true });
        self.email = ko.observable(data.email).extend({ required: true });

        self.rentShow = function () {
            var formatUnitPrice = parseFloat(self.unitPrice());
            return "£" + formatUnitPrice.toFixed(2);
        };
        
        self.errors = ko.validation.group(self);
        self.toJson = function () { return ko.toJSON(self); };
    };
   
    app.addNewHouseItem = function (data) {
        ko.validation.rules.pattern.message = 'Invalid.';

        ko.validation.init({
            registerExtenders: true,
            messagesOnModified: true,
            insertMessages: true,
            parseInputAttributes: true,
            messageTemplate: null
        }, true);
        var self = this;
        self.id = ko.observable(data.id);
        self.tenant2 = ko.observable(data.tenant2);
        self.tenant1 = ko.observable(data.tenant1).extend({ required: true });
        self.address1 = ko.observable(data.address1).extend({ required: true });;
        self.address2 = ko.observable(data.address2).extend({ required: true });;
        self.address3 = ko.observable(data.address3).extend({ required: true });;
        self.address4 = ko.observable(data.address4);
        self.address5 = ko.observable(data.address5);
        self.dateFrom = ko.observable(new Date(data.dateFrom)).extend({ required: true });;
        self.dateTo = ko.observable(new Date(data.dateTo)).extend({ required: true });;
        self.landlordId = ko.observable(data.landlordId);
        self.rent = ko.observable(data.rent).extend({ required: true });;
        self.deposit = ko.observable(data.deposit).extend({ required: true });;
        self.mobile = ko.observable(data.mobile).extend({ required: true });;
        self.email = ko.observable(data.email).extend({ required: true });;
        self.errors = ko.validation.group(self);
       

        self.toJson = function () { return ko.toJSON(self); };
    };
    app.printHouse = function (house, landlord) {
        
        var self = this;
        self.id = ko.observable(house.id);
        self.tenant2 = ko.observable(house.tenant2);
        self.tenant1 = ko.observable(house.tenant1);
        self.address1 = ko.observable(house.address1);
        self.address2 = ko.observable(house.address2);
        self.address3 = ko.observable(house.address3);
        self.address4 = ko.observable(house.address4);
        self.address5 = ko.observable(house.address5);
        self.dateFrom = ko.observable(moment(new Date(house.dateFrom)).format("DD-MM-YYYY"));
        self.dateTo = ko.observable(moment(new Date(house.dateTo)).format("DD-MM-YYYY"));
        self.landlordId = ko.observable(house.landlordId);
        self.rent = ko.observable(house.rent);
        self.deposit = ko.observable(house.deposit);
        self.mobile = ko.observable(house.mobile);
        self.email = ko.observable(house.email);
        self.landlordName = ko.observable(landlord.name);
        self.landlordAddress1 = ko.observable(landlord.address1);
        self.landlordAddress2 = ko.observable(landlord.address2);
        self.landlordAddress3 = ko.observable(landlord.address3);
        self.landlordAddress4 = ko.observable(landlord.address4);
        self.landlordAddress5 = ko.observable(landlord.address5);
       
        self.toJson = function () { return ko.toJSON(self); };
    };

})(window.app = window.app || {});

