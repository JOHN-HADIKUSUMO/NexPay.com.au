describe('app', function () {
    var input = {
        BSBNo: '420377',
        AccountNO: '90031551',
        AccountName: 'John Doe',
        Reference: 'Billing Payment',
        Amount: 425.25
    };

    var output = { "status": true }

    var dataService = {};

    beforeEach(module('myApp'));
    beforeEach(module('ngRoute'));
    beforeEach(module('ui.bootstrap'));


    beforeEach(angular.mock.inject(function (_dataService_) {
        dataService = _dataService_;
    }));

    it('Save Bank Payment', function () {
        expect(dataService.save(input)).toEqual(output);
    });
});