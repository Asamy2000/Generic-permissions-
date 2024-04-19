const customDropdowns = document.querySelectorAll(".dropdown-news");
let selectedValue = null;

const itemsPerPage = 20;
let currentPage = 1;

// Demo data replace it
const NewsData = [
    {
        "title": "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
        "image": "../assets/whats-new/whats-new.jpg",
        "date": "30 يناير 2024",
        "content": "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
        "source": "إدارة الإعلام - بمحافظة القاهرة"
    },
    {
        "title": "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
        "image": "../assets/whats-new/whats-new.jpg",
        "date": "30 يناير 2024",
        "content": "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
        "source": "إدارة الإعلام - eeeeبمحافظة القاهرة"
    },
    {
        "title": "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
        "image": "../assets/whats-new/whats-new.jpg",
        "date": "30 يناير 2024",
        "content": "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
        "source": "إدارة الإعلام -222 بمحافظة القاهرة"
    },
    {
        "title": "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
        "image": "../assets/whats-new/whats-new.jpg",
        "date": "30 يناير 2024",
        "content": "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
        "source": "إدارة الإعلام -11111 بمحافظة القاهرة"
    },
    {
        "title": "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
        "image": "../assets/whats-new/whats-new.jpg",
        "date": "30 يناير 2024",
        "content": "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
        "source": "إدارة الإعلام -222 بمحافظة القاهرة"
    },
    {
        "title": "فرع جديد للأكاديمية المهنية للمعلمين بجامعة الاسكندرية",
        "image": "../assets/whats-new/whats-new.jpg",
        "date": "30 يناير 2024",
        "content": "اعتمد السيد اللواء/ خالد عبد العال ـ محافظ القاهرة نتيجة امتحانات الفصل الدراسي الأول لشهادة إتمام التعليم الأساسي (الشهادة الإعدادية) للعام 2023/ 2024 بنسبة نجاح 78.4% ...",
        "source": "إدارة الإعلام -11111 بمحافظة القاهرة"
    }
];

const totalPages = Math.ceil(NewsData.length / itemsPerPage);

customDropdowns.forEach((dropdown) => {
    const select = dropdown.querySelector(".select");
    const caret = dropdown.querySelector(".caret");
    const menu = dropdown.querySelector(".menu");
    const options = dropdown.querySelectorAll(".menu li");
    const selected = dropdown.querySelector(".selected");

    let selectedOption = null;

    select.addEventListener("click", () => {
        caret.classList.toggle("caret-rotate");
        menu.classList.toggle("menu-open");
    });

    options.forEach((option) => {
        option.addEventListener("click", () => {
            selectedOption = option.innerText;
            selectedValue = selectedOption;
            selected.classList.remove("placeholder");
            selected.innerText = selectedOption;
            caret.classList.remove("caret-rotate");
            menu.classList.remove("menu-open");
            options.forEach((opt) => opt.classList.remove("active"));
            option.classList.add("active");
        });
    });
});


let paginationHTML = '';
paginationHTML += `<button class="page-btn prev-page" disabled>&lt;</button>`;
for (let i = 0; i < totalPages; i++) {
    paginationHTML += `<a href="#" class="page-number ${i === 0 ? 'active' : ''}" onclick="showPage(${i + 1}, NewsData)">${i + 1}</a>`;
}
paginationHTML += `<button class="page-btn next-page">${totalPages > 1 ? '&gt;' : ''}</button>`;
$('.pagination').html(paginationHTML);

function updatePaginationButtons() {
    $('.prev-page').prop('disabled', currentPage === 1);
    $('.next-page').prop('disabled', currentPage === totalPages);
}

function showPage(pageNumber, data) {
    let startIndex = (pageNumber - 1) * itemsPerPage;
    let endIndex = startIndex + itemsPerPage;
    let pageData = data.slice(startIndex, endIndex);

    let cardsHTML = '';
    pageData.forEach(function (item) {
        cardsHTML += `
            <div class="card col-md-3">
                <img src="${item.image}" alt="new" class="card-img">
                <h6 class="card-text">${item.content}</h6>
                <div class="date-container" >
                    <small class="text-muted">${item.date}</small>
                    <a href="#" class='read-more'>تابع القراءة</a>
                </div>
            </div>
            `;
    });

    $('.all-news-gallery').html(cardsHTML);

    $('.page-number').removeClass('active');
    $(`.page-number:nth-child(${pageNumber})`).addClass('active');

    currentPage = pageNumber;

    updatePaginationButtons();
}

$('.prev-page').on('click', function () {
    if (currentPage > 1) {
        showPage(currentPage - 1, NewsData);
    }
});

$('.next-page').on('click', function () {
    if (currentPage < totalPages) {
        showPage(currentPage + 1, NewsData);
    }
});

showPage(1, NewsData);

const latestNewCards = document.querySelectorAll('.latest-new-card');

latestNewCards.forEach(card => {
    card.addEventListener('click', () => {
        card.querySelector('.latest-img-container').classList.toggle('red-layer');
    });
});
