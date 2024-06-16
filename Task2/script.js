document.addEventListener("DOMContentLoaded", function () {
    const carTypeSelect = document.getElementById("car-type");
    const leasePeriodSelect = document.getElementById("lease-period");
    const carValueInput = document.getElementById("car-value-input");
    const downPaymentInput = document.getElementById("down-payment-input");
    const carValueRange = document.getElementById("car-value-range");
    const downPaymentRange = document.getElementById("down-payment-range");
    const totalLeasingCostText = document.getElementById("total-leasing-cost-text");
    const downPaymentText = document.getElementById("down-payment-text");
    const monthlyInstallmentText = document.getElementById("monthly-installment-text");
    const interestRateText = document.getElementById("interest-rate-text");


    //init
    changeInterestRatePercentage();
    carValueInput.value = carValueRange.value;
    downPaymentInput.value = downPaymentRange.value;
    calculateLeasing();

    //events
    carTypeSelect.addEventListener("change", changeInterestRatePercentage);
    carValueInput.addEventListener("change", function () {
        inputValidation(carValueInput, carValueRange);
        calculateLeasing();
    });
    downPaymentInput.addEventListener("change", function () {
        inputValidation(downPaymentInput, downPaymentRange);
        calculateLeasing();
    })
    carValueInput.addEventListener("focusout", function () {
        if (document.activeElement.id !== carValueInput.id) {
            carValueInput.classList.remove("invalid");
            carValueInput.value = carValueRange.value;
        }
        calculateLeasing();
    });
    downPaymentInput.addEventListener("focusout", function () {
        if (document.activeElement.id !== downPaymentInput.id) {
            downPaymentInput.classList.remove("invalid");
            downPaymentInput.value = downPaymentRange.value;
        }
        calculateLeasing();
    })
    carValueRange.addEventListener("input", function () {
        carValueInput.value = carValueRange.value;
        calculateLeasing()
    })
    downPaymentRange.addEventListener("input", function () {
        downPaymentInput.value = downPaymentRange.value;
        calculateLeasing();
    })
    carTypeSelect.addEventListener("change", function () {
        calculateLeasing();
    })
    leasePeriodSelect.addEventListener("change", function () {
        calculateLeasing();
    })

    //functions
    function changeInterestRatePercentage() {
        if (carTypeSelect.value === "new") {
            interestRateText.innerText = "2.99";
        } else {
            interestRateText.innerText = "3.7";
        }
    }

    function inputValidation(inputElement, inputElementRange) {
        if (inputElement.id === carValueInput.id) {
            if (isNaN(Number(inputElement.value)) || Number(inputElement.value) < 10_000 || Number(inputElement.value) > 200_000) {
                alert("Please enter a valid number.");
                inputElement.value = inputElementRange.value;
                inputElement.classList.add("invalid");
                inputElement.focus();
            } else {
                inputElement.classList.remove("invalid");
                inputElementRange.value = inputElement.value;
            }
        } else if (inputElement.id === downPaymentInput.id) {
            if (isNaN(Number(inputElement.value)) || Number(inputElement.value) < 10 || Number(inputElement.value) > 50) {
                alert("Please enter a valid number.");
                inputElement.value = inputElementRange.value;
                inputElement.classList.add("invalid");
                inputElement.focus();
            } else {
                inputElement.classList.remove("invalid");
                inputElementRange.value = inputElement.value;
            }
        }
    }

    function calculateLeasing() {
        let carValue = Number(carValueInput.value);
        let downPaymentPercentage = Number(downPaymentInput.value);
        let interestRate = Number(interestRateText.innerText);
        let leasePeriodMonths = Number(leasePeriodSelect.value);

        let downPayment = carValue * (downPaymentPercentage / 100);
        let financedAmount = carValue - downPayment;
        let monthlyInterestRate = interestRate / 100 / 12;
        let monthlyInstallment = (financedAmount * monthlyInterestRate) / (1 - Math.pow(1 + monthlyInterestRate, -leasePeriodMonths));
        let totalLeasingCost = monthlyInstallment * leasePeriodMonths;

        totalLeasingCostText.innerText = totalLeasingCost.toFixed(2);
        monthlyInstallmentText.innerText = monthlyInstallment.toFixed(2);
        downPaymentText.innerText = downPayment.toFixed(2);
        interestRateText.innerText = interestRate.toFixed(2);
    }
});
