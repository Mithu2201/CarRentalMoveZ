
    document.addEventListener("DOMContentLoaded", function () {
    // Filter for Bookings
    const bookingFilter = document.querySelector(".bookings-card select");
    if (bookingFilter) {
        bookingFilter.addEventListener("change", function () {
            const selected = this.value.toUpperCase();
            document.querySelectorAll(".bookings-card tbody tr").forEach(row => {
                const status = row.getAttribute("data-status");
                row.style.display = (selected === "ALL STATUSES" || selected === status) ? "" : "none";
            });
        });
    }

    // Filter for Payments
    const paymentFilter = document.querySelector(".payments-card select");
    if (paymentFilter) {
        paymentFilter.addEventListener("change", function () {
            const selected = this.value.toUpperCase();
            document.querySelectorAll(".payments-card tbody tr").forEach(row => {
                const status = row.getAttribute("data-status");
                row.style.display = (selected === "ALL PAYMENTS" || selected === status) ? "" : "none";
            });
        });
    }
});


function confirmCancel(bookingId) {
    Swal.fire({
        title: 'Are you sure?',
        text: "Do you really want to cancel this booking?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#6c757d',
        confirmButtonText: 'Yes, cancel it!'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch('/Customer/CancelBooking', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: `id=${bookingId}`
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        Swal.fire('Cancelled!', data.message, 'success')
                            .then(() => location.reload());
                    } else {
                        Swal.fire('Not Allowed!', data.message, 'error');
                    }
                })
                .catch(() => {
                    Swal.fire('Error!', 'Something went wrong.', 'error');
                });
        }
    });
}

document.addEventListener("DOMContentLoaded", function () {
    const statusFilter = document.getElementById("statusFilter");
    const searchInput = document.getElementById("searchInput");
    const rows = document.querySelectorAll("#bookingsTable tbody tr");

    function filterTable() {
        const selectedStatus = statusFilter.value.toUpperCase();
        const searchText = searchInput.value.toLowerCase();

        let anyMatch = false;

        rows.forEach(row => {
            const status = row.getAttribute("data-status")?.toUpperCase() || "";
            const rowText = row.innerText.toLowerCase();

            const matchesStatus = (selectedStatus === "ALL" || status === selectedStatus);
            const matchesSearch = (searchText === "" || rowText.includes(searchText));

            if (matchesStatus && matchesSearch) {
                row.style.display = "";
                anyMatch = true;
            } else {
                row.style.display = "none";
            }
        });

        // If no matches → show all rows back
        if (!anyMatch && searchText !== "") {
            rows.forEach(row => row.style.display = "");
        }
    }

    statusFilter.addEventListener("change", filterTable);
    searchInput.addEventListener("input", filterTable);

    // expose function for button
    window.filterTable = filterTable;
});


           
    
        document.addEventListener("DOMContentLoaded", function () {
        const statusFilter = document.getElementById("statusFilter");
        const searchInput = document.getElementById("searchInput");
        const rows = document.querySelectorAll("#paymentsTable tbody tr");

        function filterTable() {
            const selectedStatus = statusFilter.value.toUpperCase();
        const searchText = searchInput.value.toLowerCase();

        let anyMatch = false;

            rows.forEach(row => {
                const status = row.getAttribute("data-status")?.toUpperCase() || "";
        const rowText = row.innerText.toLowerCase();

        const matchesStatus = (selectedStatus === "ALL" || status === selectedStatus);
        const matchesSearch = (searchText === "" || rowText.includes(searchText));

        if (matchesStatus && matchesSearch) {
            row.style.display = "";
        anyMatch = true;
                } else {
            row.style.display = "none";
                }
            });

        // If no matches → show all rows back
        if (!anyMatch && searchText !== "") {
            rows.forEach(row => row.style.display = "");
            }
        }

        statusFilter.addEventListener("change", filterTable);
        searchInput.addEventListener("input", filterTable);

        // expose function for button
        window.filterTable = filterTable;
    });
    