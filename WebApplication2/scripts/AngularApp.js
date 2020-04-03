var app = angular.module('myApp', []);


app.controller('myCtrl', function ($scope, $http) {
    $scope.CommentsData = null;
    $http.get('http://localhost:51975/api/Comments/GetAllComments').then(function (response) {
        $scope.CommentsData = JSON.parse(response.data);
    }, function (response) {
        //Second function handles error
        alert('Error Occured !!!' + response.status + '  ' + response.statusText);
    });




    $scope.comment = {
        Id: '',
        Text: '',
        File_name: '',
        File_content: '',
        Submit_date: ''
    };

    // Reset product details
    $scope.clear = function () {
        $scope.comment.Id = '';
        $scope.comment.Text = '';
        $scope.comment.File_content = '';
        $scope.comment.File_name = '';
        $scope.comment.Submit_date = '';
    }

    //Add New Item
    $scope.save = function () {
        if ($scope.comment.Text != "" && $scope.comment.File_name != "") {
            // Call Http request using $.ajax


            //$scope.comment.File_content = 'none';

            //var f = document.getElementById('file').files[0], r = new FileReader();
            //r.onloadend = function (e) {
            //    alert('hhh');
            //    var binary = "";
            //    var bytes = new Uint8Array(e.target.result);
            //    var length = bytes.byteLength;

            //    for (var i = 0; i < length; i++) {
            //        binary += String.fromCharCode(bytes[i]);
            //    }
                
            //    $scope.comment.File_content.data = (binary).toString();

            //}

            //alert($scope.comment.File_content.data);
            //r.readAsArrayBuffer(f);

            // or you can call Http request using $http
            $http({
                method: 'POST',
                url: 'http://localhost:51975/api/comments/Postcomments',
                data: $scope.comment
            }).then(function successCallback(response) {
                // this callback will be called asynchronously
                // when the response is available
                $scope.CommentsData.push(response.data);
                $scope.clear();
                alert("Product Added Successfully !!!");
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                alert("Error : " + response.data.ExceptionMessage);
            });
        }
        else {
            alert('Please Enter All the Values !!');
        }
    };


    // Delete  details
    $scope.delete = function (index) {
        $http({
            method: 'DELETE',
            url: 'http://localhost:51975/api/comments/Deletecomments/' + $scope.CommentsData[index].Id,
        }).then(function successCallback(response) {
            $scope.CommentsData.splice(index, 1);
            alert("comments Deleted Successfully !!!");
        }, function errorCallback(response) {
            alert("Error : " + response.data.ExceptionMessage);
        });
    };


});


