/// <reference path="angular.min.js" />


var weddingApp = angular.module("MyModule", [])
                        .controller("CommonInfoController", function ($scope) {
                        
                        });

weddingApp.factory('GetCommonInfo', ['$http', function ($http) {

    var urlBase = '/api/WeddingAPI';
    var GetCommonInfo = {};
    GetCommonInfo.result = function () {
        return $http.get(urlBase + '/GetCommonInfo');
    };

    return GetCommonInfo;
}]);

weddingApp.controller('UpdateController', function ($scope, GetCommonInfo) {

    commonInfoData();

    function commonInfoData() {
        GetCommonInfo.result()
            .success(function (result) {
                $scope.AboutUs = result.AboutUs;
                $scope.Address = result.Address;
                $scope.AttendCount = result.AttendCount;
                $scope.BrideFullName = result.BrideFullName;
                $scope.BridemaidsContent = result.BridemaidsContent;
                $scope.BridesmaidCount = result.BridesmaidCount;
                $scope.ContactInfo = result.ContactInfo;
                $scope.CoupleInfo = result.CoupleInfo;
                $scope.CouplePictureUrl = result.CouplePictureUrl;
                $scope.GiftRegistryContent = result.GiftRegistryContent;
                $scope.GiftRegistryImageUrl = result.GiftRegistryImageUrl;
                $scope.GoogleMapAddress = result.GoogleMapAddress;
                $scope.GroomFullName = result.GroomFullName;
                $scope.GroomsmenContent = result.GroomsmenContent;
                $scope.GroomsmenCount = result.GroomsmenCount;
                $scope.GuestCount = result.GuestCount;
                $scope.WeddingDate = result.WeddingDate;
                $scope.StringWeddingDate = result.StringWeddingDate;
               

            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;

            });
    }
});

weddingApp.factory('GetEntityImages', ['$http', function ($http) {

    var urlBase = '/api/weddingapi';
    var GetEntityImages = {};
    GetEntityImages.result = function () {
        return $http.get(urlBase + '/GetCollectionEntityImages');
    };

    return GetEntityImages;
}]);


weddingApp.controller('EntityImageController', function ($scope, GetEntityImages, $http) {

    getEntities();

    $scope.deleteThis = function(response)
    {
        console.log(response);
        $http({
            method: 'POST',
            url: '/api/WeddingAPI/PostDeleteImage',
            data: {
                "EntityImageID": response
            }, //forms user object
            headers: { 'Content-Type': 'application/json' }
        })
         .success(function (data) {
             getEntities();
         });

    }
    function getEntities() {
        GetEntityImages.result()
            .success(function (result) {
                $scope.EntityOurMemoriesImages = result.OurMemoriesImages;
                $scope.EntityGroomsmenImages = result.GroomsmenImages;
                $scope.EntityBridesmaidImages = result.BridesmaidImages;
                $scope.EntityMainSliderImages = result.MainSliderImages;
            })
            .error(function (error) {
                $scope.status = 'Unable to load data: ' + error.message;

            });
    }
});


