angular.module('demoApp', []);

angular.module('demoApp').controller('productCtrl',
    function ($http) {

        this.getProducten = () => {
            $http.get('api/product')
                .then(response => {
                    this.producten = response.data;
                });
        };

        this.newProduct = () => {
            $http.post('api/product', this.newProduct)
                .then(() => {
                    this.producten.push(this.newProduct);
                    delete this.newProduct;
                });
        };
    });

angular.module('demoApp').controller('homeCtrl', function ($http) {
    this.getItems = () => {
        $http.get('/getTodoItems')
            .then(response => {
                this.todoitems = response.data;
            });
    };
});