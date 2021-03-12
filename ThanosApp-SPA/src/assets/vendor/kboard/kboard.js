$(window).on('load resize', function() {
    if($(window).innerWidth() < 992) {
        $('.scrum-body').addClass('list');
    } else {
        $('.scrum-body').removeClass('list');
    }
});


function dragover(ev) {
    ev.preventDefault();
    ev.dataTransfer.dropEffect = "move";
}

function dragstart(ev) {
    ev.dataTransfer.setData("text/plain", ev.target.id);
    ev.dataTransfer.effectAllowed = "move";
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.closest('.scrum-board-column').appendChild(document.getElementById(data));
}