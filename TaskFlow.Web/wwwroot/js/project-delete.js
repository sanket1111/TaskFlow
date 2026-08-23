const deleteProjectModal = document.getElementById("deleteProjectModal");

deleteProjectModal.addEventListener("show.bs.modal", function (event) {

    const button = event.relatedTarget;

    const projectId = button.getAttribute("data-project-id");
    const projectName = button.getAttribute("data-project-name");

    document.getElementById("deleteProjectId").value = projectId;
    document.getElementById("deleteProjectName").textContent = projectName;
});