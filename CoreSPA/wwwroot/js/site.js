window.UI = (function () {

    // Show confirmation modal
    function confirm(message, callback) {
        const modalEl = document.getElementById('confirmModal');
        if (!modalEl) {
            console.error('Confirm modal element not found!');
            return;
        }

        $('#confirmModal .modal-body').text(message);
        const modal = new bootstrap.Modal(modalEl);
        modal.show();

        $('#confirmYesBtn').off('click').on('click', function () {
            callback();
            modal.hide();
        });
    }

    // Show toast notification
    function toast(message, type = 'success') {
        const toastEl = $('#actionToast');
        if (!toastEl.length) {
            console.error('Toast element not found!');
            return;
        }

        toastEl.removeClass('bg-success bg-danger bg-info bg-warning')
            .addClass({
                success: 'bg-success',
                error: 'bg-danger',
                info: 'bg-info',
                warning: 'bg-warning'
            }[type]);

        toastEl.find('.toast-body').text(message);
        const toastInstance = new bootstrap.Toast(toastEl[0], { delay: 2500 });
        toastInstance.show();
    }

    return {
        confirm,
        toast
    };

})();
