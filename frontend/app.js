const API_URL = "/places";

const searchInput = document.getElementById("search");
const categorySelect = document.getElementById("category");
const latitudeInput = document.getElementById("latitude");
const longitudeInput = document.getElementById("longitude");
const distanceInput = document.getElementById("distance");
const statusEl = document.getElementById("status");
const placesEl = document.getElementById("places");

let currentPlaces = [];

// Leaflet map with OpenStreetMap tiles
const map = L.map("map").setView([52.52, 13.405], 12);
L.tileLayer("https://tile.openstreetmap.org/{z}/{x}/{y}.png", {
  maxZoom: 19,
  attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a>',
}).addTo(map);
const markerLayer = L.layerGroup().addTo(map);
let searchMarker = null;

// Click on the map sets the position for the nearby search
map.on("click", (e) => {
  latitudeInput.value = e.latlng.lat.toFixed(5);
  longitudeInput.value = e.latlng.lng.toFixed(5);
  updateSearchMarker();
});

function updateSearchMarker() {
  const latlng = [Number(latitudeInput.value), Number(longitudeInput.value)];
  if (searchMarker) {
    searchMarker.setLatLng(latlng);
  } else {
    searchMarker = L.circleMarker(latlng, { radius: 8, color: "#c62828" }).addTo(map);
    searchMarker.bindTooltip("Suchposition");
  }
}

function renderMap(places) {
  markerLayer.clearLayers();
  places.forEach((place) => {
    const marker = L.marker([place.latitude, place.longitude]).addTo(markerLayer);
    marker.bindPopup(
      `<strong>${escapeHtml(place.name)}</strong><br>${escapeHtml(place.category)}<br>` +
      `${escapeHtml(place.district)}, ${escapeHtml(place.city)}<br>Bewertung: ${place.rating} ★`
    );
    place.marker = marker;
  });
  if (places.length > 0) {
    map.fitBounds(L.latLngBounds(places.map((p) => [p.latitude, p.longitude])), { padding: [30, 30], maxZoom: 15 });
  }
}

function escapeHtml(text) {
  const div = document.createElement("div");
  div.textContent = text;
  return div.innerHTML;
}

async function fetchPlaces(url) {
  setStatus("Lade Orte ...");
  try {
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error(`HTTP ${response.status}`);
    }
    currentPlaces = await response.json();
    render();
  } catch (error) {
    currentPlaces = [];
    placesEl.innerHTML = "";
    setStatus(`Orte konnten nicht geladen werden: ${error.message}`, true);
  }
}

function setStatus(text, isError = false) {
  statusEl.textContent = text;
  statusEl.className = isError ? "error" : "";
}

function render() {
  const term = searchInput.value.trim().toLowerCase();
  const filtered = currentPlaces.filter((p) =>
    !term ||
    p.name.toLowerCase().includes(term) ||
    p.district.toLowerCase().includes(term) ||
    p.tags.some((t) => t.toLowerCase().includes(term))
  );

  placesEl.innerHTML = "";
  filtered.forEach((place) => placesEl.appendChild(createCard(place)));
  renderMap(filtered);
  setStatus(`${filtered.length} Orte gefunden`);
}

function createCard(place) {
  const card = document.createElement("article");
  card.className = "card";

  const title = document.createElement("h2");
  title.textContent = place.name;

  const category = document.createElement("span");
  category.className = "category";
  category.textContent = place.category;

  const address = document.createElement("p");
  address.textContent = `${place.district}, ${place.city}`;

  const rating = document.createElement("p");
  rating.textContent = `Bewertung: ${place.rating} ★`;

  const tags = document.createElement("p");
  tags.className = "tags";
  place.tags.forEach((tag) => {
    const span = document.createElement("span");
    span.textContent = tag;
    tags.appendChild(span);
  });

  card.append(title, category, address, rating, tags);
  // Click on a card: zoom to the place and open its popup
  card.addEventListener("click", () => {
    map.setView([place.latitude, place.longitude], 16);
    place.marker.openPopup();
    document.getElementById("map").scrollIntoView({ behavior: "smooth", block: "center" });
  });
  return card;
}

async function loadCategories() {
  try {
    const response = await fetch(API_URL);
    const places = await response.json();
    const categories = [...new Set(places.map((p) => p.category))].sort();
    categories.forEach((c) => {
      const option = document.createElement("option");
      option.value = c;
      option.textContent = c;
      categorySelect.appendChild(option);
    });
    currentPlaces = places;
    render();
  } catch (error) {
    setStatus(`Orte konnten nicht geladen werden: ${error.message}`, true);
  }
}

function loadAll() {
  fetchPlaces(API_URL);
}

categorySelect.addEventListener("change", () => {
  const category = categorySelect.value;
  if (category) {
    fetchPlaces(`${API_URL}/category/${encodeURIComponent(category)}`);
  } else {
    loadAll();
  }
});

searchInput.addEventListener("input", render);

document.getElementById("nearbyBtn").addEventListener("click", () => {
  const params = new URLSearchParams({
    latitude: latitudeInput.value,
    longitude: longitudeInput.value,
    maxDistanceInMeters: distanceInput.value,
  });
  categorySelect.value = "";
  fetchPlaces(`${API_URL}/nearby?${params}`);
});

document.getElementById("locate").addEventListener("click", () => {
  if (!navigator.geolocation) {
    setStatus("Geolocation wird vom Browser nicht unterstützt.", true);
    return;
  }
  navigator.geolocation.getCurrentPosition(
    (pos) => {
      latitudeInput.value = pos.coords.latitude.toFixed(5);
      longitudeInput.value = pos.coords.longitude.toFixed(5);
      updateSearchMarker();
      map.setView([pos.coords.latitude, pos.coords.longitude], 14);
    },
    () => setStatus("Standort konnte nicht ermittelt werden.", true)
  );
});

document.getElementById("reset").addEventListener("click", () => {
  searchInput.value = "";
  categorySelect.value = "";
  loadAll();
});

loadCategories();
