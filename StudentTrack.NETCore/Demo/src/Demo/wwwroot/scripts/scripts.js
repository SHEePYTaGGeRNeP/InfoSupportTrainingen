angular.module('demoApp', [])

angular.module('demoApp').controller('productCtrl', function ($http) {

    this.getProducten = () => {
        $http.get('api/product').then(response => {
            this.producten = response.data;
        });
    };
});