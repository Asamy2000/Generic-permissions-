const itemsPerPage = 2;
let currentPage = 1;

// Demo data replace it
const data = [
  {
    title: "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
    image: "../assets/whats-new/whats-new.jpg",
    date: "30 يناير 2024",
    content: "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
    source: "إدارة الإعلام - بمحافظة القاهرة",
  },
  {
    title: "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
    image: "../assets/whats-new/whats-new.jpg",
    date: "30 يناير 2024",
    content: "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
    source: "إدارة الإعلام - eeeeبمحافظة القاهرة",
  },
  {
    title: "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
    image: "../assets/whats-new/whats-new.jpg",
    date: "30 يناير 2024",
    content: "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
    source: "إدارة الإعلام -222 بمحافظة القاهرة",
  },
  {
    title: "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
    image: "../assets/whats-new/whats-new.jpg",
    date: "30 يناير 2024",
    content: "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
    source: "إدارة الإعلام -11111 بمحافظة القاهرة",
  },
  {
    title: "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
    image: "../assets/whats-new/whats-new.jpg",
    date: "30 يناير 2024",
    content: "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
    source: "إدارة الإعلام -222 بمحافظة القاهرة",
  },
  {
    title: "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
    image: "../assets/whats-new/whats-new.jpg",
    date: "30 يناير 2024",
    content: "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
    source: "إدارة الإعلام -11111 بمحافظة القاهرة",
  },
];

const totalPages = Math.ceil(data.length / itemsPerPage);

// Pagination logic
let paginationHTML = "";
paginationHTML += `<button class="page-btn prev-page" disabled>&lt;</button>`;
for (let i = 0; i < totalPages; i++) {
  paginationHTML += `<a href="#" class="page-number ${i === 0 ? "active" : ""}" onclick="showPage(${i + 1}, data)">${i + 1}</a>`;
}
paginationHTML += `<button class="page-btn next-page">${totalPages > 1 ? "&gt;" : ""}</button>`;
$(".pagination").html(paginationHTML);

// Function to update pagination buttons
function updatePaginationButtons() {
  $(".prev-page").prop("disabled", currentPage === 1);
  $(".next-page").prop("disabled", currentPage === totalPages);
}

// Function to display specific page
function showPage(pageNumber, data) {
  let startIndex = (pageNumber - 1) * itemsPerPage;
  let endIndex = startIndex + itemsPerPage;
  let pageData = data.slice(startIndex, endIndex);

  // Generate HTML for cards
  // let cardsHTML = '';
  // pageData.forEach(function(item) {
  //     cardsHTML += `
  //     <div class="card">
  //         <h5 class="card-header">${item.title}</h5>
  //         <img src="${item.image}" alt="new" class="card-img">
  //         <div class="card-text">
  //             <img src="../assets/whats-new/clock.png" alt="clock">
  //             <small class="text-muted">${item.date}</small>
  //         </div>
  //         <div class="card-text">${item.content}</div>
  //         <div class="card-title">${item.source}</div>
  //     </div>
  //     `;
  // });

  // $('.whats-new-content').html(cardsHTML);

  // Update active class for pagination links
  $(".page-number").removeClass("active");
  $(`.page-number:nth-child(${pageNumber + 1})`).addClass("active");

  currentPage = pageNumber;

  updatePaginationButtons();
}

$(".prev-page").on("click", function () {
  if (currentPage > 1) {
    showPage(currentPage - 1, data);
  }
});

$(".next-page").on("click", function () {
  if (currentPage < totalPages) {
    showPage(currentPage + 1, data);
  }
});

// Initial display of first page
showPage(1, data);
