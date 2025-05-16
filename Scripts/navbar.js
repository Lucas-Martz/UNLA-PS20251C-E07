window.addEventListener('scroll', function () {
    var nav = document.getElementById('navbar');
    if (window.pageYOffset > 50) {
        nav.classList.add('shrink');
    } else {
        nav.classList.remove('shrink');
    }
});