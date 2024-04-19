const centersData = [
  {
    "logo": "../assets/eyouth.webp",
    "center": "منصة ايوث التعليمية"
  },
  {
    "logo": "../assets/eyouth.webp",
    "center": "منصة ايوث التعليمية"
  },
  {
    "logo": "../assets/eyouth.webp",
    "center": "منصة ايوث التعليمية"
  }
]

const centersContainer = document.querySelector(".centers");

centersData.forEach((data, index) => {
  // Create elements
  const cardDiv = document.createElement("div");
  const img = document.createElement("img");
  const text = document.createElement("p");

  cardDiv.classList.add("card");
  cardDiv.classList.add("border-0");
  cardDiv.classList.add("col-12"); 
  cardDiv.classList.add("col-sm-6"); 
  cardDiv.classList.add("col-md-3"); 
  cardDiv.classList.add("col-lg-3");
  cardDiv.style.flexWrap = "wrap";
  img.src = data.logo;
  img.alt = data.center;
  img.classList.add("card-img-top", "grayscale"); // Add grayscale class
  text.classList.add("card-text");
  text.classList.add("text-center");
  text.textContent = data.center;

  // Append elements to the card div
  cardDiv.appendChild(img);
  cardDiv.appendChild(text);

  // Append the card div to the container
  
  centersContainer.appendChild(cardDiv);
  centersContainer.style.flexWrap = "wrap";
});








// Call the function for each counter
//animateCounterWhenVisible("trainings-counter", endNumbers.trainings);
//animateCounterWhenVisible("face-to-face-counter", endNumbers.faceToFace);
//animateCounterWhenVisible("trainers-stats-counter", endNumbers.trainersStats);
//animateCounterWhenVisible("centers-visitors-counter", endNumbers.centersVisitors);

function isHorizontallyCentered(element) {
    const elementRect = element.getBoundingClientRect();
    const screenWidth = window.innerWidth;
    const screenCenter = screenWidth / 2;

    console.log(screenCenter, 'value');

    return Math.abs(elementRect.left + elementRect.width / 2 - screenCenter) < 1;
}

// Function to handle scroll event
function handleScroll() {
    const screenWidth = window.innerWidth;
    const screenCenterX = screenWidth / 2;

    logoImages.forEach(img => {
        const rect = img.getBoundingClientRect();
        const imgCenterX = rect.left + rect.width / 2;

        if (Math.abs(imgCenterX - screenCenterX) < 50) {
            img.classList.add('centered');
        } else {
            img.classList.remove('centered');
        }
    });
}

// Callback function for mutation observer
const handleMutation = function (mutationsList, observer) {
    for (let mutation of mutationsList) {
        if (mutation.type === 'childList') {
            // Call handleScroll when there is a change in the child list
            handleScroll();
        }
    }
};

// Create a new observer instance
const observer = new MutationObserver(handleMutation);

// Start observing the .logos div for changes in child elements
observer.observe(document.querySelector('.logos'), { childList: true });

// Get all img elements inside .logos div
const logoImages = document.querySelectorAll('.partner-logo');


handleScroll();


setInterval(handleScroll, 1000);

