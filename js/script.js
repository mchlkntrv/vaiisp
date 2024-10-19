function toggleHeart(icon) {
    const isLiked = icon.classList.contains('fa-solid');

    if (isLiked) {
        icon.className = 'fa-regular fa-heart';
        icon.style.color = '';
    } else {
        icon.className = 'fa-solid fa-heart';
        icon.style.color = 'red'; 
    }
}
