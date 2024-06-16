# Prime Holding Internship tasks

### Task 1 - general idea:
- We have a basic car rental system in which we calculate the rental and insurance cost based on numerous factors.
- In the main class there are a couple of methods 
    - **Init()**, which initializes a dictionary with the cars that are available for rental.
    - **PrintInvoice()**, which prints the invoice for the selected vehicle.
    - **Input()**, where we can test and validate different inputs as well as test different rental cases. (note this is commented out to match the expected output)

### Task 2 - general idea:
- We have a basic responsive html page which calculates the total leasing for a car, as well as the monthly installment based on the parameters picked from the page.
- The formula to calculate the total cost of the lease is as follows:
 $$\text{Monthly Installment} = \frac{\text{Financed Amount} \times \text{Monthly Interest Rate}}{1 - (1 + \text{Monthly Interest Rate})^{-\text{Lease Period in Months}}}$$