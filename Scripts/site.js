$(document).ready(function () {
    $("#searchForm").submit(function (e) {
        e.preventDefault();
        var searchTerm = $("#searchInput").val().toLowerCase();

        // Filter
        $(".medicine-row").each(function () {
            var medicineName = $(this).find(".medicine-name").text().toLowerCase();
            if (medicineName.includes(searchTerm)) {
                $(this).show();
            } else {
                $(this).hide();
            }
            var quantity = parseInt($(this).find(".quantity").text(), 10);
            var expiryDate = new Date($(this).find(".expiry-date").text());

            // Compare quantity and expiry date
            var isQuantityWarning = quantity < 10;
            var isExpiryWarning = expiryDate < new Date().setDate(new Date().getDate() + 30);

            // Apply styles based on warnings
            $(this).toggleClass("quantity-warning", isQuantityWarning);
            $(this).toggleClass("expiry-warning", isExpiryWarning);
        });

        // Display "No Data Found" msg
        var noDataFoundMessage = $(".medicine-row:visible").length === 0 ? "No Data Found" : "";
        $("#noDataFound").text(noDataFoundMessage);
    });
    // Handle the click event for the Add Medicine btn
    $("#addMedicineBtn").click(function () {
        // Redirect to the Add view
        window.location.href = "/Medicine/Add";
    });
});
