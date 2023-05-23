// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


    $(document).ready(function () {
        $('.info-tooltip2').tooltip();
    });



// Récupère tous les éléments avec la classe "word-info"
var wordElements = document.getElementsByClassName('word-info');

// Parcourt tous les éléments et ajoute les gestionnaires d'événements
Array.prototype.forEach.call(wordElements, function (element) {
    element.addEventListener('mouseenter', function () {
        showInfoPopup(this);
    });

    element.addEventListener('mouseleave', function () {
        hideInfoPopup();
    });
});

// Affiche la fenêtre contextuelle avec les informations
function showInfoPopup(element) {
    var info = element.getAttribute('data-info');
    // Crée et positionne la fenêtre contextuelle
    var popup = document.createElement('div');
    popup.className = 'info-popup';
    popup.textContent = info;
    element.appendChild(popup);
}

// Masque la fenêtre contextuelle
function hideInfoPopup() {
    var popup = document.getElementsByClassName('info-popup')[0];
    if (popup) {
        popup.parentNode.removeChild(popup);
    }
}