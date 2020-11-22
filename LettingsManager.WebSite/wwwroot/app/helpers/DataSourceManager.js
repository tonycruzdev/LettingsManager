(function (app) {
    app.pageData = function (pageSize) {
        var self = this;
        self.itemPerPage = ko.observable(pageSize || 10),
            self.title = ko.observable(),
            self.nameFilter = ko.observable('').extend({ throttle: 500 }),
            self.currentRecord = ko.observable(),
            self.printRecord = ko.observable(),
            self.dataSource = ko.observableArray(),
            self.displaySource = ko.observableArray(),
            self.currentPage = ko.observable(0),
            self.selectedRecord = function (item) {
                self.currentRecord(item);
            },
            self.pageCount = ko.computed(function () {
                return Math.ceil(self.dataSource().length / self.itemPerPage()) || 1;
            }),
            self.nextPage = function () {
                if (self.currentPage() < (self.pageCount() - 1)) {
                    var results = self.currentPage(self.currentPage() + 1);
                    self.currentRecord(self.displaySource()[0]);
                    return results;
                }
            },
            self.firstPage = function () {
                return self.currentPage(0);
            },
            self.lastPage = function () {
                return self.currentPage(self.pageCount() - 1);
            },
            self.previeusPage = function () {
                if (self.currentPage() > 0)
                    var results = self.currentPage(self.currentPage() - 1);
                self.currentRecord(self.displaySource()[0]);
                return results;
            },
            self.hasNext = function () {
                if (self.currentPage() < self.PageCount() - 1) {
                    return true;
                } else {
                    return false;
                }
            },
            self.hasPrevieus = function () {
                if (self.currentPage() > 0) {
                    return true;
                } else {
                    return false;
                }

            },
            self.page = ko.computed(function () {
                var size = self.itemPerPage();
                var start = self.currentPage() * size;
                self.displaySource(self.dataSource.slice(start, start + size));
                if (self.displaySource().length) {
                    self.currentRecord(self.displaySource()[0]);
                }
                return self.displaySource;
            }, self);
        self.itemPerPage.subscribe(function () { self.currentPage(0); });
        self.dataSource.subscribe(function () { self.currentPage(0); });
    };
})(window.app = window.app || {});