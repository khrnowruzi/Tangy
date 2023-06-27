window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation Successful', { timeOut: 5000 })
    }
    else if (type === "error") {
        toastr.error(message, 'Operation Failed', { timeOut: 5000 })
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire({
            title: 'Success Notification!',
            text: message,
            icon: 'success',
            confirmButtonText: 'Ok'
        })
    }
    else if (type === "error") {
        Swal.fire({
            title: 'Error Notification!',
            text: message,
            icon: 'error',
            confirmButtonText: 'Ok'
        })
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}
function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}