weddingApp.controller('postController', function ($scope, $http) {
    // create a blank object to handle form data.
    //$scope.user = {};
    // calling our submit function.
    $scope.submitForm = function () {
        // Posting data to php file
        //var f = document.getElementById('image').files[0];
        //console.log(f);
        //$http({
        //    method: 'POST',
        //    url: '/api/WeddingAPI/PostFileUpload',
        //    data: f,
        //    headers: { 'Content-Type': 'image/jpeg' }
        //})
        $http({
            method: 'POST',
            url: '/api/WeddingAPI/PostCommonInfo',
            data: {
                "AboutUs" : $scope.AboutUs,
                "Address": $scope.Address,
                "AttendCount": $scope.AttendCount,
                "BrideFullName": $scope.BrideFullName,
                "BridemaidsContent": $scope.BridemaidsContent,
                "BridesmaidCount": $scope.BridesmaidCount,
                "ContactInfo": $scope.ContactInfo,
                "CoupleInfo": $scope.CoupleInfo,
                "CouplePictureUrl": $scope.CouplePictureUrl,
                "GiftRegistryContent": $scope.GiftRegistryContent,
                "GiftRegistryImageUrl": $scope.GiftRegistryImageUrl,
                "GoogleMapAddress": $scope.GoogleMapAddress,
                "GroomFullName": $scope.GroomFullName,
                "GroomsmenContent": $scope.GroomsmenContent,
                "GroomsmenCount": $scope.GroomsmenCount,
                "GuestCount": $scope.GuestCount,
                "WeddingDate": $scope.WeddingDate,
                "StringWeddingDate": $scope.StringWeddingDate
            }, //forms user object
            headers: { 'Content-Type': 'application/json' }


        })
          .success(function (data) {
              if (data.errors) {
                  // Showing errors.
                  $scope.errorName = "Internal Server Error";
              } else {
                  $scope.message = data.Message;
              }
              console.log(data);
          });

       //var data = {
       //     "AboutUs" : $scope.AboutUs,
       //     "Address": $scope.Address,
       //     "AttendCount": $scope.AttendCount,
       //     "BrideFullName": $scope.BrideFullName,
       //     "BridemaidsContent": $scope.BridemaidsContent,
       //     "BridesmaidCount": $scope.BridesmaidCount,
       //     "ContactInfo": $scope.ContactInfo,
       //     "CoupleInfo": $scope.CoupleInfo,
       //     "CouplePictureUrl": $scope.CouplePictureUrl,
       //     "GiftRegistryContent": $scope.GiftRegistryContent,
       //     "GiftRegistryImageUrl": $scope.GiftRegistryImageUrl,
       //     "GoogleMapAddress": $scope.GoogleMapAddress,
       //     "GroomFullName": $scope.GroomFullName,
       //     "GroomsmenContent": $scope.GroomsmenContent,
       //     "GroomsmenCount": $scope.GroomsmenCount,
       //     "GuestCount": $scope.GuestCount,
       //     "WeddingDate": $scope.WeddingDate,
       //     "StringWeddingDate": $scope.StringWeddingDate
       //}

       //console.log(data);
    };
});


weddingApp.controller("PostLoveStoryController", function ($scope, $http) {
    $scope.TemplateId = 1;
    $scope.submit = function () {

        console.log($scope.ImageUrl);
    $http({
        method: 'POST',
        url: "/api/WeddingAPI/PostNewLoveStory",
        data: {
            "Title1": $scope.Title1,
            "Title2": $scope.Title2,
            "Content": $scope.Content,
            "CommentBy": $scope.CommentBy,
            "PublishDate": $scope.PublishDate,
            "SpecialComment": $scope.SpecialComment,
            "TemplateId": $scope.TemplateId,
            "ImageUrl": $scope.ImageUrl
        },
        headers: { 'Content-Type': 'application/json' }

    })
    //Message

    .success(function (data) {
        if (data.errors) {
            // Showing errors.
            $scope.errorName = "Internal Server Error";
        } else {
            $scope.message = data.Message;
        }
        console.log(data);
    });
    }
});


weddingApp.controller("PostEventController", function ($scope, $http) {


    $scope.submitEvent = function () {

        $http({
            method: 'POST',
            url: "/api/WeddingAPI/PostNewEvent",
            data: {
                "Title": $scope.Title,
                "EventLocation": $scope.EventLocation,
                "EventContent": $scope.EventContent

            },
            headers: { 'Content-Type': 'application/json' }

        })
        .success(function (data) {
            if (data.errors) {
                // Showing errors.
                $scope.errorName = "Internal Server Error";
            } else {
                $scope.message = data.Message;
            }
            console.log(data);
        });
    }
});

weddingApp.controller("DeleteLovStory", function ($scope, $http){

    $scope.deleteThis = function (data) {

        $http({
            method: 'POST',
            url: '/api/WeddingAPI/PostDeleteLoveStory',
            data: {
                "OurStoryID": data
            }, //forms user object
            headers: { 'Content-Type': 'application/json' }
        })
          .success(function (data) {
              //getEntities();
          });
    }

});