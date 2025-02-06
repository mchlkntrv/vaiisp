async function searchMinerals() {
    const searchTerm = document.getElementById('searchInput').value;

    if (searchTerm) {
        const response = await fetch(`http://localhost:5023/api/mineral/search?query=${encodeURIComponent(searchTerm)}`,
            {
                method: 'GET'
            });

        if (response.ok) {
            const minerals = await response.json(); 
            updateMineralList(minerals);
        }
    } else {
        const response = await fetch('http://localhost:5023/api/mineral');
        if (response.ok) {
            const minerals = await response.json();
            updateMineralList(minerals);
        }
    }
}

function updateMineralList(minerals) {
    const mineralsContainer = document.getElementById('mineralsContainer');
    mineralsContainer.innerHTML = '';

    minerals.forEach(mineral => {
        const mineralCard = `
            <div class="col-sm-6 col-md-6 col-lg-3 mb-4 d-flex">
                <div class="card mineral-card flex-fill">
                    <div class="card-body d-flex flex-column">
                        <img src="images/minerals/${mineral.name}.jpg" class="card-img-top" alt="${mineral.name}">
                        <h5 class="card-title font-weight-bold d-flex justify-content-between align-items-center">
                            ${mineral.name}
                            <span>
                                <i class="fa-solid fa-plus" title="Pridať do kolekcie"></i>
                            </span>
                        </h5>
                        <p class="no-margin"> Chemický vzorec: </p>
                        <p class="mineral-card-formula">${mineral.formula}</p>
                        <p class="card-text">${mineral.information}</p>
                        <a href="/mineral/${mineral.id}" class="mineral-card-link mt-auto">Prečítať si viac...</a>
                    </div>
                </div>
            </div>
        `;
        mineralsContainer.innerHTML += mineralCard;
    });
}
