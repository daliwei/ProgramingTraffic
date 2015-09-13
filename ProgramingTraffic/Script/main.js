function SetPanel() {
    var currentTop = $(window).scrollTop();
    //check if user is scrolling up
    var rowpanelwidth = parseFloat($('#panel-row').css("width").replace('px', '')) * 0.2;
    console.log(rowpanelwidth);
    $('.panel-category').css("width", rowpanelwidth + 'px');
    if (currentTop > 510) {
        $('.panel-category').css("position", 'fixed');
        $('.panel-category').css("top", '80px');
        var panel_cat_height = parseInt($('.panel-category').css("height").replace('px', ''));
        $('.panel-tag').css("position", 'fixed');
        var pos = panel_cat_height + 100;
        $('.panel-tag').css("top", pos + 'px');
        console.log(pos);
    }
    else {
        $('.panel-category').css("position", 'absolute');
        $('.panel-category').css("top", '0px');
        var panel_cat_height = parseInt($('.panel-category').css("height").replace('px', ''));
        console.log(panel_cat_height);
        $('.panel-tag').css("position", 'absolute');
        var pos = panel_cat_height + 20;
        $('.panel-tag').css("top", pos + 'px');
        console.log(pos);
    }
}


var url = "/BlogEF/Category";
//set category and tag panels
function loadcategorytags() {
    $.post(url,
        {},
        function(data)
        {
            for (i in data)
            {
                $("#panel-cate-id").append(data[i].element);
            }

            SetPanel();
        }
     );
};

$(document).ready(function () {
    loadcategorytags();
    SetPanel();
});