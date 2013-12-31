
if (!window.console) { window.console = function () { }; }

function Mother($scope, $http) {
    $scope.refresh = function() {
        $http.get('GetKids').success(function(data) {
                $scope.kids = data;
            })
            .error(function(data) {
                console.log("error: " + data);
            });
    };

    $scope.newAge = 1;
    $scope.refresh();

    $scope.incrementAge = function() {
        this.kid.Age += 1;
    };

    $scope.decrementAge = function() {
        this.kid.Age -= 1;
    };

    $scope.Add = function() {
        var defaultName = "heyYou";
        $scope.kids.push({ "Name": $scope.newKid || defaultName, "Age": $scope.newAge });
        $scope.newKid = "";
    };

    $scope.remove = function() {
        this.kid.IsDeleted = true;
    };

    $scope.unremove = function() {
        this.kid.IsDeleted = false;
    };

    $scope.puke = function() {
        var msg = JSON.stringify($scope.kids);
        alert(msg);
    };

    $scope.save = function() {
        console.log("saving");
        $http.post('SaveKids', $scope.kids).success(function() {
            console.log("saved");
        }).then( function (){
            $scope.refresh();
        });
    };

    $scope.ShowKid = function() {
        this.kid.clikd = true;
    };
    $scope.AgeToggle = function() {
        this.kid.ageClikd = !this.kid.ageClikd;
    };

    $scope.HideKid = function() {
        this.kid.clikd = false;
    };
}


var app = angular.module('app', []);
app.directive('myEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngEnter);
                });
                event.preventDefault();
            }
        });
    };
});

//focus directive
app.directive('myFocus', function () {
    return {
        restrict: 'A',
        link: function (scope, element, attr) {
            scope.$watch(attr.myFocus, function (n, o) {
                if (n != 0 && n) {
                    element[0].focus();
                }
            });
        }
    };
});