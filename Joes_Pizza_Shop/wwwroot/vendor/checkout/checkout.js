    //disable proceed button if the cart is empty
    function disabledBtnProceed() {
            var CartNum = document.querySelector('.cartNum span').textContent;
            var btnProceed = document.getElementById("btnProceed");
            if (CartNum == 0) {
        btnProceed.disabled = true;
                btnProceed.style.backgroundColor = "gray";
                btnProceed.style.borderColor = "gray";
            }
        }

        //if proceed button clicked, Cart div is hidden and Checkout div is shown
        function hideCart() {
            // Creating new variables.
            var btnProceed = document.getElementById("btnProceed");
            var spanCheckoutColor = document.getElementById("spanCheckoutColor");
            var DivShoppingCart = document.getElementById("DivShoppingCart");

            if (btnProceed.click) {
        DivShoppingCart.style.display = "none";
                DivPayment.style.display = "flex";
                spanCheckoutColor.style.color = "#f34949";
                spanCheckoutColor.style.fontWeight = 400;
            }
        }

        //if back button clicked, Cart div is shown and Checkout div is hidden
        function hideCheckout() {
            // Creating new variables.
            var btnBack = document.getElementById("btnBack");
            var spanCheckoutColor = document.getElementById("spanCheckoutColor");
            var DivShoppingCart = document.getElementById("DivShoppingCart");

            if (btnBack.click) {
        DivShoppingCart.style.display = "flex";
                DivPayment.style.display = "none";
                spanCheckoutColor.style.color = "black";
                spanCheckoutColor.style.fontWeight = 100;
            }
        }

        //validation form
        function payment() {
            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.querySelectorAll('.needs-validation')
            // Loop over them and prevent submission
            Array.prototype.slice.call(forms)
                .forEach(function (form) {
        form.addEventListener('submit', function (event) {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }
            form.classList.add('was-validated')
        }, false)
    })
        }