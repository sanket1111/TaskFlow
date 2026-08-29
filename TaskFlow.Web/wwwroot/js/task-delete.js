const deleteTaskModal = document.getElementById("deleteTaskModal");

deleteTaskModal.addEventListener("show.bs.modal", function (event) {

    const button = event.relatedTarget;

    const taskId = button.getAttribute("data-task-id");
    const taskName = button.getAttribute("data-task-name");

    document.getElementById("deleteTaskId").value = taskId;
    document.getElementById("deleteTaskName").textContent = taskName;
});