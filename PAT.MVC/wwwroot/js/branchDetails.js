
document.addEventListener("DOMContentLoaded", function () {
    // Initialize Feather icons
    feather.replace();

    // Handle change event of the dropdown
    document.getElementById('governorates').addEventListener('change', function () {
        var branchId = this.value;
        if (branchId) {
            fetch(`/Branches/Details?id=${branchId}`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.text();
                })
                .then(html => {
                    document.querySelector('.results').innerHTML = html;
                })
                .catch(error => {
                    console.error('There has been a problem with your fetch operation:', error);
                });
        } else {
            document.querySelector('.results').innerHTML = '';
        }
    });
});

