

function Mother($scope, $http) {
    $scope.newAge = 1;
    $http.get('Demo').success(function (data) {
        $scope.kids = data;
    });
    $scope.incrementAge = function () {
        this.kid.Age += 1;
    };
    $scope.Add = function () {
        var defaultName = "heyYou";
        $scope.kids.push({ "Name": $scope.newKid || defaultName, "Age": $scope.newAge });
        $scope.newKid = "";
    };
    $scope.remove = function () {
        //$scope.kids.pop(this.kid);
        this.kid.IsDeleted = true;
    };
    $scope.puke = function () {
        var msg = JSON.stringify($scope.kids);
        alert(msg);
    };
    $scope.save = function () {
        //$http.post('/someUrl', data).success(successCallback);
        $http.post('SaveKids', $scope.kids).success(function () {
//            $scope.refresh();
        });
    };
    $scope.refresh = function() {
        $http.get('Demo').success(function (data) {
            $scope.kids = data;
        });
    };
}
