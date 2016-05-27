angular.module('demoApp', [])
angular.module('demoApp').controller('productCtrl', function() {
    this.getProducten = () => {
        $http.get('api/product').then(reponse => {
            this.producten = response.data;
        })
    }
});