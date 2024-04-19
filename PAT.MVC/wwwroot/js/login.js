function validateForm() {
    var userNumber = document.getElementById("userNumber").value;
    var password = document.getElementById("password").value;
    var userNumberError = document.getElementById("userNumberError");
    var passwordError = document.getElementById("passwordError");
    var loginButton = document.getElementById("loginButton");
    var isValid = true;

    // Validate userNumber length
    if (userNumber.trim().length !== 14) {
        userNumberError.textContent = "الرقم القومي يجب أن يتكون من 14 رقمًا";
        isValid = false;
    } else {
        userNumberError.textContent = ""; 
    }

    // Validate password
    if (password.trim() === "") {
        passwordError.textContent = "يرجى إدخال كلمة المرور";
        isValid = false;
    } else {
        passwordError.textContent = ""; 
    }

    loginButton.disabled = !isValid;

    return isValid;
}

function togglePasswordVisibility() {
    var passwordInput = document.getElementById("password");
    var passwordToggleIcon = document.querySelector(".password-toggle-icon");

    if (passwordInput.type === "password") {
        passwordInput.type = "text";
        passwordToggleIcon.classList.remove("fa-eye");
        passwordToggleIcon.classList.add("fa-eye-slash");
    } else {
        passwordInput.type = "password";
        passwordToggleIcon.classList.remove("fa-eye-slash");
        passwordToggleIcon.classList.add("fa-eye");
    }
}

document.getElementById("userNumber").addEventListener("input", function() {
    var userNumber = this.value;
    var password = document.getElementById("password").value;
    var loginButton = document.getElementById("loginButton");

    if (userNumber.trim().length === 14 && password.trim() !== "") {
        loginButton.disabled = false;
    } else {
        loginButton.disabled = true;
    }
});

document.getElementById("password").addEventListener("input", function() {
    var password = this.value;
    var userNumber = document.getElementById("userNumber").value;
    var loginButton = document.getElementById("loginButton");

    if (password.trim() !== "" && userNumber.trim().length === 14) {
        loginButton.disabled = false;
    } else {
        loginButton.disabled = true;
    }
});
function openPopup() {
    var popupContainer = document.getElementById("popupContainer");
    popupContainer.style.display = "block"; 
}

function closePopup() {
    var popupContainer = document.getElementById("popupContainer");
    popupContainer.style.display = "none"; 
}
function submitResetForm() {
// Show spinner
var resetButton = document.getElementById("resetButton");
resetButton.innerHTML = '<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> ';

setTimeout(function() {

resetButton.innerHTML = 'إرسال الطلب';




var successPopup = document.getElementById("successPopup");
successPopup.style.display = "block";


setTimeout(function() {
    successPopup.style.display = "none";
}, 3000);


closePopup();
}, 3000);

}
function closeSuccessPopup() {
var successPopup = document.getElementById("successPopup");
successPopup.style.display = "none";
}

