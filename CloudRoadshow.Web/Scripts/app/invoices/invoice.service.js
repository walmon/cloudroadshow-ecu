/**
 * Created by: Walter Montes, Enhance Solutions
 * walter@enhancesol.com
 * Created: 9/17/2015
 * Created for: Cloud Roadshow Ecuador
*/
(function () {
    'use strict';
    window.app.service('invoiceSvc', invoiceSvc);

    invoiceSvc.$inject = ['$http'];

    function invoiceSvc($http) {
        var svc = {
            getAll: getAll,
            insert: insert
        };
        return svc;
        function getAll() {
            return $http.get('/Home/GetAll');
        }
        function insert(invoice) {
            return $http({
                method: 'POST',
                url: '/Home/Insert',
                data: invoice
            });
        }
    }
})();