const showmenu = () => {
    if (document.getElementById('mobile-menu').classList.contains('hide')) {
        document.getElementById('mobile-menu').classList.remove('hide')
        document.getElementById('mobile-menu-icon').classList.remove('fa-bars')
        document.getElementById('mobile-menu-icon').classList.add('fa-xmark')
    } else {
        document.getElementById('mobile-menu').classList.add('hide')
        document.getElementById('mobile-menu-icon').classList.remove('fa-xmark')
        document.getElementById('mobile-menu-icon').classList.add('fa-bars')
    }
}