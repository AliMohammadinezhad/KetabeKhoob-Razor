function activeAddress(addressId) {
    Swal.fire({
        title: "آیا از انجام این عملیات اطمینان دارید؟ ",
        icon: "info",
        showCloseButton: true,
        showCancelButton: true,
        confirmButtonText: "بله، مطمئن هستم.",
        cancelButtonText: "خیر"
    }).then(result => {
        if (result.isConfirmed) {
            $.ajax({
                url: `/profile/addresses/SetActiveAddress?addressId=${addressId}`,
                beforeSend: () => $(".loading").show(),
                complete: () => $(".loading").hide(),
            }).done(result => {
                res = JSON.parse(result);
                if (res.Status === 1) {
                    Success("", res.Message, true);
                } else {
                    ErrorAlert("", res.Message, res.isReloadPage);
                }
            })
        }
    })
}