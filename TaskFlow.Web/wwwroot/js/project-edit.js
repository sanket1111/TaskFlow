document.getElementById("StartDate").addEventListener("change", function () {
    document.getElementById("LastModifiedDateField").value = "StartDate";
});

document.getElementById("EndDate").addEventListener("change", function () {
    document.getElementById("LastModifiedDateField").value = "EndDate";
});