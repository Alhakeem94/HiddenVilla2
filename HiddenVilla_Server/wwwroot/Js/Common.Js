window.ShowToaster = (type, message) => {
    if (type === "Success") {
        toastr.success(message,"Operation Successful")

    }
    if (type === "Error")
    {
        toastr.error(message, "Operation Failed")
    }
}

window.SweetAlert = (type,message) => {

    if (type === "Success") {
        Swal.fire(
            'Done',
            message,
            'success'
        )
    }
    if (type === "Error") {
        Swal.fire(
            'Sorry',
             message,
            'error'
        )
    }

}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}
function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}