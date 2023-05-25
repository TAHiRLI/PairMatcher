

$(".delete-btn").on("click", (e) => {
    e.preventDefault();

    Swal.fire({
        title: 'Əminsiniz?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Bəli'
    }).then((result) => {
        if (result.isConfirmed) {
            let href = e.target?.getAttribute("href");
            console.log(href)

            fetch(href).then((res) => {
                if (res.redirected) {
                    window.location = "/account/login"
                }
                Swal.fire(
                    'Silindi !',
                    'Tələbə uğurla silindi',
                    'success'
                ).then(() => {
                    window.location.reload();
                })
            })


        }
    })
})