function updateRating(carId) {
    const badge = document.querySelector(`.card[data-car-id="${carId}"] .badge`);
    fetch(`/api/ReviewApi/average-rating/${carId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to fetch');
            }
            return response.json();
        })
        .then(data => {
            if (data.averageRating !== undefined) {
                badge.textContent = data.averageRating
                    ? `Rating: ${data.averageRating.toFixed(1)}/5.0`
                    : "No Reviews";
            } else {
                badge.textContent = "Error fetching rating";
            }
        })
        .catch(() => {
            badge.textContent = "Error";
        });
}
window.onload = function () {
    document.querySelectorAll('.card').forEach(card => {
        const carId = card.getAttribute('data-car-id');
        if (carId) {
            updateRating(carId);
        }
    });
};
