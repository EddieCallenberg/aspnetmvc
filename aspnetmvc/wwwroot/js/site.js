const showmenu = () => {
    document.getElementById('mobile-menu').classList.toggle('hide')
}

const checkScreenSize = () => {
    if (window.innerWidth >= 1200) {
        document.getElementById('mobile-menu').classList.remove('hide');
    } else {
        if (!document.getElementById('mobile-menu').classList.contains('hide')) {
            document.getElementById('mobile-menu').classList.add('hide');
        }
    }
};



window.addEventListener('resize', checkScreenSize);
checkScreenSize();