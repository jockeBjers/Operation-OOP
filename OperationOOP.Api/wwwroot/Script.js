fetch('https://localhost:7154/beer')
.then(response => response.json())
.then(data => {
    var beerList = document.getElementById("beerList");

    data.forEach(beer => {
        var li = document.createElement("li");
        li.textContent = beer.name + " - " + beer.price + " kr";
        beerList.appendChild(li);
    });
})
.catch(error => {
    console.error('Error:', error);
});

fetch('https://localhost:7154/wine')
.then(response => response.json())
.then(data => {
    var wineList = document.getElementById("wineList");

    data.forEach(wine => {
        var li = document.createElement("li");
        li.textContent = wine.name + " - " + wine.price + " kr";
        wineList.appendChild(li);
    });
})
.catch(error => {
    console.error('Error:', error);
});


fetch('https://localhost:7154/soda')
.then(response => response.json())
.then(data => {
    var sodaList = document.getElementById("sodaList");

    data.forEach(soda => {
        var li = document.createElement("li");
        li.textContent = soda.name + " - " + soda.price + " kr";
        sodaList.appendChild(li);
    });
})
.catch(error => {
    console.error('Error:', error);
});