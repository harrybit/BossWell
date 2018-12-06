var clients = [];
$(function () {
    clients = $.clientsInit();
    if(clients.authorizeMenu==null || clients.authorizeMenu.length<1)
    {
        alert("缓存已失效，请重新登录");
        setTimeout(function () {
            window.location.href = "/";
        }, 500);
    }
})
$.clientsInit = function () {
    var dataJson = {
        dataItems: [],
        organize: [],
        role: [],
        duty: [],
        user: [],
        authorizeMenu: [],
        authorizeButton: []
    };
    var init = function () {
        $.ajax({
            url: "/ClientsData/GetClientsDataJson",
            type: "get",
            dataType: "json",
            async: false,
            success: function (data) {
                dataJson.dataItems = [];
                dataJson.organize = [];
                dataJson.role = [];
                dataJson.duty = [];
                dataJson.authorizeMenu = eval(data.authorizeMenu);
                dataJson.authorizeButton = data.authorizeButton;
            }
        });
    }
    init();
    return dataJson;
}