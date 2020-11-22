/// <reference path="../helpers/dataservices.js" />

(function (app) {
    app.HomeControllerInit = function () {

        var vm = new app.homesManagerVM();
        vm.getLandlordLoop();
        vm.getHomeSource();
        vm.error = ko.validation.group([vm.address1, vm.address2]);

        ko.applyBindings(vm);

    };
    app.homesManagerVM = function () {
        var self = this;
        self.homes = null;
        self.homesSource = new app.pageData(10);
        self.landlords = null;
        self.currentlandlord = ko.observable();
        self.landlordSource = ko.observableArray();
        self.homesSource.currentRecord.subscribe(function () { });
       // self.homesSource.printRecord.subscribe(function () { });
        self.homesSource.nameFilter.subscribe(function (searchAll) {
            self.filterHomes(searchAll);
        });

       self.getHomeSource = function () {
           return app.getHouse()
                .done(function (results) {
                    self.homes = results;
                    self.homesSource.dataSource($.map(self.homes, function (item) { return new app.HouseItem(item); }));
                    toastr.info('House list loaded', 'House')
                })
                .fail(function () {
                    console.log("error Getting list of Homes");
                });
        };

        self.saveData = function () {
            var homeData = self.homesSource.currentRecord();
            //var editedHome = new homesVM.addNewHome(ko.toJS(homeData));
            return app.updateHouse(homeData.toJson(),homeData.id())
                .done(function (results) {
                    console.log(results);
                    $("#editModal").modal('hide');
                    toastr.info('House  Updated', 'House')
                })
                .fail(function () {
                    console.log("error Updating Home");
                    $("#editModal").modal('hide');
                    toastr.error('Error updating House.', 'House Error!')
                });
        };

        self.saveNewData = function () {
            var homeData = self.homesSource.currentRecord();
            var newHome = new app.addNewHouseItem(ko.toJS(homeData));
            if (homeData.errors().length === 0) {
                return app.saveHouse(newHome.toJson())
                    .done(function (results) {
                        self.getHomeSource();
                        $("#addModal").modal('hide');
                        toastr.success('New House  Created', 'House')
                    })
                    .fail(function () {
                        console.log("error Updating Home");
                        $("#addModal").modal('hide');
                        toastr.error('Error Saving new House.', 'House Error!')
                    });
            } else {
                toastr.error('Please check all the required Fiels. and try again', 'Check invalid Fields!')
            }
            
        };

        self.deleteData = function () {
            var clientData = self.homesSource.currentRecord();

            return app.deleteHouse(clientData.id())
                .done(function () {
                    self.getHomeSource();
                    $("#confirmModal").modal('hide');
                })
                .fail(function () {
                    console.log("error delete category");
                });
        };

        self.showEditDialogBox = function (selected) {
           
            self.homesSource.currentRecord(selected);
            $("#editModal").modal('show');
        };
        self.dateChange = function (data) {
            const house = ko.toJS(data)
            const date = moment(house.dateFromFormat, 'DD/MM/YYYY');
            const addOneYear = moment(date).add(1, 'years')
            const updateDatefrom = moment(house.dateFromFormat, 'YYYY/MM/DD');
            const updateDateTo = moment(addOneYear._d, 'YYYY/MM/DD');
            const UpdateDateToFormat = moment(new Date(updateDateTo)).format("DD-MM-YYYY");

            data.dateFrom(updateDatefrom);
            data.dateTo(updateDateTo);
            data.dateToFormat(UpdateDateToFormat);
        };

        self.showPrintDialogBox = function (selected) {
            const homeToPrint = ko.toJS(selected);
            const landlordTofind = _.findKey(self.landlords, function (o) { return o.id === selected.landlordId(); });
            const landlordToPrint = self.landlords[landlordTofind];
            const house = homeToPrint;
            const printVM = new app.printHouse(house, landlordToPrint)
    
            self.homesSource.printRecord(printVM);
            self.findAndPrintContract();
        };

        self.showAddDialogBox = function (selected) {
            const data = {
                address1: "123 High Road",
                address2: "East Ham",
                address3: "London ",
                address4: "W5 1PF",
                address5: "UK",
                tenant1: "tony",
                tenant2: "antonio",
                dateFrom: new Date().toUTCString(),
                dateTo: new Date().toUTCString(),
                landlordId: 1,
                rent: 1000,
                deposit: 1000,
                mobile: "07590000000",
                email: "me@you.com"
            };
            const newRecord = new app.HouseItem(data);
            self.homesSource.currentRecord(newRecord);
            $("#addModal").modal('show');
        };

        self.showDeleteDialogBox = function (selected) {
            self.homesSource.currentRecord(selected);
            $("#confirmModal").modal('show');
        };

        self.getLandlordLoop = function () {
            return app.getLandlord()
                .done(function (results) {
                    self.landlords = results;
                    self.currentlandlord = new app.landlordItem(self.landlords[0]);
                    self.landlordSource($.map(self.landlords, function (item) { return new app.landlordItem(item); }));
                })
                .fail(function () {
                    console.log("error Getting list of Landlords");
                });
        };

        self.findAndPrintContract = function () {
    
            var data = document.getElementById('print').innerHTML;
            var myWindow = window.open('', 'my div', 'height=400,width=600');
            myWindow.document.write('<html><head><title>Print Contract</title>');
            myWindow.document.write('<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous"/>');
            myWindow.document.write('<link rel="stylesheet" href="/css/stylePrint.css" type="text/css" />');
            myWindow.document.write('</head><body >');
            myWindow.document.write(data);
            myWindow.document.write('</body></html>');
            myWindow.document.close();

            myWindow.onload = function () {
                myWindow.focus();
                myWindow.print();
                myWindow.close();
            };
        };

        self.filterHomes = function (filter) {
            if (filter !== '') {
                var homeResults = _.filter(self.homes, function (home) {
                    return _.includes(home.address1.trim().toLowerCase(), filter.trim().toLowerCase()) ||
                        _.includes(home.tenant1.trim().toLowerCase(), filter.trim().toLowerCase());
                });
                return self.homesSource.dataSource($.map(homeResults, function (item) { return new app.HouseItem(item); }));
            } else {
                return self.homesSource.dataSource($.map(self.homes, function (item) { return new app.HouseItem(item); }));
            }
        };

        self.formatCurrency = function (value) {
            var currency = parseFloat(value());
            return "£" + currency.toFixed(2);
        };

    };

})(window.app = window.app || {});
