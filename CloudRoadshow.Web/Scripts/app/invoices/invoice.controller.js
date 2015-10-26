/**
 * Created by: Walter Montes, Enhance Solutions
 * walter@enhancesol.com
 * Created: 9/17/2015
 * Created for: Cloud Roadshow Ecuador
*/
(function () {
    'use strict';

    window.app.controller('InvoiceCtrl', InvoiceCtrl);

    InvoiceCtrl.$inject = ['$scope', 'invoiceSvc'];

    function InvoiceCtrl($scope, invoiceSvc) {
        var vm = this;
        vm.newInvoice = {};
        vm.loaded = false;
        vm.save = saveInvoice;
        vm.addLine = addLine;

        invoiceSvc.getAll().then(function (items) {
            console.log(items.data);
                vm.invoices = items.data;            
        }, function (err) {
            alert('Error inesperado cargando las facturas');
            console.log(err);
        });

        function addLine(newLine) {
            if (isNaN(newLine.cant) || isNaN(newLine.amount) ||
                !newLine.description)
                return;
            if (vm.newInvoice.lines === undefined) {
                vm.newInvoice.lines = [];
                newLine.Id = 1;
            } else {
                newLine.Id = vm.newInvoice.lines.length + 1;
            }

            vm.newInvoice.lines.push({
                cant: newLine.cant,
                description: newLine.description,
                amount: newLine.amount
            });

            calculateTotalNewInvoice();
            vm.newLine = {};
        }
        function saveInvoice(newInvoice) {
            if (vm.invoices === undefined)
                vm.invoices = [];
            var clearedInvoice = JSON.parse(JSON.stringify(newInvoice));
            vm.invoices.push(clearedInvoice);

            invoiceSvc.insert(clearedInvoice).then(function () {
                console.log('success');
            }, function (err) {
                alert('Error inesperado creando la factura');
                console.log(err);
            });

            vm.newInvoice = {};
        }
        function calculateTotalNewInvoice() {
            var sum = 0;
            if (vm.newInvoice.lines !== undefined) {
                for (var i = 0; i < vm.newInvoice.lines.length; i++) {
                    sum += parseFloat(vm.newInvoice.lines[i].amount);
                }
            }
            vm.newInvoice.total = sum;
        }
    }

})();