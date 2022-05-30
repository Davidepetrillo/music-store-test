var heartContainer = document.getElementsByClassName('icon-wrapper');

Object.keys(heartContainer).forEach(singleElement => {

    heartContainer[singleElement].addEventListener('click', function () {
        if (heartContainer[singleElement].classList.contains('liked')) {
            heartContainer[singleElement].classList.add('unliked');
            heartContainer[singleElement].classList.remove('liked');
            setTimeout(unlikeRemover, 250);
        }
        else {
            heartContainer[singleElement].classList.add('liked');
            heartContainer[singleElement].classList.remove('unliked');
        }

        function unlikeRemover() {
            heartContainer[singleElement].classList.remove('unliked');
        }
    });

});