/// <reference path="../helpers/dataservices.js" />

(function (app) {

   app.landlordInit = function () {

        var vm = new app.landlordManagerVM();
        vm.getHomeSource();
        vm.getLandlordSource();

        ko.applyBindings(vm);

    };
   app.landlordManagerVM = function () {
        var self = this;
        //var ds = new dataControl();

        self.homes = null;
       self.homesSource = new app.pageData(8);

        self.landlords = null;
       self.landlordSource = new app.pageData(8);

       self.landlordSource.currentRecord.subscribe(function () { });

        self.landlordSource.nameFilter.subscribe(function (searchAll) {
            self.filterLandlord(searchAll);
        });

       self.getLandlordSource = function () {
           return app.getLandlord()
                .done(function (results) {
                    self.landlords = results;
                    self.landlordSource.dataSource($.map(self.landlords, function (item) { return new app.landlordItem(item); }));
                    self.landlordSource.currentRecord(new app.landlordItem(results[0]));
                    toastr.success('Landlords Loaded', 'Landlord')
                })
                .fail(function () {
                    console.log("error Getting list of Landlords");
                });
        };

        self.getHomeSource = function () {
            return app.getHouse()
                .done(function (results) {
                    self.homes = results;
                })
                .fail(function () {
                    console.log("error Getting list of Homes");
                });
        };

        self.filterLandlord = function (filter) {
            if (filter !== '') {
                var results = _.filter(self.landlords, function (item) {
                    return _.includes(item.address1.trim().toLowerCase(), filter.trim().toLowerCase()) ||
                        _.includes(item.name.trim().toLowerCase(), filter.trim().toLowerCase());
                });
                return self.landlordSource.dataSource($.map(results, function (item) { return new app.landlordItem(item); }));
            } else {
                return self.landlordSource.dataSource($.map(self.landlords, function (item) { return new app.landlordItem(item); }));
            }
        };
        self.saveData = function () {
            var landlordData = self.landlordSource.currentRecord();
            var jsonLandlord = landlordData.toJson();
            return app.updateLandlord(jsonLandlord, landlordData.id())
                .done(function (results) {
                    console.log(results);
                    toastr.success('Landlord Updated.', 'Landlord')
                    $("#editModal").modal('hide');
                })
                .fail(function () {
                    console.log("error Updating Home");
                    $("#editModal").modal('hide');
                    toastr.error('Error Updating Landlord.', 'Landlord Error!')
                });
        };
        self.saveNewData = function () {
            var newLandlordData = self.landlordSource.currentRecord();
            if (newLandlordData.errors().length === 0) {

                return app.saveLandlord(newLandlordData.toJson())
                    .done(function (results) {
                        console.log(results);
                        toastr.success('New Landlord Created.', 'New Landlord!')
                        $("#addModal").modal('hide');
                        self.getLandlordSource();
                    })
                    .fail(function () {
                        console.log("error Updating Landlord");
                        $("#addModal").modal('hide');
                        toastr.error('Error Createing Landlord.', 'Add Landlord Error!')
                    });


            } else {
                toastr.error('Please check all the required Fiels. and try again', 'Check invalid Fields!')
            }
            
            
        };
        self.deleteData = function () {
            var clientData = self.landlordSource.currentRecord();
            var landlordId = clientData.id();

            return app.deleteLandlord(landlordId)
                .done(function (results) {
                    self.getLandlordSource();
                    $("#confirmDeleteModal").modal('hide');
                })
                .fail(function () {
                    $("#confirmDeleteModal").modal('hide');
                    console.log("error delete category");
                });
        };

        self.showEditDialogBox = function (selected) {
            self.landlordSource.currentRecord(selected);
            $("#editModal").modal('show');
        };
        self.showLandlordHomesDialogBox = function (selected) {
            self.landlordSource.currentRecord(selected);
            self.filterLandlordHomes(selected.id());
            $('#landlordHousesModal').modal('show');
        };
        self.filterLandlordHomes = function (id) {
            var results = _.filter(self.homes, function (item) {
                return item.landlordId === id;
            });
            console.log(results);
            return self.homesSource.dataSource($.map(results, function (item) { return new app.HouseItem(item); }));

        };
        self.showAddDialogBox = function (selected) {
            const data = {
                name: "Landlord Name",
                address1: "123 High Road",
                address2: "Stratford",
                address3: "London ",
                address4: "E15 1PF",
                address5: "UK",
                tenant1: "tony",
                tenant2: "antonio",
                mobile: "07000000000",
                email: "my@email.com"
            };
            const newRecord = new app.landlordItem(data);
            self.landlordSource.currentRecord(newRecord);
            $("#addModal").modal('show');
        };
        self.showDeleteDialogBox = function (selected) {
            self.landlordSource.currentRecord(selected);
            $("#confirmDeleteModal").modal('show');
        };


        self.formatCurrency = function (value) {
            var currency = parseFloat(value());
            return "£" + currency.toFixed(2);
        };
    };
})(window.app = window.app || {});