var app = angular.module('myApp', ['ngRoute','ui.bootstrap']);

app.config(function ($routeProvider) {
    $routeProvider

    .when('/', {
        templateUrl: 'Templates/home.html',
        controller: 'HomeController'
    })
});

app.controller('HomeController', ['$scope', '$uibModal', 'dataService', function ($scope, $uibModal, dataService) {
    $scope.submitClick = function () {
        var data = {
            BSBNo:$scope.bsbNo,
            AccountNo:$scope.accountNo,
            AccountName:$scope.accountName,
            Reference:$scope.reference,
            Amount:$scope.paymentAmount
        };

        dataService.save(data)
        .then(function (response) {
            var modal = $uibModal.open({
                templateUrl: 'Templates/Message.html',
                controller: function ($scope) {
                    $scope.closeClick = function () {
                        modal.close();
                    };                        
                },
                scope: $scope,
                resolve: {}
            });

            modal.result.then(function () {
                $scope.bsbNo = null;
                $scope.accountNo = null;
                $scope.accountName = null;
                $scope.reference = null;
                $scope.paymentAmount = null;
                $scope.paymentForm.$setPristine();
            });
        })
        .catch(function(response){})
        .finally(function (response){})
    };
}]);

app.factory('dataService', ['$http', function ($http) {
    var dataService = {
        save: function (data) {
            return $http.post('http://localhost/NexPay.com.au/API/PAYMENT/SAVE', data);
        }
    };

    return dataService;
}]);