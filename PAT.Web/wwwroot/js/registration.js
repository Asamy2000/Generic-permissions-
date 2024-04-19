var governorateDropdown = $('#governorate');
var dropdown1 = $('#dropdown1');
var dropdown2 = $('#dropdown2');
var dropdown1Data = ["معلم", "معلم اول", "معلم اول أ"];
var dropdown2Data = ["مدرسة ابتدائى", "مدرسه اعدادى", "مدرسه ثانوى"];
var governorates = ["القاهرة",
    "الإسكندرية",
    "الجيزة",
    "القليوبية",
    "الشرقية",
    "المنوفية",
    "الغربية",
    "البحيرة",
    "الفيوم",
    "المنيا",
    "الشرقية",
    "أسيوط",
    "الوادي الجديد",
    "بني سويف",
    "المنوفية",
    "المنيا",
    "الجيزة",
    "البحيرة",
    "القليوبية",
    "أسوان",
    "قنا",
    "الإسماعيلية",
    "السويس",
    "البحر الأحمر",
    "الدقهلية",
    "سوهاج",
    "المنيا",
    "دمياط",
    "المنوفية",
    "قنا",
    "الغربية",
    "الفيوم",
    "أسوان",
    "البحر الأحمر",
    "الإسماعيلية",
    "كفر الشيخ",
    "القاهرة"];

 // Populate Governorates dropdown dynamically
$.each(governorates, function (i, governorate) {
    governorateDropdown.append($('<option>').text(governorate).attr('value', governorate));
});

// Populate dropdowns 1 and 2 dynamically from JSON file 
// Example:
$.each(dropdown1Data, function (i, value) {
    dropdown1.append($('<option>').text(value).attr('value', value));
});

$.each(dropdown2Data, function (i, value) {
    dropdown2.append($('<option>').text(value).attr('value', value));
});


function validateForm() {
    // Add form validation logic here
    return true;
}

function togglePasswordVisibility(inputId, iconId) {
    var passwordInput = document.getElementById(inputId);
    var icon = document.getElementById(iconId);

    if (passwordInput.type === "password") {
        passwordInput.type = "text";
        icon.classList.remove("fa-eye");
        icon.classList.add("fa-eye-slash");
    } else {
        passwordInput.type = "password";
        icon.classList.remove("fa-eye-slash");
        icon.classList.add("fa-eye");
    }
}