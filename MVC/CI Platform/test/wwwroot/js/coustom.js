//var navbar = document.getElementById("nav2-menu-button");
//console.log(navbar);


//navbar.addEventListener("click", function () {
//    console.log("clicked");
//});
////function openFilter() {


//    document.getElementById("header2sm").style.display = "none";
//    //document.getElementById("navbarSupportedContent").style.display = "none";
//    //document.getElementById("searchBar").style.display = "none";
//    //document.getElementById("FilterSupportedContent").style.marginLeft = "250px";
//}

//function closeFilter() {
//    document.getElementById("header2sm").style.display = "block";
//    //  document.getElementById("searchBar").style.display = "block";
//    //  document.getElementById("FilterSupportedContent").style.marginLeft = "250px";
//    //}


function showList(e) {
    var $gridCont = $('.grid-container');
    e.preventDefault();
    $gridCont.hasClass('list-view') ? $gridCont.removeClass('list-view') : $gridCont.addClass('list-view');
}
function gridList(e) {
    var $gridCont = $('.grid-container')
    e.preventDefault();
    $gridCont.removeClass('list-view');
}

$(document).on('click', '.btn-grid', gridList);
$(document).on('click', '.btn-list', showList);